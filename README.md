# 📆 Agendamento API - Autoescola

API desenvolvida em **ASP.NET Core (.NET 8)** com foco em autoescolas, permitindo o agendamento de provas para alunos com envio de **notificações via Twilio (SMS)**.

---

## 🚀 Funcionalidades

- 📌 Cadastro de alunos
- 📌 Agendamento de provas (teórica e prática)
- 📌 Envio de SMS para lembrar o aluno da prova via **Twilio**
- 📌 Integração com **SQL Server**
- 📌 Estrutura em camadas (Controllers, Services, DTOs, Repositories)
- ✅ API REST com boas práticas

---

## 🧠 Tecnologias Utilizadas

- ✅ **C# (.NET 8)**
- ✅ **ASP.NET Core Web API**
- ✅ **Entity Framework Core**
- ✅ **SQL Server**
- ✅ **Twilio API (notificações SMS)**
- ✅ **Injeção de Dependência**
- ✅ **DTOs para entrada e saída de dados**
- ✅ **Boas práticas REST**

---

## 🗂️ Estrutura do Projeto

```
AgendamentoAPI/
├── Controllers/              # Define os endpoints da API
│   ├── AlunoController.cs
│   └── AgendamentoController.cs
│
├── Services/                 # Lógica de negócio
│   ├── AlunoService.cs
│   ├── AgendamentoService.cs
│   └── TwilioService.cs
│
├── Models/                   # Classes de entidades
│   ├── Aluno.cs
│   └── Agendamento.cs
│
├── DTOs/                     # Objetos de transferência de dados
│   ├── AlunoDTO.cs
│   └── AgendamentoDTO.cs
│
├── Maps/                     # Mapeamento das entidades para o banco
│   ├── AlunoMap.cs
│   └── DiaDaProvaMap.cs
│
├── Data/                     # Configuração do DbContext
│   └── AppDbContext.cs
│
├── Settings/                 # Configuração de serviços externos
│   └── TwilioSettings.cs
│
├── appsettings.json          # Configuração geral do projeto
├── appsettings.Development.json
├── Program.cs                # Ponto de entrada da aplicação
├── Agendamento.sln
└── .gitignore

```

---

## 🔒 Configuração do Twilio (Segredos)

No `appsettings.json`, configure suas credenciais do Twilio**:

```json
"Twilio": {
  "AccountSID": "SEU_SID",
  "AuthToken": "SEU_TOKEN",
  "From": "+55SEUNUMERO"
}
```

---

## 🛠️ Como Rodar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/SeuUsuario/AgendamentoAPI.git
```

2. Configure a connection string no `appsettings.json`:

```json
"ConnectionStrings": {
  "Default": "Server=localhost\SQLEXPRESS;Database=AgendamentoDB;User Id=SeuUsuario;Password=SuaSenha;TrustServerCertificate=true;"
}
```

3. Aplique as migrations:

```bash
dotnet ef database update
```

4. Rode a API:

```bash
dotnet run
```

---

## 📱 Exemplo de Endpoint

### Agendar prova:

```
POST /api/agendamento
```

```json
{
  "alunoId": 1,
  "data": "2025-08-01T09:00:00",
  "tipo": "Prova Prática"
}
```

> Resultado: Prova agendada + SMS enviado automaticamente via Twilio 📲

---

## 👨‍💻 Autor

**Caio de Souza Nery**  
Desenvolvedor C# Júnior | Autodidata  
[GitHub](https://github.com/CaioSNery)

---
