using Core.Entities.Concrete;
using Core.Entities.Concrete.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IDataResult<User> UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
