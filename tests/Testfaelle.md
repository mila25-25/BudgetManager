## Test und Qualitätssicherung

Zur Sicherstellung der Funktionsfähigkeit und Stabilität der Anwendung wurden sowohl **manuelle Funktionstests** als auch **automatisierte Unit Tests** durchgeführt.  
Dabei wurden insbesondere die korrekte Verarbeitung von Benutzereingaben, die Persistenz der Daten sowie die Stabilität der Anwendung überprüft.

---

### Teststrategie

Die Anwendung enthält eine grafische Benutzeroberfläche (WPF). Daher wurden wichtige Funktionen zunächst durch **manuelle Testszenarien** überprüft, die typische Benutzeraktionen simulieren.

Zusätzlich wurden **automatisierte Unit Tests mit xUnit** implementiert, um zentrale Teile der Geschäftslogik unabhängig von der Benutzeroberfläche zu testen.

Die Testschwerpunkte umfassen:

- Korrekte Eingabe und Validierung von Daten (Titel, Betrag, Datum)
- Speicherung und Laden der Daten über SQLite
- Korrekte Berechnung der Balance sowie der Monatsauswertung
- Aktualisierung der Benutzeroberfläche (DataGrid, Dashboard)
- Stabilität der Anwendung bei ungültigen Eingaben oder Fehlern

---

### Testumgebung

Die Tests wurden in folgender Umgebung durchgeführt:

- Betriebssystem: Windows
- Framework: .NET (WPF)
- Datenbank: SQLite mit Entity Framework Core
- Versionsverwaltung: GitHub
- Unit-Test-Framework: xUnit
- Continuous Integration: GitHub Actions

Die automatisierten Tests werden bei jedem Push automatisch durch die CI-Pipeline ausgeführt.

---

### Manuelle Testfälle

Die manuellen Funktionstests sind im Repository dokumentiert und befinden sich im Ordner `tests/`.

Diese Testfälle decken typische Benutzeraktionen ab, z. B.:

- Starten der Anwendung
- Laden vorhandener Transaktionen
- Hinzufügen von Einnahmen und Ausgaben
- Validierung fehlerhafter Eingaben
- Löschen von Transaktionen
- Persistenz der Daten nach Neustart der Anwendung

Die Testfälle sind in strukturierter Form als Tabellen dokumentiert.

---

### Fehlerbehandlung

Die Anwendung enthält grundlegende Mechanismen zur Fehlerbehandlung:

- Datenbankzugriffe werden durch `try/catch` abgesichert, um Abstürze zu verhindern.
- Eingaben werden validiert (z. B. Betrag muss numerisch sein, Titel darf nicht leer sein).
- Fehler werden über verständliche Meldungen oder Debug-Ausgaben sichtbar gemacht.

Diese Maßnahmen tragen zur Stabilität und Robustheit der Anwendung bei.

---

### Qualität der Datenbankanwendung

Die Datenpersistenz wird über **Entity Framework Core** realisiert, wodurch konsistente Datenoperationen gewährleistet werden.

Als Datenbank wird **SQLite** verwendet, da sie eine leichtgewichtige und lokal verfügbare Lösung darstellt.

Weitere Qualitätsaspekte:

- Asynchrone Datenzugriffe vermeiden UI-Blockierungen
- Klare Struktur des Datenmodells (Tabelle `Transactions`)
- Konsistente Datentypen für Beträge, Datum und Kennzeichnung von Einnahmen/Ausgaben

---

### Ergebnis

Alle definierten Testfälle wurden erfolgreich durchgeführt.

Die Anwendung erfüllt die zentralen funktionalen Anforderungen:

- stabile Speicherung und Wiederherstellung der Daten
- korrekte Berechnung von Balance und Monatsauswertung
- konsistente Aktualisierung der Benutzeroberfläche
- zuverlässige Eingabevalidierung und Fehlerbehandlung

Die Kombination aus manuellen Tests und automatisierten Unit Tests trägt wesentlich zur Qualität und Wartbarkeit der Anwendung bei.
