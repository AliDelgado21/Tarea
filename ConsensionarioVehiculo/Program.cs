using ConsensionarioVehiculo;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;
        Vehiculo vehiculo = null;
        double precioConDescuento = 0;
        List<ReservaVehiculo> reservas = new List<ReservaVehiculo>(); // Lista para almacenar las reservas

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("==== Sistema de Reserva de Vehículos ====");
            Console.WriteLine("1. Crear vehículo");
            Console.WriteLine("2. Aplicar descuento");
            Console.WriteLine("3. Calcular reserva");
            Console.WriteLine("4. Mostrar información del vehículo y reservas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ingrese el modelo del vehículo:");
                    string modelo = Console.ReadLine();

                    Console.WriteLine("Ingrese el precio por día del vehículo:");
                    double precio = double.Parse(Console.ReadLine());

                    vehiculo = new Vehiculo { Modelo = modelo, PrecioPorDia = precio };
                    precioConDescuento = 0;  // Reinicia el descuento cuando se crea un nuevo vehículo
                    Console.WriteLine("Vehículo creado exitosamente.");
                    break;

                case 2:
                    if (vehiculo == null)
                    {
                        Console.WriteLine("Primero debe crear un vehículo.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese el porcentaje de descuento a aplicar:");
                        double descuento = double.Parse(Console.ReadLine());
                        precioConDescuento = Vehiculo.Descuento.AplicarDescuento(vehiculo.PrecioPorDia, descuento);
                        Console.WriteLine("Descuento aplicado. Precio con descuento: {0:C}", precioConDescuento);
                    }
                    break;

                case 3:
                    if (vehiculo == null)
                    {
                        Console.WriteLine("Primero debe crear un vehículo.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese el número de días de la reserva:");
                        int dias = int.Parse(Console.ReadLine());

                        double precioFinal = (precioConDescuento > 0) ? precioConDescuento : vehiculo.PrecioPorDia;  // Usa el precio con descuento si existe
                        double costoTotal = CalcularReserva.CalcularCostoTotal(vehiculo, dias);
                        costoTotal = precioFinal * dias;

                        // Crear y guardar la reserva
                        ReservaVehiculo nuevaReserva = new ReservaVehiculo(vehiculo, dias, costoTotal);
                        reservas.Add(nuevaReserva); // Guardar la reserva en la lista
                        Console.WriteLine("Reserva realizada. Costo total: {0:C}", costoTotal);
                    }
                    break;

                case 4:
                    if (vehiculo == null)
                    {
                        Console.WriteLine("Primero debe crear un vehículo.");
                    }
                    else
                    {
                        Console.Clear();
                        vehiculo.MostrarInfoVehiculo();
                        if (precioConDescuento > 0)
                        {
                            Console.WriteLine("Precio con descuento: {0:C}", precioConDescuento);
                        }

                        // Mostrar las reservas guardadas
                        if (reservas.Count > 0)
                        {
                            Console.WriteLine("\n=== Reservas realizadas ===");
                            foreach (var reserva in reservas)
                            {
                                reserva.MostrarReserva(); // Mostrar cada reserva
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay reservas realizadas.");
                        }
                    }
                    break;

                case 5:
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        Console.WriteLine("Gracias por utilizar el sistema de reservas.");
    }
}

