using ArticleApi.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Business.Services
{
    public interface ILogsService
    {
        void Add(string sessionid, string message, string methodname, string pagename, string loglayer, string link, string userip, int usrid);
    }
}
