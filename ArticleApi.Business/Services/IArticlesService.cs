using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;
using System.Collections.Generic;

namespace ArticleApi.Business.Services
{
    public interface IArticlesService
    {
        IResult Add(Articles model, AutUserInfo userInfo);
        IResult Update(Articles model, AutUserInfo userInfo);
        IObjResult<Articles> GetById(int id, AutUserInfo userInfo);
        IObjResult<List<Articles>> GetListByWriter(int writerid, AutUserInfo userInfo);
        IResult Delete(int id, AutUserInfo userInfo);
    }
}
