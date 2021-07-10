using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyneAwait
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            main().GetAwaiter().GetResult();
        }

        static async Task main()
        {
            StreamReader r = new StreamReader("xxx.json");
            string jsonString = r.ReadToEnd();
            string res = await PostRequest("API", jsonString);
            //do things about res
            return;
        }


        public static async Task<string> PostRequest(string URI, string PostParams)
        {
            client.BaseAddress = new Uri("http://XXX");
            client.DefaultRequestHeaders.Add("sat", "1234");
            client.DefaultRequestHeaders.Add("sid", "1234");
            client.DefaultRequestHeaders.Add("code", "");
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.Timeout = TimeSpan.FromSeconds(30);
            HttpResponseMessage response = await client.PostAsync(URI, new StringContent(PostParams));
            string content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return content;
        }
    }
}
