using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Server.Dispatcher.Http;
using ShantiTirttula.Server.Dispatcher.Models;
using ShantiTirttula.Server.Dispatcher.Producer;
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

                try
                {
                    ApiResponse<ECommandProducerAlgorithm> prodResult = JsonConvert.DeserializeObject<ApiResponse<ECommandProducerAlgorithm>>(HttpHelper.GetData("/api/auth/bykey/"+data.Key, token));
                    if (result.Success)
                    {
                        switch (prodResult.Data)
                        {
                            case ECommandProducerAlgorithm.NoneProducer: session.Producer = new NoneProducer(); break;
                            case ECommandProducerAlgorithm.TaskProducer: session.Producer = new TaskProducer(); break;
                            //case ECommandProducerAlgorithm.TriggerProducer: session.Producer = new NoneProducer(); break;
                            default: session.Producer = new NoneProducer(); break;
                        }

                        session.Producer.LoadDataForSession(token);
                    }
                } catch (Exception ex) { }


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

        public static Session RefreshSession(Session session)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Environment.GetEnvironmentVariable("API_URL") + "/api/disp/signin");
            request.Content = new StringContent(JsonConvert.SerializeObject(session.Mc), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string content = response.Content.ReadAsStringAsync().Result;
            ApiResponse<string> result = JsonConvert.DeserializeObject<ApiResponse<string>>(content);

            if (result.Success)
            {
                string token = result.Data;

                session = new Session()
                {
                    CreateTime = DateTime.UtcNow,
                    LastSendTime = DateTime.UtcNow,
                    Token = token,
                    Mc = session.Mc,
                };

                try
                {
                    ApiResponse<ECommandProducerAlgorithm> prodResult = JsonConvert.DeserializeObject<ApiResponse<ECommandProducerAlgorithm>>
                        (HttpHelper.GetData("/api/auth/bykey/" + session.Mc.Key, token));
                    if (result.Success)
                    {
                        switch (prodResult.Data)
                        {
                            case ECommandProducerAlgorithm.NoneProducer: session.Producer = new NoneProducer(); break;
                            case ECommandProducerAlgorithm.TaskProducer: session.Producer = new TaskProducer(); break;
                            case ECommandProducerAlgorithm.TriggerProducer: session.Producer = new TriggerProducer(); break;
                            default: session.Producer = new NoneProducer(); break;
                        }

                        session.Producer.LoadDataForSession(token);
                    }
                }
                catch (Exception ex) { }

                return session;
            }
            else throw new Exception("Authorization error");
        }
    }
}
