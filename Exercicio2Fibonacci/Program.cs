using System;

namespace Exercicio2Fibonaci
{
    public class Exercicio2Fibonacci
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite numero desejado para verificar se este faz parte da sequência Fibonacci");
            var numeroFibonacci = Convert.ToInt32(Console.ReadLine());

            if (verificarNumeroNaSequenciaFibonacci(numeroFibonacci))
                Console.WriteLine("O número informado pertence à sequência");
            else
                Console.WriteLine("O número informado não pertence à sequência");
        }

        public static bool verificarNumeroNaSequenciaFibonacci(int numFibonacci)
        {
            int primeiroNum = 0, segundoNum = 1, aux = 0;

            while (primeiroNum <= numFibonacci)
            {
                if (numFibonacci == primeiroNum)
                    return true;

                aux = primeiroNum;
                primeiroNum = segundoNum;
                segundoNum = primeiroNum + aux;
            }
            return false;
        }
    }
}