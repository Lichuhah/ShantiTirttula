using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Server.Api.Controllers.Common;
using System.Text;

namespace ShantiTirttula.Server.Api.Controllers.ApCrudController
{
    [Route("api/ap/triggers")]
    [ApiController]
    public class TriggerApCrudController : BaseApCrudController<TriggerDto, ITrigger>
    {
        public TriggerApCrudController(IHttpContextAccessor httpContextAccessor) : base(new TriggerManager(), httpContextAccessor)
        {

        }

        [HttpGet]
        [Route("config")]
        public ActionResult SetConfig()
        {
            IQueryable<ITrigger> data = Manager.All().Where(x => x.Auth.Id == Auth.Id && x.IsAutonomy);
            var answer = data.Select(x => (TriggerDto)Manager.ConvertToDto(x)).ToList();
            HttpClient client = new HttpClient();
            //if (token != null) client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Environment.GetEnvironmentVariable("DISP_URL") + "/api/disp/cf/" + Auth.Key)
            {
                Content = new StringContent(JsonConvert.SerializeObject(answer), Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return new ApiResponse<List<TriggerDto>>().SetData(answer).Result();
        }
    }
}
