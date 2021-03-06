USE [db_partyon_sqlsrv]
GO
/****** Object:  Table [dbo].[Asistente]    Script Date: 10/12/2018 8:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[EventoId] [int] NULL,
	[Asistente] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/12/2018 8:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 10/12/2018 8:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[EventoId] [int] NULL,
	[comentario] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 10/12/2018 8:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Evento] [varchar](100) NULL,
	[Descripcion_Evento] [nvarchar](max) NULL,
	[UsuarioId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[FechaInicioEvento] [datetime] NULL,
	[HoraEvento] [varchar](100) NULL,
	[Direccion_Evento] [varchar](100) NULL,
	[Imagen] [varchar](100) NULL,
	[Estado_Evento] [bit] NULL,
	[latitud] [varchar](100) NULL,
	[longitud] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favoritos]    Script Date: 10/12/2018 8:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favoritos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NULL,
	[EventoId] [int] NULL,
	[favorito] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/12/2018 8:40:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuario] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Telefono] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[FechaRegistro] [datetime] NULL,
	[Imagen] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asistente] ON 

INSERT [dbo].[Asistente] ([Id], [UsuarioId], [EventoId], [Asistente]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Asistente] ([Id], [UsuarioId], [EventoId], [Asistente]) VALUES (2, 1, 1, 1)
INSERT [dbo].[Asistente] ([Id], [UsuarioId], [EventoId], [Asistente]) VALUES (3, 1, 1, 1)
INSERT [dbo].[Asistente] ([Id], [UsuarioId], [EventoId], [Asistente]) VALUES (4, 2, 1, 1)
INSERT [dbo].[Asistente] ([Id], [UsuarioId], [EventoId], [Asistente]) VALUES (5, 3, 1, 1)
INSERT [dbo].[Asistente] ([Id], [UsuarioId], [EventoId], [Asistente]) VALUES (6, 9, 1, 1)
SET IDENTITY_INSERT [dbo].[Asistente] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Fiestas', N'Fiestas', 1)
INSERT [dbo].[Categoria] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Musica', N'Musica', 1)
INSERT [dbo].[Categoria] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (3, N'Gastronomia', N'Gastronomia', 1)
INSERT [dbo].[Categoria] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (4, N'Cultural', N'Cultural', 1)
INSERT [dbo].[Categoria] ([Id], [Nombre], [Descripcion], [Estado]) VALUES (5, N'Otro', N'Otros Eventos', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Comentario] ON 

INSERT [dbo].[Comentario] ([Id], [UsuarioId], [EventoId], [comentario]) VALUES (1, 1, 1, N'comentario evento 1')
SET IDENTITY_INSERT [dbo].[Comentario] OFF
SET IDENTITY_INSERT [dbo].[Evento] ON 

INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1, N'Musica Electronica', N'Evento de Musica Electronica Organizado por SONIK Music Trae a los mas rankeados ', 3, 2, CAST(N'2018-06-16T00:00:00.000' AS DateTime), N'09:49', N'Urb. Viacava C-4, 23001, Perú', N'_1.PNG', 1, N'-18.00375175309003', N'-70.24142466610107')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (2, N'Arte en Vivo', N'La casa LARAMAMANGO hace presente la primera muestra de Arte en vivo', 3, 5, CAST(N'2018-08-13T00:00:00.000' AS DateTime), N'06:00', N'Industrial 921, Tacna, Perú', N'_2.PNG', 1, N'-17.99877236876107', N'-70.24923525875244')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (3, N'Discoteca Titoz', N'Ven y disfruta de nuestros modernos ambientes y los mejores dj del momento.', 3, 1, CAST(N'2018-11-02T00:00:00.000' AS DateTime), N'10:00', N'Nieto 240, Tacna, Perú', N'_3.PNG', 1, N'-18.00505779783065', N'-70.22546015804443')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (13, N'La Posada', N'Claudio Urrutia en escena por primera vez en Tacna despues de su destacada..', 3, 2, CAST(N'2018-03-07T00:00:00.000' AS DateTime), N'09:00', N'Cajamarca a4, Tacna, Perú', N'_4.jpg', 1, N'-18.002649770314253', N'-70.23700438564452')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (14, N'D.I.E.T.R.I.C.H.', N'Festival Sadnes 2018 - Borgore - Fatima Hajji - Carl Cox', 3, 2, CAST(N'2018-11-17T00:00:00.000' AS DateTime), N'09:00', N'Hipolito Unanue 1041, Tacna, Perú', N'_img1.jpg', 1, N'-18.006241392518994', N'-70.25541506832275')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (15, N'Jeriko 25 años', N'Presentando temas de su proximo CD Bandas Invitadas :  Eclipse Final - Karkaman', 3, 2, CAST(N'2017-11-18T00:00:00.000' AS DateTime), N'09:00', N'8 De Sentiembre 1605, Tacna, Perú', N'_img2.jpg', 1, N'-18.012730615251645', N'-70.23408614223632')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (18, N'Dia del Amigo', N'Ven a festejar el día del amigo en la mejor discoteca del Sur del Perú.', 3, 1, CAST(N'2018-11-20T00:00:00.000' AS DateTime), N'09:00', N'Pje 14, Tacna, Perú', N'_img5.jpg', 1, N'-17.99452753667854', N'-70.23631774013671')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (19, N'Red Bull Batalla de Gallos', N'Muchos hablan pocos riman solo los mejores improvisan.', 3, 5, CAST(N'2018-11-16T00:00:00.000' AS DateTime), N'09:00', N'PE-40 1820, Tacna, Perú', N'_img6.jpg', 1, N'-17.98644574709143', N'-70.20859442775878')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (24, N'Presentacion Final Web 2', N'Evento donde seran aprobados todos mis alumnos', 7, 5, CAST(N'2018-10-31T00:00:00.000' AS DateTime), N'09:00', N'Capanique E-1, Tacna, Perú', N'_img1.jpg', 1, N'-18.005221052742893', N'-70.2246447665039')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1025, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-08-07T00:00:00.000' AS DateTime), N'07:00', N'Los Claveles, Tacna, Perú', N'_fiest11.jpg', 1, N'-18.0065679', N'-70.2462741')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1026, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-12-08T00:00:00.000' AS DateTime), N'07:59', N'Los Lirios 814, Tacna, Perú', N'_fiest10.jpg', 1, N'-18.000568228501308', N'-70.2627535921875')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1027, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-12-09T00:00:00.000' AS DateTime), N'06:59', N'Unnamed Road, Tacna, Perú', N'_surf12.jpeg', 1, N'-17.967260219350536', N'-70.22189818447265')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1028, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 5, CAST(N'2018-04-19T00:00:00.000' AS DateTime), N'10:00', N'L Flores Martorell 6013, Tacna, Perú', N'_cult10.jpg', 1, N'-18.00183348233601', N'-70.2318116289917')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1029, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 5, CAST(N'2018-03-17T00:00:00.000' AS DateTime), N'07:00', N'Calle El Mar, Tacna, Perú', N'_cult11.jpg', 1, N'-18.025154022549113', N'-70.23871608028463')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1030, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 5, CAST(N'2018-03-18T00:00:00.000' AS DateTime), N'17:59', N'Av. Jorge Basadre Grohmann Oeste 440, Tacna, Perú', N'_cult12.jpg', 1, N'-18.0122000588406', N'-70.26004992550048')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1031, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-12-16T00:00:00.000' AS DateTime), N'10:00', N'Gregorio Albarracin 25, Tacna, Perú', N'_gastro11.jpg', 1, N'-18.008139208793256', N'-70.25968514507446')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1032, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-08-20T00:00:00.000' AS DateTime), N'20:00', N'Av. Celestino Vargas 1820, Tacna, Perú', N'_gastro10.jpg', 1, N'-17.98628247480036', N'-70.21104060238036')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1033, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-12-21T00:00:00.000' AS DateTime), N'06:59', N'Tarapaca, Tacna, Perú', N'_cult13.jpg', 1, N'-17.98236389450198', N'-70.19456111019286')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1034, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 3, CAST(N'2018-02-15T00:00:00.000' AS DateTime), N'23:00', N'Aapitac zona b mz f lote 04, Tacna 23000, Perú', N'_cult12.jpg', 1, N'-17.986364110964782', N'-70.22674761837158')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1035, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 4, CAST(N'2018-08-23T00:00:00.000' AS DateTime), N'01:59', N'Av. Saucini S/N, Tacna, Perú', N'_cult11.jpg', 1, N'-18.007792297667205', N'-70.2587195498291')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1036, N'El evento mas esperado 2018', N'Uno de los evento mas esperados de todo el año, no te lo puedes perder variedad de emociones...', 4, 3, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'01:59', N'Calle Túpac Amaru 4, Tacna, Perú', N'_img4.jpg', 1, N'-17.995956097342305', N'-70.25833331173095')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1039, N'Prueba', N'sdsdsd', 4, 3, CAST(N'2018-06-06T00:00:00.000' AS DateTime), N'18:30', N'Bugambillas 281, Tacna, Perú', N'_cult10.jpg', 1, N'-17.998935629493193', N'-70.22322856014404')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1040, N'la fuiesta maldita1414', N'el evento se realiza en tal asdsadasd', 4, 4, CAST(N'2018-08-16T00:00:00.000' AS DateTime), N'20:01', N'Jose Caceres Vernal 820, Tacna, Perú', N'_surf12.jpeg', 1, N'-18.001670224286826', N'-70.2460595232788')
INSERT [dbo].[Evento] ([id], [Nombre_Evento], [Descripcion_Evento], [UsuarioId], [CategoriaId], [FechaInicioEvento], [HoraEvento], [Direccion_Evento], [Imagen], [Estado_Evento], [latitud], [longitud]) VALUES (1041, N'Evento Cultural', N'Evento cultural', 4, 4, CAST(N'2018-01-02T00:00:00.000' AS DateTime), N'09:00', N'Paz Soldan 560, Tacna, Perú', N'_img8.jpg', 1, N'-18.005425121170585', N'-70.25459967678222')
SET IDENTITY_INSERT [dbo].[Evento] OFF
SET IDENTITY_INSERT [dbo].[Favoritos] ON 

INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (4, 3, 3, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (5, 3, 3, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (14, 3, 13, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (15, 3, 14, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (16, 3, 15, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (1024, 0, 19, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (1025, 0, 2, 1)
INSERT [dbo].[Favoritos] ([id], [UsuarioId], [EventoId], [favorito]) VALUES (1029, 0, 20, 1)
SET IDENTITY_INSERT [dbo].[Favoritos] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (1, 2, N'nombre1', N'apellido1', N'123', N'gcalle', N'1000:hx4hnhTQDkUL3KrSKyHBq54SGTAH2cpF:N6eLPjufQ2HW0MVH2K5bx7aJSD6KszTP', CAST(N'2018-10-23T22:26:30.687' AS DateTime), N'default.jpg')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (2, 2, N'nombre2', N'apellido2', N'123', N'gary', N'1000:4YJAqN7kkFjKH6VygKwsxS6MCGgH3pFi:lu/FT7tSNcOolDYvG1YC+oNv7+PiwP28', CAST(N'2018-10-23T22:33:19.937' AS DateTime), N'default.jpg')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (3, 2, N'Gary', N'Calle', N'123', N'gcalle', N'1000:2LBnsK2qGoih5dM678ZXbf4bXKmN/qaM:BbHWtKUa76LN6wdzLgj4IYG/+wjPnlVQ', CAST(N'2018-10-25T09:12:10.123' AS DateTime), N'user.png')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (4, 2, N'pedrito', N'pedro', N'123', N'pedrito', N'1000:JoHy+cqFTGfS/A+XEHxfoxJ62r4w2xNR:SYr6+jWgvnFPBNWK7hzovvo6VRzXejXs', CAST(N'2018-10-26T10:09:31.613' AS DateTime), N'default.jpg')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (5, 2, N'christian@gmail.com', N'', N'', N'christian@gmail.com', N'1000:rd15NIPrHXLFxeBNm6DyEokTBee5P7Yu:VLFkSAeZH3+s+AQLbGD3cCK9HYT+mKip', CAST(N'2018-10-31T11:16:03.113' AS DateTime), N'Default.png')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (6, 2, N'Enrique', N'Lanchipa', N'952394482', N'elanchipa@gmail.com', N'1000:SiuAAZX+RNcOGPkKkV4YL5Yx4YvSIfhY:cZuXgpQrcGvxdBz5pyPiDUVv0jM7XZqD', CAST(N'2018-10-31T17:18:22.787' AS DateTime), N'default.jpg')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (7, 2, N'enriquelanchipa', N'', N'', N'enriquelanchipa', N'1000:NUrdH9OUfwteKFdRmF1CyOw+uIyQJDAT:u9c/aimJk5+bMvKI3W1nCXU08mANex9F', CAST(N'2018-10-31T19:06:11.643' AS DateTime), N'lanchipa.jpg')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (8, 2, N'mateo', N'', N'', N'mateo', N'1000:L/6FjMksxqdaXNQeW+92BUiRx0AvIm+7:HcYG9A8i4a5fFdIcjs6/C7JmvsJhr6q/', CAST(N'2018-11-14T17:06:31.703' AS DateTime), N'Default.png')
INSERT [dbo].[Usuario] ([Id], [TipoUsuario], [Nombre], [Apellido], [Telefono], [Email], [Password], [FechaRegistro], [Imagen]) VALUES (9, 2, N'rmoreno', N'', N'', N'rmoreno', N'1000:TbWc4u5bRqt3QM99zHbmevul/Pyh3zg3:8LjsJnzZJ+ISqzQTyndD23Be/RCWZkmi', CAST(N'2018-11-14T17:28:28.497' AS DateTime), N'Default.png')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
