using System;
using System.Collections.Generic;
using System.Text;

namespace ParkBee.Assesment.Framework.Domain
{
    public class TokenModel
    {
        public TokenModel()
        {
            Token = null;
            Expiration = null;
        }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
