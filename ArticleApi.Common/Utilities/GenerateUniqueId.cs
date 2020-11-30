using System;

namespace ArticleApi.Common.Utilities
{
    public static class GenerateUniqueId
    {
        public static string Create()
        {
            Guid gd = Guid.NewGuid();
            string result = gd.ToString();
            return result;
        }
    }
}
