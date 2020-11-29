﻿using ArticleApi.Core.Entities;
using System;
using System.Collections.Generic;

namespace ArticleApi.Data.Entities.Concrete
{
    public class Writers : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public ICollection<Articles> Articles { get; set; }
    }
}
