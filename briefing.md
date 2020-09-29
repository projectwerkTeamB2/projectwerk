# Projectwerk

## Opgave

### Deel 1 � stripcatalogus.

Het doel van deze applicatie is om een catalogus op te bouwen van strips. Deze catalogus moet ook kunnen worden beheerd, met andere woorden het is de bedoeling dat niet alleen strips kunnen worden toegevoegd, maar dat er ook kunnen worden verwijderd en gecorrigeerd.

De info die we over een strip wensen op te slaan is :

- Titel
- Reeks + nummer in de reeks
- Auteurs
- Uitgeverij

Voorbeeld : Titel : Asterix en de Gothen, Reeks : Asterix, Nummer : 6, Uitgeverij : Dargaud, Auteurs : Goscinny Ren� en Uderzo Albert

**User stories**

- Als gebruiker wil ik een gebruiksvriendelijke interface waarmee ik een strip kan toevoegen aan de catalogus. Deze UI moet in staat zijn om me te helpen bij de invoer, ik wil niet telkens opnieuw dezelfde namen van auteurs, uitgeverijen of reeksen ingeven. De applicatie moet er ook in voorzien dat er geen dubbels worden opgeslagen (en dit geldt zowel voor strips als auteurs en uitgeverijen).
- Als gebruiker wil ik een applicatie die me toelaat om eender welke info over de strip te corrigeren op een gebruiksvriendelijke manier.
- Als ik een strip wil corrigeren, dan moet ik die eenvoudig kunnen terugvinden.
- Er moet een tool voorzien worden om de catalogus uit te wisselen met ander applicaties (zowel importeren als exporteren).

##

## Deel 2 � inventaris en verkoop

Dit deel moet nog worden uitgewerkt, maar hou er rekening mee in je ontwerp dat er nog heel wat functionaliteit zal bijkomen.

## Technische randvoorwaarden

- De code wordt ontwikkeld met Visual Studio en bevat ��n solution met verschillende projecten.
- Er wordt gebruik gemaakt van C# in een .NET Core omgeving.
- Als databank wordt er gebruik gemaakt van SQL Server.
- De technologie om met de databank te communiceren is ADO.NET.
- De code base wordt beheerd in Github.
- Voor de user interface wordt er gebruik gemaakt van WPF.
- Configuratie info wordt in config bestanden beheerd.
- De kwaliteit van de code wordt onder andere gewaarborgd door het gebruik van unit tests.

Opmerking: voorzie een flexibel ontwerp zodanig dat veranderingen geen al te grote impact hebben.

## Werkwijze

Dit project wordt uitgevoerd door een team van programmeurs (in dit geval 3 of 4 personen) waarbij samenwerken een belangrijke rol speelt. Naast het schrijven van code zijn er nog een heleboel andere taken (misschien niet de leukste) die moeten worden uitgevoerd. Het uitvoeren van een project is niet enkel de applicatie opleveren op een voorgestelde datum. In de eerste plaats moeten we er zeker van zijn dat hetgeen we opleveren wel degelijk is wat de klant wenst. Daarom zullen we op een &#39;agile&#39;-achtige manier te werk gaan. Dat wil zeggen dat we een aantal tussentijdse opleveringen gaan doen waarbij we afchecken bij de klant of dit is volgens de verwachtingen. Daarnaast moeten we er ook rekening mee houden dat deze applicatie zal moeten worden onderhouden (misschien niet door ons) en dat er dus voldoende documentatie beschikbaar is zodat een andere programmeur dit ook zou kunnen uitvoeren.

Om dit vlot te laten verlopen, gaan we een aantal rollen en verantwoordelijkheden defini�ren. Deze rollen zijn:

### Organisatie-rol :

- Inplannen meetings
- Rapporteert over de taakverdeling
- Zorgt voor de opvolging van het project (ook rapportage)
- Zorgt ervoor dat er voldoende documentatie is

### Testing-rol :

- Zorgt dat er voor elke klasse de nodige unit tests zijn
- Zorgt ervoor dat alle unit tests steeds op groen staan (ook na aanpassingen)
- Geeft overzicht van wat er getest is
- Zorgt voor integratie tests
- Zorgt ervoor dat volledige applicatie is getest

### Architectuur-rol :

- Is verantwoordelijk voor het ontwerp
- Maakt beslissingen over architectuur
- Documenteert en motiveert beslissingen
- Is verantwoordelijk voor de code base (Git)

### Business-rol :

- Klaart elke onduidelijkheid over de business uit aan het team
- Controleert op inhoudelijke correctheid
- Stelt (inhoudelijke) scenario&#39;s op die moeten worden getest
- Zorgt ervoor dat de business duidelijk wordt ge�nformeerd over de vooruitgang

Opmerking : als er bij verantwoordelijkheden staat &quot;zorgt ervoor dat ...&quot; wil dat niet per se zeggen dat de persoon met deze rol ook deze taak moet uitvoeren. Deze persoon moet ervoor zorgen dat de taak wordt uitgevoerd. Voorbeeld in de organisatie-rol staat er dat deze persoon ervoor zorgt dat er voldoende documentatie is. Dit wil niet zeggen dat deze persoon alle documentatie moet schrijven. Dit betekent wel dat deze persoon er moet op toezien dat elke klasse is gedocumenteerd (op een eenduidige manier), dat overzichtschema&#39;s van de klassen (rol architectuur) en testen (rol testing) op ��n plaats beschikbaar zijn en dat de documentatie inhoudelijk voldoet.

## Git/Github

De code moet beheerd worden in Git, en dit is een taak van elk lid van het team. Dit wil zeggen dat iedereen een basiskennis moet hebben aangaande het gebruik van Git/Github. Onderstaande links wijzen naar een aantal tutorials die daarbij kunnen helpen.

Opmerking : wanneer er aan verschillende taken tegelijkertijd wordt gewerkt door verschillende teamleden is het belangrijk dat we elkaar niet &#39;storen&#39;, branches/pull requests zouden daarbij zeker kunnen helpen.

[https://www.youtube.com/playlist?list=PLB5jA40tNf3v1wdyYfxQXgdjPgQvP7Xzg](https://www.youtube.com/playlist?list=PLB5jA40tNf3v1wdyYfxQXgdjPgQvP7Xzg)

[https://www.youtube.com/watch?v=Xb7r3KETy6g](https://www.youtube.com/watch?v=Xb7r3KETy6g)

[https://www.youtube.com/watch?v=nEzeMdzA\_Wk](https://www.youtube.com/watch?v=nEzeMdzA_Wk)

**Hoe gaan we te werk ?**

- **Samenstellen teams**
- **Verdelen van de rollen (wie wenst welke rol op zich te nemen?)**
- **Gezamenlijke analyse en ontwerp**
- **Taakverdeling**
- **Rapportage (om de 2 weken) :**
  - **De planning voor de komende 2 weken wordt voorgesteld (wie gaat wat doen)**
  - **Een meeting wordt ingepland met alle teamleden + lector (klant/product owner rol)**
  - **Een presentatie van de voortgang wordt gegeven (+ eventuele demo)**
- **Naarmate het project vordert zullen er ook technische sessies worden gegeven**