Aplicação completa para gerenciamento de tarefas, com backend em .NET 8 (API RESTful) e frontend em Angular + Angular Material.

## Como executar

### Usando Docker (recomendado)

1. Certifique-se de ter o Docker instalado.
2. No diretório raiz do projeto, execute:
   ```
   docker compose -f docker/docker-compose.yml up --build
   ```
3. Acesse o frontend em: `http://localhost:8080`
4. Acesse a API (Swagger) em: `http://localhost:5000/swagger`

### Manualmente

**Backend (.NET 8):**
1. Configure a string de conexão no `appsettings.json` do projeto `GerenciadorTarefas.API`.
2. Execute as migrations:
   ```
   dotnet ef migrations add InitialCreate --project ../GerenciadorTarefas.Infrastructure --startup-project . --context AppDbContext
   dotnet ef database update
   ```
3. Inicie a API:
   ```
   dotnet run
   ```
   Acesse o Swagger: `https://localhost:<porta>/swagger`

**Frontend (Angular):**
1. No diretório do frontend, instale as dependências:
   ```
   npm install
   ```
2. Execute o projeto:
   ```
   ng serve
   ```
   Acesse: `http://localhost:4200`

## Funcionalidades

- **CRUD de Tarefas:** criar, listar, editar, alterar status e remover.
- **Filtro por status:** visualize tarefas por situação.
- **Interface responsiva:** visual moderno, adaptado para desktop e mobile.
- **Modal de edição:** edição rápida e intuitiva das tarefas.

## Endpoints principais

- `POST /api/tarefas` — Criar tarefa
- `GET /api/tarefas` — Listar tarefas
- `PATCH /api/tarefas/{id}` — Editar tarefa
- `PATCH /api/tarefas/{id}/status` — Alterar status
- `DELETE /api/tarefas/{id}` — Remover tarefa

## Estrutura

- **Backend:** API RESTful, arquitetura em camadas, Entity Framework Core, PostgreSQL.
- **Frontend:** Angular, Angular Material
- **Docker:** Orquestração de containers para banco de dados, backend e frontend.

## Observações
