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

## Spelidé
Vi har tänkt att utveckla ett "laserspel" som först och främst kommer utvecklas för android och eventuellt för IOS om vi har tid. Spelidén grundar sig i att spelaren ska kunna styra en ljuskälla som i sin tur genererar en laserstråle. Denna laserstråle ska riktas mot olika objekt på spelplanen. Ett exempel på ett objekt som vi ska implementera är speglar som används för att vinkla laserstrålen för att ta sig fram till målet och klara av banan. 


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
Vi klarade av vårt mål gällande att utveckla ett spel med grundläggande funktionalitet. Vi har nu ett spel där vi kan använda både touch och mus-klick som input och styra både ljuskälla och speglar. Vi har inte haft några större problem gällande git utan har lyckats komma överens och kommunicera med varandra när vi har blivit osäkra.

Vi känner att vissa förbättringar över kommunikation om vem som gör vad behöver förbättras och att vi behöver bli mer effektiva i avseende på möten då vi tenderar att dra ut på dessa. Vi har därför kommit på en lösning angående att time-boxa våra möten och vara tydliga med mål och syte för de olika mötena vi har. Vi har även stött på utmaningar gällande att få med alla på resan så att de känner sig bekväma med vad och hur vi arbetar. Den lösning vi har tagit fram här är att gruppen måste lyssna på alla gruppmedlemars behov om problem uppstår eller om någon inte förstår. Vi har även kommit fram till att vi måste rotera i större grad i de grupper vi sitter och arbetar i för att förbättra kunskapsutbytet i gruppen vilket kommer främja vårt arbete.

### Sprint 2
För sprint 2 lägger vi nu fokuset på att förbättra vårt samarbete i gruppen och arbetar mot målet att alla ska vara delaktiga i det vi producerat i slutet av sprinten. Förbättringar inom kommunikation och arbetsätt är något vi tillsammans har kommit fram för att förbättra vårt samarbete och lösa diverse svårigheter och oklarheter som uppstått i den första sprinten. 

Spelet fortsätter vi att uveckla med nya komponenter och förfina de gamla. Denna sprint fokuserar vi även på att knyta samman spelet med oika menyer som användaren ska kunna interagera med. 

