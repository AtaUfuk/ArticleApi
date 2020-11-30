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
using System.Linq;

namespace CommentsApi.WebApi.Controllers
{
    [Route("comment-operations")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _comment;
        private readonly ILogsService _logs;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMemoryCache _memcache;

        public CommentsController(ICommentsService comment, ILogsService logs, IHttpContextAccessor httpContext, IMemoryCache memcache)
        {
            _comment = comment;
            _logs = logs;
            _httpContext = httpContext;
            _memcache = memcache;
        }
        [Route("get-by-id")]
        [HttpGet]
        [Authorize]
        public IObjResult<Comments> GetComments(int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            Comments resultobj = null;
            try
            {
                _memcache.TryGetValue<Comments>("Comments" + id, out resultobj);
                if (resultobj == null)
                {
                    var result = _comment.GetById(id, userInfo);
                    resultcode = result.ResultCode;
                    resultmessage = result.Message;
                    resultval = result.IsSuccess;
                    resultobj = result.Object;
                    if (result.IsSuccess && result.Object != null)
                    {
                        var cacheExpOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpiration = DateTime.Now.AddMinutes(10),
                            Priority = CacheItemPriority.Normal
                        };
                        _memcache.Set<Comments>("Comments" + id, resultobj, cacheExpOptions);
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
                _logs.Add(userInfo.SessId, ex.ToString(), "GetComments", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<Comments>(resultval, resultmessage, resultcode, resultobj);
        }
        [Route("insert-comment")]
        [HttpPost]
        [Authorize]
        public IResult AddComments([FromBody] Comments model)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                _logs.Add(userInfo.SessId, string.Format("Makale ekleme işlemi ekli parametreler ile başlamıştır.{0}", Reflections.GetModelPropertyValues<Comments>(model)), "AddComments", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
                var result = _comment.Add(model, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                _logs.Add(userInfo.SessId, string.Format("Makale ekleme işlemi tamamlanmıştır.Sonuç={0}", (resultval ? "Başarılı" : "Hatalı")), "AddComments", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "AddComments", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("update-comment")]
        [HttpPost]
        [Authorize]
        public IResult UpdateComments([FromBody] Comments model)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                model.ModifiedDate = DateTime.Now;
                model.ModifiedUserId = userInfo.UsrId;
                var result = _comment.Update(model, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                if (resultval)
                {
                    if (_memcache.TryGetValue("Comments" + model.Id, out Comments val))
                    {
                        _memcache.Remove("Comments" + model.Id);
                        _memcache.Set<Comments>("Comments" + model.Id, model);
                    }
                }
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "UpdateComments", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("delete-comment")]
        [HttpPost]
        [Authorize]
        public IResult DeleteComments([FromBody] int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _comment.Delete(id, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                if(resultval)
                {
                    if(_memcache.TryGetValue("Comments" + id, out Comments val))
                    {
                        _memcache.Remove("Comments" + id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "DeleteComments", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }

        [Route("get-list-by-writer")]
        [HttpGet]
        [Authorize]
        public IObjResult<List<Comments>> GetListByArticleId([FromBody] int articleid)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            List<Comments> resultobj = null;
            _memcache.TryGetValue<List<Comments>>("CommentsByWriters" + articleid, out resultobj);
            try
            {
                if (resultobj == null)
                {
                    var result = _comment.GetListByArticle(articleid, userInfo);
                    resultcode = result.ResultCode;
                    resultmessage = result.Message;
                    resultval = result.IsSuccess;
                    resultobj = result.Object;
                    if (result.IsSuccess)
                    {
                        _memcache.Set<List<Comments>>("CommentsByArticle" + articleid, resultobj);
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
                _logs.Add(userInfo.SessId, ex.ToString(), "GetListByArticleId", "CommentsController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<List<Comments>>(resultval, resultmessage, resultcode, resultobj);
        }
    }
}
