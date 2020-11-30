using ArticleApi.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleApi.DAL.DataMap
{
    public class CommentsMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<Commenters>().WithMany().HasForeignKey(x => x.CommenterId).IsRequired();
            builder.Property(x => x.Content);
            builder.Property(x => x.Active);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.CreatedUserId).HasDefaultValue(0);
            builder.Property(x => x.ModifiedDate);
            builder.Property(x => x.ModifiedUserId);
        }
    }
}
