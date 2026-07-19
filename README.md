# 📚 Library Management System

A simple **Console Application** built with **C#** to practice the fundamentals of **Object-Oriented Programming (OOP)** and core C# concepts.

This project simulates a small library management system where users can manage books, members, borrowing records, and search operations.

---

## 🎯 Project Purpose

This project was created as a hands-on practice project to strengthen my understanding of:

- C# Fundamentals
- Object-Oriented Programming (OOP)
- Collections using Arrays
- Classes & Objects
- Inheritance
- Polymorphism
- Abstraction
- Interfaces
- Encapsulation
- Constructors
- Method Overriding
- Input Validation
- Console Application Design
- Basic System Design
- Clean Code Principles

---

## 🚀 Features

### 📖 Book Management

- Add new books
- Store author, title, genre and publication year
- Track availability status

### 👤 Member Management

Supports two member types:

- Regular Member
  - Borrow up to **3 books**
- Premium Member
  - Borrow up to **10 books**
  - Longer borrowing period

### 📚 Borrowing System

- Borrow books
- Return books
- Prevent borrowing unavailable books
- Prevent exceeding borrowing limits
- Automatically create borrowing records

### 🔍 Search

Search books by:

- Title
- Author
- Genre

Search members by:

- Name
- Email

Searching is **case-insensitive** using the `ISearchable` interface.

### 📄 Reports

- Display available books
- Display member borrowing history
- Display late borrowing records

---

## 🏗️ Project Structure

```
Library-Management-System
│
├── Models
│   ├── LibraryItem
│   ├── Book
│   ├── Member
│   ├── PremiumMember
│   └── BorrowRecord
│
├── Interfaces
│   └── ISearchable
│
├── Services
│   └── Library
│
└── Program.cs
```

---

## 🧠 OOP Concepts Used

### ✅ Encapsulation

Private fields are used to protect internal library data.

### ✅ Inheritance

```
Member
   ▲
   │
PremiumMember
```

```
LibraryItem
      ▲
      │
     Book
```

### ✅ Polymorphism

`PremiumMember` overrides:

```csharp
GetInfo()
```

### ✅ Abstraction

`LibraryItem` acts as the base abstraction for library items.

### ✅ Interface

```csharp
ISearchable
```

Implemented by:

- Book
- Member

---

## 🛠️ Technologies

- C#
- .NET
- Console Application

---

## ⚙️ Getting Started

### Prerequisites

Before running the project, make sure you have:

- .NET SDK 9.0 (or your project's target version)
- Visual Studio 2022 / Visual Studio Code
- Git (optional)

### Clone the repository

```bash
git clone https://github.com/KhaledHamada331/Library-Management-System.git
```

### Navigate to the project

```bash
cd Library-Management-System
```

### Run the application

```bash
dotnet run
```

The application will start in the console and display the main menu.

> **Note:** The project includes sample seed data to make testing easier.

---

## ▶️ Available Operations

```
1. Add Book

2. Add Member

3. Borrow Book

4. Return Book

5. Search Books & Members

6. Display Available Books

7. Display Member Borrow History

8. Display Late Borrow Records

0. Exit
```

---

## 🌱 Seed Data

The application includes sample seed data for quick testing.

It creates:

- Sample books
- Regular member
- Premium member
- Sample borrowing record

---

## 📌 Future Improvements

Some ideas for future enhancements:

- Replace Arrays with Generic Collections (`List<T>`)
- Store data in a database
- Add file persistence
- Add authentication
- Add unit testing
- Apply SOLID principles
- Implement Repository Pattern
- Build an ASP.NET Core API version
- Create a GUI using WPF or WinForms

---

## 📷 Sample Console

```text
Library Management System

1. Add Book
2. Add Member
3. Borrow Book
4. Return Book
5. Search Books & Members
6. Display Available Books
7. Display Member Borrow History
8. Display Late Borrow Records
0. Exit
```

---

## 📚 What I Learned

Building this project helped me practice:

- Object-Oriented Programming
- Designing classes and relationships
- Managing state using arrays
- Input validation
- Working with interfaces
- Building reusable methods
- Writing cleaner and more maintainable C# code

---

## 👨‍💻 Author

**Khaled Hamada**

Backend Developer (.NET)

GitHub:
https://github.com/KhaledHamada331