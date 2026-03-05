# BudgetManager

WPF desktop application for managing personal income and expenses.
Built with MVVM architecture and Entity Framework Core.

![Build](https://github.com/mila25-25/BudgetManager/actions/workflows/dotnet-desktop.yml/badge.svg)

---

## Overview

BudgetManager is a desktop application for managing personal finances.
It allows users to track income and expenses, calculate balances and analyze transactions.

The application is built with **WPF** using the **MVVM architecture** and uses **Entity Framework Core with SQLite** for data persistence.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Database](#database)
- [How to Run](#how-to-run)
- [Screenshots](#screenshots)
- [Architecture](#architecture)
- [UML Diagrams](#uml-diagrams)

---

## Features

- Add transactions (income / expense)
- Delete transactions
- View transaction list
- Monthly report (income & expenses)
- Automatic balance calculation
- Unit tests for service layer

---

## Technologies

- C#
- .NET
- WPF
- MVVM
- Entity Framework Core
- SQLite
- xUnit
- GitHub Actions (CI)
- PlantUML

---

## Database

The application uses a local **SQLite database**.

The database is created automatically when the application starts using **Entity Framework Core**.

The database file is stored locally and is not included in the repository.

---

## How to Run

1. Clone the repository

git clone https://github.com/mila25-25/BudgetManager

2. Open the solution in Visual Studio

BudgetManager.sln

3. Restore NuGet packages

4. Run the application

The database will be created automatically.

---

## Screenshots

### Dashboard

![Dashboard](docs/screenshots/dashboard.png)

### Transactions

![Transactions](docs/screenshots/transactions.png)

### Add Transaction

![Add Transaction](docs/screenshots/add_transaction.png)

### Monthly Overview

![Monthly Overview](docs/screenshots/month_overview.png)

---

## Architecture

BudgetManager uses a simple **layered architecture**::

UI (Views)
↓
ViewModels
↓
Services (Business Logic)
↓
Models (Data)

Unit tests validate the service layer. 

---

## UML Diagrams

### Use Case Diagram

![Use Case](docs/uml/usecase.png)

### Class Diagram

![Class Diagram](docs/uml/classdiagram.png)

### Database ER Model

![ER Model](docs/uml/er_model.png)

### Activity Diagram – Add Transaction

![Activity Diagram](docs/uml/activity_add.png)
