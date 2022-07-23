# School group project

## Trying to build bank/finance aspect with TDD perspective. Used Resharper Xunit for tests.





### Projektarbete

Övergripande

Detta är projektet där vi kodar, fokus kommer att ligga på fungerande sammarbete och att använda branching, PR och Kanban brädet inne på GitHub.
Vi kommer att jobba enligt TDD utefter scenarion.

### Scenario Bankkonton

En nytt bankföretag, iBank, som bara finns online ska starta upp och de behöver utveckla en backend som sköter kontohanteringen på ett säkert sätt.
Det finns olika sorts bankkonto

- Sparkonto som tillåter max 5 uttag om året (fler kan göras men då kostar det 1% av uttaget)
- Lönekonto som tillåter obegränsat antal uttag
- Kreditkonto som tillåter kredit över en viss gräns
- Investeringskonto som tillåter ett uttag om året

### Vilka regler gäller för bankkonton rent allmänt?

- Man får inte ta ut mer pengar än vad som finns i kontot
- Om kredit finns får man inte ta ut mer än krediten
- Man får inte sätta ut minusvärden ( alltså sätta in -100:- )
- Bankens egna avgifter tas ut även om kontot är på minus
- Cash Insättningar på Max 15000 åt gången (annars kan man börja misstänka att det är pengatvätt), inga fler insättningar tillåts den dagen.
