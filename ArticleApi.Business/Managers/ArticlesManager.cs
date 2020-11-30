using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.DAL.Abstract;
using ArticleApi.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using static ArticleApi.Common.Utilities.Layers;

namespace ArticleApi.Business.Managers
{
    public class ArticlesManager : IArticlesService
    {
        private readonly IArticlesDal _repos;
        private readonly ILogsService _logs;

        public ArticlesManager(IArticlesDal repos, ILogsService logs)
        {
            _repos = repos;
            _logs = logs;
        }

        public IResult Add(Articles model, AutUserInfo userInfo)
        {
            string _resultMessage = string.Empty;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            try
            {
                _repos.Add(model);
                _code = StaticValues.SuccessCode;
                _resultMessage = StaticValues.SuccessMessage;
                _resultval = true;
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "Add", "ArticlesManager", Enum.GetName(typeof(LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
                _code = StaticValues.ErrorCode;
                _resultMessage = StaticValues.ErrorMessage;
                _resultval = false;
            }
            return new Result(_resultval, _resultMessage, _code);
        }

        public IResult Delete(int id, AutUserInfo userInfo)
        {
            string _resultMessage = string.Empty;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            try
            {
                Articles model = _repos.Get(x => x.Id == id);
                if (model != null)
                {
                    model.Active = false;
                    model.Deleted = true;
                    model.ModifiedDate = DateTime.Now;
                    model.ModifiedUserId = userInfo.UsrId;
                    _repos.Update(model);
                    _code = StaticValues.SuccessCode;
                    _resultMessage = StaticValues.SuccessMessage;
                    _resultval = true;
                }
                else
                {
                    _code = StaticValues.ErrorNullObjCode;
                    _resultMessage = StaticValues.ErrorNullObjMessage;
                }

            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "Delete", "ArticlesManager", Enum.GetName(typeof(LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
                _code = StaticValues.ErrorCode;
                _resultMessage = StaticValues.ErrorMessage;
            }
            return new Result(_resultval, _resultMessage, _code);
        }

        public IObjResult<Articles> GetById(int id, AutUserInfo userInfo)
        {
            string _resultMessage = string.Empty;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            Articles _resultentity = null;
            try
            {
                _resultentity = _repos.Get(x => x.Id == id && x.Active && !x.Deleted);
                if (_resultentity != null)
                {
                    _code = StaticValues.SuccessCode;
                    _resultMessage = StaticValues.SuccessMessage;
                    _resultval = true;
                }
                else
                {
                    _code = StaticValues.ErrorNullObjCode;
                    _resultMessage = StaticValues.ErrorNullObjMessage;
                }
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "GetById", "ArticlesManager", Enum.GetName(typeof(LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
                _code = StaticValues.ErrorCode;
                _resultMessage = StaticValues.ErrorMessage;
            }
            return new ObjResult<Articles>(_resultval, _resultMessage, _code, _resultentity);
        }

        public IObjResult<List<Articles>> GetListByWriter(int writerid, AutUserInfo userInfo)
        {
            string _resultMessage = string.Empty;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            List<Articles> _resultentity = null;
            try
            {
                _resultentity = _repos.GetList(x => x.WriterId == writerid && x.Active && !x.Deleted);
                if (_resultentity != null)
                {
                    _code = StaticValues.SuccessCode;
                    _resultMessage = StaticValues.SuccessMessage;
                    _resultval = true;
                }
                else
                {
                    _code = StaticValues.ErrorNullObjCode;
                    _resultMessage = StaticValues.ErrorNullObjMessage;
                }
            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "GetById", "ArticlesManager", Enum.GetName(typeof(LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
                _code = StaticValues.ErrorCode;
                _resultMessage = StaticValues.ErrorMessage;
            }
            return new ObjResult<List<Articles>>(_resultval, _resultMessage, _code, _resultentity);
        }

        public IResult Update(Articles model, AutUserInfo userInfo)
        {
            string _resultMessage = string.Empty;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            try
            {
                Articles entity = _repos.Get(x => x.Id == model.Id);
                if (entity != null)
                {
                    _repos.Update(model);
                    _code = StaticValues.SuccessCode;
                    _resultMessage = StaticValues.SuccessMessage;
                    _resultval = true;
                }
                else
                {
                    _code = StaticValues.ErrorCode;
                    _resultMessage = StaticValues.ErrorMessage;
                }

            }
            catch (Exception ex)
            {
                _logs.Add(userInfo.SessId, ex.ToString(), "Add", "ArticlesManager", Enum.GetName(typeof(LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
                _code = StaticValues.ErrorCode;
                _resultMessage = StaticValues.ErrorMessage;
            }
            return new Result(_resultval, _resultMessage, _code);
        }
    }
}
