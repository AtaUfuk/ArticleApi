using ArticleApi.Core.DAL;
using ArticleApi.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.DAL.Abstract
{
    public interface ILogsDal : IEntityRepository<Logs>
    {
    }
}
