using System;
using Ahorcado;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("¿Qué juego quieres jugar?");
            Console.WriteLine("  1 — Ahorcado");
            Console.WriteLine("  2 — Viborita");
            Console.Write("Opción: ");

            var opcion = Console.ReadLine();

            if (opcion == "1")
            {
                JugarAhorcado();
            }
            else if (opcion == "2")
            {
                JugarViborita();
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.Write("\n¿Volver al menú principal? (s/n): ");
            if (Console.ReadLine()?.ToLower() != "s")
                break;
        }
    }

    static void JugarAhorcado()
    {
        var repositorio = new PalabrasEnMemoria();
        var motor = new MotorAhorcado(repositorio);
        var ui = new ConsolaUI(motor);

        Console.WriteLine("=== AHORCADO ===");

        while (!motor.Ganado() && !motor.Perdido())
        {
            ui.MostrarTablero();

            char letra = ui.PedirLetra();

            if (motor.LetraYaUsada(letra))
            {
                ui.MostrarMensaje("Ya usaste esa letra.");
                continue;
            }

            motor.RegistrarLetra(letra);
        }

        ui.MostrarTablero();

        if (motor.Ganado())
            ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
        else
            ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

        Console.Write("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }

    static void JugarViborita()
    {
        var motor = new MotorViborita();
        var ui = new ConsolaUIViborita(motor);

        Console.CursorVisible = false;

        while (!motor.Ganado() && !motor.Perdido())
        {
            ui.MostrarTablero();
            var tecla = ui.LeerTecla();

            if (tecla == ConsoleKey.Q)
                break;

            if (tecla != ConsoleKey.NoName)
                motor.CambiarDireccion(tecla);

            motor.Avanzar();
            System.Threading.Thread.Sleep(150);
        }

        ui.MostrarTablero();

        ui.MostrarMensaje(
            motor.Ganado()
                ? "\n¡Ganaste! Llegaste a 10 puntos."
                : "\nGame over."
        );

        Console.CursorVisible = true;

        Console.Write("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }
}