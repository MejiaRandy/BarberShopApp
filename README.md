# 💈 BarberShop App

Una aplicación completa para la gestión de barberías, desarrollada como proyecto académico en la asignatura **Introducción a la Ingeniería de Software**. La **BarberShop App** permite a clientes, barberos y administradores interactuar en un entorno organizado y funcional para la reserva, gestión y control de citas.

---

## 🎯 Objetivo

Brindar una plataforma moderna y eficiente que facilite:
- A los **clientes**, reservar y gestionar sus citas.
- A los **barberos**, organizar su agenda diaria.
- A los **administradores**, gestionar usuarios y supervisar el funcionamiento general del sistema.

---

## 🚀 Funcionalidades Principales

### 🔐 Autenticación
- Inicio de sesión para todos los usuarios.
- Registro de nuevos clientes con validaciones (campos obligatorios, contraseñas coincidentes, usuario único).

### 📊 Dashboard
- **Administrador**: estadísticas globales (citas completadas, pendientes y total de usuarios).
- **Barbero**: resumen diario de citas completadas y pendientes.

### 👤 Gestión de Usuarios (Administrador)
- Visualización y gestión de todos los usuarios registrados.
- Registro manual de nuevos usuarios (Cliente, Barbero o Administrador).

### 📅 Gestión de Citas
- **Administrador**: visualiza y elimina cualquier cita del sistema.
- **Barbero**: visualiza sus citas pendientes y puede marcarlas como completadas.
- **Cliente**:
  - Consulta y cancela sus citas.
  - Crea nuevas citas con barberos disponibles (verificando conflictos de horario).
