using ArticleApi.Common.Models.UserModels;
using ArticleApi.Common.Utilities.Results;
using ArticleApi.Data.Entities.Concrete;

namespace ArticleApi.Business.Services
{
    public interface IWritersService
    {
        IResult Add(Writers model, AutUserInfo userInfo);
        IResult Update(Writers model, AutUserInfo userInfo);
        IObjResult<Writers> GetById(int id, AutUserInfo userInfo);
        IResult Delete(int id, AutUserInfo userInfo);
    }
}
