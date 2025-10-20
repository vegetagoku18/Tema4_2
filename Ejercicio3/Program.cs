using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        public delegate double Potencia(double x);

        public static double ElevarAlCuadrado(double x)
        {
            return Math.Pow(x, 2);
        }

        public static double ElevarAlCubo(double x)
        {

            return Math.Pow(x, 3); ;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Dime un valor entero");
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor no valido. Dime un valor entero");
            }

            Console.WriteLine("Dime si quieres elevar al cuadrado (2) o al cubo (3)");
            string opcion = Console.ReadLine().Trim();
            while (opcion != "2" && opcion != "3")
            {
                Console.WriteLine("Opcion no valida");
                opcion = Console.ReadLine().Trim();
            }

            Potencia potencia = new Potencia(ElevarAlCuadrado);

            if (opcion == "3")
            {
                potencia = new Potencia(ElevarAlCubo);
            }

            Console.WriteLine($"El resultado es: {potencia(valor)}");
            Console.ReadLine();
        }
    }
}
