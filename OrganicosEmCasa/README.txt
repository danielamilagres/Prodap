- Este projeto foi criado utilizando as seguinte tecnologias
	.net famework 4.6.1
	MVC
	Banco de dados local ((localdb)\MSSQLLocalDB) 
	Entity famework (implementação feita utilizando Code Fist)

Instruções de instalação:
	- Para aproveitar o banco já criado, extrair os arquivos do APP_DATA.zip que se encontra no diretorio raiz do projeto
	- Copiar os arquivos OrganicosEmCasa.mdf e OrganicosEmCasa_log.ldf para o diretorio OrganicosEmCasa\App_Data
	- Abrir o projeto 
	- Executar Clean Solution
	- Executar Rebuild Solution
	- Rodar o site


- O que falta ser implementado
	- Alteração de quantidade do item no carrinho
	- Incluir uma funcionalidade para o cliente se logar e assim evitar que cada venda crie um novo cliente
	- Desenvolvimento da funcionalidade do continuar comprando voltar para a tela da categoria de origem
	- Criação dos demais testes, principalmente da CarrinhoController e VendaController aonde se encontram a grande maioria das regras de negócio
