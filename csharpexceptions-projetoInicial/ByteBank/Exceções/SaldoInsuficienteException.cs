using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Exceções
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get;}
        public double ValorSaque { get; }

        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(double p_saldo, double p_valorSaque) 
            : this("Tentativa de saque do valor de R$ " + p_valorSaque + "em uma conta com saldo de R$" + p_saldo)
        {
            Saldo = p_saldo;
            ValorSaque = p_valorSaque;
        }

        public SaldoInsuficienteException(string message) 
            : base(message)
        {

        }
    }
}
