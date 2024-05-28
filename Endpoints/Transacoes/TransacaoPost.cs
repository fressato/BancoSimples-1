using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;
using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BancoSimples.Endpoints.Transacoes
{
    public class TransacaoPost
    {
        public static string Template => "/clientetransacao";
        public static string[] Methods => new string[] {HttpMethod.Post.ToString()};
        public static Delegate Handle => Action;

        [Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(TransacaoRequest transacaoRequest, HttpContext http, ApplicationDbContext context)
        {
            var userId = http.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var transacao = new Transacao (transacaoRequest.IdConta, transacaoRequest.Valor, transacaoRequest.TipoMovimentacao);
            
            if (!transacao.IsValid)
            {
                return Results.ValidationProblem(transacao.Notifications.ConvertToProblemDetails());
            }


            context.Transacao.Add(transacao);
            context.SaveChanges();

            return Results.Created($"/cliente/{transacao.Id}", transacao.Id);
        }
    }
}
