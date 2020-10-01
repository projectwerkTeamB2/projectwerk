# UC strip tonen

## Actors: Klant

## Preconditie: klant is geïdentificeerd

## Basis pad

1. Klant wenst een strip te bekijken
2. Systeem vraagt titel en reeks van strip
3. Klant geeft titel en reeks van strip
4. Systeem controleert of de strip reeds bestaat DR-SBN
5. Systeem toont strip
6. Use case eindigt

### Postconditie: De klant heeft de stripo gekregen

## Alternatief A: Strip is niet gekend strip word aangemaakt

4. Systeem merkt dat de strip niet bestaat
5. UCstripAanmaken
6. Use case gaat verder op stap 5

## Alternatief B: Strip is niet gekend use case eindigt

4. Systeem merkt dat de strip niet bestaat
5. Gebruiker wenst te stoppen
6. Use case eindigt

#### Domeinregels

1. DR-SBN: Strip niet gekend
- Als een strip niet gekend is kan de gebruiker stoppen of de strip aan te maken