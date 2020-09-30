# UC strip aanmaken

## Actors: Klant

## Preconditie: Klant is geïdentificeerd

## Basis pad

1. Klant wenst een strip toe te voegen
2. Systeem vraagt titel van strip
3. Klant geeft titel strip
4. Systeem vraagt Auteur(s) strip
5. Klant geeft Auteur(s) strip
6. Systeem controleert of auteur gekend is DR-AG
7. Systeem vraagt reeks en nummer in reeks
8. Klant geeft reeks en nummer in reeks
9. Systeem controleert of reeks reeds gekend is DR-RG
10. Systeem vraagt uitgeverij
11. Klant geeft uitgeverij
12. Systeem controleert of uitgeverij reeds bestaat DR-UB
13. Systeem slaat strip op
14. Use case eindigt

### Postconditie: Strip is opgeslagen 

## Alternatief A: Auteur is niet gekend

6. Systeem controleert of auteur gekend is
7. Systeem merkt op dat auteur niet gekend is
8. Systeem vraagt naam en voornaam auteur
9. Klant geeft naam en voornaam auteur
10. Use case gaat verder op stap 7

## Alternatief B: Reeks is niet gekend

9. Systeem merkt op dat reeks niet bestaat
10. Systeem vraagt naam van reeks
11. Klant geeft naam reeks
12. Use case gaat verder op stap 11

## Alternatief C: Uitgeverij is niet gekend

12. Systeem merkt op dat de uitgeverij niet bestaat
13. Systeem vraagt naam en adres uitgeverij
14. Klant geeft naam en adres uitgeverij
15. Use case gaat verder op stap 13

#### Domeinregels

1. DR-AG: Auteur Gekend
- indien de Auteur niet gekend is word deze aangemaakt en opgeslagen voor verder verloop

2. DR-RG: Reeks gekend
- indien de Reeks niet gekend is word deze aangemaakt en opgeslagen voor verder verloop

3. DR-UB: Uitgeveriij bestaat niet
- indien de Uitgeverij niet bestaat word deze aangemaakt en opgeslagen voor verder verloop