CREATE TABLE [dbo].[Roles] (
    [email] NVARCHAR (30) NOT NULL,
    [role]  NVARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([email] ASC)
);
CREATE TABLE [dbo].[Categorie] (
    [IdCategorie] INT NOT NULL,
    [Categorie]  NVARCHAR (35) NULL,
    PRIMARY KEY CLUSTERED ([IdCategorie] ASC)
);

CREATE TABLE [dbo].[Users] (
    [IdUser]        INT           IDENTITY (1, 1) NOT NULL,
    [nomUser]       NVARCHAR (30) NOT NULL,
    [PrenomUser]    NVARCHAR (20) NULL,
    [sexe]          NCHAR (1)     NULL,
    [emailUser]     NVARCHAR (30) NOT NULL,
    [telephoneUser] NVARCHAR (15) NULL,
    [paysUser]      NVARCHAR (15) NULL,
    [villeUser]     NVARCHAR (20) NULL,
    [adresseUser]   NVARCHAR (50) NULL,
    [codePostal]    INT           NULL,
    [statusUser]    NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC)
);


CREATE TABLE [dbo].[Fournisseur] (
    [idFourn]          INT            IDENTITY (1, 1) NOT NULL,
    [nomFourn]         NVARCHAR (20)  NOT NULL,
    [descriptionFourn] NVARCHAR (MAX) NULL,
    [telephoneFourn]   VARCHAR (15)   NOT NULL,
    [paysFourn]        NVARCHAR (15)  NULL,
    [villeFourn]       NVARCHAR (20)  NULL,
    [adresseFourn]     NVARCHAR (50)  NULL,
    [codePostal]       INT            NULL,
    [emailFourn]       NVARCHAR (30)  NULL,
    [Statut]           INT DEFAULT((1))           NOT NULL,  
    PRIMARY KEY CLUSTERED ([idFourn] ASC)
);


CREATE TABLE [dbo].[Produit] (
    [idProd]          INT            IDENTITY (1, 1) NOT NULL,
    [nomProd]         NVARCHAR (15)  NOT NULL,
    [PrixProd]        FLOAT (53)     NULL,
    [statusProd]      NVARCHAR (10)  NULL,
    [UrlImage]        NVARCHAR (30)  NULL,
    [couleur]         NVARCHAR (10)  NULL,
    [capacite]        INT            NULL,
    [poids]           FLOAT (53)     NULL,
    [longeur]         FLOAT (53)     NULL,
    [largeur]         FLOAT (53)     NULL,
    [hauteur]         FLOAT (53)     NULL,
    [idFourn]         INT            NULL,
    [Idcategory]      INT            NULL,
    [descriptionProd] NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([idProd] ASC),
    FOREIGN KEY ([idFourn]) REFERENCES [dbo].[Fournisseur] ([idFourn]),
    FOREIGN KEY ([Idcategory]) REFERENCES [dbo].[Categorie] ([IdCategorie])

);


CREATE TABLE [dbo].[Avis] (
    [idAvis]     INT            NOT NULL,
    [idUser]     INT            NULL,
    [idProd]     INT            NULL,
    [note]       INT            NULL,
    [Date]       DATETIME       NULL,
    [texte]      NVARCHAR (100) NULL,
    [statusAvis] NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([idAvis] ASC),
    FOREIGN KEY ([idUser]) REFERENCES [dbo].[Users] ([IdUser]),
    FOREIGN KEY ([idProd]) REFERENCES [dbo].[Produit] ([idProd])
);


CREATE TABLE [dbo].[Commande] (
    [IdCommande]     INT           IDENTITY (1, 1) NOT NULL,
    [idUser]         INT           NOT NULL,
    [dateCommande]   DATETIME      NULL,
    [statusCommande] NVARCHAR (10) NULL,
    [PrixTotal]      REAL          NULL,
    PRIMARY KEY CLUSTERED ([IdCommande] ASC),
    FOREIGN KEY ([idUser]) REFERENCES [dbo].[Users] ([IdUser])
);


CREATE TABLE [dbo].[DetailCommande] (
    [idDetCom]   INT IDENTITY (1, 1) NOT NULL,
    [idCommande] INT NULL,
    [idProd]     INT NULL,
    [quantite]   INT NULL,
    PRIMARY KEY CLUSTERED ([idDetCom] ASC),
    FOREIGN KEY ([idCommande]) REFERENCES [dbo].[Commande] ([IdCommande]),
    FOREIGN KEY ([idProd]) REFERENCES [dbo].[Produit] ([idProd])
);


CREATE TABLE [dbo].[Facture] (
    [idFacture]     INT        IDENTITY (1, 1) NOT NULL,
    [idCommande]    INT        NOT NULL,
    [prixHT]        FLOAT (53) NULL,
    [prixTVA]       FLOAT (53) NULL,
    [prixLivraison] FLOAT (53) NULL,
    [dateFacture]   DATETIME   NULL,
    [prixTotal]     FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([idFacture] ASC),
    FOREIGN KEY ([idCommande]) REFERENCES [dbo].[Commande] ([IdCommande])
);

