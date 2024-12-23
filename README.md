# Sobre

O **MyFinance** é um projeto voltado para a gestão de finanças pessoais. 
Desenvolvido como parte do curso de Pós-Graduação em Engenharia de Software da PUC Minas, o sistema tem como objetivo simplificar a organização financeira, permitindo o controle de receitas, despesas e planejamento financeiro.

O sistema foi construído com **.NET Core** e um banco de dados **SQL Server**.

---

## Sumário

- [Plano de Contas](#plano-de-contas)
- [Registro de Transações](#registro-de-transações)
- [Como Conectar ao Banco de Dados](#como-conectar-ao-banco-de-dados)

---

## Plano de Contas

![Plano de Contas](images/myFinancePlanoDeConta.png)

Gerencie suas contas categorizando receitas e despesas. 
Crie, edite e exclua contas conforme a necessidade.

---

## Registro de Transações

![Registro de Transações](images/myFinanceRegistroTransacoes.png)

Mantenha um histórico detalhado das suas transações financeiras, incluindo datas, valores e categorias.

---

## Como Conectar ao Banco de Dados

1. Configure a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=myfinance;User Id=sa;Password=Password2024$@;TrustServerCertificate=True"
   }

