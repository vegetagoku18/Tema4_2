using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandoNewFile
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No se ha pasado ningun argumento");
                return 2;
            }

            if (args.Length > 3)
            {
                Console.WriteLine("Demasiados argumentos");
            }

            string fichero;
            string contenido;
            bool append = args[0] == "-a";

            if (append)
            {
                fichero = args[1];
                contenido = args[2];
            }
            else
            {
                fichero = args[0];
                contenido = args[1];
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fichero, append))
                {
                    sw.WriteLine(contenido);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No tiene permisos para escribir en el fichero");
                return 3;
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha producido un error: " + e.Message);
                return -1;
            }

            return 0;
        }
    }
}
