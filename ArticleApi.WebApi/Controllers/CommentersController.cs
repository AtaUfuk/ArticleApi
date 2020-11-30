using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;
using ArticleApi.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using static ArticleApi.Common.Utilities.Layers;

namespace CommenterApi.WebApi.Controllers
{
    [Route("Commenter-operations")]
    [ApiController]
    public class CommentersController : ControllerBase
    {
        private readonly ICommentersService _writer;
        private readonly ILogsService _logs;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMemoryCache _memcache;

        public CommentersController(ICommentersService writer, ILogsService logs, IHttpContextAccessor httpContext, IMemoryCache memcache)
        {
            _writer = writer;
            _logs = logs;
            _httpContext = httpContext;
            _memcache = memcache;
        }
        [Route("get-by-id")]
        [HttpGet]
        [Authorize]
        public IObjResult<Commenters> GetCommenter(int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            Commenters resultobj = null;
            try
            {
                if (!_memcache.TryGetValue<Commenters>("Commenter" + id, out resultobj))
                {
                    var result = _writer.GetById(id, userInfo);
                    resultcode = result.ResultCode;
                    resultmessage = result.Message;
                    resultval = result.IsSuccess;
                    resultobj = result.Object;
                    if (resultval)
                    {
                        _memcache.Set<Commenters>("Commenter" + id, resultobj);
                    }
                }
                else
                {
                    resultcode = StaticValues.SuccessCode;
                    resultmessage = StaticValues.SuccessMessage;
                    resultval = true;
                }

            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "GetCommenter", "CommenterController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<Commenters>(resultval, resultmessage, resultcode, resultobj);
        }
        [Route("insert-writer")]
        [HttpPost]
        [Authorize]
        public IResult AddCommenter([FromBody] Commenters model)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _writer.Add(model, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "AddCommenter", "CommenterController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("update-writer")]
        [HttpPost]
        [Authorize]
        public IResult UpdateCommenter([FromBody] Commenters model)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _writer.Update(model, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "UpdateCommenter", "CommenterController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("delete-writer")]
        [HttpPost]
        [Authorize]
        public IResult DeleteCommenter([FromBody] int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _writer.Delete(id, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "DeleteCommenter", "CommenterController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
    }
}
