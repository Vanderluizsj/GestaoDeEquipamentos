using GestaoDeEquipamentos.WebApp.Compartilhado.Dominio;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;

public sealed class Chamado : EntidadeBase
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataDeAbertura { get; set; }
    public Equipamento Equipamento { get; set; } = null!;

    public Chamado()
    {
    }

    public Chamado(string titulo, string descricao, DateTime dataDeAbertura, Equipamento equipamento)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataDeAbertura = dataDeAbertura;
        Equipamento = equipamento;
    }


    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Chamado chamadoAtualizado = (Chamado)entidadeAtualizada;

        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        DataDeAbertura = chamadoAtualizado.DataDeAbertura;
        Equipamento = chamadoAtualizado.Equipamento;
    }
}