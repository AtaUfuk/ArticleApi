using ArticleApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace ArticleApi.Data.Entities.Concrete
{
    public class Articles : IEntity
    {
        public int Id { get; set; }
        public int WriterId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Banner { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string HasTags { get; set; }
        public int SeqNum { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public Writers Writer { get; set; }
    }
}
