// using _05_ByteBank;

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

            TaxaOperacao = 30 / TotalDeContasCriadas;
            TotalDeContasCriadas++;
        }


        #region Métodos
        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
        #endregion
    }
}
