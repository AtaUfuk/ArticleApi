using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Jwt;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Common.Utilities.Security.Jwt.Encryptions;
using ArticleApi.Common.Utilities.Validations;
using ArticleApi.Data.Entities.Concrete;
using ArticleApi.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ArticleApi.Common.Utilities.Layers;

namespace ArticleApi.WebApi.Controllers
{
    [Route("user-operations")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly ILogsService _logs;
        private readonly IHttpContextAccessor _httpContext;

        public UserController(IUserService user, ILogsService logs, IHttpContextAccessor httpContext)
        {
            _user = user;
            _logs = logs;
            _httpContext = httpContext;
        }

        [Route("login")]
        [HttpPost]
        public IObjResult<AccessToken> AuthUser([FromBody] UserQuery User)
        {
            string clientip = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
            bool _resultValue = false;
            string _resultMessage = string.Empty;
            int _resultCode = 0;
            string _sessionid = GenerateUniqueId.Create();
            AccessToken token = null;
            try
            {
                IDictionary<int, string> keyValuePairs = UserValidation.UserQueryControl(User);
                if (keyValuePairs.ContainsKey(StaticValues.SuccessCode))
                {
                    string password = Encryption.GenerateSHA256String(User?.Password);
                    IObjResult<AutUserInfo> infoes = _user.GetUser(User?.Email, password, clientip, _sessionid);
                    if (infoes.IsSuccess && infoes.Object != null)
                    {
                        var result = _user.CreateToken(infoes.Object);
                        _resultValue = result.IsSuccess;
                        _resultCode = result.ResultCode;
                        _resultMessage = result.Message;
                        token = result.Object;
                        if (result.IsSuccess)
                        {
                            _httpContext.HttpContext.Session.SetObject("UserInfo", infoes.Object);
                        }
                    }
                    else
                    {
                        _resultValue = infoes.IsSuccess;
                        _resultCode = infoes.ResultCode;
                        _resultMessage = infoes.Message;
                    }

                }
                else
                {
                    _resultCode = StaticValues.ErrorNullCode;
                    keyValuePairs.TryGetValue(StaticValues.ErrorNullCode, out _resultMessage);
                }
            }
            catch (Exception ex)
            {
                _resultMessage = StaticValues.ErrorMessage;
                _resultCode = StaticValues.ErrorCode;
                _logs.Add(_sessionid, "Kullanıcı oturum açma işlemi esnasında bir sorun ile karşılaşıldı. Hata:" + ex.ToString(), "AuthUser", "UserController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, clientip, StaticValues.DefUserId);
            }

            return new ObjResult<AccessToken>(_resultValue, _resultMessage, _resultCode, token);
        }
        [Route("insert-user")]
        [HttpPost]
        public IResult CreateUser([FromBody] Users users)
        {
            string clientip = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
            bool _resultValue = false;
            string _resultMessage = string.Empty;
            int _resultCode = 0;
            string _sessionid = GenerateUniqueId.Create();
            try
            {
                string password = Encryption.GenerateSHA256String(users?.Password);
                users.Password = password;
                IResult infoes = _user.CreateUser(users, clientip, _sessionid);
                _resultValue = infoes.IsSuccess;
                _resultCode = infoes.ResultCode;
                _resultMessage = infoes.Message;



            }
            catch (Exception ex)
            {
                _resultMessage = StaticValues.ErrorMessage;
                _resultCode = StaticValues.ErrorCode;
                _logs.Add(_sessionid, "Kullanıcı oturum açma işlemi esnasında bir sorun ile karşılaşıldı. Hata:" + ex.ToString(), "AuthUser", "UserController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, clientip, StaticValues.DefUserId);
            }

            return new Result(_resultValue, _resultMessage, _resultCode);
        }
    }
}
