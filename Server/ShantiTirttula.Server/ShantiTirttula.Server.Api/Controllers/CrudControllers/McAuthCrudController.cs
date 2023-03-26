using ApiModels;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Util;
using ShantiTirttula.Server.Api.Controllers.Common;
using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Controllers.Models.Dto;
using ShantiTirttula.Server.Api.Controllers.Models.Dto.TreeDto;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;

namespace ShantiTirttula.Server.Api.Controllers.CrudControllers
{
    [Authorize]
    [Route("api/mcauth")]
    [ApiController]
    public class McAuthCrudController : BaseUserCrudController<McAuthDto, IMcAuth>
    {
        public McAuthCrudController(IHttpContextAccessor httpContextAccessor) : base(new McAuthManager(), httpContextAccessor)
        {

        }

        [HttpGet]
        [Route("devices/tree")]
        public ActionResult DeviceTree(DataSourceLoadOptions loadOptions)
        {
            try
            {
                IQueryable<IMcAuth> data = Manager.AllAllowed(User);
                List<IDevice> devices = new List<IDevice>();
                data.ForEach(x => x.Controller.Devices.ForEach(device => devices.Add(device)));
                var a = Manager.Get(1);
                List<CommonTreeDto> dto = data.Select(x => new CommonTreeDto()
                {
                    Id = -1*x.Controller.Id,
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
                IQueryable<IMcAuth> data = Manager.AllAllowed(User);
                List<ISensor> sensors = new List<ISensor>();
                data.ForEach(x => x.Controller.Sensors.ForEach(sensor => sensors.Add(sensor)));
                var a = Manager.Get(1);
                List<CommonTreeDto> dto = data.Select(x => new CommonTreeDto()
                {
                    Id = -1 * x.Controller.Id,
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
