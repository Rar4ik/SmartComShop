using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.Entities.BaseEntities;
using SmartCom.Domain.Models.BaseModels;

namespace SmartCom.Domain.DTO.Identity
{
    public class UserDTO : DTOEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}
