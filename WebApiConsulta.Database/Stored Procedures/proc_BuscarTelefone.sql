
CREATE PROCEDURE [proc_BuscarTelefone]
AS
	SELECT
		Id_Pessoa,
		Residencial,
		Celular,
		Comercial
	FROM 
		Telefone
	--WHERE 
	--	Id_Pessoa = @idPessoa
	--ORDER BY
	--	Id_Pessoa;

