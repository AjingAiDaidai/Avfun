USE [avfun]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 05/25/2014 21:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USER](
	[u_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[user_account] [char](64) NOT NULL,
	[user_password] [char](32) NOT NULL,
	[user_nickname] [nvarchar](50) NOT NULL,
	[user_sex] [bit] NOT NULL,
	[user_head] [varchar](256) NOT NULL,
	[user_isDeleted] [bit] NOT NULL,
	[user_isChecked] [bit] NOT NULL,
	[user_last_login_time] [datetime] NOT NULL,
	[user_last_login_ip] [varchar](64) NOT NULL,
	[user_money] [float] NOT NULL,
	[user_introduction] [nvarchar](256) NOT NULL,
	[user_timestamp] [timestamp] NOT NULL,
	[user_verify_code] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UN_USER_ACCOUNT] UNIQUE NONCLUSTERED 
(
	[user_account] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户账户名必须唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USER', @level2type=N'CONSTRAINT',@level2name=N'UN_USER_ACCOUNT'
GO
SET IDENTITY_INSERT [dbo].[USER] ON
INSERT [dbo].[USER] ([u_id], [user_id], [user_account], [user_password], [user_nickname], [user_sex], [user_head], [user_isDeleted], [user_isChecked], [user_last_login_time], [user_last_login_ip], [user_money], [user_introduction], [user_verify_code]) VALUES (56, N'86afcfcf-935a-4f92-91c3-256a823f0664', N'test1@163.com                                                   ', N'E10ADC3949BA59ABBE56E057F20F883E', N'1234                            ', 1, N'img/01.jpg                                                                                                                                                                                                                                                      ', 1, 0, CAST(0x0000A32F00000000 AS DateTime), N'127.0.0.1                                                       ', 0, N'123                                                                                                                                                                                                                                                             ', N'e257b66a-dc20-4b17-93fd-26bc11a0b299')
INSERT [dbo].[USER] ([u_id], [user_id], [user_account], [user_password], [user_nickname], [user_sex], [user_head], [user_isDeleted], [user_isChecked], [user_last_login_time], [user_last_login_ip], [user_money], [user_introduction], [user_verify_code]) VALUES (55, N'f524d2a0-d8f5-42c4-823b-374ff0ded88e', N'11301125@bjtu.edu.cn                                            ', N'2D993A6E55BF67EAF6432E09A36A0512', N'世界第一的公主殿下', 0, N'img%2F140525055723542478.jpg', 1, 1, CAST(0x0000A3360018AE73 AS DateTime), N'127.0.0.1', 279.74, N'teset', N'd53426fe-9dbb-4624-a7e5-2db57799d0bc')
INSERT [dbo].[USER] ([u_id], [user_id], [user_account], [user_password], [user_nickname], [user_sex], [user_head], [user_isDeleted], [user_isChecked], [user_last_login_time], [user_last_login_ip], [user_money], [user_introduction], [user_verify_code]) VALUES (53, N'79d3f10b-b83b-4407-bf42-efc2ed0d014e', N'lyx5398@163.com                                                 ', N'25F9E794323B453885F5181F1B624D0B', N'雾雨魔理沙_不吉利的黑白         ', 0, N'img%2F140518100941630437.jpg                                                                                                                                                                                                                                    ', 0, 1, CAST(0x0000A335018AB7FA AS DateTime), N'127.0.0.1', 719.73, N'一个从不脱离低级趣味的人                                                                                                                                                                                                                                        ', N'68f2a703-016c-4707-b963-87ea5d768531')
SET IDENTITY_INSERT [dbo].[USER] OFF
/****** Object:  Table [dbo].[REVIEW]    Script Date: 05/25/2014 21:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REVIEW](
	[r_id] [bigint] IDENTITY(1,1) NOT NULL,
	[review_id] [uniqueidentifier] NOT NULL,
	[review_content] [text] NOT NULL,
	[review_author] [uniqueidentifier] NOT NULL,
	[review_publish_date] [datetime] NOT NULL,
	[review_isDeleted] [bit] NOT NULL,
	[review_news] [uniqueidentifier] NOT NULL,
	[review_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_REVIEW] PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDER]    Script Date: 05/25/2014 21:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDER](
	[o_id] [bigint] IDENTITY(1,1) NOT NULL,
	[order_id] [uniqueidentifier] NOT NULL,
	[order_date] [datetime] NOT NULL,
	[order_price] [float] NOT NULL,
	[order_isPaid] [bit] NOT NULL,
	[order_isDeleted] [bit] NOT NULL,
	[order_user] [uniqueidentifier] NOT NULL,
	[order_course] [uniqueidentifier] NOT NULL,
	[order_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ORDER] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ORDER] ON
INSERT [dbo].[ORDER] ([o_id], [order_id], [order_date], [order_price], [order_isPaid], [order_isDeleted], [order_user], [order_course]) VALUES (19, N'09405c81-cfed-4bc2-a904-267c9efbe148', CAST(0x0000A3360019A412 AS DateTime), 0.03, 1, 0, N'f524d2a0-d8f5-42c4-823b-374ff0ded88e', N'a2cf3c71-2309-4bad-be85-f0a931156668')
INSERT [dbo].[ORDER] ([o_id], [order_id], [order_date], [order_price], [order_isPaid], [order_isDeleted], [order_user], [order_course]) VALUES (18, N'45b5830d-d184-4b94-b7ae-44602d15c64b', CAST(0x0000A335018AE744 AS DateTime), 30.27, 1, 0, N'79d3f10b-b83b-4407-bf42-efc2ed0d014e', N'ec12d882-b6d5-4eb2-81e9-be5a1bd27702')
INSERT [dbo].[ORDER] ([o_id], [order_id], [order_date], [order_price], [order_isPaid], [order_isDeleted], [order_user], [order_course]) VALUES (21, N'8b2fcb20-1420-467b-95e0-4a6690461240', CAST(0x0000A336010847D5 AS DateTime), 0.05, 1, 0, N'f524d2a0-d8f5-42c4-823b-374ff0ded88e', N'a2cf3c71-2309-4bad-be85-f0a931156668')
INSERT [dbo].[ORDER] ([o_id], [order_id], [order_date], [order_price], [order_isPaid], [order_isDeleted], [order_user], [order_course]) VALUES (17, N'c0cf7b5c-31ce-4123-bcaf-969477b8cf92', CAST(0x0000A33501895E9C AS DateTime), 250, 1, 0, N'79d3f10b-b83b-4407-bf42-efc2ed0d014e', N'dcc901c4-21e4-4dac-9dc2-0b29293f80b7')
INSERT [dbo].[ORDER] ([o_id], [order_id], [order_date], [order_price], [order_isPaid], [order_isDeleted], [order_user], [order_course]) VALUES (20, N'b1abd576-d0ab-4549-9348-a50de0d2e39f', CAST(0x0000A3360105A4B2 AS DateTime), 20.18, 1, 0, N'f524d2a0-d8f5-42c4-823b-374ff0ded88e', N'ec12d882-b6d5-4eb2-81e9-be5a1bd27702')
SET IDENTITY_INSERT [dbo].[ORDER] OFF
/****** Object:  Table [dbo].[NEWS]    Script Date: 05/25/2014 21:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NEWS](
	[n_id] [bigint] IDENTITY(1,1) NOT NULL,
	[news_id] [uniqueidentifier] NOT NULL,
	[news_title] [nvarchar](128) NOT NULL,
	[news_content] [text] NOT NULL,
	[news_author] [uniqueidentifier] NOT NULL,
	[news_publish_date] [datetime] NOT NULL,
	[news_isDeleted] [bit] NOT NULL,
	[news_isOnIndex] [bit] NOT NULL,
	[news_image] [varchar](256) NOT NULL,
	[news_click_count] [int] NOT NULL,
	[news_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_NEWS] PRIMARY KEY CLUSTERED 
(
	[news_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[NEWS] ON
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (6, N'b71b21aa-3bba-452c-900d-0230806e084d', N'测试图片的%2f是否被修改                                                                                                         ', N'<p>
	测试上首页及题头、标题填写、文章内容</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33200000000 AS DateTime), 0, 0, N'/news_image/140523063806172291.jpg', 2)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (7, N'e99e8c97-320c-4972-b42e-090d529887b9', N'Number 2新闻，有配图，不上首页。                                                                                                ', N'<p>
	Number 2新闻，有配图，不上首页。</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33200000000 AS DateTime), 0, 0, N'/news_image/140523063806172291.jpg', 8)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (24, N'9a283d5f-6464-4d1b-876a-0dd1578dc25b', N'分页+修改测试——13', N'<p>
	分页+修改测<strong>试&mdash;&mdash;13</strong></p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 1, 0, N'/news_image/140523063046674787.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (20, N'1859e38d-8919-4801-afa9-0df000359056', N'分页测试——9', N'<p>
	分页测试&mdash;&mdash;9</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 1, 0, N'/news_image/140523010946591833.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (18, N'c3af78e0-6632-4292-9046-1085e77d82c0', N'分页测试——7', N'<p>
	分页测试&mdash;&mdash;7</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140523062354559202.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (37, N'b945696e-0d16-4862-af4d-16ab1f405f57', N'新闻内容插入图片及HTML特效', N'<p>
	<em>新闻</em>内<span style="background-color:#ff0000;">容插入</span>图<u>片及</u><strong><u>H</u>TML特效<img alt="" src="../news_image/140523072845108725.jpg" style="width: 100px; height: 100px;" /></strong></p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33400000000 AS DateTime), 1, 0, N'/news_image/default.jpg', 5)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (29, N'8d6fed0d-8009-494f-bc90-212237756777', N'分页测试——18', N'<p>
	分页测试&mdash;&mdash;18</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 1, N'/news_image/140523062354559202.jpg', 4)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (9, N'ba169a32-64a7-4ece-b2f1-2e50c68d2f2a', N'测试配图+上首页+去前导空格', N'<p>
	测试配图+上首页+去前导空格</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33200000000 AS DateTime), 0, 1, N'/news_image/140523010743683957.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (16, N'60c24abd-28a7-4f90-97aa-38dc2a827797', N'分页测试——5', N'<p>
	分页测试&mdash;&mdash;5</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140523010743683957.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (22, N'9c81f841-e353-4f20-b2ab-399923ef570f', N'分页测试——11', N'<p>
	分页测试&mdash;&mdash;11</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (23, N'16c95c39-717e-4bac-8880-4317a93f6c06', N'分页测试——12', N'<p>
	分页测试&mdash;&mdash;12</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (27, N'f4956a02-b264-4b0f-b55f-452138b07ae4', N'分页测试——16', N'<p>
	分页测试&mdash;&mdash;16</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (11, N'ecc66600-c145-4a98-b47d-45a94026d1ce', N'无配图测试', N'<p>
	无配图测试</p>
', N'54eab900-b883-4597-b0f1-7513c96114df', CAST(0x0000A33200000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 1)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (13, N'863cf73b-9263-4c8d-8374-4db8adbe93ef', N'分页测试——2', N'<p>
	分页测试&mdash;&mdash;2</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (28, N'63cab10f-7107-4eb9-b1dc-53896d1df297', N'分页测试——17', N'<p>
	分页测试&mdash;&mdash;17</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (34, N'6aaa78db-1b0c-4d00-887d-59a180eb59c1', N'Test图片清除Cookie——有图', N'<p>
	test</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33400000000 AS DateTime), 0, 0, N'/news_image/140523064154442436.JPG', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (17, N'deb82fd6-cad2-4c8a-9b50-5a083451086f', N'分页测试——6', N'<p>
	分页测试&mdash;&mdash;6</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (8, N'9a7cdaa4-c67a-40b5-a787-5f9b14153bfd', N'测试去前导空格', N'<p>
	测试去前导空格</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33200000000 AS DateTime), 0, 0, N'/news_image/140521121046264576.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (35, N'3ae596ee-4080-4bf4-8ee0-739d66ebd423', N'Test图片清除Cookie——无图', N'<p>
	test1</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33400000000 AS DateTime), 0, 0, N'/news_image/140523064621686181.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (32, N'c3e6d267-17c5-4dda-877f-87115fc9b666', N'Test 图片Cookie', N'<p>
	test</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33400000000 AS DateTime), 0, 0, N'/news_image/140523063939012180.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (10, N'925d3e95-fba8-4d4c-adc9-977871c7a200', N'多管理员发表新闻测试', N'<p>
	多管理员发表新闻测试</p>
', N'54eab900-b883-4597-b0f1-7513c96114df', CAST(0x0000A33200000000 AS DateTime), 0, 1, N'/news_image/140521024140986561.jpg', 27)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (15, N'22a7e6af-81e0-463c-80b8-9874a729fa2c', N'分页测试——4', N'<p>
	分页测试&mdash;&mdash;4</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (19, N'508723b1-7569-4706-aca1-a22988dac19a', N'分页测试——8', N'<p>
	分页测试&mdash;&mdash;8</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (31, N'3c03121b-a882-46ed-8590-b30e3c982037', N'分页测试——20', N'<p>
	分页测试&mdash;&mdash;20</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (21, N'd375b99a-0b0e-4437-a398-b4bf75d29485', N'分页测试——10', N'<p>
	分页测试&mdash;&mdash;10</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (25, N'2466f7e6-6978-46d4-bb74-c0d04fc0b07b', N'分页测试——14', N'<p>
	分页测试&mdash;&mdash;14</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (36, N'adccf264-46a0-4742-8c96-c83f75c39b48', N'无图测试2', N'<p>
	无图测试2</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33400000000 AS DateTime), 0, 0, N'/news_image/140523064557817858.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (26, N'b7c28ed0-93ec-418e-9e79-cb2f91d7e73d', N'分页测试——15', N'<p>
	分页测试&mdash;&mdash;15</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (33, N'b363bfd2-6822-4656-a263-d283174c8ee4', N'Test 图片Cookie1', N'<p>
	test1</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33400000000 AS DateTime), 0, 0, N'/news_image/140523063939012180.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (12, N'0e8f6a7d-0c36-42a1-9d85-d6899eeacf5e', N'分页测试——1', N'<p>
	分页测试&mdash;&mdash;1</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (30, N'55bd650e-6b61-48d8-9a29-e2877f228c88', N'分页测试——19', N'<p>
	分页测试&mdash;&mdash;19</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
INSERT [dbo].[NEWS] ([n_id], [news_id], [news_title], [news_content], [news_author], [news_publish_date], [news_isDeleted], [news_isOnIndex], [news_image], [news_click_count]) VALUES (14, N'cf800f3d-482c-4d06-80a3-fa49da7149a3', N'分页测试——3', N'<p>
	分页测试&mdash;&mdash;3</p>
', N'695dc3e5-725b-46f8-b8af-aea976088a5e', CAST(0x0000A33300000000 AS DateTime), 0, 0, N'/news_image/140521024140986561.jpg', 0)
SET IDENTITY_INSERT [dbo].[NEWS] OFF
/****** Object:  Table [dbo].[ADMIN]    Script Date: 05/25/2014 21:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ADMIN](
	[a_id] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_id] [uniqueidentifier] NOT NULL,
	[admin_account] [char](64) NOT NULL,
	[admin_password] [char](32) NOT NULL,
	[admin_last_login_time] [datetime] NOT NULL,
	[admin_last_login_ip] [char](64) NOT NULL,
	[admin_nickname] [nvarchar](32) NOT NULL,
	[admin_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UN_ADMIN_ACCOUNT] UNIQUE NONCLUSTERED 
(
	[a_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一的管理员账户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ADMIN', @level2type=N'CONSTRAINT',@level2name=N'UN_ADMIN_ACCOUNT'
GO
SET IDENTITY_INSERT [dbo].[ADMIN] ON
INSERT [dbo].[ADMIN] ([a_id], [admin_id], [admin_account], [admin_password], [admin_last_login_time], [admin_last_login_ip], [admin_nickname]) VALUES (4, N'54eab900-b883-4597-b0f1-7513c96114df', N'0daydigger@gmail.com                                            ', N'2D993A6E55BF67EAF6432E09A36A0512', CAST(0x0000A33200000000 AS DateTime), N'127.0.0.1                                                       ', N'雾雨家的大小姐_不吉利的黑白')
INSERT [dbo].[ADMIN] ([a_id], [admin_id], [admin_account], [admin_password], [admin_last_login_time], [admin_last_login_ip], [admin_nickname]) VALUES (3, N'695dc3e5-725b-46f8-b8af-aea976088a5e', N'lyx5398@163.com                                                 ', N'2D993A6E55BF67EAF6432E09A36A0512', CAST(0x0000A335018B2A2D AS DateTime), N'127.0.0.1                                                       ', N'狡猾的欺诈师_因幡帝             ')
SET IDENTITY_INSERT [dbo].[ADMIN] OFF
/****** Object:  Table [dbo].[COURSE]    Script Date: 05/25/2014 21:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COURSE](
	[c_id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[course_id] [uniqueidentifier] NOT NULL,
	[course_name] [nvarchar](256) NOT NULL,
	[course_intro] [text] NOT NULL,
	[course_price] [float] NOT NULL,
	[course_robot_link] [varchar](256) NOT NULL,
	[course_begin_date] [datetime] NOT NULL,
	[course_isDeleted] [bit] NOT NULL,
	[course_timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_COURSE] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[COURSE] ON
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (1, N'00000000-0000-0000-0000-000000000000', N'Saber酱教你学日语', N'<p>
	<img alt="" src="../news_image/140523115839835380.jpg" style="width: 736px; height: 394px;" /></p>
<p>
	That&#39;s it!</p>
', 10, N'test.aspx', CAST(0x0000A33400000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (14, N'dcc901c4-21e4-4dac-9dc2-0b29293f80b7', N'课程测试分页6', N'<p>
	课程测试分页6</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (9, N'10633364-0598-4ab8-bf37-234a82c7bbc7', N'课程测试分页1', N'<p>
	课程测试分页1</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (17, N'7078b926-7d9f-4a11-8f67-2d8fe6b8171d', N'课程测试分页0', N'<p>
	课程测试分页0</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 1)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (15, N'bf94e1c7-f1e7-4c60-b0ff-6982a89ca771', N'课程测试分页7', N'<p>
	课程测试分页7</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (6, N'ae390892-928f-4c1e-9d3d-b57824fd855d', N'某科学的电磁炮日语教室', N'<p>
	<span style="background-color:#ffff00;">炮姐来了，就是这样。</span></p>
', 20.05, N'Misakamikoto.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (13, N'3eddee1f-f73e-4769-af8d-b90fe34a25bd', N'课程测试分页5', N'<p>
	课程测试分页5</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (16, N'6d4623b5-18a0-47e9-8d1e-bd185ae683ba', N'课程测试分页8', N'<p>
	课程测试分页8</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (7, N'ec12d882-b6d5-4eb2-81e9-be5a1bd27702', N'圣杯战争——远坂凛的逆袭', N'<p>
	<span style="background-color:#ffff00;">傲娇的大小姐，御三家之一来了。</span></p>
', 10.09, N'tousakarinn.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (18, N'08f134bc-e4b3-48dc-b18b-be5e6de89c86', N'列表分页测试1', N'<p>
	列表分页测试</p>
', 20, N'test.aspx', CAST(0x0000A336000324AB AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (10, N'a51f3c0d-8b5a-4049-9b39-dd72ac2f8805', N'课程测试分页2', N'<p>
	课程测试分页2</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (11, N'7a04f3c7-0e37-4014-a750-e038bcc8467c', N'课程测试分页3', N'<p>
	课程测试分页3</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 1)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (12, N'b7499a92-25e7-4520-a17a-e9083008c851', N'课程测试分页4', N'<p>
	课程测试分页4</p>
', 50, N'TestPage.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
INSERT [dbo].[COURSE] ([c_id], [course_id], [course_name], [course_intro], [course_price], [course_robot_link], [course_begin_date], [course_isDeleted]) VALUES (8, N'a2cf3c71-2309-4bad-be85-f0a931156668', N'⑨酱的日语教室', N'<p>
	<span style="background-color:#ffff00;">。&hellip;&hellip;这种课程会有人来上吗。</span></p>
', 0.01, N'kiruno.aspx', CAST(0x0000A33500000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[COURSE] OFF
/****** Object:  View [dbo].[UserCourseList]    Script Date: 05/25/2014 21:53:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserCourseList]
AS
SELECT     dbo.[ORDER].order_id, dbo.[ORDER].order_date, dbo.[ORDER].order_price, dbo.[ORDER].order_isPaid, dbo.[ORDER].order_user, dbo.[ORDER].order_course, 
                      dbo.COURSE.course_id, dbo.COURSE.course_name, dbo.COURSE.course_intro, dbo.COURSE.course_robot_link, dbo.COURSE.course_price, 
                      dbo.COURSE.course_begin_date, dbo.COURSE.course_isDeleted, dbo.[USER].user_id
FROM         dbo.[ORDER] INNER JOIN
                      dbo.[USER] ON dbo.[ORDER].order_user = dbo.[USER].user_id AND dbo.[ORDER].order_user = dbo.[USER].user_id INNER JOIN
                      dbo.COURSE ON dbo.[ORDER].order_course = dbo.COURSE.course_id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ORDER"
            Begin Extent = 
               Top = 6
               Left = 257
               Bottom = 125
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "COURSE"
            Begin Extent = 
               Top = 6
               Left = 465
               Bottom = 125
               Right = 646
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "USER"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserCourseList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserCourseList'
GO
/****** Object:  View [dbo].[AdminNewsList]    Script Date: 05/25/2014 21:53:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AdminNewsList]
AS
SELECT     dbo.ADMIN.admin_nickname, dbo.NEWS.news_id, dbo.NEWS.news_title, dbo.NEWS.news_publish_date, dbo.NEWS.news_isDeleted, dbo.NEWS.news_isOnIndex, 
                      dbo.NEWS.news_image, dbo.NEWS.news_click_count, dbo.NEWS.news_content, dbo.NEWS.news_author
FROM         dbo.ADMIN INNER JOIN
                      dbo.NEWS ON dbo.ADMIN.admin_id = dbo.NEWS.news_author
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ADMIN"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "NEWS"
            Begin Extent = 
               Top = 6
               Left = 270
               Bottom = 125
               Right = 451
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminNewsList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AdminNewsList'
GO
/****** Object:  StoredProcedure [dbo].[CreateNewOrder]    Script Date: 05/25/2014 21:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<YuXun-Lu>
-- Create date: <2014-5-24>
-- Description:	<删除订单用存储过程>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewOrder]
	-- Add the parameters for the stored procedure here
	@OrderPrice FLOAT,
	@OrderUser UNIQUEIDENTIFIER,
	@OrderCourse UNIQUEIDENTIFIER,
	@OrderIsPaid BINARY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- 一条出错整个回滚
	SET XACT_ABORT ON;
	-- 开事务
	BEGIN TRAN
	DECLARE @Result INT;
	SET @Result = 0;
		BEGIN TRY
			--首先插入一条新的订单记录
			INSERT INTO [ORDER]
			(order_id,ORDER_DATE,ORDER_PRICE,ORDER_ISPAID,ORDER_ISDELETED,ORDER_USER,ORDER_COURSE)
			 VALUES
			 (NEWID(),GETDATE(),@OrderPrice,@OrderIsPaid,0,@OrderUser,@OrderCourse);
			 
			--然后在对应用户账号里扣钱
			UPDATE [USER]
			SET user_money = user_money - @OrderPrice
			WHERE
				user_id = @OrderUser;
			COMMIT TRAN
			SET @Result = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK
			SET @Result = 0;
		END CATCH	
		RETURN @Result;
END
GO
/****** Object:  Check [CK_COURSE_PRICE]    Script Date: 05/25/2014 21:53:58 ******/
ALTER TABLE [dbo].[COURSE]  WITH CHECK ADD  CONSTRAINT [CK_COURSE_PRICE] CHECK  (([course_price]>=(0.0)))
GO
ALTER TABLE [dbo].[COURSE] CHECK CONSTRAINT [CK_COURSE_PRICE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程价格不小于0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COURSE', @level2type=N'CONSTRAINT',@level2name=N'CK_COURSE_PRICE'
GO
/****** Object:  Check [CK_ORDER_PRICE]    Script Date: 05/25/2014 21:53:58 ******/
ALTER TABLE [dbo].[ORDER]  WITH CHECK ADD  CONSTRAINT [CK_ORDER_PRICE] CHECK  (([order_price]>=(0)))
GO
ALTER TABLE [dbo].[ORDER] CHECK CONSTRAINT [CK_ORDER_PRICE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单价格不小于0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ORDER', @level2type=N'CONSTRAINT',@level2name=N'CK_ORDER_PRICE'
GO
/****** Object:  Check [CK_USER_MONEY]    Script Date: 05/25/2014 21:53:58 ******/
ALTER TABLE [dbo].[USER]  WITH CHECK ADD  CONSTRAINT [CK_USER_MONEY] CHECK  (([user_money]>=(0)))
GO
ALTER TABLE [dbo].[USER] CHECK CONSTRAINT [CK_USER_MONEY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户余额必须大于等于0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'USER', @level2type=N'CONSTRAINT',@level2name=N'CK_USER_MONEY'
GO
