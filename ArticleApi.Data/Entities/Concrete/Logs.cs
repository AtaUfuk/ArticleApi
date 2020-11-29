using ArticleApi.Core.Entities;
using System;

namespace ArticleApi.Data.Entities.Concrete
{
    public class Logs:IEntity
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string Message { get; set; }
        public string LogMethod { get; set; }
        public string LogPage { get; set; }
        public string LogLayer { get; set; }
        public string Link { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LogIp { get; set; }
        public int UserId { get; set; }
    }
}
