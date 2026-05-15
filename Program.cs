using System;

namespace Ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jugarOtraVez = true;

            while (jugarOtraVez)
            {
                // 1. PEDIR CATEGORÍA
                string categoria = ConsolaUI.PedirCategoria();

                // 2. CREAR REPOSITORIO CON CATEGORÍA
                var repositorio = new PalabrasEnMemoria(categoria);

                // 3. CREAR MOTOR Y UI
                var motor = new MotorAhorcado(repositorio);
                var ui = new ConsolaUI(motor);

                Console.WriteLine("=== AHORCADO ===");

                // 4. BUCLE DEL JUEGO
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

                // 5. RESULTADO FINAL
                ui.MostrarTablero();

                if (motor.Ganado())
                    ui.MostrarMensaje("\n¡Ganaste! 🎉");
                else
                    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

                // 6. REINICIO
                jugarOtraVez = ui.PreguntarOtraVez(); 
            }

            Console.WriteLine("Gracias por jugar 👋");
        }
    }
}