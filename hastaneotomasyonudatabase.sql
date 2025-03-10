USE [HastaneOtomasyonu]
GO
/****** Object:  Table [dbo].[Tbl_Branslar]    Script Date: 5.01.2025 11:41:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Branslar](
	[BransId] [tinyint] IDENTITY(1,1) NOT NULL,
	[BransAd] [varchar](50) NULL,
 CONSTRAINT [PK__Tbl_Bran__D0E572EC29E2FA95] PRIMARY KEY CLUSTERED 
(
	[BransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Doktorlar]    Script Date: 5.01.2025 11:41:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Doktorlar](
	[DoktorId] [tinyint] IDENTITY(1,1) NOT NULL,
	[DoktorAd] [varchar](20) NULL,
	[DoktorSoyad] [varchar](20) NULL,
	[DoktorBrans] [varchar](30) NULL,
	[DoktorTc] [char](11) NULL,
	[DoktorSifre] [varchar](10) NULL,
 CONSTRAINT [PK__Tbl_Dokt__77AF86A1608E32D3] PRIMARY KEY CLUSTERED 
(
	[DoktorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Duyurular]    Script Date: 5.01.2025 11:41:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Duyurular](
	[DuyuruId] [smallint] IDENTITY(1,1) NOT NULL,
	[Duyuru] [varchar](250) NULL,
 CONSTRAINT [PK__Tbl_Duyu__98E5E028B619F11C] PRIMARY KEY CLUSTERED 
(
	[DuyuruId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Hastalar]    Script Date: 5.01.2025 11:41:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Hastalar](
	[HastaId] [smallint] IDENTITY(1,1) NOT NULL,
	[HastaAd] [varchar](20) NOT NULL,
	[HastaSoyad] [varchar](20) NOT NULL,
	[HastaTc] [char](11) NOT NULL,
	[HastaTelefon] [varchar](15) NULL,
	[HastaSifre] [varchar](10) NOT NULL,
	[HastaCinsiyet] [varchar](5) NULL,
 CONSTRAINT [PK__Tbl_Hast__114C5C8B2373C6F2] PRIMARY KEY CLUSTERED 
(
	[HastaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Randevular]    Script Date: 5.01.2025 11:41:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Randevular](
	[RandevuId] [int] IDENTITY(1,1) NOT NULL,
	[RandevuTarih] [varchar](15) NULL,
	[RandevuSaat] [varchar](7) NULL,
	[RandevuBrans] [varchar](30) NULL,
	[RandevuDoktor] [varchar](50) NULL,
	[RandevuDurum] [bit] NULL,
	[HastaTC] [char](11) NULL,
	[HastaSikayet] [varchar](200) NULL,
 CONSTRAINT [PK__Tbl_Rand__B795F34B02F9FA9C] PRIMARY KEY CLUSTERED 
(
	[RandevuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Sekreterler]    Script Date: 5.01.2025 11:41:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Sekreterler](
	[SekreterId] [tinyint] IDENTITY(1,1) NOT NULL,
	[SekreterAd_Soyad] [varchar](40) NULL,
	[SekreterTc] [char](11) NULL,
	[SekreterSifre] [varchar](10) NULL,
 CONSTRAINT [PK__Tbl_Sekr__9552D08E847E3C90] PRIMARY KEY CLUSTERED 
(
	[SekreterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Branslar] ON 

INSERT [dbo].[Tbl_Branslar] ([BransId], [BransAd]) VALUES (1, N'Dahiliye')
INSERT [dbo].[Tbl_Branslar] ([BransId], [BransAd]) VALUES (2, N'Göz')
INSERT [dbo].[Tbl_Branslar] ([BransId], [BransAd]) VALUES (3, N'KBB')
INSERT [dbo].[Tbl_Branslar] ([BransId], [BransAd]) VALUES (4, N'Fizik Tedavi ve Rehabilitasyon')
INSERT [dbo].[Tbl_Branslar] ([BransId], [BransAd]) VALUES (5, N'Cildiye')
INSERT [dbo].[Tbl_Branslar] ([BransId], [BransAd]) VALUES (6, N'Genel Cerrahi')
SET IDENTITY_INSERT [dbo].[Tbl_Branslar] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Doktorlar] ON 

INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (1, N'Mehmet', N'Çınar', N'Dahiliye', N'11111111112', N'1123')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (2, N'Ayşe ', N'Karahan', N'Göz', N'44444444444', N'1221')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (3, N'Veli', N'Gürbüz', N'Fizik Tedavi ve Rehabilitasyon', N'99999999999', N'2332')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (5, N'Faruk', N'Emel', N'Cildiye', N'45555555555', N'2299')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (6, N'Nihat', N'Necatisel', N'Genel Cerrahi', N'27777777777', N'7744')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (7, N'Nurullah', N'Selvi', N'Dahiliye', N'58888888888', N'3355')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (8, N'Cemal', N'Görçin', N'KBB', N'10000000000', N'6677')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (9, N'Zeyyen', N'Bulut', N'Göz', N'20000000000', N'5522')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (10, N'Fidan', N'Karakeskin', N'Genel Cerrahi', N'37777777777', N'7788')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (11, N'Ozan', N'Karaosman', N'Fizik Tedavi ve Rehabilitasyon', N'12399999999', N'99999')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (13, N'Ahsen', N'Atabeyli', N'Cildiye', N'77777777778', N'11888')
INSERT [dbo].[Tbl_Doktorlar] ([DoktorId], [DoktorAd], [DoktorSoyad], [DoktorBrans], [DoktorTc], [DoktorSifre]) VALUES (15, N'Agah', N'29', N'Fizik Tedavi ve Rehabilitasyon', N'99967890876', N'3456')
SET IDENTITY_INSERT [dbo].[Tbl_Doktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Duyurular] ON 

INSERT [dbo].[Tbl_Duyurular] ([DuyuruId], [Duyuru]) VALUES (1, N'Doktorlarımızın Dikkatine,

Bugün(6.12.2024) saat 15:30''da 2. toplantı odasında bulunmanız önem arz etmektedir.

Sağlıklı Günler.')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruId], [Duyuru]) VALUES (2, N'Doktorlarımızın Dikkatine,

Yeni giriş kimlikleri dağıtımı için bugün saat 12:00''de Al400 odasında imza atmanız gerekmektedir.

Sağlıklı günler dileriz.

Hastane Yönetimi')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruId], [Duyuru]) VALUES (3, N'Doktorlarımızın Dikkatine,

18.12.2024 tarihi yeni dönem sağlık belgelerinin son teslim tarihidir. Belirtilen tarihe kadar C200 odasına teslim etmeniz beklenmektedir.

Sağlıklı günler dileriz.

Hastane Yönetimi')
INSERT [dbo].[Tbl_Duyurular] ([DuyuruId], [Duyuru]) VALUES (4, N'Doktorlarımızın Dikkatine,
21.12.2024 tarihinde kalp damar cerrahi zirvesine katılım sağlayacak doktorlarımızın 20.12.2024 tarihine kadar kayıt oluşturması beklenmektedir.

Sağlıklı günler dileriz.

Hastane Yönetimi.')
SET IDENTITY_INSERT [dbo].[Tbl_Duyurular] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Hastalar] ON 

INSERT [dbo].[Tbl_Hastalar] ([HastaId], [HastaAd], [HastaSoyad], [HastaTc], [HastaTelefon], [HastaSifre], [HastaCinsiyet]) VALUES (1, N'Baran', N'Yücedağ', N'11111111111', N'(567) 895-3332', N'1111', N'Erkek')
INSERT [dbo].[Tbl_Hastalar] ([HastaId], [HastaAd], [HastaSoyad], [HastaTc], [HastaTelefon], [HastaSifre], [HastaCinsiyet]) VALUES (11, N'Fidan', N'Akyürek', N'98765432100', N'(567) 324-4568', N'2100', N'Kadın')
INSERT [dbo].[Tbl_Hastalar] ([HastaId], [HastaAd], [HastaSoyad], [HastaTc], [HastaTelefon], [HastaSifre], [HastaCinsiyet]) VALUES (12, N'Nedim', N'Karasakal', N'56789567890', N'(567) 435-6789', N'7890', N'Erkek')
SET IDENTITY_INSERT [dbo].[Tbl_Hastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Randevular] ON 

INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (1, N'10.12.2024', N'09:00', N'Fizik Tedavi ve Rehabilitasyon', N'Veli Gürbüz', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (2, N'10.12.2024', N'10:00', N'Fizik Tedavi ve Rehabilitasyon', N'Veli Gürbüz', 1, N'56789567890', N'Son zamanlarda sırt ağrısı yaşıyorum.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (3, N'10.12.2024', N'11:00', N'Fizik Tedavi ve Rehabilitasyon', N'Veli Gürbüz', 1, N'11111111111', N'Son zamanlarda sol dizimin arkasında bir dolgunluk ve ağrı hissediyorum')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (4, N'10.12.2024', N'12:00', N'Fizik Tedavi ve Rehabilitasyon', N'Veli Gürbüz', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (5, N'10.12.2024', N'09:00', N'KBB', N'Cemal Görçin', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (6, N'10.12.2024', N'10:00', N'KBB', N'Cemal Görçin', 1, N'11111111111', N'Son zamanlarda kulağımda bir çınlama var.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (7, N'10.12.2024', N'09:00', N'Cildiye', N'Faruk Emel', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (8, N'10.12.2024', N'10:00', N'Cildiye', N'Faruk Emel', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (9, N'10.12.2024', N'12:00', N'Cildiye', N'Faruk Emel', 1, N'11111111111', N'Son zamanlarda cildimde kuruluk var.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (10, N'10.12.2024', N'14:00', N'Cildiye', N'Faruk Emel', 1, N'98765432100', N'Son zamanlarda kendimi yorgun hissediyorum.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (11, N'10.12.2024', N'14:00', N'Cildiye', N'Ahsen Atabeyli', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (12, N'10.12.2024', N'15:00', N'Cildiye', N'Ahsen Atabeyli', 1, N'22222222222', N'Son zamanlarda ellerimde egzamalar çok arttı. Kremler kısa süreliğine etki ediyor.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (13, N'10.12.2024', N'15:30', N'Cildiye', N'Ahsen Atabeyli', 1, N'98765432100', N'Son zamanlarda cildimde kuruluk var.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (14, N'10.12.2024', N'11:00', N'Dahiliye', N'Nurullah Selvi', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (15, N'10.12.2024', N'13:00', N'Dahiliye', N'Nurullah Selvi', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (16, N'10.12.2024', N'13:00', N'Dahiliye', N'Mehmet Çınar', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (17, N'10.12.2024', N'14:00', N'Dahiliye', N'Mehmet Çınar', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (18, N'10.12.2024', N'15:00', N'Dahiliye', N'Mehmet Çınar', 1, N'98765432100', N'Son zamanlarda kendimi yorgun hissediyorum.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (19, N'10.12.2024', N'13:00', N'Genel Cerrahi', N'Nihat Necatisel', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (20, N'10.12.2024', N'13:45', N'Genel Cerrahi', N'Nihat Necatisel', 1, N'98765432100', N'Son zamanlarda kendimi iyi hissetmiyorum.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (21, N'10.12.2024', N'14:45', N'Genel Cerrahi', N'Nihat Necatisel', 1, N'11111111111', N'Son zamanlarda kendimi iyi hissetmiyorum.')
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (22, N'10.12.2024', N'15:15', N'Genel Cerrahi', N'Fidan Karakeskin', 0, NULL, NULL)
INSERT [dbo].[Tbl_Randevular] ([RandevuId], [RandevuTarih], [RandevuSaat], [RandevuBrans], [RandevuDoktor], [RandevuDurum], [HastaTC], [HastaSikayet]) VALUES (23, N'23.12.2024', N'12:00', N'Genel Cerrahi', N'Fidan Karakeskin', 1, N'56789567890', N'Son zamanlarda kendimi pek iyi hissetmiyorum.')
SET IDENTITY_INSERT [dbo].[Tbl_Randevular] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Sekreterler] ON 

INSERT [dbo].[Tbl_Sekreterler] ([SekreterId], [SekreterAd_Soyad], [SekreterTc], [SekreterSifre]) VALUES (1, N'Seda Karan', N'55555555555', N'5555')
INSERT [dbo].[Tbl_Sekreterler] ([SekreterId], [SekreterAd_Soyad], [SekreterTc], [SekreterSifre]) VALUES (2, N'Cemal Yeşilyurt', N'44444444444', N'4444')
INSERT [dbo].[Tbl_Sekreterler] ([SekreterId], [SekreterAd_Soyad], [SekreterTc], [SekreterSifre]) VALUES (3, N'Naci Şekerci', N'22222222222', N'2222')
INSERT [dbo].[Tbl_Sekreterler] ([SekreterId], [SekreterAd_Soyad], [SekreterTc], [SekreterSifre]) VALUES (4, N'Yurt Ataseven', N'77777777777', N'7777')
INSERT [dbo].[Tbl_Sekreterler] ([SekreterId], [SekreterAd_Soyad], [SekreterTc], [SekreterSifre]) VALUES (5, N'Nail Kurtbayır', N'33333333333', N'3333')
INSERT [dbo].[Tbl_Sekreterler] ([SekreterId], [SekreterAd_Soyad], [SekreterTc], [SekreterSifre]) VALUES (6, N'Yeşim Leylak', N'88888888888', N'8888')
SET IDENTITY_INSERT [dbo].[Tbl_Sekreterler] OFF
GO
ALTER TABLE [dbo].[Tbl_Randevular] ADD  CONSTRAINT [DF_Tbl_Randevular_RandevuDurum]  DEFAULT ((0)) FOR [RandevuDurum]
GO
