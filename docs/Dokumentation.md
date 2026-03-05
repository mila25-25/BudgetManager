## UML- und Datenbankdiagramme

Zur strukturierten Planung und Dokumentation der Anwendung wurden mehrere Diagramme erstellt.
Diese Diagramme unterstützen das Verständnis der Anforderungen, der Systemarchitektur sowie der
zentralen Abläufe innerhalb der Anwendung.

Alle Diagramme befinden sich im Repository im Ordner `docs/uml/`.

---

### Use-Case-Diagramm

Das Use-Case-Diagramm stellt die Anwendung aus Sicht des Benutzers dar.
Es zeigt, welche Funktionen dem Benutzer zur Verfügung stehen und wie er mit dem System interagiert.

Der Benutzer kann:

- Transaktionen (Einnahmen und Ausgaben) hinzufügen  
- Transaktionen löschen  
- Alle Transaktionen anzeigen  
- Monat und Jahr auswählen  
- Eine Monatsauswertung (Einnahmen, Ausgaben und Saldo) anzeigen  

Das Diagramm verdeutlicht, dass alle Kernfunktionen direkt vom Benutzer ausgelöst werden
und bildet die Grundlage für die funktionalen Anforderungen der Anwendung.

![Use-Case Diagramm](uml/usecase.png)

---

### Klassendiagramm

Das Klassendiagramm beschreibt die statische Struktur der Anwendung und zeigt die wichtigsten Klassen
sowie deren Beziehungen untereinander.

Zentrale Klassen sind:

- **Transaction (Model)**: Repräsentiert eine einzelne Einnahme oder Ausgabe.
- **MainViewModel (ViewModel)**: Enthält die Geschäftslogik sowie berechnete Werte
  wie Balance und Monatsauswertung.
- **ReportService (Service)**: Stellt Funktionen zur Berechnung der Gesamtbalance
  sowie der monatlichen Einnahmen und Ausgaben bereit.
- **BudgetDbContext**: Stellt die Verbindung zur SQLite-Datenbank her
  und verwaltet die Persistenz über Entity Framework Core.

Zusätzlich existiert ein Testprojekt (**ReportServiceTests**),
das die wichtigsten Berechnungsfunktionen automatisiert überprüft.

![Klassendiagramm](uml/classdiagram.png)

---

### Aktivitätsdiagramm – „Transaktion hinzufügen“

Das Aktivitätsdiagramm beschreibt den Ablauf beim Hinzufügen einer neuen Transaktion.

Der Prozess beginnt mit der Eingabe der Daten durch den Benutzer und endet mit der
Aktualisierung der Benutzeroberfläche.

Wichtige Schritte sind:

- Eingabe der Transaktionsdaten
- Validierung der Eingaben
- Speicherung der Daten in der Datenbank
- Aktualisierung der Transaktionsliste
- Neuberechnung der Balance und Monatsauswertung

![Aktivitätsdiagramm – Transaktion hinzufügen](uml/activity_add.png)

---

### Datenbankmodell (ER-Modell)

Das Datenbankmodell wird durch ein Entity-Relationship-Diagramm beschrieben.
Die Anwendung verwendet eine SQLite-Datenbank mit einer zentralen Tabelle **Transactions**.

Die Tabelle enthält folgende Attribute:

- **Id** – Primärschlüssel  
- **Title** – Beschreibung der Transaktion  
- **Amount** – Betrag  
- **Date** – Datum der Transaktion  
- **IsIncome** – Kennzeichnung für Einnahme oder Ausgabe  

![ER-Modell](uml/er_model.png)

---

## Test und Qualitätssicherung

Zur Sicherstellung der Funktionsfähigkeit und Stabilität der Anwendung wurden
manuelle Funktionstests sowie automatisierte Unit Tests durchgeführt.

Die manuellen Testfälle befinden sich im Repository im Ordner:

`docs/tests/`

Zusätzlich wurden Unit Tests mit **xUnit** implementiert,
um zentrale Funktionen der Business-Logik zu überprüfen.

Diese Tests befinden sich im Projekt:

`BudgetManager.Tests`

Die automatisierten Tests werden über **GitHub Actions (CI)** bei jedem Push
in das Repository automatisch ausgeführt.

---

### Zusammenfassung

Die Diagramme unterstützen die strukturierte Entwicklung der Anwendung
und stellen sicher, dass Anforderungen, Architektur und Implementierung
konsistent aufeinander abgestimmt sind.

Dank der verwendeten Architektur (MVVM, Service-Schicht und Entity Framework Core)
ist die Anwendung gut wartbar und kann problemlos erweitert werden.
