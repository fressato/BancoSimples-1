namespace BancoSimples.Endpoints.Cliente
{
    public class ClienteResponse
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Active { get; set; } =true;
    }
}