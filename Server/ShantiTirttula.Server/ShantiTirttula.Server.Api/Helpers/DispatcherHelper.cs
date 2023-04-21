namespace ShantiTirttula.Server.Api.Helpers
{
    public static class DispatcherHelper
    {
        public static bool RefreshDispatcher(string key)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Environment.GetEnvironmentVariable("DISP_URL") + "/api/disp/" + key);
            HttpResponseMessage response = client.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return true;
        }
    }
}
