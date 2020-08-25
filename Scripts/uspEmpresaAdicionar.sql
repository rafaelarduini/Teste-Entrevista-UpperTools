USE [CadastroEmpresas]
GO

/****** Object:  StoredProcedure [dbo].[uspEmpresaAdicionar]    Script Date: 24/08/2020 22:40:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEmpresaAdicionar]
	@CNPJ varchar(100),
	@Nome varchar(100),
	@AtividadePrincipal varchar(MAX),
	@DataSituacao varchar(100),
	@Tipo varchar(100),
	@Situacao varchar(100),
	@Logradouro varchar(100),
	@Numero varchar(100),
	@Bairro varchar(100),
	@CEP varchar(100),
	@Municipio varchar(100),
	@UF varchar(100),
	@Telefone varchar(100),
	@AtividadesSecundarias varchar(MAX),
	@Porte varchar(100),
	@DataAbertura varchar(100),
	@NaturezaJuridica varchar(100),
	@NomeFantasia varchar(100),
	@Complemento varchar(100),
	@Email varchar(100),
	@Efr varchar(100),
	@MotivoSituacao varchar(100),
	@SituacaoEspecial varchar(100),
	@DataSituacaoEspecial varchar(100),
	@CapitalSocial decimal(18,0),
	@UltimaAtualizacao varchar(100),
	@Qsa varchar(MAX)
AS
BEGIN

	INSERT INTO tblEmpresas
	(
		CNPJ,
		Nome,
		AtividadePrincipal,
		DataSituacao,
		Tipo,
		Situacao,
		Logradouro,
		Numero,
		Bairro,
		CEP,
		Municipio,
		UF,
		Telefone,
		AtividadesSecundarias,
		Porte,
		DataAbertura,
		NaturezaJuridica,
		NomeFantasia,
		Complemento,
		Email,
		Efr,
		MotivoSituacao,
		SituacaoEspecial,
		DataSituacaoEspecial,
		CapitalSocial,
		UltimaAtualizacao,
		Qsa
	)
	VALUES
	(
		@CNPJ,
		@Nome,
		@AtividadePrincipal,
		@DataSituacao,
		@Tipo,
		@Situacao,
		@Logradouro,
		@Numero,
		@Bairro,
		@CEP,
		@Municipio,
		@UF,
		@Telefone,
		@AtividadesSecundarias,
		@Porte,
		@DataAbertura,
		@NaturezaJuridica,
		@NomeFantasia,
		@Complemento,
		@Email,
		@Efr,
		@MotivoSituacao,
		@SituacaoEspecial,
		@DataSituacaoEspecial,
		@CapitalSocial,
		@UltimaAtualizacao,
		@Qsa
	)

	SELECT @Nome AS Retorno

END
GO

