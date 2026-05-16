using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        private readonly ConsoleColor[] _coloresCuerpo =
        {
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.Blue,
            ConsoleColor.DarkYellow,
            ConsoleColor.White
        };

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"=== VIBORITA === Puntos: {_motor.Puntos}");
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");

            var cuerpoArray = _motor.Cuerpo.ToList();

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.Write("|");

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    // Cabeza
                    if (cuerpoArray.First() == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                        Console.ResetColor();
                    }

                    // Cuerpo
                    else if (cuerpoArray.Contains(pos))
                    {
                        int index = cuerpoArray.IndexOf(pos);

                        Console.ForegroundColor =
                            _coloresCuerpo[index % _coloresCuerpo.Length];

                        Console.Write("o");
                        Console.ResetColor();
                    }

                    // Comida
                    else if (_motor.Comida == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                        Console.ResetColor();
                    }

                    // Espacio vacío
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.WriteLine("Flechas: mover | Q: salir");
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;

            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}