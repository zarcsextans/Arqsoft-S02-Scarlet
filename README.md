# Viborita Console Game
---
## Descripción

Este proyecto es un juego clásico de Viborita (Snake) desarrollado en C# utilizando consola, al mismo tiempo igual puedes elegir jugar ahorcado.

El objetivo del juego es controlar la serpiente, comer la comida y aumentar la puntuación sin chocar con las paredes ni con el propio cuerpo.

El proyecto forma parte de un ejercicio académico para practicar programación orientada a objetos y principios de arquitectura de software.

# Funcionalidades

Movimiento de la serpiente con flechas del teclado
Generación aleatoria de comida
Crecimiento de la serpiente al comer
Sistema de puntuación
Detección de colisiones (paredes y cuerpo)
Condición de victoria al alcanzar cierto puntaje
Opción de salir del juego con tecla Q

# Arquitectura del proyecto

El proyecto está separado en capas para mejorar la organización del código:

MotorViborita: lógica del juego (movimiento, colisiones, comida)
ConsolaUIViborita: interfaz de usuario en consola
Program.cs: menú principal y control del flujo del juego

# Controles
⬆️ Flecha arriba: mover arriba
⬇️ Flecha abajo: mover abajo
⬅️ Flecha izquierda: mover izquierda
➡️ Flecha derecha: mover derecha
Q: salir del juego

# Objetivo del juego

Comer comida (*) para aumentar puntos
Evitar chocar con paredes o contigo mismo
Alcanzar la puntuación objetivo para ganar

# Estructura del proyecto
Proyecto
│
├── MotorViborita.cs
├── ConsolaUIViborita.cs
├── Program.cs
└── IMotorJuego.cs

# Capturas de los juegos

<img width="1327" height="722" alt="Captura de pantalla 2026-05-15 193916" src="https://github.com/user-attachments/assets/e8f7dc4c-4e1c-4260-807c-9bd6672ad2e3" />

<img width="1205" height="648" alt="Captura de pantalla 2026-05-15 194038" src="https://github.com/user-attachments/assets/3186721b-acad-4ab0-9e70-5f720a31959d" />

<img width="1447" height="816" alt="Captura de pantalla 2026-05-15 174533" src="https://github.com/user-attachments/assets/0d5fd0cc-21e2-4e8d-996c-3718eb7e3109" />




## Clausula de IA

Este proyecto Yo Scarlet Angelina Ruelas Cardeña he utilizado herramientas de inteligencia artificial como apoyo durante su desarrollo, principalmente para:

Comprender conceptos de programación y arquitectura de software
Mejorar la redacción de documentación (README y ADR)
Recibir guía en la organización del proyecto y buenas prácticas (SOLID y separación por capas)
Resolver dudas puntuales durante el desarrollo

La inteligencia artificial se la utilicé únicamente como herramienta de apoyo académico.
