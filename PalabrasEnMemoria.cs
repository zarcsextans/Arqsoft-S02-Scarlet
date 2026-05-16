using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly List<string> _palabras;
        private readonly Random _random = new();

        public PalabrasEnMemoria(string categoria)
        {
            categoria ??= "";

            _palabras = categoria.ToLower() switch
            {
                "arquitectura" => new List<string>
                {
                    "arquitectura",
                    "componente",
                    "dependencia",
                    "acoplamiento"
                },

                "poo" => new List<string>
                {
                    "polimorfismo",
                    "encapsulamiento",
                    "herencia",
                    "clase"
                },

                ".net" => new List<string>
                {
                    "namespace",
                    "interfaz",
                    "delegado",
                    "middleware"
                },

                _ => new List<string>
                {
                    "arquitectura"
                }
            };
        }

        public string ObtenerPalabraAleatoria()
        {
            return _palabras[_random.Next(_palabras.Count)];
        }
    }
}