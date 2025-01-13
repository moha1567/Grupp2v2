
# User Stories

---

## User Stories för applikationen


### Verifiera korrekt personnummer:
1. **Som en användare vill jag kunna mata in ett svenskt personnummer så att jag kan få veta om det är korrekt eller inte.**

**Kriterier för acceptans:**
- Om personnumret är korrekt enligt kontrollreglerna, ska ett meddelande visas som bekräftar detta.
- Om personnumret är felaktigt, ska ett meddelande visas som anger att det är ogiltigt.

### Få detaljer om personnumret
2. **Som en användare vill jag kunna få information om personens födelsedatum och kön baserat på personnumret, så att jag kan förstå mer om dess struktur.**
	
**Kriterier för acceptans:**
- Applikationen ska returnera födelsedatum i formatet ÅÅÅÅ-MM-DD.
- Applikationen ska identifiera könet baserat på den näst sista siffran i personnumret.

### Hantering av ogiltig inmatning
3. **Som en användare vill jag få ett tydligt felmeddelande om jag matar in ett personnummer i fel format, så att jag kan rätta till det.**

**Kriterier för acceptans:**
- Om personnumret inte är i rätt format, ska ett felmeddelande visas som anger att det är ogiltigt.
- Om inmatningen innehåller ogiltiga tecken (t.ex. bokstäver eller specialtecken), ska applikationen hantera detta med ett tydligt felmeddelande.

### Hantering av ogiltig inmatning
4. **Som en användare vill jag att applikationen inte kraschar vid felaktiga inmatningar, så att jag kan känna mig trygg att använda den.**

**Kriterier för acceptans:**
- Applikationen ska hantera ogiltiga inmatningar utan att krascha.
- Ett felmeddelande ska visas, och användaren ska få en chans att mata in ett nytt personnummer.

### Visa avslutande meddelande
5. **Som en användare vill jag att applikationen visar ett meddelande om jag väljer att avsluta, så att jag vet att processen är färdig.**

**Kriterier för acceptans:**
- Applikationen ska visa "Tack för att du använde verifieraren!" vid avslutning.


---

## User Stories för enhetstester

### Verifiera giltiga personnummer
1. **Som en utvecklare vill jag att tester ska verifiera att applikationen korrekt identifierar giltiga svenska personnummer så att valideringslogiken är robust.**

**Kriterier för acceptans:**
- Testa flera giltiga personnummer i olika format, t.ex.: 
	- `19900101-1234` (12-siffrigt format med bindestreck).
	- `9001011234` (10-siffrigt format utan bindestreck).
- Bekräfta att metoden för validering returnerar true för dessa giltiga personnummer



###Identifiera ogiltiga personnummer**
2. **Som en utvecklare vill jag att tester ska verifiera att applikationen korrekt identifierar ogiltiga svenska personnummer så att felaktig data avvisas.**

**Kriterier för acceptans:**
- Testa flera ogiltiga personnummer, t.ex.:
	- `19901301-1234` (ogiltigt födelsedatum: 13:e månad).
	- `19900230-1234`(ogiltigt födelsedatum: 30 februari).
	- `900101-123` (felaktig längd).
	- `abc123` (felaktigt format).
- Bekräfta att metoden för validering returnerar false för dessa personnummer.

### Kontrollera födelsedatumsextrahering
3.**Som en utvecklare** vill jag testa metoden som extraherar födelsedatum från ett giltigt personnummer så att datumet visas korrekt.** 

**Kriterier för acceptans:**
- Från personnumret `19900101-1234`, ska metoden returnera födelsedatumet `1990-01-01`.
- Från personnumret `9001011234`, ska metoden returnera födelsedatumet `1990-01-01`.

###  Hantera olika format
5. **Som en utvecklare** vill jag testa att applikationen hanterar personnummer i olika format (med eller utan bindestreck, 10- eller 12-siffriga) så att användaren kan ange data flexibelt.**

