using ArticleApi.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.DAL.DataMap
{
    public class ArticlesMap : IEntityTypeConfiguration<Articles>
    {
        public void Configure(EntityTypeBuilder<Articles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<Writers>().WithMany().HasForeignKey(x => x.WriterId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.ShortDescription).HasMaxLength(500);
            builder.Property(x => x.Content);
            builder.Property(x => x.Banner).HasMaxLength(255);
            builder.Property(x => x.SeoTitle).HasMaxLength(255);
            builder.Property(x => x.SeoDescription).HasMaxLength(255);
            builder.Property(x => x.SeoKeywords).HasMaxLength(255);
            builder.Property(x => x.HasTags).HasMaxLength(500);
            builder.Property(x => x.SeqNum).HasDefaultValue(99);
            builder.Property(x => x.Active);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CreatedUserId).HasDefaultValue(0);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.ModifiedUserId);
        }
    }
}
