using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    internal class Program
    {
        public delegate void MyDelegate();

        public static bool MenuGenerator(string[] opciones, MyDelegate[] acciones)
        {
            if (opciones == null || opciones.Length == 0 || acciones == null || acciones.Length != opciones.Length)
            {
                return false;
            }

            int opcion;

            do
            {
                Console.WriteLine("Seleccione una opcion:");
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {opciones[i]}");
                }
                Console.WriteLine((opciones.Length + 1) + ". Salir");
                string opcionElegida = Console.ReadLine();

                if (!int.TryParse(opcionElegida, out opcion) || opcion > opciones.Length + 1 || opcion < 1)
                {
                    Console.WriteLine("Opcion no válida");
                }

                if (opcion >= 1 && opcion <= opciones.Length)
                {
                    acciones[opcion - 1]();

                }
            } while (opcion != opciones.Length + 1);

            return true;
        }
        /*static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }*/
        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Op1", "Op2", "Op3" }, new MyDelegate[] {
                () =>Console.WriteLine("A"),
                () => Console.WriteLine("B"),
                () => Console.WriteLine("C")
            });
            Console.ReadKey();
        }
    }
}
