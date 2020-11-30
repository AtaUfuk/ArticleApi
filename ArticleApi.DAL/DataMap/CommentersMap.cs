using ArticleApi.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ArticleApi.DAL.DataMap
{
    public class CommentersMap : IEntityTypeConfiguration<Commenters>
    {
        public void Configure(EntityTypeBuilder<Commenters> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Active);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CreatedUserId).HasDefaultValue(0);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.ModifiedUserId);
        }
    }
}
