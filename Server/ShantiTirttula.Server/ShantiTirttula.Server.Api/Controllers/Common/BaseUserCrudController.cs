using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ShantiTirttula.Domain.Models;
using ShantiTirttula.Domain.Dto;
using ShantiTirttula.Repository.Managers;

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
        [Route("grid")]
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
