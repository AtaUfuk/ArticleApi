using ArticleApi.Core.DAL;
using ArticleApi.Data.Entities.Concrete;

namespace ArticleApi.DAL.Abstract
{
    public interface IUsersDal : IEntityRepository<Users>
    {
    }
}
