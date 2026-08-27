
using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencias
{
    public static void AdicionarCamadaDeInfra(this IServiceCollection services)
    {
        services.AddScoped<ContextoJson>(services =>
        {
            ContextoJson contexto = new ContextoJson();

            contexto.Carregar();

            return contexto;
        });

        //Config repositorios
    }
}
