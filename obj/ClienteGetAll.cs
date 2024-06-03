using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;

namespace BancoSimples.Endpoints.Cliente
{
    public class ClienteGetAll
    {
        public static string Template => "/cliente";
        public static string[] Methods => new string[] {HttpMethod.Get.ToString()};
        public static Delegate Handle => Action;

        public static IResult Action( ApplicationDbContext context)
        {
            
           var cliente = context.ClientePessoa.ToList();
           //var response = cliente.Select(c => new ClienteResponse { Nome = c.Nome, Active = c.Active, Cpf = c.Cpf });

            return Results.Ok(cliente);
        }
    }
}
