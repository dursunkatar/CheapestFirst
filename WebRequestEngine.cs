using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnUcuzUrun
{
    public static class WebRequestEngine
    {
        public static string Get(string url)
        {
            using var client = GetHttpClient();
            return client.GetStringAsync(url).Result;
        }

        public static string Post(string url, IEnumerable<KeyValuePair<string, string>> data)
        {
            var content = new FormUrlEncodedContent(data);
            using var client = GetHttpClient();
            using var responseMessage = client.PostAsync(url, content).Result;
            return responseMessage.Content.ReadAsStringAsync().Result;
        }

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:85.0) Gecko/20100101 Firefox/85.0");
            return client;
        }
    }
}
