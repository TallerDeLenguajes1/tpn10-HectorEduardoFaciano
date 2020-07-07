using System;
using System.Diagnostics;
using System.IO;

namespace _2Morse
{
    class Conversor
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            string fecha = now.ToString("dd-MM-yyyy");
            string direccion = Directory.GetCurrentDirectory();
            string directorio = direccion + @"\Morse\";
            
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            foreach (string archi in Directory.GetFiles(direccion))
            {
                Console.WriteLine("\n" + archi);
                if (archi.EndsWith(".mp3"))
                {
                    try
                    {
                        Directory.Move(archi, directorio + Path.GetFileName(archi));
                        Console.WriteLine("\n" + archi + " movido a " + directorio);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No se pudo mover: " + archi);
                    }

                }
            }

            string cadena;
            //ingreso una cadena de caracteres
            Console.WriteLine("Ingrese un texto para convertirlo a morse y guardarlo en un archivo: ");
            cadena = Console.ReadLine();
            
            //convierto la cadena a codigo morse
            string textAmorse = ConversorDeMorse.TextoAMorse(cadena);
            Console.WriteLine("Codigo Morse guardado: " + textAmorse);

            string fileNameMorse = directorio + "Codigo Morse de "+ "{" + cadena + "}" + "{" + fecha + "}" + ".txt";

            //almaceno la cadena de texto en el archivo fileNameMorse
            ConversorDeMorse.CrearArchivo(directorio, fileNameMorse, textAmorse);
            string nuevaCad = ConversorDeMorse.LeerMorse(fileNameMorse);

            //leo el codigo morse y lo convierto a audio
            ConversorDeMorse.CrearArchivoAudio(textAmorse, cadena);

            //convierto el codigo morse nuevamente a texto
            string morseAtext = ConversorDeMorse.MorseATexto(nuevaCad);
            Console.WriteLine("Codigo convertido a texto: " + morseAtext);

            string fileName = directorio + "Texto de " + "{" + cadena + "}" + "{" + fecha + "}" + ".txt";

            ConversorDeMorse.CrearArchivo(directorio, fileName, morseAtext);
            FileInfo ruta = new FileInfo(fileName);
            Console.WriteLine("Archivos guardados en: " + ruta.Directory);
        }
    }
}
