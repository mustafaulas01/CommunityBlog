using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace Business.Abstract
{
    public interface ITokenService
    {
        string CreateToken(AppUserLoginDto userLogin);

    }
}