using GestaoDeChamados.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

public sealed class ChamadoController : Controller
{
    private readonly RepositorioChamadoEmArquivo repositorioChamado;
    private readonly RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public ChamadoController(
        RepositorioChamadoEmArquivo repositorioChamado,
        RepositorioEquipamentoEmArquivo repositorioEquipamentro
    )
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamentro;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarChamadoViewModel> viewModels = new List<ListarChamadoViewModel>();

        foreach (Chamado c in repositorioChamado.SelecionarTodos())
        {
            ListarChamadoViewModel viewModel = new ListarChamadoViewModel(
                c.Id,
                c.Titulo,
                c.DataAbertura,
                c.equipamento
            );

            viewModels.Add(viewModel);
        }

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarChamadoViewModel viewModel = new(
            null,
            null,
            null,
            0,
            ObterEquipamentosDisponiveis()
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarChamadoViewModel viewModel)
    {
        Equipamento? equipamentoSelecionado =
            repositorioEquipamento.SelecionarPorId(viewModel.EquipamentoId);

        if (equipamentoSelecionado == null)
            ModelState.AddModelError(nameof(viewModel.EquipamentoId), "Selecione um equipamento válido");

        if (!ModelState.IsValid)
        {
            viewModel = viewModel with
            {
                EquipamentosDisponiveis = ObterEquipamentosDisponiveis()
            };

            return View(viewModel);
        }

        Chamado chamado = new(
            viewModel.Titulo ?? string.Empty,
            viewModel.Descricao ?? string.Empty,
            viewModel.DataDeAbertura.GetValueOrDefault(),
            equipamentoSelecionado!
        );

        repositorioChamado.Cadastrar(chamado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Chanmado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        EditarChamadoViewModel viewModel = new(
            chamnadoSelecionado.Id,
            chamnadoSelecionado.Titulo,
            chamnadoSelecionado.Descricao,
            chamnadoSelecionado.DataDePublicacao,
            chamnadoSelecionado.Equipamento.Id,
            ObterEquipamentosDisponiveis()
        );


        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(int id, EditarChamadoViewModel viewModel)
    {
        Equipamento? equipamentoSelecionado =
            repositorioEquipamento.SelecionarPorId(viewModel.EquipamentoId);

        if (equipamentoSelecionado == null)
            ModelState.AddModelError(nameof(viewModel.EquipamentoId), "Selecione um equipamento válido.");

        if (!ModelState.IsValid)
        {
            viewModel = viewModel with
            {
                EquipamentosDisponiveis = ObterEquipamentosDisponiveis()
            };

            return View(viewModel);
        }

        Chamado chamadoAtualizado = new(
           viewModel.Titulo ?? string.Empty,
           viewModel.Titulo ?? string.Empty,
           viewModel.DataDeAbertura.GetValueOrDefault(),
           equipamentoSelecionado!
        );

        bool conseguiuEditar = repositorioChamado.Editar(id, chamadoAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        ExcluirChamadoViewModel viewModel = new(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirChamadoViewModel viewModel)
    {
        bool conseguiuExcluir = repositorioChamado.Excluir(viewModel.Id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    private List<SelecionarEquipamentoViewModel> ObterEquipamentosDisponiveis()
    {
        List<SelecionarEquipamentoViewModel> viewModels = new();

        foreach (Equipamento e in repositorioEquipamento.SelecionarTodos())
        {
            SelecionarEquipamentoViewModel viewModel = new(e.Id, e.Titulo);

            viewModels.Add(viewModel);
        }

        return viewModels;
    }
}