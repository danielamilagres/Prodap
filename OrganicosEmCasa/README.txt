- Este projeto foi criado utilizando as seguinte tecnologias
	.net famework 4.6.1
	Banco de dados local ((localdb)\MSSQLLocalDB) 
	Entity famework (implementação feita utilizando Code Fist)

- Basta abrir o projeto no visual studio 2017 e executá-lo, assim que qualquer ação de manipulação do banco for executada o banco será criado localmente

- Para que o sistema fique usual assim que for executado sugiro a execução dos seguintes scripts na base de dados:
SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([ID], [Nome], [URLImagem], [Descricao]) VALUES (1, N'Leite', N'leite.png', N'Leite organico lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste, aut, esse, laborum placeat id illo a expedita aperiam.')
INSERT INTO [dbo].[Categorias] ([ID], [Nome], [URLImagem], [Descricao]) VALUES (2, N'Carnes', N'carne.jpg', N'Carne organica lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste, aut, esse, laborum placeat id illo a expedita aperiam.')
INSERT INTO [dbo].[Categorias] ([ID], [Nome], [URLImagem], [Descricao]) VALUES (3, N'Padaria', N'padaria.jpg', N'Padaria organica organico lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste, aut, esse, laborum placeat id illo a expedita aperiam.')
INSERT INTO [dbo].[Categorias] ([ID], [Nome], [URLImagem], [Descricao]) VALUES (4, N'Frutas e Legumes', N'legumes.jpg', N'Frutas organicas organico lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste, aut, esse, laborum placeat id illo a expedita aperiam.')
SET IDENTITY_INSERT [dbo].[Categorias] OFF

SET IDENTITY_INSERT [dbo].[Produtoes] ON
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (1, N'Peito Nelori', N'Maça de Peito', N'produtoCarne.jpg', CAST(19.90 AS Decimal(18, 2)), 2)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (3, N'Picanha', N'Picanha', N'produtoCarne.jpg', CAST(39.90 AS Decimal(18, 2)), 2)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (4, N'Leite de Cabra', N'Leite de Cabra', N'produtoLeite.jpg', CAST(8.90 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (5, N'Iogurte Natural', N'Iogurte Natural', N'produtoLeite.jpg', CAST(2.90 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (6, N'Manteiga', N'Manteiga', N'produtoLeite.jpg', CAST(10.90 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (7, N'Burrata', N'Burrata', N'produtoLeite.jpg', CAST(23.90 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (11, N'Cenoura', N'Cenoura', N'cenoura.jpg', CAST(2.90 AS Decimal(18, 2)), 4)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (12, N'Tomate', N'Tomate', N'tomate.jpeg', CAST(3.90 AS Decimal(18, 2)), 4)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (13, N'Pão Integral', N'Pão Integral', N'pao.jpg', CAST(11.90 AS Decimal(18, 2)), 3)
INSERT INTO [dbo].[Produtoes] ([ID], [Nome], [Descricao], [URLImagem], [Preco], [Categoria_ID]) VALUES (15, N'Rosca', N'Rosca', N'rosca.jpg', CAST(7.90 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Produtoes] OFF
	
- O que falta ser implementado
	- Alteração de quantidade do item no carrinho
	- Incluir uma funcionalidade para o cliente se logar e assim evitar que cada venda crie um novo cliente
	- Desenvolvimento da funcionalidade do continuar comprando voltar para a tela da categoria de origem
	- Criação dos demais testes, principalmente da CarrinhoController e VendaController aonde se encontram a grande maioria das regras de negócio
