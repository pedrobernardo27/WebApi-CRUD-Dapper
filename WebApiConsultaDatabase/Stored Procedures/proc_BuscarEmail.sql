CREATE PROCEDURE [dbo].[proc_BuscarEmail]
	@nome VARCHAR(15)
AS
	SELECT 
		Ema.Id_Pessoa,
		Pes.Nome,
		Pes.Sobrenome,
		Ema.Pessoal,
		Ema.Empresarial
	FROM
		Email Ema
		INNER JOIN Pessoa Pes ON PES.Id = Ema.Id_Pessoa
	WHERE
		Pes.Nome LIKE '%' + @nome + '%';