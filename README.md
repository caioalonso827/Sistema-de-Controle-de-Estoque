# 📦 Sistema de Controle de Estoque

## 🖼️ Screenshots
> *(adicione aqui imagens das telas do WPF, por exemplo: tela de login, cadastro de produtos, movimentações, relatórios)*

![Tela Cadastro Produto](<img width="1292" height="786" alt="image" src="https://github.com/user-attachments/assets/d4ccf215-fcd1-4774-ac89-0e71aa243e0f" />
)
![Cadastro de Produto](docs/images/cadastro-produto.png)
![Movimentações](docs/images/movimentacoes.png)

---

## 🚀 Sobre o Projeto
O **Sistema de Controle de Estoque** é uma aplicação completa composta por:

- **Frontend Desktop (WPF)**  
  Interface amigável para gerenciar produtos, categorias e movimentações de estoque.

- **Backend (ASP.NET Core API)**  
  API REST que centraliza as operações de cadastro, listagem e movimentação de itens, integrada ao banco **PostgreSQL**.

---

## ⚙️ Funcionalidades

- ✅ Cadastro de produtos e categorias  
- ✅ Registro de entradas e saídas de estoque  
- ✅ Relatórios de movimentações  
- ✅ Integração com banco de dados PostgreSQL  
- ✅ Documentação via Swagger para testar endpoints da API  

---

## 🛠️ Tecnologias Utilizadas

- **C# / .NET 8**
- **WPF** (Windows Presentation Foundation)
- **ASP.NET Core Minimal API**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger UI**

---

## 📡 Endpoints da API

Exemplo de alguns endpoints disponíveis:

| Método | Rota                          | Descrição                        |
|--------|-------------------------------|----------------------------------|
| GET    | `/Movimentacao/ListarTodas`   | Lista todas as movimentações     |
| POST   | `/Produto/Cadastrar`          | Cadastra um novo produto         |
| GET    | `/Categoria/Listar`           | Lista todas as categorias        |

---

## 🔧 Como Rodar

### 1. Clonar o repositório
```bash
git clone https://github.com/seuusuario/sistema-controle-estoque.git
