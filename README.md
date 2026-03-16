# ABC Microservices - Plataforma de Gestión de Pedidos

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blueviolet" alt=".NET 8.0">
  <img src="https://img.shields.io/badge/Angular-17+-red" alt="Angular 17+">
  <img src="https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white" alt="Docker">
  <img src="https://img.shields.io/badge/MongoDB-47A248?style=flat&logo=mongodb&logoColor=white" alt="MongoDB">
  <img src="https://img.shields.io/badge/License-MIT-green" alt="License">
</p>

---

## 📋 Descripción General del Proyecto

**ABC Microservices** es un proyecto de arquitectura basada en microservicios que representa la migración de una plataforma monolítica de gestión de pedidos hacia un modelo moderno y escalable. Este MVP técnico demuestra los fundamentos de esta transición, implementando una solución fullstack con las mejores prácticas de desarrollo.

### Objetivos del Proyecto

- ✅ Demostrar arquitectura de microservicios con comunicación REST
- ✅ Implementar un frontend moderno con Angular
- ✅ Integrar API pública externa
- ✅ Dockerización completa de todos los componentes
- ✅ Sistema de autenticación y autorización basado en roles

---

## 🏗️ Arquitectura del Sistema

### Diagrama de Arquitectura

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                           FRONTEND (Angular 17+)                            │
│                    Puerto: 4200    │    nginx en producción                │
└─────────────────────────────────────────────────────────────────────────────┘
                                      │
                                      ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                          API GATEWAY (nginx)                                 │
│                    Puerto: 80 (expuesto como 4200)                         │
└─────────────────────────────────────────────────────────────────────────────┘
                                      │
        ┌─────────────────────────────┼─────────────────────────────┐
        │                             │                             │
        ▼                             ▼                             ▼
┌───────────────────┐   ┌───────────────────┐   ┌───────────────────┐
│  USUARIOS SERVICE │   │  PEDIDOS SERVICE  │   │  PAGOS SERVICE    │
│   Puerto: 5001    │   │   Puerto: 5002    │   │   Puerto: 5003    │
│   ASP.NET Core    │   │   ASP.NET Core    │   │   ASP.NET Core    │
│   (Puerto:8080)   │   │   (Puerto:8080)   │   │   (Puerto:8080)   │
└─────────┬─────────┘   └─────────┬─────────┘   └─────────┬─────────┘
          │                       │                       │
          └───────────────────────┼───────────────────────┘
                                  │
                                  ▼
                  ┌───────────────────────────────┐
                  │      MONGODB DATABASE         │
                  │       Puerto: 27017           │
                  │   (usersdb, ordersdb,         │
                  │    paymentsdb)                │
                  └───────────────────────────────┘
```

### Microservicios Definidos

| Servicio | Tecnología | Puerto | Función |
|----------|------------|--------|---------|
| **UsersService** | ASP.NET Core 8.0 | 5001 | Gestión de usuarios y autenticación |
| **OrdersService** | ASP.NET Core 8.0 | 5002 | Administración de pedidos |
| **PaymentsService** | ASP.NET Core 8.0 | 5003 | Procesamiento de pagos |

### Modelo de Comunicación

- **REST API**: Comunicación síncrona entre servicios y con el frontend
- **JSON**: Formato de intercambio de datos
- **Endpoints Base**:
  - `http://localhost:5001/api` - Usuarios
  - `http://localhost:5002/api` - Pedidos
  - `http://localhost:5003/api` - Pagos

### Selección de Bases de Datos

| Servicio | Base de Datos | Justificación |
|----------|---------------|----------------|
| **Users** | MongoDB | Flexibilidad para almacenar perfiles de usuario con diferentes estructuras |
| **Orders** | MongoDB | Documents jerárquicos ideales para pedidos con líneas de detalle |
| **Payments** | MongoDB | Transacciones flexibles con historial de estados |

**Justificación de MongoDB**:
- Esquema flexible para evolución de modelos de datos
- Alta escalabilidad horizontal
- Excelente rendimiento para operaciones de lectura/escritura
- Comunidad activa y soporte robusto en contenedores Docker

---

## 💻 Decisiones Técnicas

### Frontend (Angular 17+)

| Decisión | Justificación |
|----------|---------------|
| **Angular 17+** | Framework maduro con soporte completo para aplicaciones empresariales. Inyección de dependencias nativa, modularidad y strongly-typed |
| **SSR con Angular Universal** | Mejora el SEO y tiempo de carga inicial |
| **CSS Puro (sin frameworks)** | Demuestra habilidades técnicas, menor bundle size, mayor control sobre el diseño |
| **NgRx para estado** | Gestión predictible del estado de la aplicación |
| **Guardias de rutas** | Seguridad a nivel de navegación para rutas protegidas |
| **Dark/Light Mode** | Mejora la experiencia de usuario con persistencia de preferencia |

