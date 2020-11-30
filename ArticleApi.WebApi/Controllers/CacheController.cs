using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using static ArticleApi.Common.Utilities.Layers;

namespace ArticleApi.WebApi.Controllers
{
    [Route("cache-operations")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memcache;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogsService _logs;

        public CacheController(IMemoryCache memcache, IHttpContextAccessor httpContext, ILogsService logs)
        {
            _memcache = memcache;
            _httpContext = httpContext;
            _logs = logs;
        }
        [Route("delete-cache")]
        [HttpGet]
        [Authorize]
        public IResult RemoveCache([FromQuery] string key)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                if (_memcache.TryGetValue(key, out object val))
                {
                    _memcache.Remove(key);
                    resultmessage = StaticValues.SuccessMessage;
                    resultcode = StaticValues.SuccessCode;
                    resultval = true;
                }
                else
                {
                    resultmessage = StaticValues.ErrorNullObjMessage;
                    resultcode = StaticValues.ErrorNullObjCode;
                }

            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "RemoveCache", "CacheController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
    }
}
