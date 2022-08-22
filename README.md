Obrazloženje implementacije seminarskog rada - Razvoj Softvera II

API je deployan na heroku i njegova dokumentacija je dostupna na : https://rs2seminarski.herokuapp.com/swagger

Također i baza podataka je deployana na plesk, pa nema potrebe restorati podatke. Ukoliko budete htjeli da restorate ima spremljena skripta u ovom repozirotiju sa šemom i podacima baze podataka. U folderu dokumentacija imate dokumentovanu šemu baze podataka u UML-u (.vpp fajl).

Neki podaci su ručno generisani i preuzimani online (kao što su historijski podaci kripto valuta) bez kojih ne možete na mobilnom dijelu pregledati statistiku i grafove valuta (preporucujem korištenje deplojane verzije ili restoranje skriptom).

Nemaju sve kripto valute historijske podatke jer je proces veoma spor, tako da sve valute nemaju izvještaj na mobile-u.

Mobile i desktop direktno komuniciraju sa deplojanom verzijom API-ija (rs2seminarski.herokuapp.com). Ukoliko želite testirati lokalno na mobilu možete iskoristit sljedeću komandu radi specificiranja adrese:

flutter run --dart-define=baseUrl=VAŠA ADRESA

Na desktopu je url definisan u resources fajlu, gdje možete modifikovati adresu servera (također se tu nalazi i adresa dokeriziranog, lokalnog i deployanog servera).

Login za desktop (admin) je : username = admin password = admin

Login za mobile (klijent) je: username = user1 ili user2 password = user1 ili user2

Također na klijentu imate mogučnost i registrovanja novog korisnika (verifikacija računa ne radi jer jer gmail support za slanje mailova manje sigurnim aplikacijama istekao - radila je prije isteka suporta)

Testiranje dokera možete izvršiti kucanjem komande: docker-compose up --build
