# Budget Manager (WPF, MVVM)

## Overview
Budget Manager is a desktop application for managing personal finances.
It allows users to track income and expenses, calculate balances and analyze transactions.

The application is built with WPF using the MVVM architecture and uses Entity Framework Core with SQLite for data storage.

---

## Features

- Add income and expense transactions
- View list of transactions
- Automatic balance calculation
- Categorize transactions
- Simple and intuitive WPF user interface
- Data persistence using SQLite and Entity Framework Core

---

## Architecture

The application follows the MVVM (Model-View-ViewModel) architecture.

- **Model** – data structures and database entities  
- **View** – WPF user interface  
- **ViewModel** – application logic and data binding

## Tech Stack

- C#
- .NET
- WPF
- MVVM
- Entity Framework Core
- SQLite

---

## Database

The application uses a SQLite database.

The database is created automatically when the application starts using Entity Framework Core migrations.

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


### Main Window

![Main Window](docs/main_window.png)

### Add Transaction

![Add Transaction](docs/add_transaction.png)

## Screenshots

### Dashboard

![Dashboard](docs/screenshots/dashboard.png)

### Transactions

![Transactions](docs/screenshots/transactions.png)

### Add Transaction

![Add Transaction](docs/screenshots/add_transaction.png)

### Monthly Overview

![Monthly Overview](docs/screenshots/month_overview.png)
