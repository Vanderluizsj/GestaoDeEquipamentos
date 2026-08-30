using System.ComponentModel.DataAnnotations;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public record ListarChamadoViewModel(
    int Id,
    string Titulo,
    string Descricao,
    DateTime DataDeAbertura,
    string NomeEquipamento
);

public record SelecionarEquipamentoViewModel(int Id, string Nome);

public record CadastrarChamadoViewModel(

    [Required(ErrorMessage = "O campo \"Titulo\" é obrigatório.")]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "O campo \"Nome\" deve conter entre 6 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descricao\" é obrigatório.")]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "O campo \"Nome\" deve conter entre 6 e 100 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime? DataDeAbertura,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Equipamentro\" é obrigatório.")]
    int EquipamentroId,

    List<SelecionarEquipamentoViewModel>? EquipamentosDisponiveis
);

public record EditarChamadoViewModel(
    int Id,

    [Required(ErrorMessage = "O campo \"Titulo\" é obrigatório.")]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "O campo \"Nome\" deve conter entre 6 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descricao\" é obrigatório.")]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "O campo \"Nome\" deve conter entre 6 e 100 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime? DataDeAbertura,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Equipamentro\" é obrigatório.")]
    int EquipamentroId,

    List<SelecionarEquipamentoViewModel>? EquipamentosDisponiveis
);

public record ExcluirChamadoViewModel(
    int Id,
    string Nome
);