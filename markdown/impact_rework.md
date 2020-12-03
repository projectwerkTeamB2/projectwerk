# Impact rework

##Algemeen

Globaal gezien verwachten wij dat deze scope wijziging dertig uur in beslag zal nemen.
wij voorzien hiervoor een volle dag werk(8 uur) om de database, business- en datalaag aan te passen aan de nieuwe vereisten.

De overige 22 uur plannen we in om de GUI op een zinvolle manier te herwerken.  

##Database (geschatte tijd: 30 minuten)

We schatten een half uur om de aanpassingen aan de databank uit te voeren.

We verwachten twee extra kolommen bij te moeten voegen.
  - StripCollectie
  - StripCollectie_has_strips
 
 Deze laatste fungeert als een tussentabel omwille van de many to many relatie tussen strips en stripcollecties.

##Businesslaag (geschatte tijd: 2 uur)
Wij voorzien volgende wijzigingen op de Businesslaag:
 - het aanmaken van    
    -  StripCollectie model 
    -  StripCollectie Manager
    -  StripCollectie IRepository

##Datalaag (geschatte tijd: 4 uur)
Wij voorzien volgende wijzigingen op de Datalaag:
 - het aanmaken van    
    -  StripCollectie Datalaagmodel 
    -  StripCollectie ConvertieFuncties
    -  StripCollectie Repository & queries
    
 - het wijzigen van onze sqlQueryBuilder 
    -  stripcollecties kunnen verwerken.

##Presentatielaag (geschat snelst op: 17.7 uur, verwacht: 19.5 uur)

###Main strip GUI: Geschatte tijd: 10.8uur

- Aanmaken/aanpassingen van nieuwe schermen of buttons
  - Er zou een knop en code moeten aangemaakt worden om een collectie aan te maken.(120 min)
 
  - Er zou een knop en code moeten aangemaakt worden om een collectie te wijzigen.(120 min)

  - Er zou een knop en code moeten aangemaakt worden om een collectie te verwijderen.(20 min)
   - Nieuwe zoek radiobutton en code schrijven op collection naam.(45 min)
 - Aanpassingen van al bestaande componenten
   - Mainwindow datagrid zou nu ook stripcollection moeten kunnen tonen als strip in collectie zit.
 Men kan een knop maken om dan **enkel** collections eens apart te bekijken en de strips erin, of een klik mogelijkheid om de collectie in meer details te bekijken.(50 min)
 
   - Manager moet in code zowel strips als stripcollections ontvangen van db langs de generalManager.(15 min)
   - Resetknop standaardgedrag wijzingen om rekening te houden met collecties.(25 min)
 - Laatste stappen
   - Er moet documentatie bijgeschreven/veranderd moeten worden.(25 min)

   - Extra try catchers aanmaken.(30 min)
 
   - Testen + mensen die de GUI uit proberen.(180 min)
 
 
###Json GUI: Geschatte tijd: 6.9 uur

   - verwachte wijzigen:
   
     -  extra models en convertion functies
     
     - zowel strip als stripcollections weg kunnen schrijven en inlezen.(200 min)

     - De bewerk knop zou moeten nagekeken worden op nieuwe methodes hierboven.(45 min)
     - 
 - Laatste stappen
     - Er moet documentatie bijgeschreven/veranderd moeten worden.(25 min)

     - Extra try catchers aanmaken.(25 min)
 
     - Testen + mensen die de GUI uit proberen.(120 min)



##Testing (geschatte tijd 5 uur)

Unit tests
- constructor & regels
- bevat de collectie effectief lijsten van strips 

integratietests
- CRUD functies
- bestaan de strips in collectie



##Besluit