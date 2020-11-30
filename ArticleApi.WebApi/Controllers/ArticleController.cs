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

namespace ArticleApi.WebApi.Controllers
{
    [Route("article-operations")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticlesService _article;
        private readonly ILogsService _logs;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMemoryCache _memcache;

        public ArticleController(IArticlesService article, ILogsService logs, IHttpContextAccessor httpContext, IMemoryCache memcache)
        {
            _article = article;
            _logs = logs;
            _httpContext = httpContext;
            _memcache = memcache;
        }
        [Route("get-by-id")]
        [HttpGet]
        [Authorize]
        public IObjResult<Articles> GetArticle(int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            Articles resultobj = null;
            try
            {
                _memcache.TryGetValue<Articles>("Article" + id, out resultobj);
                if (resultobj == null)
                {
                    var result = _article.GetById(id, userInfo);
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
                        _memcache.Set<Articles>("Article" + id, resultobj, cacheExpOptions);
                    }
                }
                else
                {
                    resultobj.Title += "-Mem";
                    resultcode = StaticValues.SuccessCode;
                    resultmessage = StaticValues.SuccessMessage;
                    resultval = true;
                }

            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "GetArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<Articles>(resultval, resultmessage, resultcode, resultobj);
        }
        [Route("insert-article")]
        [HttpPost]
        [Authorize]
        public IResult AddArticle([FromBody] Articles model)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                _logs.Add(userInfo.SessId, string.Format("Makale ekleme işlemi ekli parametreler ile başlamıştır.{0}", Reflections.GetModelPropertyValues<Articles>(model)), "AddArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
                var result = _article.Add(model, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                _logs.Add(userInfo.SessId, string.Format("Makale ekleme işlemi tamamlanmıştır.Sonuç={0}", (resultval ? "Başarılı" : "Hatalı")), "AddArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "AddArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("update-article")]
        [HttpPost]
        [Authorize]
        public IResult UpdateArticle([FromBody] Articles model)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                model.ModifiedDate = DateTime.Now;
                model.ModifiedUserId = userInfo.UsrId;
                var result = _article.Update(model, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                if (resultval)
                {
                    if (_memcache.TryGetValue("Article" + model.Id, out Articles val))
                    {
                        _memcache.Remove("Article" + model.Id);
                        _memcache.Set<Articles>("Article" + model.Id, model);
                    }
                }
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "UpdateArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }
        [Route("delete-article")]
        [HttpPost]
        [Authorize]
        public IResult DeleteArticle([FromBody] int id)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            try
            {
                var result = _article.Delete(id, userInfo);
                resultcode = result.ResultCode;
                resultmessage = result.Message;
                resultval = result.IsSuccess;
                if(resultval)
                {
                    if(_memcache.TryGetValue("Article" + id, out Articles val))
                    {
                        _memcache.Remove("Article" + id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "DeleteArticle", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), _httpContext.HttpContext.Request.Path, userInfo.ClientIp, userInfo.UsrId);
            }
            return new Result(resultval, resultmessage, resultcode);
        }

        [Route("get-list-by-writer")]
        [HttpGet]
        [Authorize]
        public IObjResult<List<Articles>> GetByWriterId([FromBody] int writerid)
        {
            AutUserInfo userInfo = _httpContext.HttpContext.Session.GetObject<AutUserInfo>("UserInfo");
            string resultmessage = StaticValues.ErrorMessage;
            int resultcode = StaticValues.ErrorCode;
            bool resultval = false;
            List<Articles> resultobj = null;
            _memcache.TryGetValue<List<Articles>>("ArticlesByWriters" + writerid, out resultobj);
            try
            {
                if (resultobj == null)
                {
                    var result = _article.GetListByWriter(writerid, userInfo);
                    resultcode = result.ResultCode;
                    resultmessage = result.Message;
                    resultval = result.IsSuccess;
                    resultobj = result.Object;
                    if (result.IsSuccess)
                    {
                        _memcache.Set<List<Articles>>("ArticlesByWriters" + writerid, resultobj);
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
                _logs.Add(userInfo.SessId, ex.ToString(), "GetByWriterId", "ArticleController", Enum.GetName(typeof(LayerInfo), 1), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<List<Articles>>(resultval, resultmessage, resultcode, resultobj);
        }
    }
}
