## UML-Diagramme – Analyse und Entwurf

Zur strukturierten Planung und Dokumentation der Anwendung wurden mehrere UML-Diagramme erstellt.
Diese Diagramme unterstützen das Verständnis der Anforderungen, der Systemarchitektur sowie der
zentralen Abläufe innerhalb der Anwendung.

Alle Diagramme befinden sich im Repository im Ordner `docs/uml/`.

---

### 1. Use-Case-Diagramm

Das Use-Case-Diagramm stellt die Anwendung aus Sicht des Benutzers dar.
Es zeigt, welche Funktionen dem Benutzer zur Verfügung stehen und wie er mit dem System interagiert.

Der Benutzer kann:
- Transaktionen (Einnahmen und Ausgaben) hinzufügen
- Transaktionen löschen
- Alle Transaktionen anzeigen
- Monat und Jahr auswählen
- Eine Monatsauswertung (Einnahmen, Ausgaben, Saldo) anzeigen

Das Diagramm verdeutlicht, dass alle Kernfunktionen direkt vom Benutzer ausgelöst werden
und bildet die Grundlage für die funktionalen Anforderungen.

![Use-Case Diagramm](uml/usecase.png)

---

### 2. Klassendiagramm

Das Klassendiagramm beschreibt die statische Struktur der Anwendung und zeigt die wichtigsten Klassen
sowie deren Beziehungen untereinander.

Zentrale Klassen sind:
- **Transaction** (Model): Repräsentiert eine einzelne Einnahme oder Ausgabe.
- **MainViewModel** (ViewModel): Enthält die Geschäftslogik, Commands und berechnete Werte
  wie Balance und Monatsauswertung.
- **BudgetDbContext**: Stellt die Verbindung zur SQLite-Datenbank her (Entity Framework Core).

Das Diagramm verdeutlicht die Umsetzung des MVVM-Architekturmusters und zeigt die klare Trennung
zwischen Datenmodell, Logik und Datenhaltung.

![Klassendiagramm](uml/classdiagram.png)

---

### 3. Aktivitätsdiagramm – „Transaktion hinzufügen“

Das Aktivitätsdiagramm beschreibt den Ablauf beim Hinzufügen einer neuen Transaktion.

Der Prozess beginnt mit der Eingabe der Daten durch den Benutzer und endet mit der Aktualisierung
der Benutzeroberfläche. Wichtige Schritte sind:
- Eingabe der Transaktionsdaten
- Validierung der Eingaben
- Speicherung der Daten in der Datenbank
- Aktualisierung der Liste und der Berechnungen (Balance, Monatswerte)

Dieses Diagramm zeigt den Kontrollfluss und hilft, die Implementierung der Logik im ViewModel
nachvollziehbar darzustellen.

![Aktivitätsdiagramm – Transaktion hinzufügen](uml/activity_add.png)

---

### 4. ER-Modell / Datenbankmodell

Das ER-Modell stellt die Struktur der Datenbank dar.
Die Anwendung verwendet eine SQLite-Datenbank mit einer zentralen Tabelle **Transactions**.

Die Tabelle enthält folgende Attribute:
- **Id**: Primärschlüssel
- **Title**: Beschreibung der Transaktion
- **Amount**: Betrag
- **Date**: Datum der Transaktion
- **IsIncome**: Kennzeichnung für Einnahme oder Ausgabe

Das Datenbankmodell ist bewusst einfach gehalten und ermöglicht eine effiziente Speicherung
und Auswertung der Finanzdaten. Es ist zudem leicht erweiterbar, z. B. um Kategorien oder Benutzer.

![ER-Modell](uml/er_model.png)

---

### Zusammenfassung

Die UML-Diagramme unterstützen die strukturierte Entwicklung der Anwendung und stellen sicher,
dass Anforderungen, Architektur und Implementierung konsistent aufeinander abgestimmt sind.
Sie tragen wesentlich zur Verständlichkeit, Wartbarkeit und Erweiterbarkeit des Projekts bei.
