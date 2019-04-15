using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using WebServices.Utility.Parse;

namespace WebServices.Utility
{
    public class DownloadLaunch
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _filePath = String.Empty;
        private readonly Uri _requestUri;
        private StringContent _content;

        public DownloadLaunch(Uri requestUri, string filePath, string broker, string barcode)
        {
            this._requestUri = requestUri;
            this._filePath = filePath;

            var data = new Dictionary<string, string>
            {
                { "broker", broker },
                { "barcode", barcode }
            };

            _content = new StringContent(
                JsonParser.SerializeStrDictionary(data),
                Encoding.UTF8,
                "application/json");
        }

        public async Task<string> SendAsync()
        {
            string statusCode = String.Empty;

            try
            {
                HttpResponseMessage response = await _client.PostAsync(_requestUri, _content);
                statusCode = response.StatusCode.ToString();
                response.EnsureSuccessStatusCode();

                byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes(@_filePath, bytes);

            }
            catch (HttpRequestException ex)
            {
                _client.Dispose();
                return statusCode;
            }

            _client.Dispose();
            return "00";
        }
    }
}
