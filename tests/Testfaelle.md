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

### 5.3 Testfälle (manuell)

| ID | Testfall | Vorbedingung | Schritte | Erwartetes Ergebnis |
|----|----------|--------------|----------|---------------------|
| T01 | Anwendung startet | Projekt ist gebaut | App starten | Hauptfenster wird angezeigt, keine Crashs |
| T02 | Daten werden geladen | DB enthält Einträge | App starten | Transaktionen erscheinen im DataGrid |
| T03 | Neue Einnahme hinzufügen | App läuft | Titel=„Gehalt“, Betrag=„1500“, Datum wählen, Einnahme aktiv, „Hinzufügen“ | Eintrag erscheint in Liste, Balance steigt |
| T04 | Neue Ausgabe hinzufügen | App läuft | Titel=„Miete“, Betrag=„500“, Datum wählen, Einnahme deaktivieren, „Hinzufügen“ | Eintrag erscheint, Balance sinkt |
| T05 | Ungültiger Betrag (Text) | App läuft | Betrag=„abc“ eingeben | Hinzufügen nicht möglich (Validierung greift) |
| T06 | Betrag mit Komma/Punkt | App läuft | Betrag=„15,25“ bzw. „15.25“ | Betrag wird akzeptiert und korrekt gespeichert |
| T07 | Leerer Titel | App läuft | Titel leer lassen, Betrag>0 | Hinzufügen nicht möglich (CanAdd=false) |
| T08 | Löschen einer Transaktion | Eintrag vorhanden | Eintrag markieren → „Auswahl löschen“ | Eintrag wird aus Liste entfernt und aus DB gelöscht |
| T09 | Löschen ohne Auswahl | Keine Auswahl im Grid | „Auswahl löschen“ klicken | Kein Crash, keine Änderung |
| T10 | Persistenz nach Neustart | DB enthält Einträge | App schließen → erneut starten | Alle Daten sind weiterhin vorhanden |
| T11 | Monatsauswertung aktualisiert | Einträge in mehreren Monaten | Monat/Jahr auswählen | MonthIncome/MonthExpense/MonthSaldo ändern sich passend |
| T12 | Balance korrekt berechnet | Mehrere Einträge | Einnahmen und Ausgaben hinzufügen | Balance = Summe(Einnahmen) − Summe(Ausgaben) |

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
