CREATE PROCEDURE [dbo].[proc_DeletarEndereco]
	@Id int
AS
	DELETE FROM
		Endereco
	WHERE
		Id = @Id