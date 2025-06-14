# ASP.NET Core Web API with Serilog Logging

This is a basic ASP.NET Core Web API project demonstrating:

- RESTful API with CRUD operations on `Product`
- Middleware pipeline with logging
- Global exception handling
- Serilog-based structured logging (console and file)

---

## 🚀 Features

- `GET`, `POST`, `PUT`, and `DELETE` endpoints for managing products
- Middleware logging with a scoped service
- Global error handling for unhandled exceptions
- Serilog logging to both **console** and **file** (logs/logs.txt)

---

## 🛠 Technologies Used

- .NET 7+ / .NET 6+
- ASP.NET Core
- Serilog
- C#

---

## 📦 API Endpoints

Base URL: `http://localhost:5000/api/products`

| Method | Endpoint               | Description             |
|--------|------------------------|-------------------------|
| GET    | `/api/products`        | Get all products        |
| GET    | `/api/products/{id}`   | Get a product by ID     |
| POST   | `/api/products`        | Create a new product    |
| PUT    | `/api/products/{id}`   | Update an existing one  |
| DELETE | `/api/products/{id}`   | Delete a product        |

---

## 📄 Sample Request (POST)

```json
POST /api/products
Content-Type: application/json

{
  "name": "Laptop",
  "price": 999.99,
  "description": "A powerful laptop"
}
