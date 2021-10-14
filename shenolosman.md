
# Bankapp 

Vi planerade våran programmet genom att kolla Scenario av bakkonton.


Detta är det första projektet där ni kodar tillsammans, så fokus kommer att ligga på fungerande sammarbete och att använda branching, PR och Kanban brädet inne på GitHub. Ni kommer att jobba enligt TDD utefter ett scenario men ni måste inte bli klara med uppgiften. I framtida kurser när ni kan arbetsflödet så kommer det att bli mer fokus på färdiga produkter

### Sparkonto 
Sparkonto som tillåter max 5 uttag om året (fler kan göras men då kostar det 1% av uttaget)


### Lönekonto
Lönekonto som tillåter obegränsat antal uttag

### Investeringkonto
Investeringskonto som tillåter ett uttag om året

### Kreditkonto
Kreditkonto som tillåter kredit över en viss gräns


## Tester

Vi gör TDD på så sätt;
	
###### Vilka regler gäller för bankkonton rent allmänt?

- Man får inte ta ut mer pengar än vad som finns i kontot
- Om kredit finns får man inte ta ut mer än krediten
- Man får inte sätta ut minusvärden ( alltså sätta in -100:- )
- Bankens egna avgifter tas ut även om kontot är på minus
- Cash Insättningar på Max 15000 åt gången (annars kan man börja misstänka att det är pengatvätt), inga fler insättningar tillåts den dagen.


```{
class Person {
    public string DateTime BirthDay { get; init; }
    public string int Age => DateTime.Now.Year - BirthDay.Year;
}
```



- [ ] Ska läggas tid begränsning till investeringkonto
- [x] Kan inte ta ut pengarna inom året
- [x] bla bla feature ska fixas


