namespace BancoSimples.Endpoints.Transacoes
{
    public record TransacaoRequest(double Valor, int IdConta, string TipoMovimentacao);
   
}