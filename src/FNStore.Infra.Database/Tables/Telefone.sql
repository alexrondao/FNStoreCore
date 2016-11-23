CREATE TABLE [dbo].[Telefone]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Numero] VARCHAR(11) NOT NULL, 
	[ClienteId] UNIQUEIDENTIFIER NOT NULL, 
    [DataCadastro] DATETIME NOT NULL
	
    CONSTRAINT [PK_dbo.Telefone] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_dbo.Telefone.ClienteId] FOREIGN KEY([ClienteId]) REFERENCES [dbo].[Cliente](Id),
)
