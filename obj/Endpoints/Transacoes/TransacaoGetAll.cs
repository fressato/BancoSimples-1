using BancoSimples.Infra.Data;
using BancoSimples.Domain.Conta;
using Microsoft.AspNetCore.Authorization;

namespace BancoSimples.Endpoints.Cliente
{
    public class TransacaoGetAll
    {
        public static string Template => "/transacao";
        public static string[] Methods => new string[] {HttpMethod.Get.ToString()};
        public static Delegate Handle => Action;

        [Authorize(Policy = "EmployeePolicy")]
        public static async Task<IResult> Action(int? page, int? rows, QueryAllUsersWithClaimName query)
        {
            var result = await query.Execute(page.Value, rows.Value);
            return Results.Ok(result);
        }
    }
}

