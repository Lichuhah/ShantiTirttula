using System;

namespace ShantiTirttula.Server.Api.Controllers.Models.Dto.TreeDto
{
    public class CommonTreeDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }

}