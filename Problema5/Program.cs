using System;

// Clase: Servomotor
class Servomotor
{
    // Propiedad: posición actual del servo (grados)
    public double PosicionActual { get; set; }

    // Propiedad: posición objetivo del servo (grados)
    public double PosicionObjetivo { get; set; }

    // Método: verifica que una posición esté dentro del intervalo permitido [0, 180]
    // Parámetro: posicion (grados)
    public static bool PosicionValida(double posicion)
    {
        return posicion >= 0 && posicion <= 180;
    }

    // Método: calcula el desplazamiento absoluto entre la posición actual y la objetivo (grados)
    public double CalcularDesplazamiento()
    {
        return Math.Abs(PosicionObjetivo - PosicionActual);
    }

    // Método: determina el tipo de movimiento según las posiciones
    public string DeterminarMovimiento()
    {
        if (PosicionObjetivo > PosicionActual)
        {
            return "Movimiento hacia una posición mayor";
        }
        else if (PosicionObjetivo < PosicionActual)
        {
            return "Movimiento hacia una posición menor";
        }
        else
        {
            return "No hay movimiento";
        }
    }
}

class Program
{
    // Lee una posición y la solicita nuevamente mientras esté fuera de 0° a 180°
    static double LeerPosicion(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor) && Servomotor.PosicionValida(valor))
            {
                return valor;
            }
            Console.WriteLine("Valor inválido. Debe ser un número entre 0° y 180°.");
        }
    }

    static void Main()
    {
        Console.WriteLine("=== Control de servomotor (0° a 180°) ===");

        // Objeto: servo
        Servomotor servo = new Servomotor();

        servo.PosicionActual = LeerPosicion("Posición actual (°): ");
        servo.PosicionObjetivo = LeerPosicion("Posición objetivo (°): ");

        Console.WriteLine();
        Console.WriteLine($"Posición actual: {servo.PosicionActual:F1}°");
        Console.WriteLine($"Posición objetivo: {servo.PosicionObjetivo:F1}°");
        Console.WriteLine($"Desplazamiento absoluto: {servo.CalcularDesplazamiento():F1}°");
        Console.WriteLine(servo.DeterminarMovimiento());

        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }
}