using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;
using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BancoSimples.Endpoints.Cliente
{
    public class ClientePost
    {
        public static string Template => "/cliente";
        public static string[] Methods => new string[] {HttpMethod.Post.ToString()};
        public static Delegate Handle => Action;

        [Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(ClienteRequest clienteRequest, HttpContext http, ApplicationDbContext context)
        {
            var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var cliente = new ClientePessoa(clienteRequest.Nome, userId, userId);
            
            if (!cliente.IsValid)
            {
                return Results.ValidationProblem(cliente.Notifications.ConvertToProblemDetails());
            }

                

            context.ClientePessoa.Add(cliente);
            context.SaveChanges();

            return Results.Created($"/cliente/{cliente.Id}", cliente.Id);
        }
    }
}