### Backend (.NET 8.0)

| Decisión | Justificación |
|----------|---------------|
| **ASP.NET Core 8.0** | Framework multiplataforma, alto rendimiento, soporte nativo a Kubernetes |
| **Minimal APIs** | Código limpio y moderno, menor sobrecarga |
| **Swagger/OpenAPI** | Documentación automática de endpoints |
| **Health Checks** | Monitoreo de disponibilidad de servicios |
| **Docker multi-stage** | Imágenes optimizadas y seguras |

### Infraestructura

| Decisión | Justificación |
|----------|---------------|
| **Docker Compose** | Orquestación simple para entorno de desarrollo |
| **nginx como reverse proxy** | Balanceo de carga, caché, compresión |
| **Redes bridge** | Aislamiento seguro entre servicios |

---

## 🚀 Pasos para Ejecutar el Sistema

### Prerrequisitos

- [Docker Desktop](https://www.docker.com/products/docker-desktop) instalado
- [Git](https://git-scm.com/) instalado
- Puerto 4200, 5001, 5002, 5003 y 27017 disponibles

### Instrucciones de Ejecución

El proyecto está configurado para funcionar de dos maneras:

#### Opción 1: Ejecución LOCAL (Recomendado - Funciona inmediatamente)

```bash
# Clonar el repositorio
git clone https://github.com/tu-usuario/ABC.Microservices.git
cd ABC.Microservices

# Ejecutar (construye y levanta todos los servicios)
docker-compose up -d
```

#### Opción 2: Docker Hub (Requiere haber subido imágenes primero)

```bash
# 1. Construir y hacer push a Docker Hub
docker-compose build
docker-compose push

# 2. Ejecutar usando imágenes de Docker Hub
docker-compose -f docker-compose.yml -f docker-compose.hub.yml up -d
```

#### 4. Acceder a los Servicios

#### 3. Verificar los Servicios

```bash
# Ver estado de los contenedores
docker-compose ps

# Ver logs en tiempo real
docker-compose logs -f
```

#### 4. Acceder a los Servicios

| Servicio | URL |
|----------|-----|
| **Frontend** | http://localhost:4200 |
| **Users Service** | http://localhost:5001/swagger |
| **Orders Service** | http://localhost:5002/swagger |
| **Payments Service** | http://localhost:5003/swagger |
| **MongoDB** | localhost:27017 |

### Credenciales de Prueba

| Rol | Usuario | Contraseña |
|-----|---------|------------|
| **Administrador** | admin | admin123 |
| **Usuario** | user | user123 |

### Comandos Útiles

```bash
# Detener todos los servicios
docker-compose down

# Eliminar volúmenes también
docker-compose down -v

# Reconstruir un servicio específico
docker-compose build frontend
docker-compose up -d frontend
```

---

## 🔌 API Pública Integrada

### JSONPlaceholder API

- **URL Base**: `https://jsonplaceholder.typicode.com`
- **Endpoints utilizados**:
  - `GET /posts` - Lista de publicaciones
  - `GET /posts/{id}` - Publicación individual
  - `GET /users` - Lista de usuarios
  - `GET /comments` - Comentarios

### Documentación

Para más información, visite: [JSONPlaceholder Documentation](https://jsonplaceholder.typicode.com/)

---

## 📱 Capturas del Frontend

### Pantalla de Login

```
┌─────────────────────────────────────────┐
│  ╔═══════════════════════════════════╗  │
│  ║         ABC Microservices         ║  │
│  ║            🛒  🛒  🛒              ║  │
│  ╠═══════════════════════════════════╣  │
│  ║  Usuario:                         ║  │
│  ║  [________________________]       ║  │
│  ║                                   ║  │
│  ║  Contraseña:                      ║  │
│  ║  [________________________]       ║  │
│  ║                                   ║  │
│  ║      [ INICIAR SESIÓN ]          ║  │
│  ╚═══════════════════════════════════╝  │
└─────────────────────────────────────────┘
```

### Dashboard - Vista Administrador

```
┌──────────────────────────────────────────────────────────┐
│ ━━━━━━━━━━━ ABC Microservices    [🌙] [Logout]          │
├────────────┬─────────────────────────────────────────────┤
│            │                                             │
│ 📊 Dashboard                                      [Admin] │
│ ──────────│                                             │
│ 👥 Usuarios   ┌─────────────────────────────────────┐   │
│ ──────────│   │  BIENVENIDO, ADMINISTRADOR          │   │
│ 📦 Pedidos    │                                     │   │
│ ──────────│   │  [Tarjetas de estadísticas]         │   │
│ 💳 Pagos      │                                     │   │
│ ──────────│   │  [Gráficos de actividad]            │   │
│ 🌐 Datos API │                                     │   │
│ ──────────│   └─────────────────────────────────────┘   │
│            │                                             │
└────────────┴─────────────────────────────────────────────┘
```

### Menú Lateral - Diferencia por Rol

**Administrador** (Acceso total):
- Dashboard
- Usuarios
- Pedidos
- Pagos
- Datos API

**Usuario** (Acceso limitado):
- Dashboard
- Usuarios
- Pedidos
- *(No visible: Pagos, Datos API)*

### Modo Oscuro/Claro

```
Modo Claro:                              Modo Oscuro:
┌─────────────────────┐                  ┌─────────────────────┐
│  ████████████████  │                  │  ░░░░░░░░░░░░░░░░░  │
│  │ ABC │ Sidebar  │ │                  │  │ ABC │ Sidebar  │ │
│  │     │          │ │                  │  │     │          │ │
│  │     │ Dashboard│ │                  │  │     │ Dashboard│ │
│  │     │ Users    │ │                  │  │     │ Users    │ │
│  └─────┴──────────┘ │                  │  └─────┴──────────┘ │
└─────────────────────┘                  └─────────────────────┘
```

---

## 📁 Estructura del Repositorio

```
ABC.Microservices/
├── ABC_FrontEnd/                    # Aplicación Angular 17+
├── backend/                         # Microservicios .NET 8.0
│   └── src/
│       ├── UsersService.Api/
│       ├── OrdersService.API/
│       └── PaymentsService.API/
│
├── docker-compose.yml              # Build y ejecución LOCAL
├── docker-compose.hub.yml          # Para usar imágenes de Docker Hub
├── README.md                       # Este archivo
└── .gitignore
```

---

## 📝 Endpoints de los Microservicios

### Users Service (Puerto 5001)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/health` | Estado de salud del servicio |
| GET | `/status` | Información detallada del estado |
| GET | `/api/users` | Listar todos los usuarios |
| GET | `/api/users/{id}` | Obtener usuario por ID |
| POST | `/api/users` | Crear nuevo usuario |
| PUT | `/api/users/{id}` | Actualizar usuario |
| DELETE | `/api/users/{id}` | Eliminar usuario |

### Orders Service (Puerto 5002)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/health` | Estado de salud del servicio |
| GET | `/status` | Información detallada del estado |
| GET | `/api/orders` | Listar todos los pedidos |
| GET | `/api/orders/{id}` | Obtener pedido por ID |
| POST | `/api/orders` | Crear nuevo pedido |
| PUT | `/api/orders/{id}` | Actualizar pedido |
| DELETE | `/api/orders/{id}` | Eliminar pedido |

### Payments Service (Puerto 5003)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/health` | Estado de salud del servicio |
| GET | `/status` | Información detallada del estado |
| GET | `/api/payments` | Listar todos los pagos |
| GET | `/api/payments/{id}` | Obtener pago por ID |
| POST | `/api/payments` | Crear nuevo pago |
| PUT | `/api/payments/{id}` | Actualizar pago |
| DELETE | `/api/payments/{id}` | Eliminar pago |

---

## 🔧 Desarrollo Local (Opcional - Requiere .NET y Node.js)

Si deseas ejecutar sin Docker o modificar el código:

```bash
cd ABC_FrontEnd
npm install
npm start
# Acceder a http://localhost:4200
```

### Backend

```bash
cd backend/src/UsersService.Api
dotnet run
# Puerto 5001

cd backend/src/OrdersService.API
dotnet run
# Puerto 5002

cd backend/src/PaymentsService.API
dotnet run
# Puerto 5003
```

---

## 📦 Tecnologías Utilizadas

### Frontend
- **Angular 17+** - Framework de desarrollo web
- **TypeScript** - Lenguaje de programación
- **RxJS** - Programación reactiva
- **CSS3** - Estilos (sin frameworks)

### Backend
- **.NET 8.0** - Framework de desarrollo
- **ASP.NET Core** - Framework web
- **Entity Framework Core** - ORM (opcional)
- **MongoDB Driver** - Conexión a MongoDB

### Infraestructura
- **Docker** - Containerización
- **Docker Compose** - Orquestación
- **nginx** - Servidor web y reverse proxy
- **MongoDB** - Base de datos NoSQL

---

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor, lee las guías de contribución antes de enviar un Pull Request.

1. Fork el proyecto
2. Crea tu rama de características (`git checkout -b feature/AmazingFeature`)
3. Commitea tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo `LICENSE` para más información.

---

## 📧 Contacto

Para preguntas o sugerencias, por favor abre un issue en el repositorio de GitHub.

---

<p align="center">
  <strong>ABC Microservices © 2026</strong><br>
  Construido con ❤️ y ☕
</p>