**Kriterier för acceptans:**
- Personnumret `19900101-1234` ska behandlas som giltigt.
- Personnumret `9001011234` ska behandlas som giltigt.
- Personnumret `199001011234` ska behandlas som giltigt.

###  Hantera tom eller ogiltig inmatning
6. **Som en utvecklare** vill jag testa att applikationen hanterar tomma strängar eller strängar med felaktiga tecken så att den inte kraschar.**

**Kriterier för acceptans:**
- En tom sträng (`""`) ska returnera `false`.
- En sträng med ogiltiga tecken (`"abc123"`) ska returnera `false`.
- En sträng med specialtecken (`"1990@01!01234"`) ska returnera `false`

### Validera enligt Luhn-algoritmen
7. **Som en utvecklare** vill jag testa att valideringslogiken implementerar Luhn-algoritmen korrekt så att kontrollsiffran verifieras.**

**Kriterier för acceptans:**
- Personnumret `19900101-1234` (med korrekt kontrollsiffra) ska returnera `true`.
- Personnumret `19900101-1235` (med felaktig kontrollsiffra) ska returnera `false`.


---

## User Stories för GitHub Actions och CI/CD

### Automatisera byggen**
1. **Som en utvecklare vill jag att GitHub Actions automatiskt bygger projektet vid varje push till huvudgrenen så att jag kan säkerställa att koden alltid kompileras korrekt.**
**Kriterier för acceptans:**
- Workflow ska triggas automatiskt vid varje push eller pull request till huvudgrenen (main).
- Workflow ska inkludera steg för att installera beroenden, bygga projektet och rapportera om bygget lyckades eller misslyckades.
- Om bygget misslyckas ska felmeddelanden loggas tydligt i GitHub Actions-loggarna.

### **Automatisera enhetstester**
2. **Som en utvecklare vill jag att GitHub Actions kör alla enhetstester automatiskt vid varje push så att jag kan upptäcka buggar i ett tidigt skede.**

   **Kriterier för acceptans:**
   - Workflow ska köra alla enhetstester automatiskt efter att projektet byggts.
   - Om något test misslyckas ska ett felmeddelande visas med information om vilka tester som misslyckades.
   - Testresultat ska vara tydligt synliga i GitHub Actions-loggarna.

### **Hantera flera brancher**
3. **Som en utvecklare vill jag att GitHub Actions bara kör workflows på specifika brancher (t.ex. `main` och `development`) så att onödiga tester inte körs på irrelevanta brancher.**

   **Kriterier för acceptans:**
   - Workflow ska konfigureras så att det endast körs för `main` och `development`-brancher.
   - Workflow ska ignorera brancher som inte är relevanta för integration eller release.

### **Automatisera kodgranskning**
4. **Som en utvecklare vill jag att GitHub Actions validerar kodkvalitet genom att köra statiska analyser så att kodstandarder upprätthålls.**

   **Kriterier för acceptans:**
   - Workflow ska inkludera steg för att köra statiska analysverktyg (t.ex. linters eller analys av kodtäckning).
   - Om kod inte uppfyller standarder ska ett felmeddelande visas i loggarna.
   - Statiska analysresultat ska visas som kommentarer på pull requests.

### **Automatiskt rapportera status**
5. **Som en utvecklare vill jag att GitHub Actions uppdaterar status för byggen och tester på varje pull request så att teamet kan fatta informerade beslut om kodsammanfogning.**

   **Kriterier för acceptans:**
   - Pull requests ska visa status för byggen och tester direkt i GitHub (grön bock för godkänt, röd kryss för misslyckat).
   - Statusmeddelanden ska innehålla tydlig information om orsaken till eventuella misslyckanden.

   ### **Stöd för flera miljöer**
6. **Som en utvecklare vill jag att GitHub Actions workflows ska kunna köras i olika miljöer (t.ex. olika .NET-versioner) så att jag kan säkerställa kompatibilitet.**

   **Kriterier för acceptans:**
   - Workflow ska inkludera en matrisstrategi för att testa projektet på flera versioner av .NET (t.ex. `6.0`, `7.0`).
   - Workflow ska misslyckas om projektet inte fungerar korrekt i någon av de specificerade miljöerna.

   ### **Minimera exekveringstid**
