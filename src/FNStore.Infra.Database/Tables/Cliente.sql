﻿CREATE TABLE [dbo].[Cliente]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Nome] VARCHAR(100) NOT NULL, 
    [Endereco] VARCHAR(300) NOT NULL, 
    [DataCadastro] DATETIME NOT NULL

	CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED ([Id] ASC),
)
