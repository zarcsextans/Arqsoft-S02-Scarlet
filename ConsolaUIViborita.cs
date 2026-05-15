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
            int index = 0;

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.Write("|");

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);

                    if (cuerpoArray.First() == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@"); // cabeza
                        Console.ResetColor();
                    }
                    else if (cuerpoArray.Contains(pos))
                    {
                        // color dinámico por segmento
                        int cuerpoIndex = cuerpoArray.IndexOf(pos);
                        var color = _coloresCuerpo[cuerpoIndex % _coloresCuerpo.Length];

                        Console.ForegroundColor = color;
                        Console.Write("o");
                        Console.ResetColor();
                    }
                    else if (_motor.Comida == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*"); // comida
                        Console.ResetColor();
                    }
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