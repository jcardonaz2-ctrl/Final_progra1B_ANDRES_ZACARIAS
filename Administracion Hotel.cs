using System;
using System.Collections.Generic;
using System.Linq;

class Reserva
{
    public string Cliente;
    public int Habitacion;
    public int Noches;
    public double PrecioPorNoche;

    public Reserva(string cliente, int habitacion, int noches, double precioPorNoche)
    {
        Cliente = cliente;
        Habitacion = habitacion;
        Noches = noches;
        PrecioPorNoche = precioPorNoche;
    }

    public double CalcularCosto()
    {
        return Noches * PrecioPorNoche;
    }
}

class Hotel
{
    private List<Reserva> reservas = new List<Reserva>();

    public void RegistrarReserva(Reserva reserva)
    {
        reservas.Add(reserva);
    }

    public void ListarReservas()
    {
        Console.WriteLine("=== LISTA DE RESERVAS ===");

        foreach (Reserva r in reservas)
        {
            Console.WriteLine(
                $"Cliente: {r.Cliente} | Habitación: {r.Habitacion} | " +
                $"Noches: {r.Noches} | Precio por noche: Q{r.PrecioPorNoche} | " +
                $"Total: Q{r.CalcularCosto()}"
            );
        }
    }

    public double CalcularIngresoTotal()
    {
        return reservas.Sum(r => r.CalcularCosto());
    }

    public Reserva ReservaMayorDuracion()
    {
        return reservas.OrderByDescending(r => r.Noches).First();
    }
}

class Program
{
    static void Main()
    {
        Hotel hotel = new Hotel();

        // Reservas de ejemplo
        hotel.RegistrarReserva(new Reserva("Jose Cardona", 101, 3, 250));
        hotel.RegistrarReserva(new Reserva("Maria Lopez", 102, 5, 300));
        hotel.RegistrarReserva(new Reserva("Carlos Perez", 103, 2, 200));

        // Listar reservas
        hotel.ListarReservas();

        // Ingreso total
        Console.WriteLine("\n=== INGRESO TOTAL ===");
        Console.WriteLine($"Q{hotel.CalcularIngresoTotal()}");

        // Reserva de mayor duración
        Reserva mayor = hotel.ReservaMayorDuracion();

        Console.WriteLine("\n=== RESERVA DE MAYOR DURACIÓN ===");
        Console.WriteLine($"Cliente: {mayor.Cliente}");
        Console.WriteLine($"Habitación: {mayor.Habitacion}");
        Console.WriteLine($"Noches: {mayor.Noches}");
        Console.WriteLine($"Total: Q{mayor.CalcularCosto()}");
    }
}