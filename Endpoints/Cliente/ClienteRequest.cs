namespace BancoSimples.Endpoints.Cliente
{
    public class ClienteRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Saldo { get; set; }
        public bool Active { get; set; } =true;
    }
}