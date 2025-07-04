# 🍗 KFC Backend API Documentation

This document describes all available endpoints for the KFC Backend Application built with ASP.NET MVC (.NET Framework) and MySQL.

---

## 📌 Base URL

```
https://localhost:44324/
```

---

## 📂 UserController

### GET /User/Index
Returns a list of all users.

### POST /User/Create
Creates a new user.

Request Body:
```json
{
  "Name": "John Doe",
  "Email": "john@example.com",
  "TelNum": "555123456",
  "Password": "secret"
}
```

### POST /User/OrderProduct
Places a new order by user.

Request Body:
```json
{
  "userId": 1,
  "productId": 2,
  "quantity": 1,
  "restaurantId": 1
}
```

### POST /User/Delete
Deletes a user by ID.

Request Body:
```json
{
  "id": 1
}
```

---

## 📂 ManagerController

### GET /Manager/Index
Returns a list of all managers.

### POST /Manager/Create
Creates a new manager.

Request Body:
```json
{
  "Name": "Giorgi M",
  "Email": "manager@kfc.com",
  "TelNum": "555000000",
  "Password": "adminpass"
}
```

### POST /Manager/AddProduct
Adds a new product.

Request Body:
```json
{
  "Name": "Zinger Burger",
  "Price": 9.99,
  "Description": "Spicy chicken burger"
}
```

### POST /Manager/DeleteProduct
Deletes a product by ID.

Request Body:
```json
{
  "productId": 2
}
```

### POST /Manager/Delete
Deletes a manager by ID.

Request Body:
```json
{
  "id": 1
}
```

---

## 📂 StaffController

### GET /Staff/Index
Returns all staff members.

### POST /Staff/Create
Creates a new staff member.

Request Body:
```json
{
  "Name": "Lela",
  "Email": "lela@kfc.com",
  "TelNum": "555987654",
  "Password": "staffpass",
  "RestaurantId": 1
}
```

### POST /Staff/PrepareOrder
Marks an order as Prepared.

Request Body:
```json
{
  "orderId": 3
}
```

### POST /Staff/DeleteOrder
Deletes an order.

Request Body:
```json
{
  "orderId": 3
}
```

### POST /Staff/Delete
Deletes a staff member.

Request Body:
```json
{
  "id": 2
}
```

---

## 📂 OrderController

### GET /Order/Index
Returns all orders.

### POST /Order/MakeOrder
Creates a new order.

Request Body:
```json
{
  "UserId": 1,
  "ProductId": 2,
  "RestaurantId": 1,
  "Quantity": 2
}
```

### POST /Order/CancelOrder
Marks an order as Canceled.

Request Body:
```json
{
  "id": 5
}
```

### POST /Order/Delete
Permanently deletes an order.

Request Body:
```json
{
  "id": 5
}
```

---

## 📂 RestaurantController

### GET /Restaurant/Index
Returns all restaurants.

### POST /Restaurant/Create
Creates a new restaurant.

Request Body:
```json
{
  "Name": "KFC Rustaveli",
  "Address": "Rustaveli Ave",
  "TelNum": "0322000000",
  "WorkingHours": "10:00 - 22:00"
}
```

### POST /Restaurant/Delete
Deletes a restaurant by ID.

Request Body:
```json
{
  "id": 1
}
```

---

## 📂 AuthController

### POST /Auth/Register
Registers a new user.

Request Body:
```json
{
  "Name": "Ana",
  "Email": "ana@example.com",
  "TelNum": "555123000",
  "Password": "mypassword"
}
```

### POST /Auth/Login
Logs in a user.

Request Body:
```json
{
  "email": "ana@example.com",
  "password": "mypassword"
}
```

---

## 🔐 Notes
- All POST endpoints expect application/json content type.
- All responses are JSON.