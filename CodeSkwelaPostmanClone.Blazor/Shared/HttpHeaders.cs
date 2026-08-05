using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using static MudBlazor.CategoryTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeSkwelaPostmanClone.Blazor.Shared
{
    public class HttpHeaders
    {
        public List<KeyValuePair<string, HeaderType>> GetAll()
        {
            return new List<KeyValuePair<string, HeaderType>>
            {
                new KeyValuePair<string, HeaderType>("Accept", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Accept-Charset", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Accept-Encoding", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Accept-Language", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Authorization", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Cache-Control", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Connection", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Date", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Expect", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Expect-Continue", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("From", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Host", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("If-Match", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("If-Modified-Since", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("If-None-Match", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("If-Range", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("If-Unmodified-Since", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Max-Forwards", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("NonValidated", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Pragma", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Protocol", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Proxy-Authorization", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Range", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Referrer", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("TE", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Trailer", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Transfer-Encoding", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Upgrade", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("User-Agent", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Via", HeaderType.Request),
                new KeyValuePair<string, HeaderType>("Warning", HeaderType.Request),

                new KeyValuePair<string, HeaderType>("Allow", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Disposition", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Encoding", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Language", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Length", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Location", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-MD5", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Range", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Content-Type", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Expires", HeaderType.Content),
                new KeyValuePair<string, HeaderType>("Last-Modified", HeaderType.Content)
            };
        }
    }

    public enum HeaderType
    {
        Request = 1,
        Content = 2
    }
}
