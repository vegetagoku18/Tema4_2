using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4
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

            string directorio = Environment.ExpandEnvironmentVariables(args[0]);
            if (!Directory.Exists(directorio))
            {
                Console.WriteLine("El directorio no existe");
                return 1;
            }
            try
            {
                string[] archivos = Directory.GetFiles(directorio);
                foreach (string archivo in archivos)
                {
                    if (File.Exists(archivo))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        FileInfo info = new FileInfo(archivo);
                        Console.WriteLine($"{info.Name} {info.Length} bytes");
                    }
                }
                string[] subdirectorios = Directory.GetDirectories(directorio);
                foreach (string subdirectorio in subdirectorios)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    DirectoryInfo info = new DirectoryInfo(subdirectorio);
                    Console.WriteLine($"{info.Name}");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.ResetColor();
                Console.WriteLine("No tienes permisos para acceder a este directorio");
                return -1;
            }
            Console.ResetColor();
            return 0;
        }
    }
}
