﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Server.Api.Controllers.Common;
using System.Text;
using Newtonsoft.Json;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/triggers")]
    [ApiController]
    public class TriggerCrudController : BaseUserCrudController<TriggerDto, ITrigger>
    {
        public TriggerCrudController(IHttpContextAccessor httpContextAccessor) : base(new TriggerManager(), httpContextAccessor)
        {

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
            IQueryable<ITrigger> data = Manager.AllAllowed(User);
            List<ApiDto<ITrigger>> list = data.Where(x => x.Auth.Id == authId).Select(x=>Manager.ConvertToDto(x)).ToList();
            //if (token != null) client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Environment.GetEnvironmentVariable("DISP_URL") +"/api/triggers/"+ key);
            request.Content = new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return true;
        }
    }
}
