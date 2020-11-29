using ArticleApi.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleApi.DAL.DataMap
{
    public class WritersMap : IEntityTypeConfiguration<Writers>
    {
        public void Configure(EntityTypeBuilder<Writers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Password).HasMaxLength(256);
            builder.Property(x => x.Active);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CreatedUserId).HasDefaultValue(0);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.ModifiedUserId);
        }
    }
}
