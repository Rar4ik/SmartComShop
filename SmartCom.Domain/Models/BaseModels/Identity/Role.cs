﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartCom.Domain.Models.BaseModels.Identity
{
    public class Role : IdentityRole
    {
        public const string Administrator = "Admin";
        public const string User = "User";
    }
}
