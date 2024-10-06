using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsensionarioVehiculo
{
    public class Vehiculo
    {
        // Propiedades de Vehículo
        public string Modelo { get; set; }
        public double PrecioPorDia { get; set; } 

        // Clase interna Descuento para gestionar descuentos
        public class Descuento
        {
            public static double AplicarDescuento(double precio, double porcentajeDescuento)
            {
                return precio - (precio * (porcentajeDescuento / 100));
            }
        }
    }

  

}

