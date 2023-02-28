using Newtonsoft.Json;
using System.Text;

namespace ShantiTirttula.Server.Dispatcher.Http
{
    public static class HttpHelper
    {
        public static string PostData(string url, string data, string token = null)
        {
            HttpClient client = new HttpClient();
            //if(token != null) client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            if (token != null) client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Environment.GetEnvironmentVariable("API_URL") + url);
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
