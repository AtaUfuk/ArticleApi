using Autofac;
using AwsDynamoDbExam.Business.IWorkFlows;
using AwsDynamoDbExam.Business.WorkFlows;
using AwsDynamoDbExam.Common.Utilities;
using AwsDynamoDbExam.Common.Utilities.Jwt;
using AwsDynamoDbExam.DataAccess.Components;
using AwsDynamoDbExam.DataAccess.IComponents;
using Microsoft.AspNetCore.Http;

namespace AwsDynamoDbExam.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailWorkFlows>().As<IMailWorkFlow>();
            builder.RegisterType<MailsComponent>().As<IMailsComponent>();
            builder.RegisterType<UserWorkFlow>().As<IUserWorkFlow>();
            builder.RegisterType<UsersComponent>().As<IUsersComponent>();
            builder.RegisterType<LogWorkFlow>().As<ILogWorkFlow>();
            builder.RegisterType<LogComponent>().As<ILogComponent>();
            builder.RegisterType<GetUserIp>().As<IGetUserIp>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
