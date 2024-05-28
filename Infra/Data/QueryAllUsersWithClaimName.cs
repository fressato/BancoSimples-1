using BancoSimples.Endpoints.Employees;
using Dapper;
using System.Data.SqlClient;

namespace BancoSimples.Infra.Data;
public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;

    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<EmployeeResponse>> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
        var query =
            @"select Email, ClaimValue as Nome 
            from AspNetUsers u inner
            join AspNetUserClaims c
            on u.id = c.UserId and claimtype = 'Nome'
            order by nome
            OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
        return await db.QueryAsync<EmployeeResponse>(
            query,
            new { page, rows }
        );
    }
}
