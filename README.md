#e_pi_i

##Kino

**Članovi tima**:
1. Amila Jakubović 
2. Emina Medar
3. Nejla Smajić

####**Opis teme**

Ovaj softver je osmisljen tako da komunikaciju izmedu klijenta i uposlenika  kina cini jednstavnijom. Kada se klijent pozeli prepustiti carima sedme umjetnosti potrebno je da dodje na blagajnu kina gdje ce moci izabrati nesto iz ponude bas po svojoj mjeri. Nakon sto odabere film iz ponude, i vrijeme projekcije, na raspolaganju je i niz drugih mogucnosti. Naime, ukoliko zeli, klijent moze uzeti i nesto od hrane i pica, kao i zakupiti parking mjesto na nekoliko sati. Kako su zelje klijenta zapovijed poslodavca, menadzer kina pomocu ovog softvera, pored formiranja klasicne ponude kina, u stanju je formirati i posebne pakete usluga. Ti paketi ukljucuju razlicite kombinacije usluga koje koje kino moze pruziti, a namijenjeni su razlicitim ciljnim grupama. Nakon sto klijent kaze svoje zelje, uposlenik ce uz pomoc sofvera provjeriti raspolozivost. Ukoliko kapaciteti nisu popunjeni uposlenik na blagajni zakljucuje narudzbu, i izvrsi naplatu, a softver automacki azurira podatke sistema u skladu sa onim sto je klijent odabrao.
Bitno je napomenuti da su direktoru i menadzeru kina u svakom trenutku dostupni podaci o profitu, posjecenosti, gledanosti, stanju zaliha, i to pomocu ovog softvera, koji je napravljen tako da u svakom trenutku moze generisati pojedine izvjestaje.  Sa svim mogucnostima koje ovaj softver pruza, on bi trebao doprinijeti efikasnijem radu kina, i fleksibilnijoj komunikaciji izmedju uposlenika i posjetitelja kina.


####**Procesi**

######**Formiranje ponude**
Ponudu kina u cjelosti formira menadžer. Nakon sto se loguje na softver, njemu je omogućeno da dodaje nove i briše stare  filmove sa popisa filmova čija se projekcija vrši naredne sedmice. Također, on formira posebne pakete usluga koji sa sobom nose određene pogodnosti za klijente (family, birthday, lady,... pakete). Prilikom formiranja ponude menadžer određuje cijene  karata za projekcije, kao i cijene posebnih paketa.
######**Izmjena  ponude**
Nakon logovanja na softver menadžer je u mogućnosti da napravi izmjene u ponudi za tekuću sedmicu, poput promjene termina pojedinih projekcija, ili neke dugoročnije izmjene, poput promjene cijena grickalica i sokova.
######**Praćenje i nabavka zaliha robe**
Softver prati stanje zaliha grickalica i sokova. Ukoliko broj artikala jedne vrste padne na 30 ili manje softver o tome obavještava uposlenika, koji komunicira sa dobavljačima. Nakon što se stanje artikala poveća uposlenik koji komunicira sa dobavljačima moze ažurirati podatke o zalihama.
######**Prodaja karata, robe i izdavanje parking-prostora**
Karte i grickalice se prodaju na kasi, na zahtjev klijenta. Uposlenik na blagajni/blagajnik je tu da pomogne klijentu pri izboru filma ili, eventualno, nekog od paketa usluga koji uključuje parking, grickalice i sl, kao i da izvrši naplatu. Treba napomenuti da je moguće da klijent napravi i rezervaciju 7 dana unaprijed.
######**Registracija VIP članova**
Klijent ukoliko želi može postati i VIP član kina. Potrebno je da na licu mjesta ostavi neke osobne podatke (ime, prezime, adresu, e-mail, broj telefona,...), koji bivaju pohranjeni u softver, a zatim je potrebno da uplati godišnju članarinu. Softver generiše jedinstveni kod za novog VIP korisnika kina. Nakon što postane VIP korisnik, klijent ostvaruje popust na sve usluge u vrijednosti od 10% za godinu dana.
######**Izdavanje izvještaja o dnevnoj posjećenosti i profitu**
Nakon završetka radnog dana menadžeru i vlasniku kina se šalju izvještaji o posjećenosti kina proteklog dana, pojedinačnoj gledanosti filmova koji su u ponudi, i prihodu koji je ostvaren proteklog dana.

####**Funkcionalnosti**

- Modul za logiranje na softver za zaposlenike

- Modul za prijavu VIP klijenata

- Registracija novog VIP klijenta

- Modul za odabir filma

- Modul za odabir paketa

- Modul za formiranje ponuda

- Modul za izmjenu ponuda

- Modul za praćenje kapaciteta sala i parkinga

- Modul za praćenje zaliha robe

- Modul za rezervaciju

- Modul za pravljenje izvještaja o posjećenosti, gledanosti i prihodu

- Modul za narudžbenicu artikala

####**Akteri**

######**Direktor** 
- kontroliše ispravnost svih radnji unutar posmatranog sistema, ima pristup svim segmentima softvera

######**Menadžer** 
- ima potpunu kontrolu nad sotverom (refresh liste filmova, termina, postavljanje cijena usluga, odabir posebnih paketa i pogodnosti...), u svakom trenutku može pristupiti aktuelnom stanju

######**Uposlenici (blagajna)** 
- rezervacija/prodaja karata, prodaja grickalica/napitaka, te korištenje softvera za nabavku istih, izdavanje parking-prostora na zahtjev klijenta, ažuriranje VIP članova

######**Korisnici usluga (klijenti)** 
- imaju mogućnost gledanja kino-projekcija ili korištenja određenih paketa, mogućnost kupovine grickalica/napitaka, rezervacije parking-prostora. Klijent može postati VIP član, čime ostvaruje posebne pogodnosti
