USE [CadastroEmpresas]
GO

/****** Object:  StoredProcedure [dbo].[uspEmpresaBuscarPorNome]    Script Date: 24/08/2020 22:42:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEmpresaBuscarPorNome]
	@Nome varchar(100)

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
		Nome LIKE '%' + @Nome + '%'

END
GO

