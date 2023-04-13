CREATE PROCEDURE [dbo].[proc_AtualizarEndereco]
	@Id int,
	@Rua varchar (100),
	@Bairro varchar (100),
	@Cidade varchar (100),
	@Cep char (11),
	@Id_Pessoa int
AS
	UPDATE 
        [dbo].[Endereco]
    SET Rua = @Rua,
        Bairro = @Bairro,
        Cidade = @Cidade,
        Cep = @Cep
	WHERE
		Id = @Id