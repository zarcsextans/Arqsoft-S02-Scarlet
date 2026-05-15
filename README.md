# Actualización de README

# Juego del Ahorcado

## Introducción

Este proyecto consiste en el desarrollo de un juego de Ahorcado en consola utilizando C# y programación orientada a objetos. El objetivo principal de la actividad fue aplicar principios de diseño de software y refactorización, separando responsabilidades en distintas clases para lograr un código más limpio, reutilizable y mantenible.

Además, el sistema incorpora mejoras funcionales como pistas dinámicas, categorías de palabras y una estructura basada en inyección de dependencias, lo que permite un código más limpio, escalable y mantenible.

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

<img width="912" height="527" alt="Captura de pantalla 2026-05-15 164840" src="https://github.com/user-attachments/assets/5ecf9841-c00d-478b-9d11-e5e7905b5270" />

# 5 refactor: extraer ConsolaUI

ConsolaUI no contiene lógica del juego, únicamente se encarga de la interacción con el usuario, cumpliendo el principio de responsabilidad única (SRP).

Qué contiene:
Interfaz de usuario en consola:
ConsolaUI

Responsabilidades:
Mostrar tablero
Pedir letras
Mostrar mensajes

<img width="948" height="625" alt="Captura de pantalla 2026-05-15 165829" src="https://github.com/user-attachments/assets/728b8cb3-2393-40a2-97aa-77a92e1efb31" />

# 6 refactor: limpiar Program.cs con inyección de dependencias

Program.cs actúa únicamente como punto de entrada del sistema, realizando la inyección de dependencias y delegando la lógica a las clases correspondientes, cumpliendo el principio de inversión de dependencias (DIP).

Qué contiene:
Program.cs solo coordina objetos:
var repositorio = new PalabrasEnMemoria();
var motor = new MotorAhorcado(repositorio);
var ui = new ConsolaUI(motor);

Mejora:
Se aplica inyección manual de dependencias
Código más limpio y modular

<img width="941" height="633" alt="Captura de pantalla 2026-05-15 170539" src="https://github.com/user-attachments/assets/7b7ffef2-679b-49c9-bfc2-5d2c6ddef073" />


# 7 feat: agregar pistas al ahorcado (clase dios vs refactorizado)

Se implementa la funcionalidad de pistas en el ahorcado. La lógica se encuentra en el MotorAhorcado y la presentación en ConsolaUI, activándose cuando los intentos restantes son menores o iguales a 3.

Qué contiene:
Nueva funcionalidad de pista:
public bool MostrarPista => _intentosRestantes <= 3;
UI muestra pista:
Pista: la palabra empieza con 'A'
if (_motor.MostrarPista)
    Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");

# 8 feat: agregar categorías de palabras (tarea - versión refactorizada)

Se implementa un sistema de categorías de palabras. El usuario selecciona una categoría al iniciar el juego y el repositorio devuelve palabras diferentes según la selección, permitiendo mayor flexibilidad y escalabilidad.

Qué contiene:
Selección de categoría:
Arquitectura
POO
.NET
Palabras dinámicas según categoría:
new PalabrasEnMemoria(categoria);

Mejora:
Juego más dinámico
Mayor escalabilidad
Extensible sin tocar Motor

<img width="643" height="441" alt="Captura de pantalla 2026-05-15 171519" src="https://github.com/user-attachments/assets/3f02365e-1ffe-461a-b8c2-067683b1f115" />


<img width="647" height="527" alt="Captura de pantalla 2026-05-15 171415" src="https://github.com/user-attachments/assets/682f2e4e-d381-4584-a4f9-c42de65bb162" />
