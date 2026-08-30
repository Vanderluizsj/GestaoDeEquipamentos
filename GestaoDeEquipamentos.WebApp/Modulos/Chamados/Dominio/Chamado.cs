using GestaoDeEquipamentos.WebApp.Compartilhado.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;

public sealed class Chamado : EntidadeBase
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public Equipamento equipamento { get; set; } = null!;

    public Chamado()
    {
    }

    public Chamado(string titulo, string descricao, DateTime dataAbertura, Equipamento equipamento)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataAbertura = dataAbertura;
        Equipamento = equipamento;
    }


    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Equipamento equipamentoAtualizado = (Equipamento)entidadeAtualizada;

        Titulo = equipamentoAtualizado.Titulo;
        Descricao = equipamentoAtualizado.Descricao;
        DataAbertura = equipamentoAtualizado.DataAbertura;
        Equipamento = equipamentoAtualizado.Equipamento;
    }
}