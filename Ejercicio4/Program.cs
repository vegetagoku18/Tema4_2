using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] notas = { 5, 2, 8, 1, 9, 4 };
            string[] palabras = { "Sol", "Luna", "Estrella", "Cielo" };
            string mensaje = Array.Exists(notas, nota => nota >= 5) ? "Hay algún aprobado" : "No hay ningún aprobado";
            Console.WriteLine(mensaje);

            int[] aprobados = Array.FindAll(notas, nota => nota >= 5);
            Console.WriteLine("Notas aprobadas: " + string.Join(", ", aprobados));

            Console.WriteLine(Array.FindLast(notas, nota => nota >= 5));

            Console.WriteLine(notas.Count(nota => nota % 2 == 0));

            Console.WriteLine(Array.Find(palabras, palabra => palabra.Length > 3));

            string[] palabrasMayus = Array.ConvertAll(palabras, palabra => palabra.ToUpper());
            Console.WriteLine(string.Join(", ", palabrasMayus));

            Console.WriteLine(Array.FindIndex(palabras, palabra => palabra.StartsWith("E")));
        }
    }
}
