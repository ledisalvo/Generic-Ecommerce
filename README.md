# Generic Ecommerce API

Backend API para la gestión de clientes y pedidos de un comercio, desarrollada en **.NET 8** aplicando **Clean Architecture**, **CQRS** y **MediatR**.

El foco del proyecto está puesto en el modelado correcto del dominio, la separación de responsabilidades y la mantenibilidad del código.

---

## 🧱 Arquitectura

El proyecto sigue los principios de **Clean Architecture**, separando claramente cada capa:

```
src/
 ├── Generic_Ecommerce.Domain
 ├── Generic_Ecommerce.Application
 ├── Generic_Ecommerce.Infrastructure
 └── Generic_Ecommerce.API
tests/
 ├── Generic_Ecommerce.Domain.Tests
 └── Generic_Ecommerce.Application.Tests
```

### Capas

#### Domain
- Entidades de negocio (`Customer`, `Order`, `OrderItem`)
- Reglas e invariantes del dominio
- Sin dependencias externas
- Dominio no anémico y correctamente encapsulado

#### Application
- Casos de uso (Commands y Queries)
- Interfaces de repositorios
- DTOs
- Implementación de CQRS mediante **MediatR**
- No conoce detalles de infraestructura

#### Infrastructure
- Implementaciones de repositorios
- Entity Framework Core
- Configuración de mapeos y persistencia
- Acceso a base de datos

#### API
- Controllers REST
- Configuración de Dependency Injection
- Exposición de endpoints
- No contiene lógica de negocio

---

## 🔁 CQRS y MediatR

El proyecto utiliza **CQRS** separando:
- **Commands**: operaciones que modifican el estado
- **Queries**: operaciones de solo lectura

La comunicación entre la API y la capa Application se realiza mediante **MediatR**:

```csharp
await _mediator.Send(command);
```

Esto permite:
- Bajo acoplamiento
- Casos de uso explícitos
- Código fácil de testear y mantener

---

## 📌 Funcionalidades implementadas

### Clientes
- Crear cliente
- Obtener cliente por ID (incluye pedidos)
- Listar todos los clientes
- Listar pedidos de un cliente

### Pedidos
- Crear pedido para un cliente
- Obtener pedidos por cliente
- Pedido con múltiples ítems

---

## 🌐 Endpoints principales

### Clientes
- `POST /api/customers`
- `GET /api/customers/{id}`
- `GET /api/customers`
- `GET /api/customers/{id}/orders`

### Pedidos
- `POST /api/orders`

---

## 🧪 Testing

- Tests de dominio para validar invariantes
- Tests de Application para casos de uso
- Framework utilizado: **xUnit**

---

## 🗄 Persistencia

- Entity Framework Core
- Base de datos relacional
- Modelado con Aggregates y Owned Entities
- Colecciones encapsuladas utilizando backing fields

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos
- .NET 8 SDK
- SQL Server o SQLite (según configuración)

### Pasos
1. Clonar el repositorio
2. Configurar la cadena de conexión en `appsettings.json`
3. Ejecutar migraciones:
   ```bash
   dotnet ef database update
   ```
4. Levantar la API:
   ```bash
   dotnet run --project Generic_Ecommerce.API
   ```
5. Acceder a Swagger:
   ```
   https://localhost:{puerto}/swagger
   ```

---

## 📌 Decisiones técnicas destacadas

- Uso de Clean Architecture para desacoplar dominio y framework
- CQRS para claridad y separación de responsabilidades
- MediatR como orquestador de los casos de uso
- Dominio encapsulado (sin setters públicos innecesarios)
- EF Core adaptado al dominio y no al revés

---
