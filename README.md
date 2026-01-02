# Budget Manager (WPF, MVVM)

## Projektbeschreibung
Der **Budget Manager** ist eine Desktop-Anwendung zur Verwaltung von Einnahmen und Ausgaben.
Benutzer können finanzielle Transaktionen erfassen, anzeigen, löschen und ihre Finanzen
monatlich auswerten. Die Daten werden dauerhaft in einer SQLite-Datenbank gespeichert.

Das Projekt wurde im Rahmen eines C#-Projekts mit Fokus auf **MVVM-Architektur**,
**Datenbankanbindung** und **GUI-Entwicklung** umgesetzt.

---

## Ziel des Projekts
Ziel ist die Entwicklung einer benutzerfreundlichen Anwendung zur privaten Budgetverwaltung,
die eine strukturierte Erfassung und Auswertung finanzieller Daten ermöglicht.

---

## Verwendete Technologien
- **Programmiersprache:** C#
- **Framework:** .NET (WPF)
- **Architektur:** MVVM (Model-View-ViewModel)
- **Datenbank:** SQLite
- **ORM:** Entity Framework Core
- **Versionsverwaltung:** Git & GitHub

---

## Funktionen
- Hinzufügen von Einnahmen und Ausgaben
- Anzeige aller Transaktionen in einer Tabelle
- Löschen ausgewählter Transaktionen
- Automatische Berechnung des Gesamt-Balance
- Monatsauswertung (Einnahmen, Ausgaben, Saldo)
- Persistente Speicherung der Daten (SQLite)
- Benutzerfreundliche grafische Oberfläche (GUI)

---

## Projektstruktur
BudgetManager.sln
README.md
docs/
tests/
BudgetManager/

- **BudgetManager/** – Quellcode (Views, ViewModels, Models, Datenbank)
- **docs/** – Projektdokumentation, UML-Diagramme, Screenshots
- **tests/** – Testfälle und Qualitätssicherung
- **README.md** – Projektübersicht

---

## Architektur (MVVM)
- **Model:** Datenklassen (z. B. Transaction)
- **View:** WPF-Oberfläche (XAML)
- **ViewModel:** Geschäftslogik, Commands, Datenbindung
- **Persistence:** Entity Framework Core mit SQLite

---

## Datenbank
Die Anwendung verwendet eine SQLite-Datenbank mit folgender Tabelle:

**Transactions**
- Id (Primärschlüssel)
- Title
- Amount
- Date
- IsIncome

---

## Tests & Qualität
- Manuelle Testfälle zur Überprüfung der Kernfunktionen
- Validierung von Benutzereingaben
- Fehlerbehandlung bei Datenbankzugriffen
- Saubere Trennung von Logik und UI durch MVVM

---

## Innovation
- Monatsauswertung mit dynamischer Auswahl von Monat und Jahr
- Übersichtliches Dashboard mit Banner und Kennzahlen
- Erweiterbar (z. B. Kategorien, Export, Diagramme)

---

## Autor
Projekt im Rahmen einer C#-Projektarbeit  
Abgabe: **08.01**

