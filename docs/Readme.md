# Gerenciador de Tarefas (.NET 8)

API para gerenciamento de tarefas, construída em .NET 8, utilizando Entity Framework Core e arquitetura em camadas.

## Como rodar

1. **Configuração do banco de dados**
   - Configure a string de conexão no `appsettings.json` do projeto `GerenciadorTarefas.API`.

2. **Migrations e atualização do banco**
   - Para rodar as migrations do EF, especifique o projeto de contexto com `--context` ou `--project`:
     ```
     dotnet ef migrations add InitialCreate --project ../GerenciadorTarefas.Infrastructure --startup-project . --context AppDbContext
     ```
   - Depois:
     ```
     dotnet ef database update
     ```

3. **Executando a API**
   - No diretório do projeto `GerenciadorTarefas.API`:
     ```
     dotnet run
     ```
   - Acesse a documentação Swagger em: `https://localhost:<porta>/swagger`

## Estrutura do Projeto

- **GerenciadorTarefas.API**: Camada de apresentação (controllers, configuração da aplicação).
- **GerenciadorTarefas.Application**: Handlers e comandos para orquestração das operações.
- **GerenciadorTarefas.Domain**: Entidades, enums e interfaces de domínio.
- **GerenciadorTarefas.Infrastructure**: Implementação do repositório e contexto do EF Core.

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

## Observações

- Projeto utiliza injeção de dependência e segue boas práticas de separação de responsabilidades.
- O contexto do banco de dados é configurado para PostgreSQL via `UseNpgsql`.

---