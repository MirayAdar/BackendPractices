using Practise.Core.Entities.Concrete;
using Practise.Core.Utilities.Results;
using Practise.Core.Utilities.Security.Jwt;
using Practise.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterForUserDto registerForUserDto);
        IDataResult<User> Login(LoginForUserDto loginForUserDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
