para rodar o migrations do EF, você precisa especificar o projeto de contexto com --context ou --project:
 dotnet ef migrations add InitialCreate --project ../GerenciadorTarefas.Infrastructure --startup-project . --context AppDbContext
depois :
dotnet ef database update
