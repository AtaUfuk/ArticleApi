using ArticleApi.Business.Services;
using ArticleApi.DAL.Abstract;
using ArticleApi.Data.Entities.Concrete;
using System;

namespace ArticleApi.Business.Managers
{
    public class LogsManager : ILogsService
    {
        private readonly ILogsDal _repos;

        public LogsManager(ILogsDal repos)
        {
            _repos = repos;
        }

        public void Add(string sessionid, string message, string methodname, string pagename, string loglayer, string link, string userip, int usrid)
        {
            Logs log = new Logs
            {
                CreatedDate = DateTime.Now,
                Link = link,
                LogIp = userip,
                LogLayer = loglayer,
                LogPage = pagename,
                LogMethod = methodname,
                Message = message,
                SessionId = sessionid,
                UserId = usrid
            };
            _repos.Add(log);
        }
    }
}
