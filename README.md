**Uppgiftsbeskrivning: C# Konsolapplikation och Docker Container för Kontroll av Svenskt Personnummer**

Välj gruper själva om ca 4 personer och skriv upp er i följande dokument senast måndag 13/1 kl 8.30
https://docs.google.com/spreadsheets/d/1qWvunKB7zd8lB_Mn9he6-arAcEWzwoy2oy0n5ZASFn8/edit?usp=sharing

Målet med denna uppgift är att skapa en konsolapplikation i C#, som fungerar som en kontroll av ett svenskt personnummer. Applikationen ska kunna verifiera om ett givet personnummer är korrekt. Dessutom ska du skriva enhetstester för applikationen och använda GitHub Actions för att automatisera testning samt bygga och publicera en Docker-container till DockerHub.
Läs mer om personnummer : https://sv.wikipedia.org/wiki/Personnummer_i_Sverige

**Krav:**

1. **Skapa en C# Konsolapplikation för Personnummerkontroll:**
   - Skapa en konsolapplikation som tar emot ett svenskt personnummer och verifierar dess korrekthet.
   - Använd C# för att implementera kontrolllogiken för personnumret.

2. **Skriv enhetstester:**
   - Skriv enhetstester för olika delar av din personnummerkontrollapplikation.
   - Använd ett enhetstestramverk som NUnit eller XUnit.

3. **Använd GitHub Actions för kontinuerlig integration:**
   - Konfigurera GitHub Actions för att automatisera bygget och enhetstestningen av projektet.

4. **Bygga och publicera en Docker-container:**
   - Skapa en Dockerfile för att paketera din personnummerkontrollapplikation i en Docker-container.
   - Konfigurera GitHub Actions för att bygga Docker-container och publicera den på DockerHub.
   - Använd GitHub Secrets för att säkert lagra och använda DockerHub-credential.

5. **Dokumentation:**
   - Skriv dokumentation för hur man kan köra och testa personnummerkontrollapplikationen lokalt och hur man kan dra ner och köra Docker-containern.
   - Inkludera även information om svenska regler för personnummer och hur din applikation genomför kontrollen.
   - Inkludera dokumentationen i README.md i ert github projekt

**Deadline:**

Inlämning ska ske senast 17/1 klockan 23.59 på omniway. Alla gruppmedlemmar lämnar in länk till GitHub repot.
Onsdag 15/1 ska varje grupp göra en avstämning med utbildaren.

Lycka till!
________________________________________
________________________________________
________________________________________

<u>**Projektets dokumentation**</u>

**Svenska regler för personnummer**

Ett svenskt personnummer består av följande format:
YYYYMMDD-XXXX eller YYMMDD-XXXX, med eller utan bindestreck.
YY eller YYYY: År, kan anges med 2 eller 4 siffror.
MM: Månad, 1-12.
DD: Dag 1-31.
XXXX: De tre första siffrorna efter bindestrecket är ett unikt individnummer som identifierar personen. Innan 1990 angav de 2 första av dessa siffrorna vilket län personen var född i. Sedan 1990 är dessa siffror slumpvis valda. Den tredje siffran avslöjar juridiskt kön, udda siffra = man, jämn siffra = kvinna.
Den sista siffran är en kontrollsiffra som beräknas med hjälp av Luhn-algoritmen. Den säkerställer att hela personnumret är korrekt.
________________________________________
Hur applikationen validerar personnummer
Applikationen består av en klass, PersonalNumberValidator, som stegvis kontrollerar ett personnummer enligt de svenska reglerna. Valideringsprocessen sker i följande steg:
1. Rensa personnumret från bindestreck och mellanslag
Metoden CleanPersonalNumber tar bort bindestreck och mellanslag från användarens inmatning för att förenkla valideringen.
Exempel: 19851231-1234 omvandlas till 198512311234.
2. Kontrollera att formatet är korrekt
Metoden IsValidFormat verifierar att personnumret består av antingen 10 eller 12 siffror och att det endast innehåller numeriska värden.
3. Kontrollera att datumdelen är giltig
Metoden IsValidDate kontrollerar om de första siffrorna i personnumret motsvarar ett giltigt datum i formatet yyyyMMdd (för 12 siffror) eller tolkar datumet med hjälp av sekel (för 10 siffror):
•	För 10-siffriga personnummer avgörs århundradet baserat på årtalet:
o	Om årtalet är högre än nuvarande år tolkas som 19xx.
o	Annars som 20xx
Denna metod kommer alltså inte fungera för personer som är äldre än 100 år och som anger 10 siffror.
•	DateTime.TryParseExact används för att säkerställa att datumen är giltiga.

4. Kontrollera Luhn-algoritmen
Metoden PassesLuhnAlgorithm använder Luhn-algoritmen för att validera den sista siffran (kontrollsiffran).
Processen:
1.	Om personnumret har 12 siffror tas de första två siffrorna (århundrade) bort.
2.	Algoritmen itererar genom varje siffra i personnumret, räknat från höger till vänster:
o	Varannan siffra multipliceras med 2.
o	Om resultatet blir större än 9, subtraheras 9 från resultatet. Det är samma som att addera de två siffrorna till varandra. 
3.	Summan av alla modifierade siffror beräknas.
4.	Kontrollera att summan är delbar med 10.
Om summan är jämnt delbar med 10 anses personnumret vara giltigt enligt Luhn-algoritmen.
5. Helhetsvalidering
Metoden ValidatePersonalNumber anropar följande steg i turordning:
1.	Rensa personnumret.
2.	Kontrollera formatet.
3.	Validera datumdelen.
4.	Kontrollera Luhn-algoritmen.
Om samtliga steg godkänns anses personnumret giltigt.

Exempel på användning
1.	Applikationen begär inmatning från användaren via Console.ReadLine().
2.	Metoden ValidatePersonalNumber utför valideringen.
3.	Resultatet (giltigt eller ogiltigt) presenteras i konsolen.

