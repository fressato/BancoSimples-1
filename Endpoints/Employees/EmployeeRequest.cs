namespace BancoSimples.Endpoints.Employees
{
    public record EmployeeRequest(string Email, string Password, string Nome, string EmployeeCode);
}
