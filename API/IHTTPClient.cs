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
    /// Allows you to do HTTP requests which acts like a browser from the server perspective.
    /// Allows you to keep sessions, login and similar.
    /// </summary>
    public interface IHTTPClient
    {
        /// <summary>
        /// Make a request using the options method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHTTPResponse Options(string url);
        IHTTPResponse Options(HttpWebRequest req);
        IHTTPResponse Options(HTTPRequest req);

        /// <summary>
        /// Make a request using the get method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHTTPResponse Get(string url);
        IHTTPResponse Get(HttpWebRequest req);
        IHTTPResponse Get(HTTPRequest req);

        /// <summary>
        /// Make a request using the head method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHTTPResponse Head(string url);
        IHTTPResponse Head(HttpWebRequest req);
        IHTTPResponse Head(HTTPRequest req);

        /// <summary>
        /// Make a request using the post method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="vars"></param>
        /// <returns>The async request</returns>
        IHTTPResponse Post(string url, NameValueCollection vars = null);
        IHTTPResponse Post(HttpWebRequest req, NameValueCollection vars = null);
        IHTTPResponse Post(HTTPRequest req, NameValueCollection vars = null);

        /// <summary>
        /// Make a request using the put method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHTTPResponse Put(string url);
        IHTTPResponse Put(HttpWebRequest req);
        IHTTPResponse Put(HTTPRequest req);

        /// <summary>
        /// Make a request using the delete method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHTTPResponse Delete(string url);
        IHTTPResponse Delete(HttpWebRequest req);
        IHTTPResponse Delete(HTTPRequest req);

        /// <summary>
        /// Make a request using the trace method
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IHTTPResponse Trace(string url);
        IHTTPResponse Trace(HttpWebRequest req);
        IHTTPResponse Trace(HTTPRequest req);
    }
}
