using System;
using System.Text;

namespace Exercicio5InversaoCaracteres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a palavra na qual voce quer realizar a inversao de strings");
            var palavra=Console.ReadLine();

            Console.WriteLine(inverterString(palavra));
         
        }

        static string inverterString(string palavra)
        {
            StringBuilder palavraInvertida = new StringBuilder();
            for (var i = palavra.Length - 1; i >= 0; i--)
            {
                palavraInvertida.Append(palavra[i]);                             
            }
            return palavraInvertida.ToString();
        }
    }
}
