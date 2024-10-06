using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsensionarioVehiculo
{
    // Método de extensión para formatear y mostrar la información del vehículo
    public static class VehiculoExtension
    {
        public static void MostrarInfoVehiculo(this Vehiculo vehiculo)
        {
            Console.WriteLine("Modelo: {0}", vehiculo.Modelo);
            Console.WriteLine("Precio por día: {0:C}", vehiculo.PrecioPorDia);
           
        }

  
    }

    // Método estática para calcular el total de la reserva
    public static class CalcularReserva
    {
        public static double CalcularCostoTotal(Vehiculo vehiculo, int dias)
        {
            return vehiculo.PrecioPorDia * dias;
        }
    }


}
