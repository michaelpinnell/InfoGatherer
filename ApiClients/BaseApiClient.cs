namespace InfoGatherer.ApiClients
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;

    public class BaseApiClient
    {
        public BaseApiClient(Uri baseUri, HttpClient httpClient)
        {
            var baseUriText = baseUri.ToString();
            if (!baseUriText.EndsWith("/"))
            {
                baseUri = new Uri($"{baseUriText}");
            }

            httpClient.BaseAddress = baseUri;
            this.HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<HttpResponseMessage> Get(string endPointBase, NameValueCollection queryParameters, Action<HttpRequestHeaders> addHeaders = null)
        {
            var requestUri = BuildRequestUri(endPointBase, queryParameters);
            return await this.Get(requestUri, addHeaders);
        }

        public async Task<HttpResponseMessage> Get(Uri requestUri, Action<HttpRequestHeaders> addHeaders = null)
        {
            var requestMessage =  new HttpRequestMessage
            {
                RequestUri = requestUri,
                Method = HttpMethod.Get
            };

            if (addHeaders != null)
            {
                addHeaders(requestMessage.Headers);
            }

            return await this.HttpClient.SendAsync(requestMessage);
        }

        private static Uri BuildRequestUri(string endPointBase, NameValueCollection queryParameters)
        {
            var url = endPointBase;
            if (queryParameters != null)
            {
                var parameters =
                    from key in queryParameters.AllKeys
                    from value in queryParameters.GetValues(key)
                    select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}";
                
                url += $"?{string.Join("&", parameters)}";
            }

            var requestUri = new Uri(url, UriKind.Relative);
            return requestUri;
        }
    }
}