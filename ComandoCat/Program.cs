using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandoCat
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No se ha pasado ningun argumento");
                return 2;
            }
            string fichero = Environment.ExpandEnvironmentVariables(args[0]);
            if (!File.Exists(fichero))
            {
                Console.WriteLine("El fichero no existe");
                return 1;
            }
            int numLineas = 0;
            if (args[0].StartsWith("-n"))
            {
                string numFilas = args[0].Substring(2);
                if (!int.TryParse(numFilas, out  numLineas) || numLineas <= 0)
                {
                    Console.WriteLine("El argumento no es valido");
                    return 2;
                }
            }
            try
            {
                using (StreamReader sr = new StreamReader(fichero))
                {

                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No tienes permisos para acceder a este fichero");
                return -1;
            }
            return 0;
        }
    }
}
