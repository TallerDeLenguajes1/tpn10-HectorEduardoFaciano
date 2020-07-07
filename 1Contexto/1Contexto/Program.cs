using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _1Contexto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Propiedad> Lista = new List<Propiedad>();

            string dirCarpeta = Directory.GetCurrentDirectory() + @"\CarpetaNueva\";
            string file1 = "ArchivoBase.csv";
            string file2 = "ArchivoCompleto.csv";
            if (!Directory.Exists(dirCarpeta))
            {
                Directory.CreateDirectory(dirCarpeta);
            }
           
            int respuesta = 1;
            do
            {
                switch (respuesta)
                {
                    case 1:
                        Lista.Add(Agregar());
                        Carga(Lista, dirCarpeta, file1, file2);
                        break;
                    case 2:
                        Mostrar(Lista);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Presione 1 para seguir cargando o 2 para mostrar");
                respuesta = Convert.ToInt32(Console.ReadLine());
            } while (respuesta != 0);
        }

        public static void Carga(List<Propiedad> Lista, string dirCarpeta, string file1, string file2)
        {
            FileStream fs1 = new FileStream(dirCarpeta + file1, FileMode.Create);
            StreamWriter sw1 = new StreamWriter(fs1);
            List<string> fila1 = new List<string>();

            foreach (Propiedad p1 in Lista)
            {
                fila1.Add(p1.Id.ToString() + ";" +
                        p1.TipoDePropiedad + ";" +
                        p1.Domicilio);
            }
            fs1.Close();
            File.WriteAllLines(dirCarpeta + file1, fila1);

            FileStream fs2 = File.Open(dirCarpeta + file2, FileMode.Create);
            StreamWriter sw2 = new StreamWriter(fs2);
            List<string> fila2 = new List<string>();

            foreach (Propiedad p2 in Lista)
            {
                fila2.Add(p2.Id.ToString() + ";" +
                        p2.TipoDePropiedad + ";" +
                        p2.TipoDeOperacion + ";" +
                        p2.Tamaño.ToString() + ";" +
                        p2.Cantidad_de_baños.ToString() + ";" +
                        p2.Habitaciones.ToString() + ";" +
                        p2.Domicilio + ";" +
                        p2.Precio + ";" +
                        p2.Estado.ToString());
            }
            fs2.Close();
            File.WriteAllLines(dirCarpeta + file2, fila2);
        }
                    
        public static Propiedad Agregar()
        {
            int tipo = 0;
            var rand = new Random();
            Propiedad p = new Propiedad();
            Console.WriteLine("ID: ");
            p.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("OPERACION | 1 VENTA - 2 ALQUILER: ");
            tipo = Convert.ToInt32(Console.ReadLine()) - 1;
            p.TipoDeOperacion = ((Operacion)tipo).ToString();
            Console.WriteLine("PROPIEDAD | 1 DPTO - 2 CASA - 3 DUPLEX - 4 PENTHHOUSE - 5 TERRENO: ");
            tipo = Convert.ToInt32(Console.ReadLine()) - 1;
            p.TipoDePropiedad = ((Tipo)tipo).ToString();
            p.Tamaño = (float)(rand.Next(50, 200) + rand.NextDouble() * 1);
            p.Cantidad_de_baños = rand.Next(1, 5);
            p.Habitaciones = rand.Next(1, 10);
            Console.WriteLine("DIRECCION: ");
            p.Domicilio = Console.ReadLine();
            p.Precio = rand.Next(1000000, 10000000);
            tipo = rand.Next(2);
            if (tipo == 1) { p.Estado = true; } else { p.Estado = false; }
            Console.WriteLine("VALOR DEL INMUEBLE: " + p.ValorDelInmueble());
            return p;
        }

        public static void Mostrar(List<Propiedad> Lista)
        {
            Console.Clear();
            int cont = 1;
            foreach (Propiedad p in Lista)
            {
                Console.WriteLine("INDICE: {0} | ID: {1}", cont, p.Id);
                Console.WriteLine("OPERACION: " + p.TipoDeOperacion);
                Console.WriteLine("TIPO: " + p.TipoDePropiedad);
                Console.WriteLine("TAMAÑO: " + p.Tamaño);
                Console.WriteLine("BAÑOS: {0} | HABITACIONES:  {1}", p.Cantidad_de_baños, p.Habitaciones);
                Console.WriteLine("DIRECCION: " + p.Domicilio);
                Console.WriteLine("PRECIO ESTANDAR: " + p.Precio);
                if (p.Estado)
                {
                    Console.WriteLine("PROPIEDAD DISPONIBLE");
                }
                else { Console.WriteLine("PROPIEDAD NO DISPONIBLE"); }
                Console.WriteLine("PRECIO INMUEBLE: " + p.ValorDelInmueble());
                Console.WriteLine("-------------------\n");
                cont++;
            }
        }
    }
}
