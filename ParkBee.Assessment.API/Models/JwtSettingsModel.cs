using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkBee.Assessment.API.Models
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
