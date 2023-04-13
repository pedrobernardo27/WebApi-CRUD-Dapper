CREATE PROCEDURE [dbo].[proc_BuscarEndereco]
AS
	SELECT
		Id,
		Rua,
		Bairro,
		Cidade,
		Cep,
		Id_Pessoa
	FROM 
		Endereco;