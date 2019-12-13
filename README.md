## SCRIPT STORED PROCEDURE `BUSCA LIVROS DO AUTOR`
```
CREATE PROCEDURE [dbo].[Busca_Livros]
	@id_author as int
AS
	select			*
	from			dbo.Books			b
	where			b.Id in (
						SELECT		ba.BookId
						FROM		dbo.BookAuthors			ba
						WHERE		ba.AuthorId = @id_author
					)
```