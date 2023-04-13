CREATE PROCEDURE [dbo].[proc_BuscarTelefone]
	@id INT
AS
	SELECT
		Id
		Residencial,
		Celular,
		Comercial,
		Id_Pessoa
	FROM 
		Telefone
	WHERE
		Id = @id;