using System;

namespace BancoSimples.Domain.Conta
{
    public class AbrirNovaContas:Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Saldo { get; set; }

        public AbrirNovaContas(string nome, string cpf, double saldo)
        {
            Nome = nome;
            Cpf = cpf;
            Saldo = saldo;
          
        }
        public void EditInfo(string nome, string cpf, double saldo)
        {
            Nome = nome;
            Cpf = cpf;           
            Saldo = saldo;

         }
    }
}
