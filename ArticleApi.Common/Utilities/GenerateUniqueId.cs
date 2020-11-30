using System;

namespace ArticleApi.Common.Utilities
{
    public static class GenerateUniqueId
    {
        /// <summary>
        /// Session için yeni Guid değeri oluşturan metottur.
        /// </summary>
        /// <returns></returns>
        public static string Create()
        {
            Guid gd = Guid.NewGuid();
            string result = gd.ToString();
            return result;
        }
    }
}
