
# 🚦 API de Check-in e Check-out de Motos 🏍️

## 📚 Descrição do Projeto

Esta API RESTful foi desenvolvida para gerenciar um sistema de **check-in e check-out de motos em um pátio**, permitindo o controle de clientes, motos, pátios e movimentações.

A API permite:
- Cadastrar clientes e motos
- Controlar quais motos estão no pátio (check-in e check-out)
- Consultar histórico de movimentações
- Cadastro de pátios

O projeto utiliza:
- 🔥 **ASP.NET Core 8**
- 🔥 **Entity Framework Core**
- 🔥 **Banco de dados Oracle**
- 🔥 **Swagger (OpenAPI)** para documentação

---

## 👨‍💻 Desenvolvedores

- **Diogo Paquete Weyne** – RM 558380  
- **Gustavo Tonato Maia** – RM 555393  
- **João Victor de Souza** – RM 555290  

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Banco Oracle (FIAP)
- Swagger para documentação
- Visual Studio 2022

---

## 🔥 Como Rodar este Projeto Localmente

### ✔️ Pré-requisitos

- ✅ .NET SDK (8.0 ou superior)
- ✅ Banco Oracle da FIAP (ou sua instância Oracle local)
- ✅ Git instalado

---

### ⚙️ Instalação

1️⃣ Clone este repositório:

```bash
git clone https://github.com/diogoweyne/CheckInOutMotosApi.git
```

2️⃣ Acesse a pasta do projeto:

```bash
cd CheckInOutMotosApi
```

3️⃣ Restaure os pacotes:

```bash
dotnet restore
```

4️⃣ Configure sua conexão com o Oracle no arquivo **`appsettings.json`**:

```json
"ConnectionStrings": {
  "DefaultConnection": "User Id=rm558380;Password=fiap24;Data Source=oracle.fiap.com.br:1521/ORCL"
}
```

5️⃣ Execute a migration para criar as tabelas no banco Oracle:

```bash
dotnet ef database update
```

6️⃣ Rode a aplicação:

```bash
dotnet run
```

7️⃣ Acesse a documentação Swagger no navegador:

```
https://localhost:5001/swagger/index.html
```

---

## 🔗 Documentação da API — Rotas Disponíveis

### 🧠 **Clientes**

| Método | Rota                      | Descrição                   |
|--------|----------------------------|------------------------------|
| GET    | `/api/clientes`            | Lista todos os clientes      |
| GET    | `/api/clientes/{id}`       | Consulta cliente por ID      |
| POST   | `/api/clientes`            | Cria um cliente              |
| PUT    | `/api/clientes/{id}`       | Atualiza dados de cliente    |
| DELETE | `/api/clientes/{id}`       | Deleta um cliente            |

---

### 🧠 **Motos**

| Método | Rota                      | Descrição                   |
|--------|----------------------------|------------------------------|
| GET    | `/api/motos`               | Lista todas as motos         |
| GET    | `/api/motos/{id}`          | Consulta moto por ID         |
| POST   | `/api/motos`               | Cria uma moto                |
| PUT    | `/api/motos/{id}`          | Atualiza dados da moto       |
| DELETE | `/api/motos/{id}`          | Deleta uma moto              |

---

### 🧠 **Pátios**

| Método | Rota                      | Descrição                   |
|--------|----------------------------|------------------------------|
| GET    | `/api/patios`              | Lista todos os pátios        |
| GET    | `/api/patios/{id}`         | Consulta pátio por ID        |
| POST   | `/api/patios`              | Cria um pátio                |
| PUT    | `/api/patios/{id}`         | Atualiza dados do pátio      |
| DELETE | `/api/patios/{id}`         | Deleta um pátio              |

---

### 🧠 **Movimentações (Check-in e Check-out)**

| Método | Rota                               | Descrição                            |
|--------|-------------------------------------|---------------------------------------|
| GET    | `/api/movimentacoes`               | Lista todas as movimentações          |
| POST   | `/api/movimentacoes/checkin`       | Realiza check-in da moto              |
| POST   | `/api/movimentacoes/checkout`      | Realiza check-out da moto             |
| DELETE | `/api/movimentacoes/{id}`          | Remove uma movimentação               |

---

## 🔥 Documentação OpenAPI (Swagger)

Acesse no navegador:

```
https://localhost:5001/swagger/index.html
```

Ou:

```
http://localhost:5000/swagger/index.html
```

---

## 📜 Observações Finais

- O projeto foi enviado em formato ZIP devido ao tamanho dos arquivos e restrições da plataforma de entrega.  
- Foi utilizada autenticação via string de conexão Oracle fornecida pela FIAP.  

---

## 🏆 Conclusão

> Projeto desenvolvido como parte da disciplina **Advanced Business Development with .NET**, aplicando conceitos de desenvolvimento de APIs RESTful, integração com bancos de dados relacionais (Oracle) e documentação de APIs utilizando OpenAPI (Swagger).

---
