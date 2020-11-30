using ArticleApi.Business.Services;
using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities;
using ArticleApi.Common.Utilities.Jwt;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.DAL.Abstract;
using ArticleApi.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUsersDal _users;
        private readonly ILogsService _log;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUsersDal users, ILogsService log, ITokenHelper tokenHelper)
        {
            _users = users;
            _log = log;
            _tokenHelper = tokenHelper;
        }

        public IObjResult<AccessToken> CreateToken(AutUserInfo userInfo)
        {
            string _resultMessage;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            AccessToken token = null;
            try
            {
                _log.Add(userInfo.SessId, "Kullanıcı için token oluşturma işlemi başlamıştır", "CreateToken", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
                token = _tokenHelper.CreateToken(userInfo);
                if (token != null)
                {
                    _resultMessage = StaticValues.SuccessMessage;
                    _code = StaticValues.SuccessCode;
                    _resultval = true;
                }
                else
                {
                    _resultMessage = StaticValues.ErrorMessage;
                    _code = StaticValues.ErrorCode;
                }
                _log.Add(userInfo.SessId, "Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=" + (_resultval ? "Başarılı" : "Hatalı"), "CreateToken", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
            }
            catch (Exception ex)
            {
                _resultMessage = StaticValues.ErrorMessage;
                _code = StaticValues.ErrorCode;
                _log.Add(userInfo.SessId, "Kullanıcı bilgileri getirme esnasında bir sorun ile karşılaşıldı. Hata içeriği=" + ex.ToString(), "CreateToken", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", userInfo.ClientIp, userInfo.UsrId);
            }
            return new ObjResult<AccessToken>(_resultval, _resultMessage, _code, token);
        }

        public IResult CreateUser(Users users, string clientip, string sessionid)
        {
            string _resultMessage = string.Empty;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            try
            {
                _users.Add(users);
                _resultMessage = StaticValues.SuccessMessage;
                _code = StaticValues.SuccessCode;
                _resultval = true;
            }
            catch (Exception ex)
            {
                _log.Add(sessionid, "Kullanıcı bilgileri getirme esnasında bir sorun ile karşılaşıldı. Hata içeriği=" + ex.ToString(), "CreateToken", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", clientip, StaticValues.DefUserId);
            }
            return new Result(_resultval, _resultMessage, _code);
        }

        public IObjResult<AutUserInfo> GetUser(string email, string password, string clientip, string sessionid)
        {
            string _resultMessage;
            int _code = StaticValues.InfoCode;
            bool _resultval = false;
            AutUserInfo usrInfo = new AutUserInfo
            {
                ClientIp = clientip,
                SessId = sessionid,
                UsrId = StaticValues.DefUserId
            };
            try
            {
                _log.Add(sessionid, "Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=" + email + ",password=Güvenlik sebebiyle şifre kaydedilmemektedir", "GetUser", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", clientip, usrInfo.UsrId);
                Users user = _users.Get(x => x.Email == email && x.Password == password && x.Active && !x.Deleted);
                if (user != null)
                {
                    _resultMessage = StaticValues.SuccessMessage;
                    _resultval = true;
                    _code = StaticValues.SuccessCode;
                    usrInfo.UsrId = user.Id;
                }
                else
                {
                    _resultMessage = StaticValues.ErrorUserAuthMessage;
                    _resultval = false;
                    _code = StaticValues.ErrorUserAuthCode;
                }
                _log.Add(sessionid, "Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=" + (_resultval ? "Başarılı" : "Hatalı"), "GetUser", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", clientip, usrInfo.UsrId);
            }
            catch (Exception ex)
            {
                _resultMessage = StaticValues.ErrorMessage;
                _code = StaticValues.ErrorCode;
                _log.Add(sessionid, "Kullanıcı bilgileri getirme esnasında bir sorun ile karşılaşıldı. Hata içeriği=" + ex.ToString(), "GetUser", "UserManager", Enum.GetName(typeof(Layers.LayerInfo), 2), "", clientip, usrInfo.UsrId);
            }
            return new ObjResult<AutUserInfo>(_resultval, _resultMessage, _code, usrInfo);
        }
    }
}
