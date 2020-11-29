using ArticleApi.Core.DAL.EntityFramework;
using ArticleApi.DAL.Abstract;
using ArticleApi.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.DAL.Concrete.EntityFramework
{
    public class LogsDal : EntityRepositoryBase<Logs, ArticleApiDbContext>, ILogsDal
    {
    }
}
