using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ArticleApi.Common.Utilities.Layers;

namespace ArticleApi.WebApi.Controllers
{
    [Route("article-operations")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticlesService _article;
        private readonly ILogsService _logs;
        private readonly IHttpContextAccessor _httpContext;

        public ArticleController(IArticlesService article, ILogsService logs, IHttpContextAccessor httpContext)
        {
            _article = article;
            _logs = logs;
            _httpContext = httpContext;
        }
        [Route("get-by-id")]
        [HttpGet]
        [Authorize]
        public IObjResult<Articles> GetArticle(int id)
        {
            AutUserInfo userinfo = new AutUserInfo();
            userinfo.ClientIp = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
            userinfo.SessId = GenerateUniqueId.Create();
            userinfo.UsrId = 0;
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            Articles resultobj = null;
            try
            {
                var result = _article.GetById(id, userinfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                resultobj = result.Object;
            }
            catch (Exception ex)
            {
                _logs.Add(userinfo.SessId, ex.ToString(), "GetArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userinfo.ClientIp, userinfo.UsrId);
            }
            return new ObjResult<Articles>(resultval, resultmessage, resultcode, resultobj);
        }
        [Route("insert-article")]
        [HttpPost]
        [Authorize]
        public IResult AddArticle([FromBody]Articles model)
        {
            AutUserInfo userinfo = new AutUserInfo();
            userinfo.ClientIp = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
            userinfo.SessId = GenerateUniqueId.Create();
            userinfo.UsrId = 0;
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _article.Add(model, userinfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logs.Add(userinfo.SessId, ex.ToString(), "AddArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userinfo.ClientIp, userinfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("update-article")]
        [HttpPost]
        [Authorize]
        public IResult UpdateArticle([FromBody] Articles model)
        {
            AutUserInfo userinfo = new AutUserInfo();
            userinfo.ClientIp = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
            userinfo.SessId = GenerateUniqueId.Create();
            userinfo.UsrId = 0;
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _article.Update(model, userinfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logs.Add(userinfo.SessId, ex.ToString(), "UpdateArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userinfo.ClientIp, userinfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("delete-article")]
        [HttpPost]
        [Authorize]
        public IResult DeleteArticle([FromBody] int id)
        {
            AutUserInfo userinfo = new AutUserInfo();
            userinfo.ClientIp = _httpContext.HttpContext.Connection.RemoteIpAddress.ToString();
            userinfo.SessId = GenerateUniqueId.Create();
            userinfo.UsrId = 0;
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _article.Delete(id, userinfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
            }
            catch (Exception ex)
            {
                _logs.Add(userinfo.SessId, ex.ToString(), "DeleteArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userinfo.ClientIp, userinfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
    }
}
