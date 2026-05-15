# Actualización de README

# Juego del Ahorcado

## Introducción

Este proyecto consiste en el desarrollo de un juego de Ahorcado en consola utilizando C# y programación orientada a objetos. El objetivo principal de la actividad fue aplicar principios de diseño de software y refactorización, separando responsabilidades en distintas clases para lograr un código más limpio, reutilizable y mantenible.

Durante el desarrollo se implementaron conceptos como interfaces, abstracciones e inyección de dependencias, organizando la lógica del juego, la interfaz de usuario y el repositorio de palabras en componentes independientes

# 1 feat: juego ahorcado base (clase dios)

Estado inicial del proyecto:

Toda la lógica en una sola clase (Juego.cs)
UI + lógica + datos mezclados
Difícil de mantener o escalar 

# 2 docs: identificar violaciones SOLID en Juego.cs

Antes (clase dios):
SRP → una clase hace todo
OCP → no es extensible sin modificar
DIP → depende de implementaciones concretas

Juego.cs hacía TODO:
lógica del juego
consola (UI)
manejo de palabras

MotorAhorcado

validar letras
controlar intentos
saber si gana o pierde

ConsolaUI

mostrar tablero
pedir letras
mostrar mensajes

PalabrasEnMemoria

ObtenerPalabraAleatoria()

# 3 refactor: separar IRepositorioPalabras y PalabrasEnMemoria

Se crea interfaz:
IRepositorioPalabras
Implementación:
PalabrasEnMemoria

Mejora:
Se desacopla el origen de palabras
Permite futuras extensiones (BD, API, etc.)

# 4 refactor: extraer MotorAhorcado

Qué contiene:
Lógica del juego separada en:
MotorAhorcado

Responsabilidades:
Validar letras
Controlar intentos
Determinar victoria o derrota