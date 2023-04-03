using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Http;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Models.ApiModels;
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
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiUrl+ "/api/disp/signin");
            request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string content = response.Content.ReadAsStringAsync().Result;
            ApiResponse<string> result = JsonConvert.DeserializeObject<ApiResponse<string>>(content);
            if (result.Success)
            {
                string token = result.Data;

                Session session = new Session()
                {
                    CreateTime = DateTime.UtcNow,
                    LastSendTime = DateTime.UtcNow,
                    Token = token,
                    Mc = data,
                };

                //try
                //{
                //    List<DispatcherTrigger> triggers = JsonConvert.DeserializeObject<ApiResponse<List<DispatcherTrigger>>>(HttpHelper.GetData("/api/ap/triggers", token)).Data;
                //    session.Triggers = triggers;
                //}
                //catch (Exception ex) { }

                Sessions.Add(session);
                return session;
            }
            else throw new Exception("Authorization error");
        }

        public Session RefreshSession(Session oldsession)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiUrl + "/api/disp/signin");
            request.Content = new StringContent(JsonConvert.SerializeObject(oldsession.Mc), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string token = JsonConvert.DeserializeObject<ApiResponse<string>>(response.Content.ReadAsStringAsync().Result).Data;

            Sessions.Remove(oldsession);
            Session session = new Session()
            {
                CreateTime = DateTime.UtcNow,
                LastSendTime = oldsession.LastSendTime,
                Token = token,
                Mc = oldsession.Mc,
                SensorsData = oldsession.SensorsData,
                //Triggers = oldsession.Triggers,
                Commands = oldsession.Commands
            };

            //session.LoadTriggers();
            Sessions.Add(session);
            return session;
        }
    }
}
