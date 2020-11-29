using ArticleApi.DAL.DataMap;
using ArticleApi.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ArticleApi.DAL.Concrete.EntityFramework
{
    public class ArticleApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\sqlexpress;Initial Catalog=ArticleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;AttachDbFileName=C:\Users\Vegeta\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\sqlexpress\ArticleDb.mdf;");
        }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Commenters> Commenters { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Writers> Writers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticlesMap());
            modelBuilder.ApplyConfiguration(new CommentersMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());
            modelBuilder.ApplyConfiguration(new LogsMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new WritersMap());
        }
    }
}
