CREATE PROCEDURE [proc_BuscarEndereco]
AS
	SELECT
		Id_Pessoa,
		Rua,
		Bairro,
		Cidade,
		Cep
	FROM 
		Endereco;
