using DevExpress.Data;
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
        IUser User;
        public BaseUserCrudController(EntityManager<EntityType> manager, IHttpContextAccessor httpContextAccessor) : base(manager)
        {
            var a = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Sid);
            var b = "t";
        }
    }
}
