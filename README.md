# Library Management System (WPF - MVVM)

A professional, lightweight, and decoupled desktop application built using **WPF (Windows Presentation Foundation)** and **.NET Framework**. This project strictly implements the **MVVM (Model-View-ViewModel)** architectural pattern to ensure clean separation of concerns, high maintainability, and scalable business logic.

---

## 🚀 Features

### 1. Interactive Dashboard
* **Real-time Metrics:** Displays instant counters for Total Books, Registered Readers, and Active Borrow Tickets.
* **Inventory Alerts:** Automatically flags and lists low-stock or out-of-stock books to assist librarians.

### 2. Intelligent Book Inventory Management
* **CRUD Operations:** Seamlessly add and delete books from the system.
* **Real-time Search:** Instant, keystroke-by-keystroke filtering by **Book Title** or **Author** utilizing `ICollectionView` without needing to press a search button.

### 3. Reader & Membership Management
* **Membership Tracking:** Manage reader profiles, unique library card IDs, and contact info.
* **Decoupled Workflows:** Dedicated views ensuring user data remains independent of book logic.

### 4. Advanced Borrow & Return Workflows
* **Dynamic Inventory Sync:** Loaning a book instantly decrements the `AvailableQuantity` in real-time. Returning it increments the stock automatically.
* **Validation Rules:** Prevents processing loans if the book is entirely out of stock or if input data is missing.
* **Status Tracking:** Automatically manages due dates and tracking statuses.

---

## 🛠️ Technologies Used

* **Language:** C# 
* **Framework:** .NET Framework (WPF App)
* **UI Markup:** XAML (Extensible Application Markup Language)
* **Design Pattern:** Pure MVVM (Zero third-party framework dependencies)

---

## 📂 Directory Structure

The project layout maintains a strict separation between UI controls, data states, and presentation logic:

```text
libraryManagement/
│
├── Properties/             # Application properties and configuration
├── References/             # Framework assemblies
│
├── Models/                 # Data Blueprints (Pure C# Classes)
│   ├── Book.cs             # Book attributes & inventory counts
│   ├── Reader.cs           # Reader credentials & contacts
│   └── BorrowTicket.cs     # Loan data structures & return states
│
├── ViewModels/             # Application Brains (Presentation Logic)
│   ├── RelayCommand.cs     # Custom ICommand reusable boilerplate
│   ├── BookViewModel.cs    # Handles book state changes & searching logic
│   ├── ReaderViewModel.cs  # Manages reader registration workflows
│   └── DashboardViewModel.cs# Aggregates system metrics & alert filters
│
├── Views/                  # User Interfaces (XAML Declarations)
│   ├── MainWindow.xaml     # Shell Window acting as the primary navigation hub
│   ├── BookView.xaml       # View layout for inventory management
│   ├── ReaderView.xaml     # View layout for reader membership profiles
│   └── DashboardView.xaml   # View layout for numerical metrics & alerts
│
├── App.config              # Runtime configuration details
└── App.xaml                # App entry point and StartupUri declarations
