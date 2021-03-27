// using _05_ByteBank;

using ByteBank.Exceções;
using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        private double _saldo = 100;

        public static double TaxaOperacao { get; set; }

        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }

        #region Propriedades

        public int Agencia { get; }

        public int Numero { get; }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }
        #endregion


        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0 )//nameOf é uma boa prática para evitar que caso mude o nome do parametro ele mande mudar aqui
                throw new ArgumentException("O argumento Agência deve ser maior que 0. ", nameof(agencia));
            
            if(numero <= 0)
                throw new ArgumentException("O argumento Número deve ser maior que 0. ",nameof(numero));


            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;

        }


        #region Métodos
        public bool Sacar(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            

            if (_saldo < valor)
                throw new SaldoInsuficienteException($"Você tentou sacar {valor} , porém seu saldo atual é de {_saldo}. Transação Inválida");
            

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));

            Sacar(valor);
            contaDestino.Depositar(valor);
         
        }
        #endregion
    }
}
