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

#### Spegel 
En spegel är ett objekt som kan reflektera ljuset. Bygger på samma principer som en vanlig spegel. När en ljustråle träffar spegeln anropas HandleLaserCollision som i sin tur skapar en ny ljusstråle.   

#### Flytta och rotera objekt 
Vissa objekt har spelaren möjlighet att flytta och rotera. Det fungerar som att objektet har en "hitbox" som när spelaren klickar så följer objektet spelarens finger till spelaren släpper objeket. Om objeket är roterbart så kommer ett roteringsvektyg nu fran på skärmen och det är möjligt att rotera objeket. Klickar spelaren någonannastans på skärmen så försvinner verktyget.   

## Sammanfattning för sprint 1
Vi klarade av vårt mål gällande att utveckla ett spel med grundläggande funktionalitet. Vi har nu ett spel där vi kan använda både touch och mus-klick som input och styra både ljuskälla och speglar. Vi har inte haft några större problem gällande git utan har lyckats komma överens och kommunicera med varandra när vi har blivit osäkra.

Vi känner att vissa förbättringar över kommunikation om vem som gör vad behöver förbättras och att vi behöver bli mer effektiva i avseende på möten då vi tenderar att dra ut på dessa. Vi har därför kommit på en lösning angående att time-boxa våra möten och vara tydliga med mål och syte för de olika mötena vi har. Vi har även stött på utmaningar gällande att få med alla på resan så att de känner sig bekväma med vad och hur vi arbetar. Den lösning vi har tagit fram här är att gruppen måste lyssna på alla gruppmedlemars behov om problem uppstår eller om någon inte förstår. Vi har även kommit fram till att vi måste rotera i större grad i de grupper vi sitter och arbetar i för att förbättra kunskapsutbytet i gruppen vilket kommer främja vårt arbete.

## Sprint 2
För sprint 2 lägger vi nu fokuset på att förbättra vårt samarbete i gruppen och arbetar mot målet att alla ska vara delaktiga i det vi producerat i slutet av sprinten. Förbättringar inom kommunikation och arbetsätt är något vi tillsammans har kommit fram för att förbättra vårt samarbete och lösa diverse svårigheter och oklarheter som uppstått i den första sprinten. 

Spelet fortsätter vi att uveckla med nya komponenter och förfina de gamla. Denna sprint fokuserar vi även på att knyta samman spelet med oika menyer som användaren ska kunna interagera med. 

### Stories

#### Ljusdelaren - prisma
Ljusdelaren är ett objekt som ska vara utplacerad på spelplanen. Den har egenskapen att dela in infallande ljustrålar i tre nya ljustrålar med färger Röd, Grön, Blå (RGB). I sin senaste version har det ändrats på så sätt att objektet - ljusdelaren - i Unity har tre tomma "barnobjekt" kopplade till sig och varje gång ljus infaller mot ena sida, genereras tre nya ljusstrålar i den position de tre knutna barnobjekt sitter i förhållande till rummet, mitt emot infallsvinkeln.

#### Gate - ColorChanger
En ColorChanger inväntar en laserstråle och vid kollision mellan laserstråle och gatens hitbox genereras en ny laserstråle med den nya färgen specad i parametern Color.

#### Mover & BezierCurve
Mover förekommer i fyra olika former, varje form transporterar valfritt spelobjekt fram och tillbaka längs formen.
1. Rak linje
2. Fyrkant
3. Cirkel
4. S-formad
Varje mover har en BezierCurve (script) som definierar kurvan som ett externt objekt. 

*För att kunna förflytta ett objekt krävs att det tilldelas scriptet BezierMover samt att kurvan som objektet ska följa dras till parametern B (Bezier Curve).*
* Toggl ändrar riktning på förflyttningen
* Speed definierar hastigheten, innehar typiskt ett värde [1-20]

## Sammanfattning för sprint 2

Vi klarade av vårt mål att få hela gruppen engagerad och delaktiga i demon. Vi lyckades även förbättra samarbetet och kommunikationen i gruppen genom att rotera i högre grad runt och arbeta med "nya" partners. Vi stötte på ett par problem i sprint 2 gällande ojämn fördelning av arbete. Vi fick att ett par personer tog sig an större uppgifter och blev låsta en längre tid medan andra hade ingenting att göra. Lösningen vi föreslår till nästa sprint är att rotera partners varje dag för att involvera fler i gruppen i samma problem samtidigt som flera får arbeta med olika stora problem. 

## Sprint 3 

Inför sprint 3 lägger vi nu fokus på att sätta ihop alla delar i spelet och har som mål att producera en första release-kandidat. I den första releasen ska vi fokusera på att skapa ett häftigare och mer sammanhängande spel genom att introducera ett tema för alla komponenter samt att lägga på animeringar i spelet. En annan viktig egenskap som vi har tänkt att prioritera i denna sprint är minnes-hanteringen i spelet så att användaren kan avancera i spelet och hålla koll på sin utveckling mellan spelomgångar samtidigt som vi utvecklare kan implementera spelet på ett mer effektivt sätt. Vi tänker även prioritera feedback så att vi får en bredare insyn i hur vi kan förbättra vårt spel.

I vårt arbetssätt kommer vi att försöka fördela arbetsuppgifter mer jämt mellan personer så att flera får bättre kunskap om designen i vitala delar av spelet och flera får mer varierade arbetsuppgifter. 

## Sammanfattning för sprint 3

Vi klarade av vårt sprint mål och har en release-kandidat. Vi har lyckats implementera både animeringar, minne samt kunnat få lite feedback på vad som behöver förbättras i vårt spel. Vi behöver dock fortfarande se över våra komponenter i spelet så att de håller sig till samma tema samt fixa en del buggar. 

TBC

