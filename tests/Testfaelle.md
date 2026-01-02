## 5. Test und Qualitätssicherung

Zur Sicherstellung der Funktionsfähigkeit und Stabilität der Anwendung wurden manuelle Funktionstests anhand definierter Testfälle durchgeführt. Zusätzlich wurden Eingabevalidierung, Fehlerbehandlung und Datenbankintegrität überprüft.

### 5.1 Teststrategie

Die Tests wurden als **manuelle Funktionstests** ausgeführt, da die Anwendung eine GUI (WPF) enthält und der Fokus auf korrekter Bedienung, Datenpersistenz und konsistenter Anzeige liegt.

Testschwerpunkte:
- Korrekte Eingabe und Validierung (Titel, Betrag, Datum)
- Speicherung und Laden über SQLite (Persistenz)
- Korrekte Berechnungen (Balance, Monatsauswertung)
- Korrekte UI-Aktualisierung (DataGrid, Dashboard)
- Fehlerbehandlung bei Datenbankoperationen

### 5.2 Testumgebung

- Betriebssystem: Windows
- Framework: .NET (WPF)
- Datenbank: SQLite (EF Core)
- Versionierung: GitHub (Commits als Entwicklungshistorie)

### 5.4 Fehlerbehandlung

- Datenbankzugriffe werden in `try/catch` abgesichert, um Abstürze zu verhindern.
- Bei Fehlern (z. B. DB-Problem) wird eine verständliche Meldung ausgegeben bzw. Debug-Output verwendet.
- Eingaben werden validiert (z. B. Betrag nur numerisch, Title nicht leer), um fehlerhafte Datensätze zu vermeiden.

### 5.5 Qualität der Datenbankanwendung

- Entity Framework Core verwaltet die Persistenz und stellt konsistente Datenoperationen sicher.
- SQLite wird als lokale, leichtgewichtige Datenbank genutzt.
- Daten werden asynchron geladen/gespeichert, um die UI nicht zu blockieren.
- Datenmodell ist klar strukturiert (Tabelle `Transactions` mit passenden Datentypen).

### 5.6 Ergebnis

Alle definierten Testfälle wurden erfolgreich durchgeführt. Die Anwendung erfüllt die Kernanforderungen:
- stabile Speicherung/Ladung
- korrekte Berechnungen
- saubere GUI-Aktualisierung
- sinnvolle Validierung und Fehlerbehandlung
Testfälle für BudgetManager
