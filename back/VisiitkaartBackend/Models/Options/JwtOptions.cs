using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisiitkaartBackend.Models.Options
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string LifeTimeMinutes { get; set; }
    }
}
