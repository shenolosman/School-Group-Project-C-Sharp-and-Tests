
# Bankapp 

Vi planerade v�ran programmet genom att kolla Scenario av bakkonton.


Detta �r det f�rsta projektet d�r ni kodar tillsammans, s� fokus kommer att ligga p� fungerande sammarbete och att anv�nda branching, PR och Kanban br�det inne p� GitHub. Ni kommer att jobba enligt TDD utefter ett scenario men ni m�ste inte bli klara med uppgiften. I framtida kurser n�r ni kan arbetsfl�det s� kommer det att bli mer fokus p� f�rdiga produkter

### Sparkonto 
Sparkonto som till�ter max 5 uttag om �ret (fler kan g�ras men d� kostar det 1% av uttaget)


### L�nekonto
L�nekonto som till�ter obegr�nsat antal uttag

### Investeringkonto
Investeringskonto som till�ter ett uttag om �ret

### Kreditkonto
Kreditkonto som till�ter kredit �ver en viss gr�ns


## Tester

Vi g�r TDD p� s� s�tt;
	
###### Vilka regler g�ller f�r bankkonton rent allm�nt?

- Man f�r inte ta ut mer pengar �n vad som finns i kontot
- Om kredit finns f�r man inte ta ut mer �n krediten
- Man f�r inte s�tta ut minusv�rden ( allts� s�tta in -100:- )
- Bankens egna avgifter tas ut �ven om kontot �r p� minus
- Cash Ins�ttningar p� Max 15000 �t g�ngen (annars kan man b�rja misst�nka att det �r pengatv�tt), inga fler ins�ttningar till�ts den dagen.


```{
class Person {
    public string DateTime BirthDay { get; init; }
    public string int Age => DateTime.Now.Year - BirthDay.Year;
}
```



- [ ] Ska l�ggas tid begr�nsning till investeringkonto
- [x] Kan inte ta ut pengarna inom �ret
- [x] bla bla feature ska fixas


