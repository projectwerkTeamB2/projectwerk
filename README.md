# Algemeen samenwerkings document

## Algemene Afspraken

•  Discord is het main communicatiekanaal  
•  Om de paar dagen (zeker 2 keer per week) houden we een voice call.  
•  gebruik projects in github om de tickets te bewegen waar je mee bezig bent  
•  tickets gaan maar naar done eens ze besproken geweest zijn tijdens een call.  
•  Iedere 2 weken word op zondag om 22 uur develop gemerged met master dus zorg voor werkende dingen op develop tegen dan.  
•  gebruik branches voor features die nog niet af zijn.  
•  Een uur voor de call op maandag bespreken we samen de dingen.  


## TaakVerdeling

    Organisatie-rol :  césar
    •    Inplannen meetings
    •    Rapporteert over de taakverdeling
    •    Zorgt voor de opvolging van het project (ook rapportage)
    •    Zorgt ervoor dat er voldoende documentatie is
    
    Testing-rol : Vlad
    •    Zorgt dat er voor elke klasse de nodige unit tests zijn
    •    Zorgt ervoor dat alle unit tests steeds op groen staan (ook na aanpassingen)
    •    Geeft overzicht van wat er getest is
    •    Zorgt voor integratie tests
    •    Zorgt ervoor dat volledige applicatie is getest
    
    Architectuur-rol : Jef
    •    Is verantwoordelijk voor het ontwerp
    •    Maakt beslissingen over architectuur
    •    Documenteert en motiveert beslissingen
    •    Is verantwoordelijk voor de code base (Git)
    
    Business-rol : Ljena
    •    Klaart elke onduidelijkheid over de business uit aan het team
    •    Controleert op inhoudelijke correctheid
    •    Stelt (inhoudelijke) scenario’s op die moeten worden getest
    •    Zorgt ervoor dat de business duidelijk wordt geïnformeerd over de vooruitgang
    
 ### now VS later
    now
     - een project met solution maken, en online zetten
     - klasses aanmaken (business laag)
       + Strip
       +Reeks (+nummer in reeks)
       + Auteur
       + Uitgeverij
     - repository aanmaken (business laag) moet kunnen:
       +aanmaken,wijzigen en verwijderen van strips
       +strip opzoeken en weegeven
 
     Later...
     - databank aanmaken 
     - bestanden kunnen ophalen (data laag)
     - bestanden kunnen weglezen (data laag)
     - repository aanmaken (data laag)
     - testen aanmaken (business laag)
     - testen aanmaken (data laag)
     - gui opzetten
