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
    public class BaseApCrudController<DtoType, EntityType> : ControllerBase where DtoType : ApiDtoWithAuth<EntityType> where EntityType : IEntityAuth
    {
        protected EntityManager<EntityType> Manager;
        protected IAuth Auth;
        public BaseApCrudController(EntityManager<EntityType> manager, IHttpContextAccessor httpContextAccessor)
        {
            Auth = new AuthManager().Get(Convert.ToInt32(httpContextAccessor.HttpContext.Session.GetInt32("AuthId")));
            Manager = manager;
        }

        [HttpGet]
        [Route("grid")]
        public virtual ActionResult List(DataSourceLoadOptions loadOptions)
        {
            try
            {
                IQueryable<EntityType> data = Manager.All();
                List<ApiDtoWithAuth<EntityType>> list = data.Select(x => (ApiDtoWithAuth<EntityType>)Manager.ConvertToDto(x)).ToList();
                list = list.Where(x => x.AuthId == Auth.Id).ToList();
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
                IQueryable<EntityType> data = Manager.All().Where(x => x.Auth.Id == Auth.Id);
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
                dto.AuthId = Auth.Id;
                EntityType data = Manager.ConvertFromDto(dto);
                dto.Id = Manager.Save(data).Id;
                RefreshDispatcher();
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
                RefreshDispatcher();
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
                RefreshDispatcher();
                return new ApiResponse<bool>().SetData(true).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }

        private bool RefreshDispatcher()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Environment.GetEnvironmentVariable("DISP_URL") + "/api/disp/" + Auth.Key);
            HttpResponseMessage response = client.Send(request);
            string result = response.Content.ReadAsStringAsync().Result;
            return true;
        }
    }
}