7. **Som en utvecklare vill jag att GitHub Actions workflows ska köras så snabbt som möjligt så att jag slipper vänta länge på resultaten.**

   **Kriterier för acceptans:**
   - Workflow ska konfigureras för att endast köra nödvändiga steg och använda cache för beroenden (t.ex. `dotnet restore`).
   - Tiden för att köra ett workflow ska loggas, och workflow ska optimeras för att minska onödiga steg.

   ---

   ## **User Stories för Docker-container med CI/CD**

### **Skapa och bygga Docker-container**
1. **Som en utvecklare vill jag skapa en Docker-container för personnummerkontrollapplikationen så att applikationen kan köras i en isolerad och portabel miljö.**

   **Kriterier för acceptans:**
   - En Dockerfile ska skapas och inkludera alla nödvändiga steg för att bygga applikationen (t.ex. kopiera källkod, installera beroenden, köra applikationen).
   - Docker-containern ska kunna byggas lokalt med kommandot `docker build`.
   - När containern körs ska applikationen starta och vara funktionell.

---

### **Automatisera Docker-build med GitHub Actions**
2. **Som en utvecklare vill jag att GitHub Actions automatiskt bygger Docker-containern vid varje push till huvudgrenen så att processen är helt automatiserad.**

   **Kriterier för acceptans:**
   - GitHub Actions ska konfigureras för att bygga Docker-containern automatiskt vid varje `push` eller `pull request` till huvudgrenen (`main`).
   - Workflow ska innehålla steg för att:
     - Klona repository.
     - Bygga Docker-containern med hjälp av `docker build`.
   - Fel i byggprocessen ska loggas tydligt i GitHub Actions-loggarna.

---

### **Publicera Docker-container till DockerHub**
3. **Som en utvecklare vill jag att Docker-containern publiceras automatiskt på DockerHub så att andra kan använda den enkelt.**

   **Kriterier för acceptans:**
   - Workflow ska inkludera ett steg för att logga in på DockerHub med hjälp av GitHub Secrets.
   - Containern ska taggas korrekt (t.ex., med `latest` eller commit-hash).
   - Containern ska pushas till ett fördefinierat DockerHub-repository (t.ex. `username/personnummerkontroll`).
   - Publiceringssteget ska endast köras om bygget är framgångsrikt.

---

### **Användning av GitHub Secrets**
4. **Som en utvecklare vill jag använda GitHub Secrets för att säkert hantera mina DockerHub-credentials så att känslig information inte exponeras.**

   **Kriterier för acceptans:**
   - DockerHub-användarnamn och lösenord ska lagras som GitHub Secrets (`DOCKER_USERNAME` och `DOCKER_PASSWORD`).
   - Workflow ska använda dessa secrets för att logga in på DockerHub.
   - Secrets ska inte vara synliga i GitHub Actions-loggarna.

---

### **Testa Docker-containern**
5. **Som en utvecklare vill jag att Docker-containern testas efter att den byggts så att jag kan säkerställa att den fungerar korrekt.**

   **Kriterier för acceptans:**
   - Workflow ska innehålla ett steg för att köra Docker-containern och verifiera att applikationen startar.
   - Om containern inte startar eller om applikationen inte fungerar som förväntat ska felmeddelanden loggas tydligt.
   - Teststeget ska köras innan containern publiceras till DockerHub.

---

### **Stöd för flera miljöer**
6. **Som en utvecklare vill jag kunna bygga och testa Docker-containern i olika miljöer (t.ex. olika basbilder) så att jag kan säkerställa kompatibilitet.**

   **Kriterier för acceptans:**
   - Workflow ska använda en matrisstrategi för att testa Docker-containern med flera basbilder (t.ex., `debian`, `alpine`).
   - Workflow ska logga om något test misslyckas i en specifik miljö.