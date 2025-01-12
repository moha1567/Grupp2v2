
# User Stories

---

## User Stories för applikationen


### Verifiera korrekt personnummer:
* 1.Som en användare vill jag kunna mata in ett svenskt personnummer så att jag kan få veta om det är korrekt eller inte.
|
└── ** Kriterier för acceptans:
	 * Om personnumret är korrekt enligt kontrollreglerna, ska ett meddelande visas som bekräftar detta.
	 * Om personnumret är felaktigt, ska ett meddelande visas som anger att det är ogiltigt.

### Få detaljer om personnumret
* 2.Som en användare vill jag kunna få information om personens födelsedatum och kön baserat på personnumret, så att jag kan förstå mer om dess struktur.
|
└── ** Kriterier för acceptans:
	 * Applikationen ska returnera födelsedatum i formatet ÅÅÅÅ-MM-DD.
	 * Applikationen ska identifiera könet baserat på den näst sista siffran i personnumret.

### Hantering av ogiltig inmatning
* 3.Som en användare vill jag få ett tydligt felmeddelande om jag matar in ett personnummer i fel format, så att jag kan rätta till det.
|
└── ** Kriterier för acceptans:
	 * Om personnumret inte är i rätt format, ska ett felmeddelande visas som anger att det är ogiltigt.
	 * Om inmatningen innehåller ogiltiga tecken (t.ex. bokstäver eller specialtecken), ska applikationen hantera detta med ett tydligt felmeddelande.

### Hantering av ogiltig inmatning
* 4.Som en användare vill jag att applikationen inte kraschar vid felaktiga inmatningar, så att jag kan känna mig trygg att använda den.
|
└── ** Kriterier för acceptans:
	 * Applikationen ska hantera ogiltiga inmatningar utan att krascha.
     * Ett felmeddelande ska visas, och användaren ska få en chans att mata in ett nytt personnummer.

### Visa avslutande meddelande
* 5.Som en användare vill jag att applikationen visar ett meddelande om jag väljer att avsluta, så att jag vet att processen är färdig.
|
└──	** Kriterier för acceptans:
	 * Applikationen ska visa "Tack för att du använde verifieraren!" vid avslutning.


---

## User Stories för enhetstester

### Verifiera giltiga personnummer
* 1. Som en utvecklare vill jag att tester ska verifiera att applikationen korrekt identifierar giltiga svenska personnummer så att valideringslogiken är robust.
|
└── ** Kriterier för acceptans:
	 * Testa flera giltiga personnummer i olika format, t.ex.: 
	 * 19900101-1234 (12-siffrigt format med bindestreck).
	 * 9001011234 (10-siffrigt format utan bindestreck).
	 * Bekräfta att metoden för validering returnerar true för dessa giltiga personnummer