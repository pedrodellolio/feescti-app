# Rodando o aplicativo localmente
1- Clone o repositório pelo Git:
```
git clone https://github.com/pedrodellolio/feescti-app.git
```
2- Rode o script SQL [database.sql](https://github.com/pedrodellolio/feescti-app/blob/2e055c5c66c24d33b969e2a2a1bde23695ac392d/FEESCTI-ASPNET/sql/database.sql) para gerar o banco de dados com as tabelas;


3- Altere no arquivo [appsettings.json](https://github.com/pedrodellolio/feescti-app/blob/2e055c5c66c24d33b969e2a2a1bde23695ac392d/FEESCTI-ASPNET/appsettings.json) o valor da chave "DefaultConnection":
```
"DefaultConnection": "Data Source=DATA_SOURCE;Initial Catalog=INITIAL_CATALOG;Integrated Security=True"
```
Onde ``DATA_SOURCE`` é o servidor do banco no SQL Server e ``INITIAL_CATALOG`` o próprio banco de dados.
