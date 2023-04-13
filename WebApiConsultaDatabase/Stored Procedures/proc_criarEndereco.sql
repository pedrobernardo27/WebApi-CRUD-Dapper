CREATE PROCEDURE [dbo].[proc_CriarEndereco]
	@Rua varchar (100),
	@Bairro varchar (100),
	@Cidade varchar (100),
	@Cep char (11),
	@Id_Pessoa int
AS
	INSERT INTO [dbo].[Endereco]
           ([Rua]
           ,[Bairro]
           ,[cidade]
           ,[Cep]
           ,[Id_Pessoa])
     VALUES
           (@Rua,
           @Bairro,
           @Cidade,
           @Cep,
           @Id_Pessoa);
