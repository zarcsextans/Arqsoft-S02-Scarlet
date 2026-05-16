using System;
using System.Threading;
using Ahorcado;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("¿Qué juego quieres jugar?");
            Console.WriteLine("1 - Ahorcado");
            Console.WriteLine("2 - Viborita");
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
                Console.WriteLine("Opción inválida");
            }

            Console.Write("\n¿Volver al menú? (s/n): ");

            if (Console.ReadLine()?.ToLower() != "s")
                break;
        }
    }

    static void JugarAhorcado()
    {
        Console.Clear();

        Console.WriteLine("Categorías:");
        Console.WriteLine("1 - arquitectura");
        Console.WriteLine("2 - poo");
        Console.WriteLine("3 - .net");
        Console.Write("Elige categoría: ");

        string opcion = Console.ReadLine();

        string categoria = opcion switch
        {
            "1" => "arquitectura",
            "2" => "poo",
            "3" => ".net",
            _ => "arquitectura"
        };

        var repo = new PalabrasEnMemoria(categoria);
        var motor = new MotorAhorcado(repo);
        var ui = new ConsolaUI(motor);

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
            ui.MostrarMensaje("\n¡Ganaste!");
        else
            ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

        Console.WriteLine("\nPresiona ENTER para continuar...");
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

            Thread.Sleep(150);
        }

        ui.MostrarTablero();

        if (motor.Ganado())
            ui.MostrarMensaje("\n¡Ganaste!");
        else
            ui.MostrarMensaje("\nGame Over");

        Console.CursorVisible = true;

        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }
}