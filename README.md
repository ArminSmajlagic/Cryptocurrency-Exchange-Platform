Obrazloženje implementacije seminarskog rada - Razvoj Softvera II

API je deployan na heroku i plesk, te je njegova dokumentacija dostupna na : https://rs2seminarski.herokuapp.com/swagger i https://rs2.p2098.app.fit.ba/swagger

Pri kucanju komande: docker-compose up --build

na startup-u API-ja se kreira baza podataka, njena šema te se vrši seed podataka sa podacima deployane instance baze podataka (deployana na plesk).

Historisjski podaci kripto valuta su skidani online i popunjavani u bazu ručno, kako je taj proces spor samo bitcoin i etherium posjeduje historijske podatke.
(Na osnovu historijskih podataka se generiše report i graf na mobilnom dijelu aplikacije, tako da samo ove dvije valute imaju spomenute funckionalnosti)

Mobile i desktop direktno komuniciraju sa deplojanom verzijom API-ija (rs2seminarski.herokuapp.com). 

Ukoliko želite testirati lokalno na mobilu možete iskoristit sljedeću komandu radi specificiranja adrese:

flutter run --dart-define=baseUrl=http://vaša-adresa:5192 (127.0.0.1 ili 10.0.2.2 ili 192.168.x.x)

Ukoliko imate problema sa konekcijom android emulatora na docker API možete kucati vašu lokalnu adresu - http://192.168.x.x:5192; Ova opcija kod mene uvijek radi

Komanda : flutter run --dart-define=baseUrl=http://192.168.x.x:5192

Na desktopu je url definisan u resources fajlu gdje možete modifikovati adresu servera (tu se nalazi adresa dokeriziranog, lokalnog i deployanog servera)
tako što modifikujete property "server" u resursima.

Login za desktop (admin) je : username = admin password = admin

Login za mobile (klijent) je: username = user1 ili user2 password = user1 ili user2

Upute za testiranje mobile aplikacije:

Na mobilu imate več uplačeno 5000 wcasha na oba korisnika sa kojim možete kupovati, također jedan korisnik ima 5 bitcoin-a kojeg možete prodati (npr 0.01).

Nakon toga se možete prijaviti na drugog korisnika i kupiti ga za WCash.

U walletu korisnika imate dugme koje vas vodi na uvid transakcija od trentuka njenog kreiranja (uvid u stanja i ostale detalje transakcije).

