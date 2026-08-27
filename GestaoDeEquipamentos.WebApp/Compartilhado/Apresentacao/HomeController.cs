using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao.Views;
public class HomeController : Controller
{
    /*
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
*/
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
/*
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
    */
}
