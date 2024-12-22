# Sobre

O **MyFinance** é um projeto voltado para a gestão de finanças pessoais. 
Desenvolvido como parte do curso de Pós-Graduação em Engenharia de Software da PUC Minas, o sistema tem como objetivo simplificar a organização financeira, permitindo o controle de receitas, despesas e planejamento financeiro.

O projeto utiliza as boas práticas da **Clean Architecture**, que assegura:
- Um código modular e de fácil manutenção.
- Separação clara de responsabilidades entre as camadas:
  - **Camada de Aplicação**: Implementação das regras de negócio específicas.
  - **Camada de Domínio**: Regras genéricas e entidades que representam o núcleo do negócio.
  - **Camada de Infraestrutura**: Integração com banco de dados e outros serviços.
  - **Camada de Interface**: Apresentação utilizando **ASP.NET MVC**.

O sistema foi construído com **.NET Core** e um banco de dados **SQL Server**, aproveitando recursos como a injeção de dependência e o Entity Framework Core para um desenvolvimento robusto e escalável.

---

## Sumário

- [Plano de Contas](#plano-de-contas)
- [Registro de Transações](#registro-de-transações)
- [Relatório de Transações por Período](#relatório-de-transações-por-período)
- [Despesas e Receitas](#despesas-e-receitas)
- [Diagrama do Banco de Dados](#diagrama-do-banco-de-dados)
- [Como Conectar ao Banco de Dados](#como-conectar-ao-banco-de-dados)

---

## Plano de Contas

![Plano de Contas](./screenshots/plano-contas.png)

Gerencie suas contas categorizando receitas e despesas. Crie, edite e exclua contas conforme a necessidade.

---

## Registro de Transações

![Registro de Transações](./screenshots/registro-transacoes.png)

Mantenha um histórico detalhado das suas transações financeiras, incluindo datas, valores e categorias.

---

## Relatório de Transações por Período



---

## Despesas e Receitas



---

## Diagrama do Banco de Dados


---

## Como Conectar ao Banco de Dados

1. Configure a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=MyFinanceDb;Trusted_Connection=True;"
   }

