USE [CadastroEmpresas]
GO

/****** Object:  StoredProcedure [dbo].[uspEmpresaExcluir]    Script Date: 24/08/2020 22:42:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEmpresaExcluir]
	@CNPJ NVARCHAR(100)
AS
BEGIN

	DELETE FROM
		tblEmpresas
	WHERE
		CNPJ = @CNPJ

	SELECT @CNPJ AS Retorno

END
GO

