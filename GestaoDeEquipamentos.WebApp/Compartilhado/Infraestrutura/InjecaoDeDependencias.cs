
using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;

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
        services.AddScoped<RepositorioFabricanteEmArquivo>();
        services.AddScoped<RepositorioEquipamentoEmArquivo>();
    }
}
