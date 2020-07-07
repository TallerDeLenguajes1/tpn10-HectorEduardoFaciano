using System;
using System.Collections.Generic;
using System.Text;

namespace _1Contexto
{
    enum Operacion
    {
        Venta = 0,
        Alquiler = 1
    }
    enum Tipo
    {
        Departamento = 0,
        Casa = 1,
        Duplex = 2,
        PenthHouse = 3,
        Terreno = 4
    }
    class Propiedad
    {
        int id, cantidad_de_baños, habitaciones;
        string tipoDePropiedad, tipoDeOperacion, domicilio;
        float tamaño, precio;
        bool estado;

        public int Id { get => id; set => id = value; }
        public int Cantidad_de_baños { get => cantidad_de_baños; set => cantidad_de_baños = value; }
        public int Habitaciones { get => habitaciones; set => habitaciones = value; }
        public string TipoDePropiedad { get => tipoDePropiedad; set => tipoDePropiedad = value; }
        public string TipoDeOperacion { get => tipoDeOperacion; set => tipoDeOperacion = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public float Tamaño { get => tamaño; set => tamaño = value; }
        public float Precio { get => precio; set => precio = value; }
        public bool Estado { get => estado; set => estado = value; }

        public float ValorDelInmueble()
        {
            float valor;
            if (TipoDeOperacion == Convert.ToString((Operacion)1))
            {
                valor = Precio * (float)(1.21 + 0.10) + 10000;
            }
            else
            {
                valor = Precio * (float)(0.02 + 0.005);
            }
            return valor;
        }
    }
}
