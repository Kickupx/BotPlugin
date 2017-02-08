using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace BotPlugin.API
{
    /// <summary>
    /// Represents an asynchronous response.
    /// </summary>
    /// <remarks>
    /// All properties and functions may throw because it can be made async with the async keyword.
    /// </remarks>
    public interface IHTTPResponse
    {
        /// <summary>
        /// The <see href="https://en.wikipedia.org/wiki/HTTP_cookie">cookies</see> of the response.
        /// </summary>
        /// <exception cref="Exception">If request fails</exception>
        CookieCollection Cookies
        {
            get;
        }

        /// <summary>
        /// The <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers">headers</see> including the <see href="https://en.wikipedia.org/wiki/HTTP_cookie">cookies</see> of the response.
        /// </summary>
        /// <exception cref="Exception">If request fails</exception>
        WebHeaderCollection Headers
        {
            get;
        }

        /// <summary>
        /// The internal object used to make the request.
        /// </summary>
        /// <remarks>
        /// This task is awaiting until all data has been read.
        /// </remarks>
        /// <exception cref="Exception">If request fails</exception>
        HttpWebResponse Internal
        {
            get;
        }

        /// <summary>
        /// Parse the document as <see href="http://www.w3schools.com/html/">HTML</see>.
        /// </summary>
        /// <exception cref="Exception">If request fails</exception>
        /// <exception cref="Exception">If HTML parsing fails</exception>
        HtmlDocument HTML
        {
            get;
        }

        /// <summary>
        /// Parse the document as <see href="http://www.w3schools.com/xml/">XML</see>.
        /// </summary>
        /// <exception cref="Exception">If request fails</exception>
        /// <exception cref="Exception">If XML parsing fails</exception>
        XmlDocument XML
        {
            get;
        }

        /// <summary>
        /// A list of the <see href="http://html.net/tutorials/php/lesson10.php">HTTP query variables</see> which was on the last request.
        /// </summary>
        Dictionary<string, string> QueryVars
        {
            get;
        }

        /// <summary>
        /// Returns the string which the HTTP request sent. Nothing else.
        /// </summary>
        string Text
        {
            get;
        }

        /// <summary>
        /// Returns the url decoded url.
        /// </summary>
        string Url
        {
            get;
        }

        /// <summary>
        /// Parse the document as <see href="http://www.w3schools.com/js/js_json_intro.asp">JSON</see>.
        /// </summary>
        /// <exception cref="Exception">If request fails</exception>
        /// <exception cref="Exception">If JSON parsing fails</exception>
        T JSON<T>() where T : new();

        /// <summary>
        /// Completes the request if it is not already completes.
        /// Or with other words, waits for it to complete.
        /// </summary>
        void Complete();
    }
}