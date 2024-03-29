USE [F:\DEVELOPPEMENT\FORMATIONS\C#\GK\PROJET-GK\TIRELIRE\TIRELIRE\APPLICATIONTIRELIRE\APP_DATA\BDDTIRELIRE.MDF]
GO
/****** Object:  Table [dbo].[Avis]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avis](
	[idAvis] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NULL,
	[idProd] [int] NULL,
	[note] [int] NULL,
	[Date] [datetime] NULL,
	[texte] [nvarchar](100) NULL,
	[statusAvis] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAvis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[IdCategorie] [int] IDENTITY(1,1) NOT NULL,
	[Categorie] [nvarchar](35) NULL,
	[UrlImage] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commande]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commande](
	[IdCommande] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[dateCommande] [datetime] NULL,
	[statusCommande] [int] NULL,
	[PrixTotal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCommande] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailCommande]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailCommande](
	[idDetCom] [int] IDENTITY(1,1) NOT NULL,
	[idCommande] [int] NULL,
	[idProd] [int] NULL,
	[quantite] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetCom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facture]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facture](
	[idFacture] [int] IDENTITY(1,1) NOT NULL,
	[idCommande] [int] NOT NULL,
	[prixHT] [float] NULL,
	[prixTVA] [float] NULL,
	[prixLivraison] [float] NULL,
	[dateFacture] [datetime] NULL,
	[prixTotal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[idFacture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fournisseur]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fournisseur](
	[idFourn] [int] IDENTITY(1,1) NOT NULL,
	[nomFourn] [nvarchar](30) NOT NULL,
	[descriptionFourn] [nvarchar](max) NULL,
	[telephoneFourn] [varchar](15) NOT NULL,
	[paysFourn] [nvarchar](15) NULL,
	[villeFourn] [nvarchar](20) NULL,
	[adresseFourn] [nvarchar](50) NULL,
	[codePostal] [int] NULL,
	[emailFourn] [nvarchar](30) NULL,
	[Statut] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idFourn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produit]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produit](
	[idProd] [int] IDENTITY(1,1) NOT NULL,
	[nomProd] [nvarchar](50) NOT NULL,
	[PrixProd] [float] NULL,
	[statusProd] [int] NULL,
	[UrlImage] [nvarchar](100) NULL,
	[couleur] [nvarchar](50) NULL,
	[capacite] [int] NULL,
	[poids] [float] NULL,
	[longeur] [float] NULL,
	[largeur] [float] NULL,
	[hauteur] [float] NULL,
	[idFourn] [int] NULL,
	[Idcategorie] [int] NULL,
	[descriptionProd] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[RoleAttribut] [nvarchar](15) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/02/2020 11:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[nomUser] [nvarchar](30) NOT NULL,
	[PrenomUser] [nvarchar](20) NULL,
	[sexe] [nchar](1) NULL,
	[emailUser] [nvarchar](30) NULL,
	[telephoneUser] [nvarchar](15) NULL,
	[paysUser] [nvarchar](15) NULL,
	[villeUser] [nvarchar](20) NULL,
	[adresseUser] [nvarchar](50) NULL,
	[codePostal] [int] NULL,
	[statusUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fournisseur] ADD  DEFAULT ((1)) FOR [Statut]
GO
ALTER TABLE [dbo].[Avis]  WITH CHECK ADD FOREIGN KEY([idProd])
REFERENCES [dbo].[Produit] ([idProd])
GO
ALTER TABLE [dbo].[Avis]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[Commande]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[DetailCommande]  WITH CHECK ADD FOREIGN KEY([idCommande])
REFERENCES [dbo].[Commande] ([IdCommande])
GO
ALTER TABLE [dbo].[DetailCommande]  WITH CHECK ADD FOREIGN KEY([idProd])
REFERENCES [dbo].[Produit] ([idProd])
GO
ALTER TABLE [dbo].[Facture]  WITH CHECK ADD FOREIGN KEY([idCommande])
REFERENCES [dbo].[Commande] ([IdCommande])
GO
ALTER TABLE [dbo].[Produit]  WITH CHECK ADD FOREIGN KEY([Idcategorie])
REFERENCES [dbo].[Categorie] ([IdCategorie])
GO
ALTER TABLE [dbo].[Produit]  WITH CHECK ADD FOREIGN KEY([idFourn])
REFERENCES [dbo].[Fournisseur] ([idFourn])
GO
