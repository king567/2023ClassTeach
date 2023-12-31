USE [DB15]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OttTypes]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OttTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_OttTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoGenres]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoGenres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaInfoId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_VideoGenres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoOttTypes]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoOttTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MediaInfoId] [int] NOT NULL,
	[OttTypeId] [int] NOT NULL,
 CONSTRAINT [PK_VideoOttTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaInfos]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](150) NULL,
	[OverView] [nvarchar](max) NULL,
	[ReleaseDate] [datetime] NULL,
	[Adult] [bit] NULL,
	[Popularity] [float] NULL,
	[OriginalLanguage] [nvarchar](50) NULL,
	[OriginalTitle] [nvarchar](255) NULL,
	[Video] [bit] NULL,
	[BackdropPath] [nvarchar](255) NULL,
	[PosterPath] [nvarchar](50) NULL,
 CONSTRAINT [PK_MediaInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[main]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[main]
AS
SELECT      dbo.Categories.Name AS Expr2, dbo.MediaInfos.Title, dbo.Genres.Name, 
                            dbo.OttTypes.Name AS Expr1
FROM           dbo.Categories INNER JOIN
                            dbo.MediaInfos ON dbo.Categories.Id = dbo.MediaInfos.Id INNER JOIN
                            dbo.VideoGenres ON dbo.MediaInfos.Id = dbo.VideoGenres.MediaInfoId INNER JOIN
                            dbo.Genres ON dbo.VideoGenres.GenreId = dbo.Genres.Id INNER JOIN
                            dbo.VideoOttTypes ON dbo.MediaInfos.Id = dbo.VideoOttTypes.MediaInfoId INNER JOIN
                            dbo.OttTypes ON dbo.VideoOttTypes.OttTypeId = dbo.OttTypes.Id
GO
/****** Object:  Table [dbo].[Popularitys]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Popularitys](
	[Id] [int] NOT NULL,
	[Rate] [float] NOT NULL,
	[MediaInfoId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/8/25 下午 04:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [nvarchar](250) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (1, N'TV', 10)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (2, N'Movie', 20)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (3, N'Anime', 30)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (12, N'Adventure')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (14, N'Fantasy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (16, N'Animation')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (18, N'Drama')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (27, N'Horror')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (28, N'Action')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (35, N'Comedy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (36, N'History')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (37, N'Western')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (53, N'Thriller')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (80, N'Crime')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (99, N'Documentary')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (878, N'Science Fiction')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (9648, N'Mystery')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10402, N'Music')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10749, N'Romance')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10751, N'Family')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10752, N'War')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (10770, N'TV Movie')
GO
SET IDENTITY_INSERT [dbo].[MediaInfos] ON 

INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (18, 2, N'巨齒鯊2：海溝深淵', N'《巨齒鯊2：海溝深淵》（英語：Meg 2: The Trench，中國大陸譯《巨齒鯊2：深淵》，香港譯《極悍巨鯊2：深溝》）是一部2023年美中合拍的科幻動作片，2018年電影《巨齒鯊》的續集，改編自史蒂夫·艾騰的《深海巨鯊：奪命海溝》一書。電影由班·懷特利執導，傑森·史塔森、吳京、蔡書雅、佩吉·甘迺迪、賽吉兒·佩里斯-曼切塔、絲凱樂·山繆斯、席安娜·蓋蘿莉和克利夫·柯蒂斯主演。劇情講述喬納斯·泰勒（Jonas Taylor，史塔森飾演）率領一支研究小組潛入未知水域的最深處進行探勘，但一場惡意的採礦作業造成他們的阻礙，眾人被迫捲入更加危險的爭鬥之中。

在第一部電影票房成功後，續集於2018年10月宣布進行開發，懷特利接替強·托特陶擔任導演，劇本由迪恩·喬蓋瑞斯（Dean Georgaris)、喬恩·霍伯 (Jon Hoeber) 、埃里希·霍伯 (Erich Hoeber) 和史蒂夫·艾騰於2019年完成。該片2022年2月至5月在亞洲多個地點和倫敦利維斯登工作室開始拍攝，主演陣容在此期間加入劇組。

《巨齒鯊2：海溝深淵》2023年6月9日在上海國際電影節進行全球首映，由華納兄弟定檔2023年8月4日在美國上映。口碑惡評居多。', CAST(N'2023-06-09T00:00:00.000' AS DateTime), 1, NULL, N'en', N'Meg 2: The Trench', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (19, 2, N'變形金剛：萬獸崛起', N'再度以精彩刺激的動作場面及氣勢磅薄的宏偉奇觀捕捉全球影迷的想像力，《變形金剛：萬獸崛起》一片將帶領觀眾回到1990年代，跟著博派變形金剛展開一場橫跨全世界的冒險旅程，並且介紹一個全新品種的變形金剛－強大金剛－加入博派變形金剛與狂派變形金剛之間在地球上的大戰。', CAST(N'2023-06-07T00:00:00.000' AS DateTime), 1, NULL, N'en', N'Transformers: Rise of the Beasts', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (20, 2, N'閃電俠', N'在《閃電俠》中，貝瑞使用超能力回到過去，想要改變已發生的事件，卻衝擊了時空秩序。當貝瑞試圖拯救家人時，不小心改變了未來，使他受困於另一個時空中；在這個時空中，回歸的薩德將軍正威脅著毀滅世界，但卻沒有超級英雄可以求助，除非貝瑞能說服一位退休的蝙蝠俠重現江湖，解救一位被監禁的氪星人……儘管他可能找錯了人。到頭來，貝瑞為了拯救他所在的世界，返回他所知的未來，唯一的希望就是用盡生命賽跑，但他最後做出的犧牲足以拯救整個宇宙嗎？', CAST(N'2023-06-14T00:00:00.000' AS DateTime), 1, NULL, N'en', N'The Flash', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (21, 2, N'Barbie芭比', N'芭比（瑪格羅比 飾演）在一個完美的地方過著完美的人生，會舉辦超級盛大的派對，有華麗音樂及排舞，每天都過著很棒的日子。但有一天怪事開始發生在芭比身上，她的洗澡水不熱，會從屋頂跌落，甚至發現她的腳跟竟然貼地了，變成扁平足。之後她決定與肯尼（萊恩葛斯林 飾演）進入真實世界，去探索事情的真相，並且引發一連串的意外事件。', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 0, NULL, N'en', N'Barbie', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (22, 2, N'鬼打牆', N'男孩彼得（伍迪諾曼 飾）為臥室牆壁裡不斷發出的神祕敲打聲感到困擾，但他的爸爸馬克（安東尼史塔 飾）和媽媽卡蘿（麗茲凱普蘭 飾）都堅稱那只是他的想像，父母的反應讓彼得開始懷疑他們是否有什麼不可告人的祕密……。

', CAST(N'2023-07-28T00:00:00.000' AS DateTime), 1, NULL, N'en', N'Cobweb', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (23, 1, N'法網遊龍', N'每一集影集內容不乏根據真實案件和時事頭條新聞改編的事件內容。每集都由警方偵查開啟序幕，庭上偵訊作結收場。

', CAST(N'1990-01-01T00:00:00.000' AS DateTime), 1, NULL, N'en', N'Law & Order', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (24, 1, N'戀愛島 美國版', N'American version of the British dating reality competition in which ten singles come to stay in a villa for a few weeks and have to couple up with one another. Over the course of those weeks, they face the public vote and might be eliminated from the show. Other islanders join and try to break up the couples.

', CAST(N'2019-01-01T00:00:00.000' AS DateTime), 1, NULL, N'en', N'Love Island', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (25, 3, N'辛普森家庭', N'辛普森一家是居住在美國「心臟地帶」類型的小鎮內糊的一個典型家庭。家中的父親荷馬擔任著內糊核電站的安全檢查員——這個職位與他粗心、弄臣式的個性顯得很不相稱。他的妻子瑪姬·辛普森，是一位典型的美國式主婦和母親。他們有著三個孩子：十歲的大兒子巴特是一個麻煩製造者；八歲早熟的女兒麗莎是一位積極行動主義者；小女兒麥姬是一個幾乎不會說話，只能用吸橡皮奶嘴進行交流的嬰兒。這家人養有一條名叫勇哥的狗，以及一隻名叫雪球二世的貓。兩隻寵物都曾在幾集動畫中充當中心角色。儘管度過了許多次節日或生日這樣的年度重要事件，辛普森一家人都沒有因為真實歲月的流逝而逐漸老去，其面貌與他們在1980年代末露面時並無二樣。

《辛普森家庭》有許多怪僻的次要角色：同事、老師、親朋好友、地方名人。格朗寧起初只是打算讓這些角色出現一次，讓他們充當笑料製造者，或用來填補小鎮需要的一些功能。不過，大部分的這些角色後來都被保留了下來，其形象也得到擴充，甚至不少角色在後來還成為了幾集動畫的中心人物。', CAST(N'1989-01-01T00:00:00.000' AS DateTime), 1, NULL, N'en', N'The Simpsons

', 1, NULL, NULL)
INSERT [dbo].[MediaInfos] ([Id], [CategoryId], [Title], [OverView], [ReleaseDate], [Adult], [Popularity], [OriginalLanguage], [OriginalTitle], [Video], [BackdropPath], [PosterPath]) VALUES (26, 1, N'無照律師', N'Mike Ross，一位誤入歧途的大學輟學生，為了給重病中的祖母提供更好的看護服務挺而走險。偶然遇見了知名律師事務所的王牌律師Harvey Specter。Harvey從這個年輕人身上看到了自己的影子。所以儘管Mike沒有法學學歷及律師執照，Harvey仍決定冒險雇用Mike為自己的助理律師。在這個工作壓力極大，競爭極為激烈的事務所中，要如何守住Mike的秘密？兩個處境截然不同，卻又性情相投的人之間又會擦出怎樣的火花呢？

', CAST(N'2011-01-01T00:00:00.000' AS DateTime), 0, NULL, N'en', N'Suits', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MediaInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[OttTypes] ON 

INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (1, N'Netflix', 10)
INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (2, N'HBO', 20)
INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (3, N'Disney', 30)
INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (4, N'LiTV', 40)
INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (5, N'MyVideo', 40)
INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (6, N'friDay', 50)
INSERT [dbo].[OttTypes] ([Id], [Name], [DisplayOrder]) VALUES (7, N'LINE TV', 60)
SET IDENTITY_INSERT [dbo].[OttTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (1, N'test', N'123', N'123@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (2, N'king', N'123', N'fas@gmail.com', 0)
INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (3, N'GJGJ', N'123', N'aoas@gmail.com', 1)
INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (4, N'asf', N'asf', N'asfaf', 1)
INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (5, N'hbo', N'hbo', N'hbo', 1)
INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (6, N'asfasfasfsa', N'asfasf', N'asfsaf', 1)
INSERT [dbo].[Users] ([Id], [Account], [Password], [Email], [Enabled]) VALUES (7, N'asfsaf', N'ggasa', N'asgas', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoGenres] ON 

INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (97, 18, 12)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (98, 18, 53)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (99, 19, 12)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (100, 19, 27)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (101, 20, 12)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (102, 20, 10751)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (103, 20, 10752)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (107, 21, 12)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (108, 21, 14)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (109, 21, 10402)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (110, 22, 16)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (111, 22, 27)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (112, 22, 10751)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (113, 23, 12)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (114, 23, 18)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (115, 23, 27)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (116, 24, 99)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (117, 24, 9648)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (118, 24, 10770)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (119, 25, 14)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (120, 25, 878)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (181, 26, 18)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (182, 26, 35)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (183, 26, 10402)
INSERT [dbo].[VideoGenres] ([Id], [MediaInfoId], [GenreId]) VALUES (184, 26, 10751)
SET IDENTITY_INSERT [dbo].[VideoGenres] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoOttTypes] ON 

INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (43, 18, 1)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (44, 18, 3)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (45, 19, 2)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (46, 19, 3)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (47, 20, 1)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (48, 20, 5)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (49, 21, 2)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (50, 21, 5)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (51, 22, 2)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (52, 22, 4)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (53, 23, 6)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (54, 24, 1)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (55, 24, 3)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (56, 25, 1)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (57, 25, 5)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (69, 26, 1)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (70, 26, 4)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (71, 26, 6)
INSERT [dbo].[VideoOttTypes] ([Id], [MediaInfoId], [OttTypeId]) VALUES (72, 26, 7)
SET IDENTITY_INSERT [dbo].[VideoOttTypes] OFF
GO
ALTER TABLE [dbo].[MediaInfos] ADD  CONSTRAINT [DF_MediaInfos_ReleaseDate]  DEFAULT (getdate()) FOR [ReleaseDate]
GO
ALTER TABLE [dbo].[MediaInfos] ADD  CONSTRAINT [DF_MediaInfos_Adult]  DEFAULT ((0)) FOR [Adult]
GO
ALTER TABLE [dbo].[MediaInfos] ADD  CONSTRAINT [DF_MediaInfos_Video]  DEFAULT ((1)) FOR [Video]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Categories]  WITH NOCHECK ADD  CONSTRAINT [FK_Categories_MediaInfos] FOREIGN KEY([Id])
REFERENCES [dbo].[MediaInfos] ([Id])
GO
ALTER TABLE [dbo].[Categories] NOCHECK CONSTRAINT [FK_Categories_MediaInfos]
GO
ALTER TABLE [dbo].[VideoGenres]  WITH CHECK ADD  CONSTRAINT [FK_VideoGenres_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[VideoGenres] CHECK CONSTRAINT [FK_VideoGenres_Genres]
GO
ALTER TABLE [dbo].[VideoGenres]  WITH CHECK ADD  CONSTRAINT [FK_VideoGenres_MediaInfos] FOREIGN KEY([MediaInfoId])
REFERENCES [dbo].[MediaInfos] ([Id])
GO
ALTER TABLE [dbo].[VideoGenres] CHECK CONSTRAINT [FK_VideoGenres_MediaInfos]
GO
ALTER TABLE [dbo].[VideoOttTypes]  WITH CHECK ADD  CONSTRAINT [FK_VideoOttTypes_MediaInfos] FOREIGN KEY([MediaInfoId])
REFERENCES [dbo].[MediaInfos] ([Id])
GO
ALTER TABLE [dbo].[VideoOttTypes] CHECK CONSTRAINT [FK_VideoOttTypes_MediaInfos]
GO
ALTER TABLE [dbo].[VideoOttTypes]  WITH CHECK ADD  CONSTRAINT [FK_VideoOttTypes_OttTypes] FOREIGN KEY([OttTypeId])
REFERENCES [dbo].[OttTypes] ([Id])
GO
ALTER TABLE [dbo].[VideoOttTypes] CHECK CONSTRAINT [FK_VideoOttTypes_OttTypes]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[56] 4[5] 2[19] 3) )"
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
         Begin Table = "Categories"
            Begin Extent = 
               Top = 49
               Left = 350
               Bottom = 162
               Right = 515
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MediaInfos"
            Begin Extent = 
               Top = 50
               Left = 52
               Bottom = 180
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VideoGenres"
            Begin Extent = 
               Top = 174
               Left = 351
               Bottom = 287
               Right = 516
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Genres"
            Begin Extent = 
               Top = 178
               Left = 564
               Bottom = 274
               Right = 729
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VideoOttTypes"
            Begin Extent = 
               Top = 301
               Left = 352
               Bottom = 414
               Right = 517
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OttTypes"
            Begin Extent = 
               Top = 300
               Left = 563
               Bottom = 413
               Right = 728
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
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'main'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
         Or = 1935
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'main'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'main'
GO
