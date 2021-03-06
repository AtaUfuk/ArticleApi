USE [ArticleDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WriterId] [int] NOT NULL,
	[Title] [nvarchar](255) NULL,
	[ShortDescription] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[Banner] [nvarchar](255) NULL,
	[SeoTitle] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[SeoKeywords] [nvarchar](255) NULL,
	[HasTags] [nvarchar](500) NULL,
	[SeqNum] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedUserId] [int] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commenters]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commenters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedUserId] [int] NULL,
 CONSTRAINT [PK_Commenters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommenterId] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedUserId] [int] NULL,
	[ArticleId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [nvarchar](80) NULL,
	[Message] [nvarchar](max) NULL,
	[LogMethod] [nvarchar](100) NULL,
	[LogPage] [nvarchar](100) NULL,
	[LogLayer] [nvarchar](150) NULL,
	[Link] [nvarchar](255) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LogIp] [nvarchar](30) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[LastName] [nvarchar](300) NULL,
	[Email] [nvarchar](255) NULL,
	[Password] [nvarchar](256) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedUserId] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedUserId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Writers]    Script Date: 30.11.2020 23:33:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Writers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedUserId] [int] NULL,
 CONSTRAINT [PK_Writers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201129195817_create-db', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201130195338_remove-columns', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201130200235_insert-column-comments', N'5.0.0')
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [WriterId], [Title], [ShortDescription], [Content], [Banner], [SeoTitle], [SeoDescription], [SeoKeywords], [HasTags], [SeqNum], [Active], [Deleted], [CreatedDate], [CreatedUserId], [ModifiedDate], [ModifiedUserId]) VALUES (2, 1, N'Title', N'desc', N'content', N'banner2.png', N'seo', N'seo 2', N'seo 3', N'tag,tag2', 98, 1, 1, CAST(N'2020-11-29T20:35:52.9010000' AS DateTime2), 0, CAST(N'2020-11-29T20:35:52.9010000' AS DateTime2), 0)
INSERT [dbo].[Articles] ([Id], [WriterId], [Title], [ShortDescription], [Content], [Banner], [SeoTitle], [SeoDescription], [SeoKeywords], [HasTags], [SeqNum], [Active], [Deleted], [CreatedDate], [CreatedUserId], [ModifiedDate], [ModifiedUserId]) VALUES (3, 1, N'Article Title', N'Desc', N'lorem ipsum dolor sit amet', N'abc.png', N'seo title', N'seo desc', N'seo keys', N'#lorem,#lorem 2', 11, 1, 0, CAST(N'2020-11-30T05:32:13.7980000' AS DateTime2), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Articles] OFF
SET IDENTITY_INSERT [dbo].[Logs] ON 

INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (1, N'5464f5b7-0d95-4bc8-8662-d6dd34b625d0', N'Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while updating the entries. See the inner exception for details.
 ---> Microsoft.Data.SqlClient.SqlException (0x80131904): The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Articles_Writers_WriterId". The conflict occurred in database "ArticleDb", table "dbo.Writers", column ''Id''.
The statement has been terminated.
   at Microsoft.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.SqlDataReader.TryConsumeMetaData()
   at Microsoft.Data.SqlClient.SqlDataReader.get_MetaData()
   at Microsoft.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean isAsync, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at System.Data.Common.DbCommand.ExecuteReader()
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
ClientConnectionId:3e88be51-6b72-4874-a019-eb8a7b6104d1
Error Number:547,State:0,Class:16
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(DbContext _, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges()
   at ArticleApi.Core.DAL.EntityFramework.EntityRepositoryBase`2.Add(TEntity entity) in E:\Calismalar\OrnCalismalar\CoreOrnCalismalar\ArticleApi\ArticleApi.Core\DAL\EntityFramework\EntityRepositoryBase.cs:line 19
   at ArticleApi.Business.Managers.ArticlesManager.Add(Articles model, AutUserInfo userInfo) in E:\Calismalar\OrnCalismalar\CoreOrnCalismalar\ArticleApi\ArticleApi.Business\Managers\ArticlesManager.cs:line 31', N'Add', N'ArticlesManager', NULL, N'', CAST(N'2020-11-29T23:01:24.9887136' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (2, N'97b6f119-38bb-49e4-af06-4a8b0075ed43', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T00:41:54.1193967' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (3, N'97b6f119-38bb-49e4-af06-4a8b0075ed43', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T00:41:55.5869316' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (4, N'97b6f119-38bb-49e4-af06-4a8b0075ed43', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T00:42:04.1925450' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (5, N'97b6f119-38bb-49e4-af06-4a8b0075ed43', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T00:42:05.1262762' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (6, N'55cb3c6a-e3e4-4467-8529-948367f65bea', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:06:36.2690386' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (7, N'55cb3c6a-e3e4-4467-8529-948367f65bea', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:06:37.7664508' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (8, N'55cb3c6a-e3e4-4467-8529-948367f65bea', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:06:37.7813817' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (9, N'55cb3c6a-e3e4-4467-8529-948367f65bea', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:06:37.9497967' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (10, N'60b72d5b-170f-45ff-9de3-34135730d4f4', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:12:12.4882678' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (11, N'60b72d5b-170f-45ff-9de3-34135730d4f4', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:12:13.9382289' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (12, N'60b72d5b-170f-45ff-9de3-34135730d4f4', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:12:13.9521854' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (13, N'60b72d5b-170f-45ff-9de3-34135730d4f4', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:12:14.1350679' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (14, N'64212a7f-d393-4c1f-905c-cd0cde75c3d4', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:14:34.4388760' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (15, N'64212a7f-d393-4c1f-905c-cd0cde75c3d4', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:14:35.9583831' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (16, N'64212a7f-d393-4c1f-905c-cd0cde75c3d4', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:14:35.9729993' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (17, N'64212a7f-d393-4c1f-905c-cd0cde75c3d4', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:14:36.1614560' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (18, N'5c1eacf8-d089-4e22-b1a8-0a1284800a1f', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:19:22.5316518' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (19, N'5c1eacf8-d089-4e22-b1a8-0a1284800a1f', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:19:24.0260643' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (20, N'5c1eacf8-d089-4e22-b1a8-0a1284800a1f', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:19:24.0394896' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (21, N'5c1eacf8-d089-4e22-b1a8-0a1284800a1f', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:19:24.1759216' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (22, N'a304d5e0-d291-4593-ae88-9c212c6a3937', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:20:47.6876011' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (23, N'a304d5e0-d291-4593-ae88-9c212c6a3937', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:20:49.1836756' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (24, N'a304d5e0-d291-4593-ae88-9c212c6a3937', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:20:49.1977167' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (25, N'a304d5e0-d291-4593-ae88-9c212c6a3937', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:20:49.3555949' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (26, N'b04f5c76-fd3b-4747-bd2b-d1adb0be2297', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:24:14.7841363' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (27, N'b04f5c76-fd3b-4747-bd2b-d1adb0be2297', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:24:16.5460627' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (28, N'b04f5c76-fd3b-4747-bd2b-d1adb0be2297', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:24:16.5593349' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (29, N'b04f5c76-fd3b-4747-bd2b-d1adb0be2297', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:24:16.7188488' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (30, N'5a3f9f47-e345-47c0-a4b1-caa3cdd436d9', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:28:49.5958455' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (31, N'5a3f9f47-e345-47c0-a4b1-caa3cdd436d9', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:28:51.2408380' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (32, N'5a3f9f47-e345-47c0-a4b1-caa3cdd436d9', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:28:51.2546646' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (33, N'5a3f9f47-e345-47c0-a4b1-caa3cdd436d9', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:28:51.4414077' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (34, N'56f857cb-8c52-4ca0-a7b7-d73a5fdf60ff', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:33:31.3445899' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (35, N'56f857cb-8c52-4ca0-a7b7-d73a5fdf60ff', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:33:32.8671591' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (36, N'56f857cb-8c52-4ca0-a7b7-d73a5fdf60ff', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:33:32.8809696' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (37, N'56f857cb-8c52-4ca0-a7b7-d73a5fdf60ff', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:33:33.0652077' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (38, N'00412ad0-e41b-4744-8dd4-fec4792aa1ff', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:43:00.4558439' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (39, N'00412ad0-e41b-4744-8dd4-fec4792aa1ff', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:43:00.4758154' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (40, N'00412ad0-e41b-4744-8dd4-fec4792aa1ff', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:43:00.4792505' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (41, N'00412ad0-e41b-4744-8dd4-fec4792aa1ff', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T01:43:00.4813734' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (42, N'2e4be3aa-595e-41a7-9c51-2f66ed1ec209', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:28:59.8067466' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (43, N'2e4be3aa-595e-41a7-9c51-2f66ed1ec209', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:29:03.9019285' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (44, N'2e4be3aa-595e-41a7-9c51-2f66ed1ec209', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:29:03.9165932' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (45, N'2e4be3aa-595e-41a7-9c51-2f66ed1ec209', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:29:04.6289098' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (46, N'df722d2c-5760-4684-b4f9-6cb574df16ef', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:34:24.3854907' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (47, N'df722d2c-5760-4684-b4f9-6cb574df16ef', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:34:26.2916952' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (48, N'df722d2c-5760-4684-b4f9-6cb574df16ef', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:34:26.3084276' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (49, N'df722d2c-5760-4684-b4f9-6cb574df16ef', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:34:26.4908759' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (50, N'6cdd69ad-a0ad-42ba-acc2-41308b33c6f2', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:36:49.8294445' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (51, N'6cdd69ad-a0ad-42ba-acc2-41308b33c6f2', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:36:51.9428741' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (52, N'6cdd69ad-a0ad-42ba-acc2-41308b33c6f2', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:36:51.9610792' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (53, N'6cdd69ad-a0ad-42ba-acc2-41308b33c6f2', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:36:52.1608508' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (54, N'ca9c5650-7659-46fc-937c-537aaa2c9a51', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:39:19.9096264' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (55, N'ca9c5650-7659-46fc-937c-537aaa2c9a51', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:39:22.2205532' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (56, N'ca9c5650-7659-46fc-937c-537aaa2c9a51', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:39:22.2388214' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (57, N'ca9c5650-7659-46fc-937c-537aaa2c9a51', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:39:22.4226840' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (58, N'a024f497-bcd5-4b12-b12b-a00b1c51e02e', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:41:12.8312963' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (59, N'a024f497-bcd5-4b12-b12b-a00b1c51e02e', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:41:15.0289266' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (60, N'a024f497-bcd5-4b12-b12b-a00b1c51e02e', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:41:15.0476407' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (61, N'a024f497-bcd5-4b12-b12b-a00b1c51e02e', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T08:41:15.2288200' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (62, N'01f298c4-1328-4792-8f0b-e0302839a441', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T09:18:22.8041049' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (63, N'01f298c4-1328-4792-8f0b-e0302839a441', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', NULL, N'', CAST(N'2020-11-30T09:18:24.9803473' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (64, N'01f298c4-1328-4792-8f0b-e0302839a441', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T09:18:25.0004880' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (65, N'01f298c4-1328-4792-8f0b-e0302839a441', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', NULL, N'', CAST(N'2020-11-30T09:18:25.1953581' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (66, N'368235ce-2e89-4764-9f66-2baafa8398a8', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T09:19:57.7033106' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (67, N'368235ce-2e89-4764-9f66-2baafa8398a8', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T09:20:00.0427828' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (68, N'368235ce-2e89-4764-9f66-2baafa8398a8', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T09:20:00.0643377' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (69, N'368235ce-2e89-4764-9f66-2baafa8398a8', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T09:20:00.2642778' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (70, N'b854cb89-a2ca-4dfb-a60b-647dc5931258', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T20:58:38.9690299' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (71, N'b854cb89-a2ca-4dfb-a60b-647dc5931258', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T20:58:42.4440521' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (72, N'b854cb89-a2ca-4dfb-a60b-647dc5931258', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T20:58:42.4624737' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (73, N'b854cb89-a2ca-4dfb-a60b-647dc5931258', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T20:58:42.7371122' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (74, N'8cf44107-9990-415c-ad4d-53bce893303c', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:02:04.7292117' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (75, N'8cf44107-9990-415c-ad4d-53bce893303c', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:02:07.0034362' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (76, N'8cf44107-9990-415c-ad4d-53bce893303c', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:02:07.0223653' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (77, N'8cf44107-9990-415c-ad4d-53bce893303c', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:02:07.2187466' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (78, N'faebeb70-3533-450e-9799-8a8a6f73287d', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:04:14.5370837' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (79, N'faebeb70-3533-450e-9799-8a8a6f73287d', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:04:16.8939868' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (80, N'faebeb70-3533-450e-9799-8a8a6f73287d', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:04:16.9139183' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (81, N'faebeb70-3533-450e-9799-8a8a6f73287d', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T21:04:17.1100855' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (82, N'a60ba020-102f-4b62-9891-b26568174cab', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:33:21.6166753' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (83, N'a60ba020-102f-4b62-9891-b26568174cab', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:33:23.0933623' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (84, N'a60ba020-102f-4b62-9891-b26568174cab', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:33:23.1076717' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (85, N'a60ba020-102f-4b62-9891-b26568174cab', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:33:23.2402139' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (86, N'e1117cc6-ad5f-465c-aba5-d4ce6d5b8054', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:36:21.5717950' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (87, N'e1117cc6-ad5f-465c-aba5-d4ce6d5b8054', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:36:21.5914496' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (88, N'e1117cc6-ad5f-465c-aba5-d4ce6d5b8054', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:36:21.5955738' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (89, N'e1117cc6-ad5f-465c-aba5-d4ce6d5b8054', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:36:21.5979586' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (90, N'5f936b97-c605-46c2-a9ea-0a2692e126e8', N'Kullanıcı bilgileri getirme işlemi başlamıştır. Ekli parametreler ile başlamıştır. email=ufukata34@gmail.com,password=Güvenlik sebebiyle şifre kaydedilmemektedir', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:37:12.9607109' AS DateTime2), N'::1', 0)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (91, N'5f936b97-c605-46c2-a9ea-0a2692e126e8', N'Kullanıcı bilgileri getirme işlemi tamamlanmıştır. Sonuç=Başarılı', N'GetUser', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:37:14.5171625' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (92, N'5f936b97-c605-46c2-a9ea-0a2692e126e8', N'Kullanıcı için token oluşturma işlemi başlamıştır', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:37:14.5322733' AS DateTime2), N'::1', 2)
INSERT [dbo].[Logs] ([Id], [SessionId], [Message], [LogMethod], [LogPage], [LogLayer], [Link], [CreatedDate], [LogIp], [UserId]) VALUES (93, N'5f936b97-c605-46c2-a9ea-0a2692e126e8', N'Kullanıcı için token oluşturma işlemi tamamlanmıştır.Sonuç=Başarılı', N'CreateToken', N'UserManager', N'Business', N'', CAST(N'2020-11-30T22:37:14.6907206' AS DateTime2), N'::1', 2)
SET IDENTITY_INSERT [dbo].[Logs] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password], [Active], [Deleted], [CreatedDate], [CreatedUserId], [ModifiedDate], [ModifiedUserId]) VALUES (2, N'Ufuk', N'Ata', N'ufukata34@gmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 1, 0, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Writers] ON 

INSERT [dbo].[Writers] ([Id], [Name], [LastName], [Email], [Active], [Deleted], [CreatedDate], [CreatedUserId], [ModifiedDate], [ModifiedUserId]) VALUES (1, N'Ufuk', N'Ata', N'a@a.com', 1, 0, CAST(N'2020-11-29T00:00:00.0000000' AS DateTime2), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Writers] OFF
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((99)) FOR [SeqNum]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [CreatedUserId]
GO
ALTER TABLE [dbo].[Commenters] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Commenters] ADD  DEFAULT ((0)) FOR [CreatedUserId]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT ((0)) FOR [CreatedUserId]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT ((0)) FOR [ArticleId]
GO
ALTER TABLE [dbo].[Logs] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Logs] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [CreatedUserId]
GO
ALTER TABLE [dbo].[Writers] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Writers] ADD  DEFAULT ((0)) FOR [CreatedUserId]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Writers_WriterId] FOREIGN KEY([WriterId])
REFERENCES [dbo].[Writers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Writers_WriterId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Articles_ArticleId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Commenters_CommenterId] FOREIGN KEY([CommenterId])
REFERENCES [dbo].[Commenters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Commenters_CommenterId]
GO
