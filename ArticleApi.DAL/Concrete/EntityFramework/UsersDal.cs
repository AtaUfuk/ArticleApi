using ArticleApi.Core.DAL.EntityFramework;
using ArticleApi.DAL.Abstract;
using ArticleApi.Data.Entities.Concrete;

namespace ArticleApi.DAL.Concrete.EntityFramework
{
    public class UsersDal : EntityRepositoryBase<Users, ArticleApiDbContext>, IUsersDal
    {
    }
}
