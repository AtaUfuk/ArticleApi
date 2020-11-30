using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ArticleApi.WebApi.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object sessobj)
        {
            string objString = JsonConvert.SerializeObject(sessobj);
            session.SetString(key, objString);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string strObj = session.GetString(key);
            T value = null;
            if (!string.IsNullOrWhiteSpace(strObj))
            {
                value = JsonConvert.DeserializeObject<T>(strObj);
            }
            return value;
        }
    }
}
