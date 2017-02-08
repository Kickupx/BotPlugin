using System;
using System.Collections.Generic;
using System.Drawing;

namespace BotPlugin.API
{
    /// <summary>
    /// Represents a single pixel which uses normalized positioning.
    /// </summary>
    public struct NormalizedPixel
    {
        public NormalizedPixel(double x, double y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        /// <summary>
        /// X as normalized.
        /// </summary>
        public double X
        {
            get;
        }

        /// <summary>
        /// Y as normalized.
        /// </summary>
        public double Y
        {
            get;
        }

        /// <summary>
        /// The actual color of the pixel.
        /// </summary>
        public Color Color
        {
            get;
        }
    }

    /// <summary>
    /// Represents a point in a window which uses normalized positioning.
    /// </summary>
    public class NormalizedPoint
    {
        public NormalizedPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// The X axis.
        /// </summary>
        public double X
        {
            get;
        }

        /// <summary>
        /// The Y axis.
        /// </summary>
        public double Y
        {
            get;
        }
    }

    /// <summary>
    /// Wrapper class of <see cref="Bitmap"/> to allow easy and safe enumeration.
    /// </summary>
    public interface IEasyBitmap : IEnumerable<NormalizedPixel>, IDisposable
    {

        /// <summary>
        /// Gets the actual <see cref="Bitmap"/> object.
        /// </summary>
        Bitmap Bitmap
        {
            get;
        }

        /// <summary>
        /// Alias for <see cref="Bitmap"/>.
        /// </summary>
        Bitmap Internal
        {
            get;
        }

        /// <summary>
        /// Finds the first occurence of the precise color specified.
        /// Starts from top left corner and searches rows first.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="color"></param>
        /// <returns>If no match is found null is returned.</returns>
        NormalizedPoint FindPixel(Color color);

        /// <summary>
        /// Finds the first occurence of the precise color specified.
        /// Starts from top left corner and searches rows first.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="color"></param>
        /// <returns>If no match is found null is returned.</returns>
        NormalizedPoint FindPixel(int r, int g, int b, int a = -1);

        /// <summary>
        /// Finds all occurencies of a color.
        /// Starts from top left corner and searches rows first.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="color"></param>
        /// <returns></returns>
        IList<NormalizedPoint> FindAllPixels(Color color);

        /// <summary>
        /// Finds all occurencies of a color.
        /// Starts from top left corner and searches rows first.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="color"></param>
        /// <returns></returns>
        IList<NormalizedPoint> FindAllPixels(int r, int g, int b, int a = -1);

        /// <summary>
        /// Get the color of a single pixel.
        /// </summary>
        /// <exception cref="Exception">If x or y is out of bounds.</exception>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The color at that pixel.</returns>
        Color ColorAt(int x, int y);
    }
}