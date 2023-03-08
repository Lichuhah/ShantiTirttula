using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Models;
using System.Text;

namespace ShantiTirttula.Server.Dispatcher.Sessions
{
    public class SessionList
    {
        public List<Session> Sessions;
        private static SessionList instance;
        private string ApiUrl;

        private SessionList()
        {
            ApiUrl = Environment.GetEnvironmentVariable("API_URL");
            if (Sessions == null)
                Sessions = new List<Session>();
        }

        public static SessionList GetList()
        {
            if (instance == null)
                instance = new SessionList();
            return instance;
        }
        public Session GetSession(McData data)
        {
            Session session = Sessions.FirstOrDefault(x => x.Mc.Mac == data.Mac && x.Mc.Key == data.Key);
            if (session != null)
            {
                if (DateTime.UtcNow - session.CreateTime < TimeSpan.FromMinutes(15))
                {
                    return session;
                }
                else
                {
                    return RefreshSession(session);
                }
            }
            else return CreateSession(data);
        }

        public Session CreateSession(McData data)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiUrl+"/api/auth/token");
            request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string token = response.Content.ReadAsStringAsync().Result;

            Session session = new Session()
            {
                CreateTime = DateTime.UtcNow,
                LastSendTime = DateTime.UtcNow,
                Token = token,
                Mc = data,
            };

            request = new HttpRequestMessage(HttpMethod.Get, ApiUrl + "/api/trigger/list");
            response = client.Send(request);
            string trs = response.Content.ReadAsStringAsync().Result;
            try
            {
                List<DispatcherTrigger> triggers = JsonConvert.DeserializeObject<List<DispatcherTrigger>>(trs);
                session.Triggers = triggers;
            }
            catch (Exception ex) { }

            Sessions.Add(session);
            return session;
        }

        public Session RefreshSession(Session oldsession)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiUrl + "/api/auth/token");
            request.Content = new StringContent(JsonConvert.SerializeObject(oldsession.Mc), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string token = response.Content.ReadAsStringAsync().Result;

            Sessions.Remove(oldsession);
            Session session = new Session()
            {
                CreateTime = DateTime.UtcNow,
                LastSendTime = oldsession.LastSendTime,
                Token = token,
                Mc = oldsession.Mc,
                SensorsData = oldsession.SensorsData,
                Triggers = oldsession.Triggers,
                Commands = oldsession.Commands
            };

            Sessions.Add(session);
            return session;
        }
    }
}
