namespace BancoSimples.Endpoints.Cliente
{
    public record ContaNovaRequest (string Nome, string Cpf, double Saldo);
    
}