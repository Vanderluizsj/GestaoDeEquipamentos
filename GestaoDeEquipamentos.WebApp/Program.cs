using GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao;
using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

//1. Configurar Infra(Arquivos, DB, Logs, Caches)
builder.Services.AdicionarCamadaDeInfra();
//2. Configurar MVC/Apresentação
builder.Services.AdicionarCamadaDeApresentacao();

var app = builder.Build();

//Middlewares
app.UseRouting();
app.MapDefaultControllerRoute();

app.UseStaticFiles();

// Executa o servidor 
app.Run();
