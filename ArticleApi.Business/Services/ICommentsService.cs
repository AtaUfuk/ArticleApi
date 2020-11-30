using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;
using System.Collections.Generic;

namespace ArticleApi.Business.Services
{
    public interface ICommentsService
    {
        IResult Add(Comments model, AutUserInfo userInfo);
        IResult Update(Comments model, AutUserInfo userInfo);
        IObjResult<Comments> GetById(int id, AutUserInfo userInfo);
        IObjResult<List<Comments>> GetListByArticle(int articleid, AutUserInfo userInfo);
        IResult Delete(int id, AutUserInfo userInfo);
    }
}
