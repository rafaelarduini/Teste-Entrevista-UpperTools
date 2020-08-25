USE [CadastroEmpresas]
GO

/****** Object:  Table [dbo].[tblEmpresas]    Script Date: 24/08/2020 22:40:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEmpresas](
	[CNPJ] [nvarchar](100) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[AtividadePrincipal] [nvarchar](max) NULL,
	[DataSituacao] [nvarchar](100) NULL,
	[Tipo] [nvarchar](100) NULL,
	[Situacao] [nvarchar](100) NULL,
	[Logradouro] [nvarchar](100) NULL,
	[Numero] [nvarchar](100) NULL,
	[Bairro] [nvarchar](100) NULL,
	[CEP] [nvarchar](100) NULL,
	[Municipio] [nvarchar](100) NULL,
	[UF] [nvarchar](100) NULL,
	[Telefone] [nvarchar](100) NULL,
	[AtividadesSecundarias] [nvarchar](max) NULL,
	[Porte] [nvarchar](100) NULL,
	[DataAbertura] [nvarchar](100) NULL,
	[NaturezaJuridica] [nvarchar](100) NULL,
	[NomeFantasia] [nvarchar](100) NULL,
	[Complemento] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Efr] [nvarchar](100) NULL,
	[MotivoSituacao] [nvarchar](100) NULL,
	[SituacaoEspecial] [nvarchar](100) NULL,
	[DataSituacaoEspecial] [nvarchar](100) NULL,
	[CapitalSocial] [decimal](18, 0) NULL,
	[UltimaAtualizacao] [nvarchar](100) NULL,
	[Qsa] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblEmpresas] PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

