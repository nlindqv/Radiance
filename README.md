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

### Stories

#### Lightsource
Lightsource innehåller en sfär som kropp samt ett lightspawn-objekt som används för startposition till ljusstrålen. Testscriptet roterar Lightsource en grad/frame. Scriptet kräver att första child till lightsource är lightspawn-objektet (standard). Det krävs även att man specar vilken laserstråle man vill använda, Standard är Assets/Prefabs/LaserRay.prefab

#### LaserRay
LaserRay är en komponent var moder innehåller en linerenderer som utgör själva laserstrålen som visas. Laserstrålen genereras med hjälp av linerenderer från lightspawns objektets (finns i lightsource)  position och riktning. Strålens längd bestäms utifrån raycast som genererar en osynlig stråle i spelet och kan meddela om strålen träffar något objekt. Träffar raycast något objekt så skall laserstrålen sluta vid den punkten.

#### LaserMode
LaserMode hanterar input från användaren när spelet är i laserläge. Input/musklick projeceras på spelplanen i spelet och på så sätt bestäms riktning på lightsource. Tidpunkten för genereringen av laserstrålar bestäms utifrån klassen "LaserMode". Nya laserstrålar genereras i coroutine "FireLaser" där meningen är att denna körs bara då musen/input förflyttas på skärmen vilket kräver att de gamla laserstrålarna skall förstöras och nya genereras.

#### Target & TargetMaster
Target väntar på en laserstråle som vid träff anropar HandleLaserCollision. Vid träff ändras färg på target från Röd till Grön samt Hit registreras. TargetMaster är parent till alla targets som finns på banan och undersöker varje frame om samtliga targets har registrerat hit, isåfall avancerar man till nästa nivå. Nya targets måste klassas som children till TargetMaster för att hits skall registreras korrekt.

### Sammanfattning för sprint 1


