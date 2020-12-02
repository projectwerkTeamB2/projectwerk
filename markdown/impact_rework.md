# Impact rework

##Algemeen

globaal gezien denk ik dat deze wijzinging 30 uur in beslag zou nemen, ik reken hier voor 1 dag werk op vlak van database,business en datalaag.
de overige 22 uur lijken me nodig om de UI op een zinvolle manier opnieuw in te delen.

##Database

het bedenken en maken van de aanpassingen aan de database lijken me een half uur werk.
dit lijkt me te gaan over een 2 tal extra kolommen aangezien strip collectie en strips een many to many relatie hebben moet hier ook een tussen tabel voorzien worden.

##businesslaag

 hier dient een extra model gemaakt te worden, met zijn eigen Irepository met testing schat ik dit op een 2 tal uur.
eigen manager ?

##Datalaag

implementatie en testing van de eigen repository, schrijven van de juiste queries, testing....


##Presentatielaag

###Main strip GUI:

-Mainwindow datagrid zou nu ook stripcollection moeten kunnen tonen als strip in collectie zit
 men kan een knop maken om de ENKEL collections eens apart te bekijken en de strips erin,
 of een klik mogelijkheid om de collectie in meer details te bekijken.
 
 -Manager moet in code zowel strips als stripcollections ontvangen van db langs de generalManager.
 
 -Er zou een knop en code moeten aangemaakt worden om een collectie aan te maken.
   
   ^(kan een nieuwe wpf window nodig hebben, dus een extra button+code)^
 
 -Er zou een knop en code moeten aangemaakt worden om een collectie te wijzigen.
   
   ^(kan een nieuwe wpf window nodig hebben, dus een extra button+code)^

-Er zou een knop en code moeten aangemaakt worden om een collectie te verwijderen.
 
 -Nieuwe zoek radiobutton en code schrijven op collection naam.
 
 -Reset knop zou ook van code moeten veranderen om collections te blijven tonen.
 
 -Er moet documentatie bijgeschreven/veranderd moeten worden.

 -Extra try catchers aanmaken
 
###Json GUI:

-De json reader en weschrijver zouden veranderd moeten worden:
 Zodat die zowel strip als stripcollections weg kan schrijven en inlezen.

-De bewerk knop zoud moeten nagekeken worden op nieuwe methodes hierboven.

-Er moet documentatie bijgeschreven/veranderd moeten worden.

-Extra try catchers aanmaken


##Besluit
