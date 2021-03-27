using ByteBank.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(321, 333);
                conta.Saldo = 50;
                conta.Sacar(10);

                ContaCorrente conta1 = new ContaCorrente(333, 222);
                conta.Saldo = 100;
                conta.Transferir(-10, conta);

            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo Saldo Insuficiente. ");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Ocorreu um excessão do tipo de Agumento.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
