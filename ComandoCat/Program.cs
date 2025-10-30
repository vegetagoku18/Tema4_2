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

            string fichero;
            int numLineas = -1;
            if (args[0].StartsWith("-n"))
            {
                string numFilas = args[0].Substring(2);
                if (!int.TryParse(numFilas, out numLineas) || numLineas <= 0)
                {
                    Console.WriteLine("El argumento no es valido");
                    return 2;
                }

                if (args.Length < 2)
                {
                    Console.WriteLine("No se ha especificado el fichero");
                    return 2;
                }

                fichero = Environment.ExpandEnvironmentVariables(args[1]);
                if (!File.Exists(fichero))
                {
                    Console.WriteLine("El fichero no existe");
                    return 1;
                }
            }
            else
            {
                fichero = Environment.ExpandEnvironmentVariables(args[0]);
            }
            try
            {
                using (StreamReader sr = new StreamReader(fichero))
                {
                    string linea;
                    int contador = 0;

                    while ((linea = sr.ReadLine()) != null&& contador < numLineas)
                    {
                        Console.WriteLine(linea);
                        contador++;

                  
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No tienes permisos para acceder a este fichero");
                return -1;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al leer el fichero: " + ex.Message);
                return -1;
            }
            return 0;
        }
    }
}
