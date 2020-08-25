USE [CadastroEmpresas]
GO

/****** Object:  StoredProcedure [dbo].[uspEmpresaBuscarPorCNPJ]    Script Date: 24/08/2020 22:41:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEmpresaBuscarPorCNPJ]
	@CNPJ varchar(100)

AS
BEGIN

	SELECT
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
	FROM
		tblEmpresas
	WHERE
		CNPJ LIKE '%' + @CNPJ + '%'

END
GO

