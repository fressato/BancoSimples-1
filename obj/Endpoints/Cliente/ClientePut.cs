using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BancoSimples.Endpoints.Cliente
{
    public class ClientePut
    {
        public static string Template => "/cliente/{id}";
        public static string[] Methods => new string[] {HttpMethod.Put.ToString()};
        public static Delegate Handle => Action;

       [Authorize(Policy = "EmployeePolicy")]
        public static IResult Action([FromRoute] Guid id ,ClienteRequest clienteRequest, ApplicationDbContext context)
        {
            var cliente = context.ClientePessoa.Where(c => c.Id == id).FirstOrDefault();

            if (cliente == null) 
                return Results.NotFound();

            cliente.EditInfo(clienteRequest.Nome, clienteRequest.Cpf, clienteRequest.Active, clienteRequest.Saldo);
            if (!cliente.IsValid)
                return Results.ValidationProblem(cliente.Notifications.ConvertToProblemDetails());

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
