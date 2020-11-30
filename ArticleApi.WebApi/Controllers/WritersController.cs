using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;
using ArticleApi.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static ArticleApi.Common.Utilities.Layers;

namespace WriterApi.WebApi.Controllers
{
    [Route("Writer-operations")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWritersService _writer;
        private readonly ILogsService _logs;
        private readonly IHttpContextAccessor _httpContext;

        public WritersController(IWritersService writer, ILogsService logs, IHttpContextAccessor httpContext)
        {
            _writer = writer;
            _logs = logs;
            _httpContext = httpContext;
        }
        [Route("get-by-id")]
        [HttpGet]
        [Authorize]
        public IObjResult<Writers> GetWriter(int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            Writers resultobj = null;
            try
            {
                var result = _writer.GetById(id, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                resultobj = result.Object;
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "GetWriter", "WriterController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<Writers>(resultval, resultmessage, resultcode, resultobj);
        }
        [Route("insert-writer")]
        [HttpPost]
        [Authorize]
        public IResult AddWriter([FromBody]Writers model)
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
                _logs.Add(userInfo.SessId, ex.ToString(), "AddWriter", "WriterController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("update-writer")]
        [HttpPost]
        [Authorize]
        public IResult UpdateWriter([FromBody] Writers model)
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
                _logs.Add(userInfo.SessId, ex.ToString(), "UpdateWriter", "WriterController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("delete-writer")]
        [HttpPost]
        [Authorize]
        public IResult DeleteWriter([FromBody] int id)
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
                _logs.Add(userInfo.SessId, ex.ToString(), "DeleteWriter", "WriterController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
    }
}
