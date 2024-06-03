using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BancoSimples.Endpoints.Cliente
{
    public class ContaNovaPut
    {
        public static string Template => "/contanova/{id}";
        public static string[] Methods => new string[] {HttpMethod.Put.ToString()};
        public static Delegate Handle => Action;

       // [Authorize(Policy = "EmployeePolicy")]
        public static IResult Action([FromRoute] Guid id ,ContaNovaRequest contaNovaRequest, ApplicationDbContext context)
        {
            var contaNova = context.AbrirNovaConta.Where(c => c.Id == id).FirstOrDefault();

            if (contaNova == null) 
                return Results.NotFound();

            contaNova.EditInfo(contaNovaRequest.Nome, contaNovaRequest.Cpf, contaNovaRequest.Saldo);
            if (!contaNova.IsValid)
                return Results.ValidationProblem(contaNova.Notifications.ConvertToProblemDetails());

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
