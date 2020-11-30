using ArticleApi.Core.Entities;
using System;

namespace ArticleApi.Data.Entities.Concrete
{
    public class Comments : IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int CommenterId { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
