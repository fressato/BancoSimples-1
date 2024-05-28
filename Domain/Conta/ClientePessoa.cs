using Flunt.Validations;
using System.Security.Claims;

namespace BancoSimples.Domain.Conta;

public class ClientePessoa : Entity 
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public bool Active { get; private set; }
    public double Saldo { get; set; }

    public ClientePessoa(string nome, string cpf, double saldo)
    {
        Nome = nome;
        Cpf = cpf;
        Active = true;
        Saldo = saldo;

        Validate();

    }

    public ClientePessoa(string nome, Claim userId1, Claim userId2)
    {
        Nome = nome;
    }

    private void Validate()
    {
        var contract = new Contract<ClientePessoa>()
                    .IsNotNullOrEmpty(Nome, "Nome", "Nome é obrigatório")
                    .IsGreaterOrEqualsThan(Nome, 3, "Nome")
                    .IsNotNullOrEmpty(Cpf, "Cpf", "CPF é obrigatório");
        AddNotifications(contract);
    }

    public void EditInfo(string nome, string cpf, bool active, double saldo)
    {
        Nome = nome;
        Cpf = cpf;
        Active = true;
        Saldo = saldo;

        Validate();

    }

}
