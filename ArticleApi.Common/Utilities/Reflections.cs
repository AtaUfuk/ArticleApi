using System;
using System.Reflection;
using System.Text;

namespace ArticleApi.Common.Utilities
{
    public static class Reflections
    {
        public static string GetModelPropertyValues<T>(T model) where T : class
        {
            StringBuilder _result = new StringBuilder();
            Type type = model.GetType();
            PropertyInfo[] fieldInfoes = type.GetProperties();
            int counter = 0;
            foreach (var field in fieldInfoes)
            {
                string name = field.Name;
                var value = field.GetValue(model,null);
                string fieldinfo = string.Format("{0}:{1}", name, value?.ToString());
                if (counter == 0)
                {
                    _result.Append(fieldinfo);
                    counter++;
                }
                else
                {
                    _result.Append("," + fieldinfo);
                }
            }
            return _result.ToString();
        }
    }
}
