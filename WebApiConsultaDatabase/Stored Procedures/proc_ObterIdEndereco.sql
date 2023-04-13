CREATE PROCEDURE [dbo].[proc_ObterIdEndereco]
	@Id int
AS
	SELECT
		Id,
		Rua,
		Bairro,
		Cidade,
		Cep,
		Id_Pessoa
	FROM
		Endereco
	WHERE
		Id = @Id