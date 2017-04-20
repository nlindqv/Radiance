# Ljusspel 

Projektsida för grupp 4

[Editor on GitHub](https://github.com/Byssis/Project2017/edit/master/README.md) 

### Gruppmedlemmar
**Product owner:** Senad Delic <senadmd@kth.se> <br/>
**Scrum master:** Victor Bodell <vbodell@kth.se> <br/>
Sara Ersson <saraers@kth.se><br/>
Albin Byström <albinby@kth.se><br/>
Benedith Mulongo <mulongobent@yahoo.fr><br/>
Niklas Lindqvist <nlindqv@kth.se><br/>
Emma Good <egood@kth.se><br/>
Michaela Jangefalk <mija5666@kth.se><br/>

### Kontakt

[Mail](https://github.com/contact).


## Sprint 1

För sprint 1 har vi fokuserat på de utmaningar som finns i att jobba med nya verktyg och platform som de flesta av oss inte har använt oss av förut. Vårt fokus ligger i att få en bra rutin i git-hantering men även att snabbt komma in i arbetet genom att bland annat använda parprogrammering. Just nu står vi inför en lång upplärrningsbacke och har som sprintmål att producera ett spel med grundläggande  funktionalitet utifrån vår spelidé och fokus på design kommer att prioriteras senare i projektet. 

###Stories

####Target & TargetMaster

Target väntar på en laserstråle som vid träff anropar HandleLaserCollision. Vid träff ändras färg på target från Röd till Grön samt Hit registreras. TargetMaster är parent till alla targets som finns på banan och undersöker varje frame om samtliga targets har registrerat hit, isåfall avancerar man till nästa nivå. Nya targets måste klassas som children till TargetMaster för att hits skall registreras korrekt.
