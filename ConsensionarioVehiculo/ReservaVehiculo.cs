using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsensionarioVehiculo
{
    public class ReservaVehiculo
    {
       
        public Vehiculo Vehiculo { get; set; }
        public int Dias { get; set; }
        public double CostoTotal { get; set; }

       public ReservaVehiculo(Vehiculo vehiculo, int dias, double costoTotal)
       {
           Vehiculo = vehiculo;
           Dias = dias;
           CostoTotal = costoTotal;
       }

        public void MostrarReserva()
        {
            Console.WriteLine($"Vehículo: {Vehiculo.Modelo}, Días reservados: {Dias}, Costo total: {CostoTotal:C}");
        }
    }
}  


