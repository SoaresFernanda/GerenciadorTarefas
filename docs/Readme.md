# Gerenciador de Tarefas (.NET 8)

API para gerenciamento de tarefas, constru�da em .NET 8, utilizando Entity Framework Core e arquitetura em camadas.

## Como rodar

1. **Configura��o do banco de dados**
   - Configure a string de conex�o no `appsettings.json` do projeto `GerenciadorTarefas.API`.

2. **Migrations e atualiza��o do banco**
   - Para rodar as migrations do EF, especifique o projeto de contexto com `--context` ou `--project`:
     ```
     dotnet ef migrations add InitialCreate --project ../GerenciadorTarefas.Infrastructure --startup-project . --context AppDbContext
     ```
   - Depois:
     ```
     dotnet ef database update
     ```

3. **Executando a API**
   - No diret�rio do projeto `GerenciadorTarefas.API`:
     ```
     dotnet run
     ```
   - Acesse a documenta��o Swagger em: `https://localhost:<porta>/swagger`

## Estrutura do Projeto

- **GerenciadorTarefas.API**: Camada de apresenta��o (controllers, configura��o da aplica��o).
- **GerenciadorTarefas.Application**: Handlers e comandos para orquestra��o das opera��es.
- **GerenciadorTarefas.Domain**: Entidades, enums e interfaces de dom�nio.
- **GerenciadorTarefas.Infrastructure**: Implementa��o do reposit�rio e contexto do EF Core.

## Principais Funcionalidades

- **CRUD de Tarefas**:
  - Criar, listar, editar, alterar status e remover tarefas.
- **Status da Tarefa**:
  - `Pendente`, `EmAndamento`, `Concluida`.

## Endpoints

- `POST /api/tarefas` - Criar tarefa
- `GET /api/tarefas` - Listar tarefas
- `PATCH /api/tarefas/{id}` - Editar tarefa
- `PATCH /api/tarefas/{id}/status` - Alterar status
- `DELETE /api/tarefas/{id}` - Remover tarefa

## Observa��es

- Projeto utiliza inje��o de depend�ncia e segue boas pr�ticas de separa��o de responsabilidades.
- O contexto do banco de dados � configurado para PostgreSQL via `UseNpgsql`.

---