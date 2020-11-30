using Autofac;
using ArticleApi.Business.Services;
using ArticleApi.Business.Managers;
using ArticleApi.Common.Utilities.Jwt;
using ArticleApi.DAL.Abstract;
using ArticleApi.DAL.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace ArticleApi.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticlesManager>().As<IArticlesService>();
            builder.RegisterType<ArticlesDal>().As<IArticlesDal>();
            builder.RegisterType<LogsManager>().As<ILogsService>();
            builder.RegisterType<LogsDal>().As<ILogsDal>();
            builder.RegisterType<WritersManager>().As<IWritersService>();
            builder.RegisterType<WritersDal>().As<IWritersDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UsersDal>().As<IUsersDal>();
            builder.RegisterType<CommentersDal>().As<ICommentersDal>();
            builder.RegisterType<CommentersManager>().As<ICommentersService>();
            builder.RegisterType<CommentsManager>().As<ICommentersService>();
            builder.RegisterType<CommentsDal>().As<ICommentsDal>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}
