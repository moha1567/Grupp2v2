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

