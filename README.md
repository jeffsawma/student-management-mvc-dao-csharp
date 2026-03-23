# Student Management System (MVC & DAO)

## About the project

This is a console-based application I built in C# to better understand how to structure an application using design patterns like MVC and DAO.

The goal was to simulate a simple student management system where you can manage students, courses, and their enrollments, while keeping the code organized and maintainable.

---

## Project structure

I organized the project into multiple layers to separate responsibilities:

- **ModelLayer** → Contains the core entities (Etudiant, Cours, Inscription)
- **ViewLayer** → Handles all user interactions through the console
- **ControlLayer** → Manages the application flow and connects views with data access
- **DAO** → Responsible for database operations (CRUD)
- **DataAccess** → Manages the SQL Server connection

This helped me better understand how to keep logic, UI, and data access independent.

---

## Technologies used

- C#
- .NET (Console Application)
- ADO.NET
- SQL Server

---

## Database

The application is based on three main tables:

- **Etudiants**
- **Cours**
- **Inscriptions** (links students and courses with a session and optional grade)

---

## Features

- Add, update, delete, and list students
- Add, update, delete, and list courses
- Enroll a student in a course
- View enrollments by student or by course

---

## How to run

1. Set up your SQL Server database using the provided tables
2. Update the connection string in `Connection.cs`
3. Run the project from Visual Studio

---

## What I learned

This project helped me understand:

- How MVC architecture improves code organization
- How the DAO pattern separates database logic from business logic
- How to work with SQL Server using ADO.NET
- The importance of structuring a project for scalability

---

## Notes

This project focuses more on architecture and backend structure rather than UI, since everything is done through the console.
