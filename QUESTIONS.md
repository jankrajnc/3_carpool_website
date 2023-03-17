# Meetup 3 (17.3.2023)

css, kako se to dobro naucis oz privadis kot programer, ki se s tem veliko ne ukvarja? je to neka stvar s katero se sploh veliko programerjev ukvarja?

kako drzis to vso znanje, ko toliko nekih stvari dodajas, plus se enih stvari ne dotaknes nekaj mesecev/let?
  
logika/uporaba interfacov, rad bi razumel kdaj se jih splaca uporabiti, kdaj ne, ker jih uporabljam in razumem kaj so, samo ne vem pa kdaj bi jih samo ustvaril, da bi bili uporabni in ne odvec
  
kako lokalno uravnavati razlicne verzije "globalnih" knjiznic med projekti? recimo angular ali nodejs, ustvaris samo lokalne verzije, varjanta vsak projekt ima svojo verzijo globalne pa nimas?
  
struktura ../carpool-group/[add-group] || [edit-group] || [view-group]
    - je ok
  
najboljsi nacin nalaganja dinamicne vsebine glede na ID? preko argumentov v URL pathu? varjanta [URL]/user/1 ali [URL]/user=1
    - poglej REST specifikacijo (mogoce tale? https://stackoverflow.blog/2020/03/02/best-practices-for-rest-api-design/)

debug? je vredno debug nastaviti kar v IDE-u ali naj se debuggira kar preko spleta?

testing?
    - kar zacni s testi

uporabni vmesniki za VS code

kako posodabljati knjiznice
    - ce je funkcionalnost v redu, samo updatas minor verzijo da se vulnerability popravi (npm fix?), funkcionalnost pa "naceloma" ne; ali pa vse updatas na latest pa moras gledat dokumentacijo kako popravit; resne knjiznice popravljajo tudi verzije za nazaj, samo ne prevec nazaj
    - moras posodabljati, da odstranjujes probleme, plus da ne zastaras
    - najprej vse minor, popraviti pokvarjene, pol pa knjiznica po knjiznica za major verzije

kaj delas kot arhitekt? razumem da gradis strukturo, samo kaj pa ko je to ze narejeno? delas tudi taske, ali posodabljas knjiznice ali dokumentacijo, ali gledas kaj drugega bi se lahko dodali v projekt, kar bi bilo uporabno, ali si tudi kot nek high level programer, ki se ukvarja z nekimi problemi na produkciji, deployi, taski, pomoc ekipam, ipd.?
    - nove tehnicne stvari; kak nekaj narediti - html to pdf recimo; proof of concept pred uporabo; kako so service med sabo uporabljeni, ali https ali eventi, baze, storage - torej internal in external arhitektura;
    - vedno je nekaj novega, vedno je veliko; blazer koda, ce zapakiras c# pa ali bolje/hitreje laufa
    - izboljsat kaj je, kaj lahko dodamo nekaj novega; 2 seznama; recimo document service je na SQL server namesto na postgresql; nova pa je blazer
    - kako ves da je nekaj novega dobro? release notes za TS zadnje leto pregledas; zacnes uporabljati pa drugi kopirajo tvoj stil; po vecini se gledajo release notes glavnih knjiznic (.NET, TS, VS); za vecje stvari, recimo microservice, pa samo pride po (ne)sreci