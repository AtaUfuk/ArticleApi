using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities.Jwt;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Business.Services
{
    public interface IUserService
    {
        IObjResult<AutUserInfo> GetUser(string usrname, string password, string clientip, string sessionid);
        IObjResult<AccessToken> CreateToken(AutUserInfo userInfo);
        IResult CreateUser(Users users, string clientip, string sessionid);
    }
}
