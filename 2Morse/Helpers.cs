using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _2Morse
{
    static class ConversorDeMorse
    {
        readonly static Dictionary<char, string> diccionario = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
            {' ', "/" }
        };

        public static string TextoAMorse(String texto)
        {
            texto = texto.ToLower();
            string morse = "";

            foreach (char caracter in texto.ToCharArray())
            {
                morse += diccionario[caracter] + " ";
            }

            return morse;
        }

        public static string MorseATexto(String morse)
        {
            string texto = "";

            foreach (string codigo in morse.Split(" "))
            {
                foreach (KeyValuePair<char, string> res in diccionario)
                {
                    if (res.Value == codigo)
                    {
                        texto += res.Key;
                    }
                }
            }
            return texto;
        }

        public static void CrearArchivoAudio(string texto, string cadena)
        {
            string Directorio = Directory.GetCurrentDirectory() + @"\Morse\";
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");

            string[] PalabrasMorse = texto.Split("/");

            string archmp3 = "Audio Morse de " + "{" + cadena + "}" + "{" + fecha + "}" + ".mp3";

            string archivoPunto = "punto.mp3";
            string archivoRaya = "raya.mp3";

            foreach (string palabra in PalabrasMorse)
            {
               char[] Letra = palabra.ToCharArray();
               using (FileStream stream = File.OpenWrite(Directorio + archmp3))
               {
                  foreach (char item in Letra)
                  {
                     if (item == '.')
                     {
                        byte[] punto = File.ReadAllBytes(Directorio + archivoPunto);
                        stream.Write(punto, 0, punto.Length);
                        stream.Flush();
                     }
                     else if (item == '-')
                     {
                        byte[] raya = File.ReadAllBytes(Directorio + archivoRaya);
                        stream.Write(raya, 0, raya.Length);
                        stream.Flush();
                     }
                     /*
                     else if (item == '/')
                     {
                        byte[] silencio = File.ReadAllBytes(Directorio + @"silencio.mp3");
                        stream.Write(silencio, 0, silencio.Length);
                        stream.Flush();
                     }*/
                  }
                  stream.Close();
               }
            }
        }

        public static void CrearArchivo(string Direccion, string nombre, string contenido)
        {
            if (!Directory.Exists(Direccion))
            {
                Directory.CreateDirectory(Direccion);
            }
            FileStream archivo = new FileStream(nombre, FileMode.Create);
            StreamWriter stream = new StreamWriter(archivo);
            stream.Write(contenido);
            stream.Close();
        }

        public static string LeerMorse(string pathArchivo)
        {
            FileStream archivo = new FileStream(pathArchivo, FileMode.Open);
            StreamReader stream = new StreamReader(archivo);
            string leido = stream.ReadToEnd();
            stream.Close();
            return leido;
        }
    }
}