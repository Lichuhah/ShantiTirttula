using ApiModels;
using DevExpress.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Type;
using ShantiTirttula.Server.Api.Controllers.Models;
using ShantiTirttula.Server.Api.Domain.Implementations.Managers;
using ShantiTirttula.Server.Api.Domain.Interfaces.Models;
using System.Security.Claims;

namespace ShantiTirttula.Server.Api.Controllers.Common
{
    [Authorize]
    [ApiController]
    public class BaseUserCrudController<DtoType, EntityType> : BaseCrudController<DtoType, EntityType> where DtoType : ApiDto<EntityType> where EntityType : IEntity
    {
        protected IUser User;
        public BaseUserCrudController(EntityManager<EntityType> manager, IHttpContextAccessor httpContextAccessor) : base(manager)
        {
            User = new UserManager().Get(Convert.ToInt32(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Sid).Value));
        }

        [HttpGet]
        [Route("")]
        public override ActionResult List(DataSourceLoadOptions loadOptions)
        {
            try
            {
                IQueryable<EntityType> data = Manager.AllAllowed(User);
                List<ApiDto<EntityType>> list = data.Select(x => Manager.ConvertToDto(x)).ToList();
                return new ApiResponse<LoadResult>().SetData(DataSourceLoader.Load(list, loadOptions)).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }
    }
}
