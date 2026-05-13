# 🏫 GestionEcole - School Management System

> Professional desktop application for managing student enrollments, payments, and academic records for ENSIT (École Nouvelle Supérieure d'Ingénieurs et de Technologie).

[![.NET](https://img.shields.io/badge/.NET-7.0-512BD4?style=flat&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![VB.NET](https://img.shields.io/badge/VB.NET-Windows%20Forms-512BD4?style=flat&logo=.net&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/visual-basic/)
[![License](https://img.shields.io/badge/License-Educational-blue.svg)](LICENSE)

## 📋 Overview

GestionEcole is a comprehensive school management system designed for ENSIT. It provides a complete solution for managing student lifecycle, from enrollment to graduation, including payment tracking, academic records, and administrative reporting.

### ✨ Key Features

- 👨‍🎓 **Student Management**
  - Complete student profile management
  - Photo upload and document management
  - Automatic enrollment number generation
  - Multi-criteria search and filtering

- 💰 **Payment Tracking**
  - Multiple payment types (enrollment, tuition, materials, exams)
  - Payment methods (cash, transfer, check)
  - Status tracking (complete, partial, pending)
  - Automatic PDF receipt generation

- 📊 **Interactive Dashboard**
  - Real-time KPIs (total students, payments, amounts)
  - Statistical charts and graphs
  - Distribution by program
  - Payment status overview

- 📄 **Reporting & Export**
  - Filterable student lists
  - Outstanding payments reports
  - Excel export (NPOI)
  - PDF generation (PdfSharpCore)

- 🔒 **Security & Access Control**
  - SHA256 password encryption
  - Role-based access (Administrator, Staff)
  - Activity journal and audit trail
  - Session management

- 🎓 **Academic Management**
  - Annual re-enrollment tracking
  - Level progression (1st to 5th year)
  - Complete academic history
  - Prerequisites verification

## 🛠️ Tech Stack

- **Language:** VB.NET
- **Framework:** .NET 7.0
- **UI:** Windows Forms
- **Database:** Microsoft Access (OLEDB)
- **PDF Generation:** PdfSharpCore
- **Excel Export:** NPOI 2.7.5
- **Charts:** System.Windows.Forms.DataVisualization

## 📁 Project Structure

```
GestionEcole/
├── Business/              # Business logic layer
│   └── Services.vb        # Validation, calculations, business rules
├── DataAccess/            # Data access layer
│   ├── Connexion.vb       # Database connection
│   └── DAL.vb             # CRUD operations
├── Data/                  # Database files
│   └── GestionEcole.accdb # MS Access database (auto-created)
├── Forms/                 # User interface
│   ├── LoginForm.vb       # Modern login interface
│   ├── MainForm.vb        # Main menu
│   ├── DashboardForm.vb   # Dashboard with charts
│   ├── EtudiantForm.vb    # Student management
│   ├── FiliereForm.vb     # Program management
│   ├── PaiementForm.vb    # Payment management
│   ├── ReinscriptionForm.vb # Re-enrollment
│   ├── RapportForm.vb     # Reports and exports
│   ├── JournalForm.vb     # Activity journal
│   └── UtilisateurForm.vb # User management
├── Helpers/               # Utilities
│   ├── Helpers.vb         # Security, validation, formatting
│   └── PDFGenerator.vb    # PDF generation
├── Models/                # Data models
│   ├── UtilisateurConnecte.vb # Session management
│   └── Models.vb          # Business entities
└── Themes/                # Visual styles
    └── ENSITTheme.vb      # ENSIT color scheme (Navy & Gold)
```

## 🚀 Getting Started

### Prerequisites

- Windows 10 or 11
- Visual Studio 2022 (Community, Professional, or Enterprise)
- .NET 7.0 SDK (included with Visual Studio)
- Microsoft Access Database Engine

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/iamwilliamm/gestionecole-ensit.git
   cd gestionecole-ensit
   ```

2. **Open in Visual Studio**
   - Open `GestionEcole.vbproj` in Visual Studio 2022
   - Wait for NuGet packages to restore automatically
   - If needed: Right-click solution → Restore NuGet Packages

3. **Run the application**
   - Press F5 or click "Start"
   - Database will be created automatically on first run

### Default Credentials

**Administrator (full access):**
- Login: `admin`
- Password: `12345`

**Staff (limited access):**
- Login: `secretariat`
- Password: `12345`

⚠️ **Important:** Change default passwords after first login!

## 📸 Screenshots

### Login Screen
Modern authentication interface with ENSIT branding.

### Dashboard
Interactive dashboard with real-time statistics and charts.

### Student Management
Complete student profile management with photo upload.

### Payment Tracking
Payment management with automatic PDF receipt generation.

## 🎨 Design

The application features a modern design with:
- **Color Scheme:** Navy Blue & Gold (ENSIT brand colors)
- **Typography:** Professional and readable fonts
- **Layout:** Intuitive and user-friendly interface
- **Responsiveness:** Optimized for different screen sizes

## 📊 Database Schema

The application uses Microsoft Access with the following main tables:
- `Utilisateurs` - User accounts and roles
- `Etudiants` - Student information
- `Filieres` - Academic programs
- `Paiements` - Payment records
- `Reinscriptions` - Re-enrollment history
- `Journal` - Activity audit trail

## 🔐 Security Features

- **Password Encryption:** SHA256 hashing
- **Role-Based Access:** Administrator and Staff roles
- **Activity Logging:** Complete audit trail
- **Session Management:** Secure user sessions
- **Data Validation:** Input validation and sanitization

## 📦 Dependencies

```xml
<PackageReference Include="NPOI" Version="2.7.5" />
<PackageReference Include="PdfSharpCore" Version="1.3.65" />
<PackageReference Include="System.Data.OleDb" Version="7.0.0" />
```

## 🐛 Troubleshooting

**NuGet packages not restoring:**
```bash
# In Package Manager Console
Update-Package -reinstall
```

**Compilation errors:**
```bash
Build > Clean Solution
Build > Rebuild Solution
```

**Database not found:**
- Database is created automatically on first run
- Check write permissions in project folder
- Verify Microsoft Access Database Engine is installed

## 🤝 Contributing

This is an educational project. Contributions, issues, and feature requests are welcome!

## 📝 License

This project is developed for educational purposes at ENSIT.

## 👨‍💻 Author

**William KOUASSI**
- GitHub: [@iamwilliamm](https://github.com/iamwilliamm)
- Email: kdcwilliam@gmail.com

## 🙏 Acknowledgments

- ENSIT (École Nouvelle Supérieure d'Ingénieurs et de Technologie)
- .NET Community
- Open Source Contributors

---

<div align="center">

**Built with ❤️ for ENSIT**

</div>
