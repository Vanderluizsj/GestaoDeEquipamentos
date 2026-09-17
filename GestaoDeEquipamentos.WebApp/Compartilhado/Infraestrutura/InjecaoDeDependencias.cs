
using GestaoDeChamados.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencias
{
    public static void AdicionarCamadaDeInfra(
        this IServiceCollection services, IConfiguration configuration
        )
    {
        services.AddScoped(services =>
        {
            ContextoJson contexto = new ContextoJson();

            contexto.Carregar();

            return contexto;
        });

        string connectionString = configuration.GetConnectionString("SqlServerDocker")
         ?? throw new InvalidOperationException("Connection string 'SqlServerDocker' not found.");

        //Config repositorios
        services.AddScoped<IRepositorioFabricante>(services =>
        new RepositorioFabricanteEmSql(connectionString)
        );

        services.AddScoped<IRepositorioEquipamento>(services =>
        new RepositorioEquipamentoEmSql(connectionString)
        );
        //services.AddScoped<RepositorioEquipamentoEmArquivo>();
        services.AddScoped<IRepositorioChamado>(services =>
        new RepositorioChamadoEmSql(connectionString    )
        );
    }
}
