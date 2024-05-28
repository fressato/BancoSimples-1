using BancoSimples.Domain.Conta;

namespace BancoSimples.Domain.Conta;

public class Transacao:Entity
{
    private int idConta;

    public Transacao(int idConta, double valor, string tipoMovimentacao)
    {
        this.idConta = idConta;
        Valor = valor;
    }

    public double Valor { get; set; }
    public DateTime Data { get; set; }
    public string TipoMovimentacao { get; set; }
    public bool Active { get; set; } = true;
}
