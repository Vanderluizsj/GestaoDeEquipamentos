

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaDeApresentacao(this IServiceCollection services)
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
        {
            //Reseta o mecanismo de busca de views
            options.ViewLocationFormats.Clear();

            //Confugira localização das Views Compartilhadas
            options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");

            //Configura localização das views de modulos
            options.ViewLocationFormats.Add("/Modulos/{1}s/Apresentacao/Views/{0}.cshtml");
        });
    }
}
