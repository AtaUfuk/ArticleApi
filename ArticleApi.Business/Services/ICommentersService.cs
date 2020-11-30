using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;

namespace ArticleApi.Business.Services
{
    public interface ICommentersService
    {
        IResult Add(Commenters model, AutUserInfo userInfo);
        IResult Update(Commenters model, AutUserInfo userInfo);
        IObjResult<Commenters> GetById(int id, AutUserInfo userInfo);
        IResult Delete(int id, AutUserInfo userInfo);
    }
}
