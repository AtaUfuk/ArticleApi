using ArticleApi.Common.Models.UserModels;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Common.Utilities.Validations
{
    public static class UserValidation
    {
        public static IDictionary<int, string> UserQueryControl(UserQuery user)
        {
            StringBuilder sb = new StringBuilder();
            int errorcount = 0;
            int _resultCode = StaticValues.ErrorNullCode;
            if (user != null)
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    sb.Append("Email parametresi boş bırakılamaz.");
                    errorcount++;
                }
                if (string.IsNullOrWhiteSpace(user.Password))
                {
                    sb.Append("Password parametresi boş bırakılamaz.");
                    errorcount++;
                }
            }
            else
            {
                sb.Append("Lütfen parametreleri boş bırakmayınız.");
                errorcount++;
            }
            if (errorcount == 0)
            {
                _resultCode = StaticValues.SuccessCode;
            }
            IDictionary<int, string> result = new Dictionary<int, string>
            {
                { _resultCode, sb.ToString() }
            };
            return result;
        }
    }
}
