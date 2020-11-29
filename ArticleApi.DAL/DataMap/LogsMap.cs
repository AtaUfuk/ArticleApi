using ArticleApi.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.DAL.DataMap
{
    public class LogsMap : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SessionId).HasMaxLength(80);
            builder.Property(x => x.LogLayer).HasMaxLength(150);
            builder.Property(x => x.Message);
            builder.Property(x => x.LogMethod).HasMaxLength(100);
            builder.Property(x => x.LogPage).HasMaxLength(100);
            builder.Property(x => x.Link).HasMaxLength(255);
            builder.Property(x => x.LogIp).HasMaxLength(30);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UserId).HasDefaultValue(0);
        }
    }
}
