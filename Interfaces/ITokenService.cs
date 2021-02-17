using KeerthiveeduAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Interfaces
{
    public interface ITokenService
    {
        string createToken(AppUser user);
    }
}
