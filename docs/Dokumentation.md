## UML-Diagramme

Die folgenden UML-Diagramme dokumentieren Analyse, Entwurf und Abläufe der Anwendung.  
Alle Diagramme befinden sich im Repository unter `docs/uml/`.

### Use-Case-Diagramm
Dieses Diagramm zeigt die wichtigsten Funktionen aus Sicht des Benutzers (Transaktionen verwalten, Monatsauswertung).
![Use-Case Diagramm](uml/usecase.png)

### Klassendiagramm
Das Klassendiagramm beschreibt die wichtigsten Klassen der MVVM-Architektur (Model, ViewModel, Persistence) und ihre Beziehungen.
![Klassendiagramm](uml/classdiagram.png)

### Aktivitätsdiagramm: „Transaktion hinzufügen“
Das Aktivitätsdiagramm zeigt den Ablauf beim Hinzufügen einer Transaktion (Eingabe → Validierung → Speichern → Aktualisieren).
![Aktivitätsdiagramm – Transaktion hinzufügen](uml/activity_add.png)

### ER-Modell / Datenbankmodell
Das ER-Modell beschreibt die Datenbankstruktur (Tabelle `Transactions`) mit den wichtigsten Feldern.
![ER-Modell](uml/er_model.png)

