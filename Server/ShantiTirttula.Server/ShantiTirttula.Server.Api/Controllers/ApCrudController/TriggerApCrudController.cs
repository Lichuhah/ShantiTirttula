using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using System.Text;
using Newtonsoft.Json;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Dto.Models;
using ShantiTirttula.Repository.Managers;
using NHibernate.Type;
using ShantiTirttula.Domain.Dto.Output;

namespace ShantiTirttula.Server.Api.Controllers.ApCrudController
{
    [Authorize]
    [Route("api/ap/triggers")]
    [ApiController]
    public class TriggerApCrudController : BaseApCrudController<TriggerDto, ITrigger>
    {
        public TriggerApCrudController(IHttpContextAccessor httpContextAccessor) : base(new TriggerManager(), httpContextAccessor)
        {

        }

        [HttpGet]
        [Route("config")]
        public ActionResult GetConfig()
        {
            IQueryable<ITrigger> data = Manager.All().Where(x => x.Auth.Id == this.Auth.Id);
            var answer = data.Select(x => new TriggerOutput
            {
                Type = x.Type.Id,
                SensorNumber = x.Sensor.Number,
                TriggerValue = x.TriggerValue,
                DeviceValue = x.Command.Value,
                Pin = x.Command.Device.Pin,
                IsPwm = x.Command.Device.IsAnalog
            }).ToList();
            return new ApiResponse<List<TriggerOutput>>().SetData(answer).Result();
        }

        [HttpPost]
        [Route("")]
        public override ActionResult Post([FromBody] TriggerDto dto)
        {
            try
            {
                ITrigger data = Manager.ConvertFromDto(dto);
                dto.Id = Manager.Save(data).Id;
                RefreshDispatcher(data.Auth.Id, data.Auth.Key);
                return new ApiResponse<ApiDto<ITrigger>>().SetData(dto).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public override ActionResult Put(int id, [FromBody] TriggerDto dto)
        {
            try
            {
                dto.Id = id;
                ITrigger data = Manager.ConvertFromDto(dto);
                Manager.Save(data);
                RefreshDispatcher(data.Auth.Id, data.Auth.Key);
                return new ApiResponse<ApiDto<ITrigger>>().SetData(dto).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public override ActionResult Delete(int id)
        {
            try
            {
                ITrigger data = Manager.Get(id);
                Manager.Delete(data);
                RefreshDispatcher(data.Auth.Id, data.Auth.Key);
                return new ApiResponse<bool>().SetData(true).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        private bool RefreshDispatcher(int authId, string key)
        {
            HttpClient client = new HttpClient();
            IQueryable<ITrigger> data = Manager.All().Where(x => x.Auth.Id == Auth.Id);
            List<ApiDto<ITrigger>> list = data.Where(x => x.Auth.Id == authId).Select(x => Manager.ConvertToDto(x)).ToList();
            //if (token != null) client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Environment.GetEnvironmentVariable("DISP_URL") + "/api/triggers/" + key);
            request.Content = new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return true;
        }
    }
}
