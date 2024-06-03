using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BancoSimples.Endpoints.Cliente;

namespace BancoSimples.Endpoints.ContaNova
{
    public class ContaNovaPost
    {
        public static string Template => "/contanova";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        
        public static IResult Action(ContaNovaRequest contaNovaRequest, HttpContext http, ApplicationDbContext context)
        {
            var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var contaNova = new AbrirNovaContas(contaNovaRequest.Nome, contaNovaRequest.Cpf, contaNovaRequest.Saldo);

            if (!contaNova.IsValid)
            {
                return Results.ValidationProblem(contaNova.Notifications.ConvertToProblemDetails());
            }

            context.AbrirConta(contaNova);
            context.SaveChanges();

            return Results.Created($"/cliente/{contaNova.Id}", contaNova.Id);
        }
    }
}

         
