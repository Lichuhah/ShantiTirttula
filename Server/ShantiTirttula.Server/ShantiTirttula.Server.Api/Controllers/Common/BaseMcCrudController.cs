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
    public class BaseMcCrudController<DtoType, EntityType> : BaseCrudController<DtoType, EntityType> where DtoType : ApiDtoWithAuth<EntityType> where EntityType : IEntity
    {
        protected IMcAuth Auth;
        public BaseMcCrudController(EntityManager<EntityType> manager, IHttpContextAccessor httpContextAccessor) : base(manager)
        {
            Auth = new McAuthManager().Get(Convert.ToInt32(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Sid).Value));
        }

        [HttpPost]
        [Route("")]
        public override ActionResult Post([FromBody] DtoType dto)
        {
            try
            {
                dto.AuthId = this.Auth.Id;
                EntityType data = Manager.ConvertFromDto(dto);
                dto.Id = Manager.Save(data).Id;
                return new ApiResponse<ApiDto<EntityType>>().SetData(dto).Result();
            }
            catch (Exception e)
            {
                return new ApiResponse<object>().Error(e.Message).Result();
            }
        }
    }
}
