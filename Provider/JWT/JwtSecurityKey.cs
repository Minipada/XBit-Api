using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBitApi.Provider.JWT
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
