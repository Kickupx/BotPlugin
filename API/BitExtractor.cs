using CLR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    public enum Endian
    {
        Little,
        Big
    }

    /// <summary>
    /// Allows you to extract bits and bytes from a stream.
    /// Useful when you got a packed packet from the network.
    /// </summary>
    /// <remarks>
    /// The bit reads begins from the most significant bits.
    /// This object is not threadsafe.
    /// </remarks>
    public class BitExtractor
    {
        private Stream m_stream;
        private int m_bit_offset;
        private byte m_byte;
        private Endian m_stream_endian;
        private Endian m_system_endian;

        /// <summary>
        /// Construct using a stream of your choice.
        /// </summary>
        /// <param name="stream"></param>
        public BitExtractor(Stream stream, Endian stream_endian = Endian.Big)
        {
            m_stream_endian = stream_endian;
            m_system_endian = BitConverter.IsLittleEndian ? Endian.Little : Endian.Big;
            m_stream = stream;
        }

        /// <summary>
        /// Whether the underlaying stream is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                var len = m_stream.Length;
                return len == 0 || len == 1;
            }
        }

        /// <summary>
        /// Read bits inside an byte.
        /// </summary>
        /// <remarks>
        /// Notice that the reading start from the most significant bits.
        /// I you only want a part of the byte. You need to call <see cref="IgnoreBits"/>
        /// if you want to call any of the other read bits functions.
        /// </remarks>
        /// <exception cref="Exception">If stream is empty.</exception>
        /// <param name="bits">The amount of bits you want to read.</param>
        /// <returns></returns>
        public byte ReadBits(int bits)
        {
            if (m_bit_offset == 0)
            {
                m_byte = (byte)m_stream.ReadByte();
                m_bit_offset = 8;
            }

            if (bits > m_bit_offset)
                throw new Exception("Current bit index is " + m_bit_offset + " but tried to read " + bits + "bits.");

            var left_shift = -(m_bit_offset - 8);
            byte value = (byte) (m_byte << left_shift);
            value = (byte) (value >> left_shift);
            m_bit_offset -= bits;
            
            value = (byte) (value >> m_bit_offset);
            return value;
        }

        /// <summary>
        /// Ignores the rest of the byte.
        /// Allows you to call any of the other read functions.
        /// </summary>
        public void IgnoreBits()
        {
            m_bit_offset = 0;
        }

        /// <summary>
        /// Reads a scalar or struct value out of the stream.
        /// </summary>
        /// <remarks>
        /// If it is a struct it has to be default constructible.
        /// </remarks>
        /// <exception cref="Exception">If stream is empty or if it is not large enough for whole T.</exception>
        /// <typeparam name="T">The type to read in.</typeparam>
        /// <returns></returns>
        public T Read<T>() where T :struct
        {
            enforce_not_in_bit_mode();
            var size = Marshal.SizeOf(typeof(T));
            var bytes = new byte[size];
            read(bytes);
            return from_byte_array<T>(bytes);
        }

        /// <summary>
        /// Reads an array of scalars or structs.
        /// </summary>
        /// <remarks>
        /// If it is a struct it has to be default constructible.
        /// </remarks>
        /// <exception cref="Exception">If stream is empty or if it is not large enough for whole T.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="length"></param>
        /// <returns></returns>
        public T[] ReadArray<T>(int length) where T :struct
        {
            var result = new T[length];

            for(var i = 0; i < length; ++i)
            {
                result[i] = Read<T>();
            }

            return result;
        }

        /// <summary>
        /// Reads a string with a predefined size.
        /// </summary>
        /// <exception cref="Exception">If stream is empty or if it is not large enough for whole T.</exception>
        /// <param name="length">The size of the string.</param>
        /// <returns></returns>
        public string ReadString(int length, Unicode unicode = Unicode.UTF8)
        {
            switch(unicode)
            {
                case Unicode.UTF8:
                    return Encoding.UTF8.GetString(ReadArray<byte>(length));
                case Unicode.UTF16:
                    var bytes = new byte[length * 2];

                    for (var i = 0; i < length; ++i)
                    {
                        var short_ = Read<ushort>();
                        bytes[i * 2] = (byte)(short_);
                        bytes[i * 2 + 1] = (byte)(short_ >> 8);
                    }
                    return Encoding.Unicode.GetString(bytes.ToArray());
                case Unicode.UTF32:
                    bytes = new byte[length * 4];

                    for (var i = 0; i < length; ++i)
                    {
                        var int_ = Read<uint>();
                        bytes[i * 4] = (byte)(int_);
                        bytes[i * 4 + 1] = (byte)(int_ >> 8);
                        bytes[i * 4 + 2] = (byte)(int_ >> 16);
                        bytes[i * 4 + 3] = (byte)(int_ >> 24);
                    }
                    return Encoding.UTF32.GetString(bytes.ToArray());
                default:
                    throw new Exception("Invalid value of enum Unicode. Is " + unicode + ".");
            }
        }

        /// <summary>
        /// Reads the string as if it was a C-string.
        /// Meaning it has a null terminator.
        /// </summary>
        /// <exception cref="Exception">If stream is empty or if it is not large enough for whole T.</exception>
        /// <returns></returns>
        public string ReadString(Unicode unicode = Unicode.UTF8)
        {
            switch(unicode)
            {
                case Unicode.UTF8:
                    var bytes = new List<byte>();

                    for (;;)
                    {
                        var byte_ = Read<byte>();
                        if (byte_ == 0)
                            break;
                        bytes.Add(byte_);
                    }
                    return Encoding.UTF8.GetString(bytes.ToArray());
                case Unicode.UTF16:
                    var bytes_u16 = new List<byte>();
                    for(;;)
                    {
                        var short_ = Read<short>();
                        if (short_ == 0)
                            break;
                        bytes_u16.Add((byte)(short_));
                        bytes_u16.Add((byte)(short_ >> 8));
                    }
                    return Encoding.Unicode.GetString(bytes_u16.ToArray());
                case Unicode.UTF32:
                    var bytes_u32 = new List<byte>();
                    for (;;)
                    {
                        var int_ = Read<int>();
                        if (int_ == 0)
                            break;
                        bytes_u32.Add((byte)(int_));
                        bytes_u32.Add((byte)(int_ >> 8));
                        bytes_u32.Add((byte)(int_ >> 16));
                        bytes_u32.Add((byte)(int_ >> 24));
                    }
                    return Encoding.UTF32.GetString(bytes_u32.ToArray());
                default:
                    throw new Exception("Invalid value of enum Unicode. Is " + unicode + ".");
            }
        }

        private void enforce_not_in_bit_mode()
        {
            if (m_bit_offset != 0)
                throw new Exception("Can not call non bit reads while being inside of a bit. Call IgnoreBits if you want to just to next byte");
        }

        private void read(byte[] bytes)
        {
            var read_len = bytes.Length;
            var read_bytes = m_stream.Read(bytes, 0, read_len);
            if (read_bytes != read_len)
                throw new Exception("Stream ended before all bytes could be read");
        }

        private T from_byte_array<T>(byte[] data) where T :struct
        {
            if(m_system_endian != m_stream_endian)
                Array.Reverse(data);
            return Misc.to_T<T>(data);
        }

        public static BitExtractor FromBytes(byte[] bytes, Endian endian = Endian.Big)
        {
            return new BitExtractor(new MemoryStream(bytes), endian);
        }
    }
}
