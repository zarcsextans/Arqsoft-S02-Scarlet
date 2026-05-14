using System;
using System.Collections.Generic;
using System.Text;

namespace Juego_ahorcado
{
    internal interface IMotorJuego
    {
        bool Ganado();
        bool Perdido();
    }
}
