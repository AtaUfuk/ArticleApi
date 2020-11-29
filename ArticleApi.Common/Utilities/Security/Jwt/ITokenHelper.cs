using ArticleApi.Common.Models.UserModels;

namespace ArticleApi.Common.Utilities.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AutUserInfo userInfo);
    }
}
