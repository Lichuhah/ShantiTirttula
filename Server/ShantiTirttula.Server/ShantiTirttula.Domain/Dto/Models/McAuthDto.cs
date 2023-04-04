﻿using ShantiTirttula.Domain.Models;

namespace ShantiTirttula.Domain.Dto.Models
{
    public class McAuthDto : ApiDto<IAuth>
    {
        public int ProductId { get; set; }
        public string Key { get; set; }
        public string Mac { get; set; }
        public string TypeName { get; set; }
    }
}