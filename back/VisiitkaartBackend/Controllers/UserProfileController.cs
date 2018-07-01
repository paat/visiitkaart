using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiitkaartBackend.Data.Models.Enums;

namespace VisiitkaartBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserRoleEnum.Admin))]
    public class UserProfileController : ControllerBase
    {
        public string Get()
        {
            return "UserProfile";
        }
    }
}