using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    /// <summary>
    /// Represents a HTTPRequest.
    /// Use it with <see cref="IHTTPClient"/> to actually make an HTTP request.
    /// With this you can set Cookies, Headers and Variables.
    /// </summary>
    /// <remarks>
    /// Nothing here is thread safe
    /// </remarks>
    public class HTTPRequest
    {
        public HTTPRequest(Uri uri)
        {
            Internal = WebRequest.CreateHttp(uri.ToString());
            setup();
        }

        public HTTPRequest(string uri)
        {
            Internal = WebRequest.CreateHttp(uri);
            setup();
        }

        private void setup()
        {
            Cookies = new List<Cookie>();
            Headers = new WebHeaderCollection();
        }

        /// <summary>
        /// The internal HttpWebRequest.
        /// If you want to override any behavior which <see cref="IHTTPClient"/> gives you this the object you use.
        /// </summary>
        public HttpWebRequest Internal
        {
            get;
        }

        /// <summary>
        /// A list of the cookies which you want to send with the request.
        /// </summary>
        /// <remarks>
        /// Notice that <see cref="IHTTPClient"/> automaticly sends back cookies which the server send to the client.
        /// Use this if you want to override or add any arbitrary cookie.
        /// </remarks>
        public List<Cookie> Cookies
        {
            get;
            set;
        }

        /// <summary>
        /// Allows you to set the raw headers.
        /// </summary>
        /// <remarks>
        /// <see cref="IHTTPClient"/> automaticly handles the referer header. So if you set it here
        /// you will override it.
        /// </remarks>
        public WebHeaderCollection Headers
        {
            get;
            set;
        }
    }
}
