using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Repository.Managers;

namespace ShantiTirttula.Server.Api.Controllers.Common
{
#if DEBUG
    [AllowAnonymous]
#endif
    [ApiController]
    public class BaseCrudController<DtoType, EntityType> : ControllerBase where DtoType : ApiDto<EntityType> where EntityType : IEntity
    {
        protected EntityManager<EntityType> Manager;
        public BaseCrudController(EntityManager<EntityType> manager) : base()
        {
            Manager = manager;
        }

        [HttpGet]
        [Route("grid")]
        public virtual ActionResult List(DataSourceLoadOptions loadOptions)
        {
            try
            {
                IQueryable<EntityType> data = Manager.All();
                List<ApiDto<EntityType>> list = data.Select(x => Manager.ConvertToDto(x)).ToList();
                return new ApiResponse<LoadResult>().SetData(DataSourceLoader.Load(list, loadOptions)).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpGet]
        [Route("")]
        public virtual ActionResult JsonList()
        {
            try
            {
                IQueryable<EntityType> data = Manager.All();
                List<ApiDto<EntityType>> list = data.Select(x => Manager.ConvertToDto(x)).ToList();
                return new ApiResponse<List<ApiDto<EntityType>>>().SetData(list).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Get(int id)
        {
            try
            {
                EntityType data = Manager.Get(id);
                ApiDto<EntityType> item = Manager.ConvertToDto(data);
                return new ApiResponse<ApiDto<EntityType>>().SetData(item).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpPost]
        [Route("")]
        public virtual ActionResult Post([FromBody] DtoType dto)
        {
            try
            {
                EntityType data = Manager.ConvertFromDto(dto);
                dto.Id = Manager.Save(data).Id;
                return new ApiResponse<ApiDto<EntityType>>().SetData(dto).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public virtual ActionResult Put(int id, [FromBody] DtoType dto)
        {
            try
            {
                dto.Id = id;
                EntityType data = Manager.ConvertFromDto(dto);
                Manager.Save(data);
                return new ApiResponse<ApiDto<EntityType>>().SetData(dto).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public virtual ActionResult Delete(int id)
        {
            try
            {
                EntityType data = Manager.Get(id);
                Manager.Delete(data);
                return new ApiResponse<bool>().SetData(true).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }
    }
}
