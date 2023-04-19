using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;
using ShantiTirttula.Domain.Dto;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Util;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Domain.Dto.Models.TreeDto;
using ShantiTirttula.Domain.Dto.Models;
using System.Xml.Linq;
using ShantiTirttula.Domain.Enums;
using ShantiTirttula.Domain.Managers;
using System.Security.Claims;
using DevExpress.ClipboardSource.SpreadsheetML;
using ShantiTirttula.Repository.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthCrudController : BaseUserCrudController<McAuthDto, IAuth>
    {
        public AuthCrudController(IHttpContextAccessor httpContextAccessor) : base(new AuthManager(), httpContextAccessor)
        {

        }


        [Authorize]
        [HttpPost]
        [Route("setAuth")]
        public ActionResult SetCurrentAuth([FromBody] int id)
        {
            HttpContextAccessor.HttpContext.Session.SetInt32("AuthId", id);
            return new ApiResponse<bool>().SetData(true).Result();
        }

        [HttpGet]
        [Route("byKey/{key}")]
        public ActionResult GetProducerType(string key)
        {
            try
            {
                IAuth data = Manager.All().FirstOrDefault(x=>x.Key == key);
                if(data != null)
                    return new ApiResponse<ECommandProducerAlgorithm>().SetData(data.Producer).Result();
                else
                    return new ApiResponse<object>().Error("wrong key").Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpPost]
        [Route("changeProducer/{key}")]
        public ActionResult ChangeProducerType(string key, [FromBody] ECommandProducerAlgorithm alg)
        {
            try
            {
                IAuth data = Manager.All().FirstOrDefault(x => x.Key == key);
                if (data != null)
                {
                    data.Producer = alg;
                    Manager.Save(data);

                    HttpClient client = new HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Environment.GetEnvironmentVariable("DISP_URL") + "/api/disp/" + data.Key);
                    HttpResponseMessage response = client.Send(request);
                    string result = response.Content.ReadAsStringAsync().Result;

                    return new ApiResponse<ECommandProducerAlgorithm>().SetData(data.Producer).Result();
                }       
                else
                    return new ApiResponse<object>().Error("wrong key").Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpGet]
        [Route("devices/tree")]
        public ActionResult DeviceTree(DataSourceLoadOptions loadOptions)
        {
            try
            {
                IQueryable<IAuth> data = Manager.AllAllowed(ShantiUser);
                List<IDevice> devices = new List<IDevice>();
                data.ForEach(x => x.Product.Controller.Devices.ForEach(device => devices.Add(device)));
                var a = Manager.Get(1);
                List<CommonTreeDto> dto = data.Select(x => new CommonTreeDto()
                {
                    Id = -1*x.Product.Id,
                    Name = x.Key
                }).ToList();
                dto = dto.Concat(devices.Select(x => new CommonTreeDto()
                {
                    Id = x.Id,
                    Name = x.Type.Name,
                    ParentId = -1*x.Controller.Id
                })).ToList();
                return new ApiResponse<LoadResult>().SetData(DataSourceLoader.Load(dto, loadOptions)).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpGet]
        [Route("sensors/tree")]
        public ActionResult SensorTree(DataSourceLoadOptions loadOptions)
        {
            try
            {
                IQueryable<IAuth> data = Manager.AllAllowed(ShantiUser);
                List<ISensor> sensors = new List<ISensor>();
                data.ForEach(x => x.Product.Controller.Sensors.ForEach(sensor => sensors.Add(sensor)));
                List<CommonTreeDto> dto = data.Select(x => new CommonTreeDto()
                {
                    Id = -1 * x.Product.Id,
                    Name = x.Key
                }).ToList();
                dto = dto.Concat(sensors.Select(x => new CommonTreeDto()
                {
                    Id = x.Id,
                    Name = x.Type.Name,
                    ParentId = -1 * x.Controller.Id
                })).ToList();
                return new ApiResponse<LoadResult>().SetData(DataSourceLoader.Load(dto, loadOptions)).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }
    }
}
