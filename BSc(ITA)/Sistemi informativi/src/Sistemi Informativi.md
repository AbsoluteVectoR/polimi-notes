---
title: Sistemi Informativi
author: "telegram/github/twitter: @martinopiaggi"
date: "2021-2022"
numbersections: true
geometry: 
- top=30mm
- left=23mm
- right=23mm
- bottom=30mm
---

\maketitle
\newpage
\tableofcontents
\newpage


# Introduzione

Cos'è un sistema informativo?

> Un insieme informativo è l'insieme di mezzi, conoscenza e competenze usati per gestire le informazioni aziendali.


Il sistema informatico **non** è un sistema informativo, un sistema informatico è una parte del SI.


# Dati, informazioni e progettazione del SI 

## Piramide DIKW
Dato: valore dettagliato di un evento.
Informazione: un dato a cui si associa una certa importanza/contesto
Conoscenza: giudizio dell'informazione 
Saggezza: conoscenza++ 

![piramide DIKW](images/piramideDIKW.jpg)

## Modelli per rappresentazione SI

Esistono vari modelli per rappresentare l’intero sistema informativo.

### La Piramide di Anthony

![processi](images/processii.jpg)

Il modello di Anthony (la piramide riportata qua sopra) è un modello gerarchico organizzativo diviso in livelli:

- strategico 
- tattico
- operazionale

Ovviamente devono esserci scambi d'informazione, sia verticali che orizzontali. 
Tale modello però non consente di avere una visione globale sull'intera organizzazione. 

### La catena del valore di Porter

Altro metodo di segmentazione e rappresentazione del SI è la **catena del valore di Porter**. 
Modello che permette di descrivere la struttura di una organizzazione come un insieme di processi, divisi in 5 primari e 4 di supporto. 
Si adatta però solo a grandi organizzazioni che vendono bene e non offrono servizi. 

### Risorsa
**Risorsa** è tutto ciò con cui un’organizzazione opera, sia materiale che digitale, per  raggiungere i suoi obiettivi.
Si possono classificare in: 

- Esterne 
- Interne 
- Struttura
- Gestione 

### Varie classificazioni SI:
Spesso i sistemi informativi sono divisi anche in due tipi di attività diverse:

- **Orizzontali**, cioè tutti quei processi che non cambiano i settori diversi (HR, aspetti amministrativi, …)
- **Verticali**, cioè che variano secondo il contesto, solitamente le attività produttive
Un processo è l'insieme delle attività che l'organizzazione svolge per raggiungere il proprio obiettivo (ben definito).

Altra classificazione in 2 categorie:

- **Sistemi operazionali**: svolgono operazioni transazionali semplici, lavoro di ufficio, contabilità. 
- **Sistemi decisionali o informazionali**: fanno da supporto delle attività decisionali e strategiche aziendali, utilizzando i dati. 

## OLAP e OLTP

In un SI possiamo avere sistemi:

- **OLAP (Online Analytical Processing)**: ha come metrica il **response time** .  Operazioni non strutturate, complesse che operano su tanti dati aggregati. Non è importante rispettare la proprietà ACID in quanto le operazioni solo di sola lettura e casuali. 
- **OLTP (Online Transaction Processing)**: orientate alle transazioni. Tante transazioni, tanti utenti. La metrica di valutazione é il **throughput** .  

![Pasted image 20220129101228](images/OLTPvsOLAP.png)

## Progettazione SI
### Framework di Zachmann
Il framework di Zachman è uno strumento efficace per descrivere il sistema informativo dell’organizzazione nel suo complesso. 
Esso è organizzato in:

- **Righe**: definiscono i diversi punti di vista che possono interessare diversi stakeholder *(coloro che hanno interesse al sistema considerato perché ad esempio ne sono proprietari o fruitori, finanziatori o utenti)*. 
- **Colonne**: definiscono gli aspetti da analizzare.

Nel framework di Zachman non c'è alcun ordinamento tra le colonne, e ciascuna di esse (dall’alto verso il basso) mostra tutti i passaggi a partire dal business per arrivare all’effettiva realizzazione del sistema.  
![Framework di Zachmann](images/FrameworkZachmann.png)
Le celle del framework di Zachman create dall’intersezione tra righe e colonne definiscono le **Viste** . 

## Progettazione e gestione SI 
![plan, develop, manage and control](images/PlanDevManageControl.png)
C'è l’esigenza di progettare e gestire in modo strutturato un sistema informa-  
tivo nel suo funzionamento e nella sua evoluzione. 
Identifichiamo 4 fasi:

- **Pianificazione**: fase in cui si delineano le linee guida strategiche, il ruolo delle componenti organizzative e le istruzioni operative per la realizzazione. A sua volta diviso in:
	
	- Pianificazione strategica: in questa fase si identificano gli obiettivi che richiedono interventi di natura informatica.  
	- Studio di fattibilità: una volta appurato il bisogno di un intervento di natura informatica, si identificano le alternative progettuali.
- **Sviluppo**: raccolta e analisi dei requisiti e sviluppo del software e definizione dell’architettura hardware.  
- **Gestione corrente**: interventi di routine eseguiti per il mantenimento del sistema.  
- **Controllo**: operazioni effettuate in modo periodico per valutare l’adeguatezza del sistema informativo.

# Approccio architetturale ai SI

## BOAT

La progettazione di un SI prevede quattro fasi quali la pianificazione, lo sviluppo, la gestione corrente e controllo.
Per progettare la Enterprise Architecture (modello dell'organizzazione con varie prospettive che permette di fornire una panoramica sui propri processi, sistemi, tecnologie e strutture) possiamo usare l'approccio boat. 
Business, Organization, Architecture and Technology. 
Perché l'approccio Boat? L'approccio boat ci permette di analizzare il SI da tutti e 4 i punti di vista. Un SI viene progettato partendo dalla prospettiva Business, per poi (iterativamente) passare alle altre (B-O-A-T-B-O-A ...).

### Prospettiva di Business

Il business puó essere quindi il punto di partenza per la progettazione del SI ma anche punto di partenza per la sua modifica (requirement pull), in alternativa a quando si modifica a causa di una spinta tecnologica (technology push). 
I partecipanti in uno scenario di Business possono essere:

- Business 
- Government 
- Citizen/Consumer

Abbiamo quindi tutti i vari casi di interazione tra i partecipanti .. B2B, B2G, B2C , ... 
Gli oggetti dell'interazione possono essere:

- prodotti fisici 
- prodotti digitali 
- prodotti finanziari 
- servizi 
- prodotti ibridi

L'orizzonte temporale di tali interazioni possono essere: 

- statico = stabile nel tempo, solitamente regolata da un contratto
- semidinamico = stabile con possibili cambiamenti 
- dinamico = rapporto limitato ai singoli ordini 
- ultradinamico = la relazione puó variare persino all'interno di un singolo ordine

#### Business Driver
I Business Driver sono quelli che **motivano** effettivamente il progetto del SI o una sua modifica.
I business Driver possono essere divisi in 2: 
Efficacia: definita come $$\frac{Output \space Effettivo}{Output \space Atteso}$$
Nella valutazione dell'efficacia inotre definiamo due qualitá : 

- Reach: l'estensione dell'efficacia in termini di estensione es:(temporale/geografica/multicanale)
- Richness: la qualitá e ricchezza della comunicazione, cioé la frequenza, il dettaglio e la tipologia di dati. es:(frequenza, interattività)

Efficienza: definita come $$\frac{Output Effettivo}{Input}$$
![Pasted image 20220128214151](images/PartiesObjTimeScopes.png)

### Prospettiva organizzativa
Per modellizzare l'organizzazione si procede per livelli, affinando sempre di piú il dettaglio.
Al *livello 0* si vede l'intero mercato come una blackbox. 
Al *livello 1* si distinguono i 3 attori della situa organizzativa: 

- consumatore
- intermediario 
- fornitore
Al *livello 2* si specificano ulteriormente i vari intermediari. 
Al *livello 3* mostra anche gli aspetti intraorganizzativi, che si dividono in 2 categorie:

- front-end : tutte le componenti dell'organizzazione nel quale sono presenti interazioni con entitá esterne 
- back-end : tutte le componenti chiave all'interno dell'organizzazione che non interagicoscono con partecipanti esterni ma solo con altre componenti interne.
Al *livello 4* vengono modellizzate le singole componenti interne dell'organizzazione evidenziando anche le interazioni con i partecipanti esterni e intermediari. 

-  Esempio B2B a lv. 4


![Pasted image 20220129111217](images/Pasted%20image%2020220129111217.png){width=50%}

- Esempio B2C a lv. 4 

![Pasted image 20220129111314](images/Pasted%20image%2020220129111314.png){width=50%}

- Esempio B2B a lv. 4 multicanale: 

![Pasted image 20220129111550](images/Pasted%20image%2020220129111550.png){width=50%}


## Prospettiva architetturale
La prospettiva di architettura ha diversi livelli di aggregazione: 

- **Architettura market-level** descrive la struttura dei sistemi a livello dei vari partecipanti, descrivendo le interazioni e i messaggi scambiati tra di essi. La possiamo vedere come una estensione della prospettiva O-4 (la quale modella le interazioni fra organizzazioni) in quanto specifica le  interazioni tra i sistemi di tali organizzazioni. Si tratta di una estensione, e nonostante spesso c'é una corrispondenza tra i moduli delle due prospettive può non esserci. Per specificare quali moduli sono comuni utilizziamo una  matrice.
- **Architettura party-level** descrive la singola organizzazione rappresentando le interfacce verso il mondo esterno, il quale é trasparente in questo livello di astrazione. Si tratta quindi di una visione intra-organizzativa nel quale descriviamo interfacce BE/BE, FE/FE. Specifichiamo anche i vari componenti tra cui i DB con annessi DBMS, e tutti i messaggi scambiati tra i componenti FE e BE (restano ancora visibili quelli scambiati con gli altri partecipanti);
- architettura system-level non ci interessa.  

![Generic components in A party level](images/Generic%20components%20in%20A%20party%20level.png)

## Prospettiva tecnologica
Dividiamo la parte tecnologica del livello tecnologico del Boat in:

- livello applicativo 
- livello di piattaforma
- livello di architettura fisica 


# BPMN per modellazione processi

Un processo di business è un insieme di attività eseguite secondo un ordine specifico per ottenere un certo obiettivo di business. Utilizziamo per modellare processi BPMN.  Business Process Modeling Notation (BPMN). 
Nella notazione BPMN gli eventi sono modellati con un cerchio al cui interno è disegnato un simbolo che ne definisce la tipologia.

![events bpmn](images/events%20bpmn.png)

Tipi di attività:

![task](images/task.png)

Tipi di Gateway:

- Gateway XOR

	![xorbpmn](images/xorbpmn.jpg)
- Gateway OR

![orbpmn](images/orbpmn.jpg)
- Gateway AND

![andbpmn](images/andbpmn.jpg)
- Gateway EVENT BASED 

 ![event based gateway](images/event%20based%20gateway.png)
 
Esempi di BPMN collaborativo, cioè con più pools e più lanes.

![bpmn collaborativo, pool](images/bpmn%20collaborativo,%20pool.png)

![Pasted image 20220125101247](images/bpmnex.png)




# Aspetto tecnologico dei SI 

## Tecnologie a livello applicativo 

### ERP
Enterprise Resource Process é una suite software che offre i vari moduli software per il SI riguardo il sistema operazionale interno. 
Il ruolo dei dati in un sistema ERP è fondamentale, in quanto uno degli scopi principali per cui viene installato un tale sistema in una azienda è il poter garantire l'unicità dei dati tra i vari moduli che gestiscono le diverse transazioni aziendali. È proprio l'unicità dei dati a livello operativo garantita dall'ERP che consente di ottenere unicità dei dati (e quindi eliminare ridondanze e incongruenze) anche a livello direzionale, e quindi poter considerare i dati, nel loro complesso, una risorsa aziendale.
Gli ERP sono caratterizzati da:

- unicitá dell'informazione : zero rindondanza e quindi zero incogruenza dei valori
- prescrittivitá : incorporano la logica di funzionamento dell'impresa. Norma cioé i processi. 
- modularitá : l'azienda 'sceglie' i moduli in base alle proprie esigenze.

I moduli di un ERP si possono classificare in:

- **ERP CORE**:
	- sistemi istituzionali : orizzontale, 
	- settoriali : verticali, specifici
	- direzionali : orizzontale
- **ERP ESTESO**: 	
	- SCM (Supply Chain Management)
	- PLM (Product Lifecycle Management)


### CRM 
Customer Relationship Manager:

- CRM analitico: analisi sul CRM operativo 
- CRM operativo: si divide in:
	- marketing 
	- servizio clienti 
	- vendite automatizzate
- CRM collaborativo: si occupa della fidelizzazione clienti principalmente

### Data Warehouse 

Il Data Warehouse é una grossa repository ottimizzata per analisi dei dati. Mantiene lo storico per garantire le analisi. 

#### DataMart
In un’architettura centralizzata esiste solo un grande DW mentre in caso di una soluzione distribuita abbiamo diverse sotto unità chiamate DataMart.
Il DW puó essere quindi: 

- **Centralizzato** (non compare il DM)
- **Distribuito** (DW + DM)
- **DW virtuale** (il DM lo ricopre interamente)

#### Tecniche ETL 
Extraction - Transformation - Loading
In che senso trasformazione? I dati non solo devono essere estratti da piú sorgenti e integrati nel DW, ma devono anche subire diversi trasformazioni.

- **estrazione**: statica o incrementale a seconda che i dati siano considerati per intero o solamente quelli più recentemente modificati.
- **trasformazione**: 
	- pulizia dei dati  
	- riconciliazione 
	- standardizzazione 
	- ricerca duplicati
- **caricamento**: si occupa di trasferire i dati nel DW secondo il modello multidimensionale da esso definito. 

L'ETL carica i dati in modo periodico, ad eccezioni magari di alcuni critici, i cui visualizzazione e analisi é necessaria. 


#### Modello logico del DW

##### Motori OLAP 
l data warehouse è un sistema di tipo OLAP (On Line Analytical Processing). Il paradigma OLAP è caratterizzato da poche transazioni e interrogazioni (query) complesse che richiedono aggregazione di dati. I sistemi OLAP hanno come misura di efficienza e di efficacia il tempo di risposta. Un sistema OLAP memorizza dati in formato aggregato, memorizza dati storici, archiviati secondo schemi multi-dimensionali (generalmente schemi detti a stella). Spesso, le interrogazioni accedono a grandi qualità di dati per rispondere a quesiti complessi come, per esempio, quale è stato il profitto netto realizzato dall’azienda in una certa area geografica nello scorso anno. I sistemi OLAP sono utilizzati per l’elaborazione di dati orientata al supporto decisionale, quindi sono adeguati a funzionalità collocate a livello di pianificazione e strategico della piramide di Anthony. 

###### Molap: Modello Multidimensionale 
Il fatto é l'elemento rilevante. Possiamo utilizzare un modello multidimensionale. Cioé vedere appunto le dimensioni di un fatto (dimensione temporale, spaziale, tipi di prodotto, clienti .. ecc.) come dimensioni spaziali. Possiamo quindi collocare i fatti in un ipercubo, dove ogni fatto é l'incrocio dei valori nella varie dimensioni.  

###### Rolap: Modello Relazionale
Rindondanza inversa al tempo di accesso. Diversi schemi:

- schema a stella
- schema a fiocco di neve

###### Holap: Modello Ibrido
Sia Molap (vantaggioso per tempo di risposta), sia Rolap (vantaggioso quando ci sono tanti dati). 
Utilizzo un modello Molap per gli utenti nel DM, i quali necessitano tempi di risposta molto veloci ma pochi dati. E utilizzo un modello Rolap per il DW. 

###### Operazioni Olap 
- Slice : vincoli sulle dimensioni
- Dice : selezione su piú dimensioni
- Rollup : tolgo granularitá, cioé aggrego, perdendo dettagli
- Drill Down: aggiungo granularitá

Ovviamente i dati nel DW ci sono sempre, tutte queste operazioni sono a un livello di visualizzazione. 

#### Data Mining 
Nel DW possiamo fare Data Mining. Cioé passare dalle informazioni alla conoscenza.
Due tipi di Data Mining: 
- supervised: conoscenze aggiuntive esterne
- unsupervised: non ha bisogno di conoscenze aggiuntive esterne

Tecniche di DM: 

- predittive: predicono eventi 
- descrittive: ti descrive pattern
- prescrittive: ''del futuro'', ti dice le decisioni da prendere

Regole associative. 
Analisi dei dati e si cercano elementi che compaiono piú spesso insieme. Cioé si cerca di capire pattern del tipo: $x \implies y$.
Confidenza sará: $\frac{x \implies y}{x}$
Cioé quanto é rilevante la regola. 

Regole di classificazione.  Cioé aggiungo classi ai miei dati. Un algoritmo mi aiuta a riconoscere tali classi. 
Uso l'80% dei miei dati come training set. 
Poi il 20% dei miei dati come test set. 
Possiamo definire una matrice diagonale. True Positive, True Negative, False  Positive, False Negative. Dove pos/neg si riferisce all'appartenza alla classe. 

$$precision = \frac{TP}{TP+FP}$$
$$recall = \frac{TP}{TP+FN}$$

Vogliamo precision e recall i piú alti possibili. 

Proprietá di classificazione: 
- accuratezza
- velocitá 
- scalabilitá 
- robustezza 

Algoritmo di classificazione:

- clustering: descrittiva, non supervisionata. Funzione di similaritá, cioé cerca sinergia tra i dati. 

Machine Learning, puó essere:

- supervised
- unsupervised 
- reinforcement learning 
- transfer learning 


### Approccio Make or Buy 
L’analisi Make-or-Buy prende in considerazione il fatto che sul mercato per alcuni interventi esistono dei prodotti software già pronti: i cosiddetti COTS (Commercial Off-The-Shelf o Commercially available Off-The-Shelf). L’adozione di questi software (alternativa Buy) si pone in alternativa alla possibilità di progettare e realizzare un prodotto su misura (alternativa Make).
![make or buy](images/make%20or%20buy.png)


## Livello di piattaforma 

Mentre l'ERP ha unificato i dati tra i databases risolvendo diversi problemi. Abbiamo comunque problemi per l'**integrazione** di moduli/applicazioni. 

- **Point to point**: ogni messaggio costruito per specifiche interfacce ha il suo destinatario.
	- message oriented middleware: c'è un intermediario
- **Hub and Spoke**: un hub, la cui logica sarà complessa, centralizzerà tutta la comunicazione.

## Architettura fisica 

Diversi modi per far collaborare differenti moduli. 

### Layer e tier 
Dividiamo i layer applicativi in 3 principali parti: 

- **presentazione** (front end)
- **logica applicativa** (back end)
- **gestione dei dati** (back end)

Posso dividere i diversi tiers in diversi modi a seconda dell'architettura distribuita che scelgo: 

- **Single Tiered**
- **Double tiered** = client-server :
	- **thin client** = client si preoccupa solo della parte di presentazione
	- **thick client** = client si preoccupa anche della parte applicativa.
- **Three Tiered** = teoricamente un tier per ciascun layer, anche se poi non è per forza così. Avrò quindi un middle tier. 
- **N-tiered** = ulteriore distribuzione dell'architettura. Si suddividono i layer logici in un numero arbitrario di tier fisici (eventualmente implementati come server farm invece che come singole macchine), al fine di aumentare la scalabilità e\o la sicurezza del sistema. Una tipica configurazione in ambito web è quella a cinque tier: client – web server – script engine – application server – database server.

### Scalabilità 
- Scalabilità verticale = potenzio la mia macchina, anche se spesso non è il migliore trade off e soprattutto prima o poi avrò limiti fisici. Il vantaggio è che non ho sbatti nella distribuzione delle applicazioni. 
- Scalabilità orizzontale/scale out = sfrutto il principio di **downsizing** cioè a parità di potenza di calcolo, tanti server di fascia bassa sono più convenienti di un singolo server di fascia alta. <- necessito però un sistema di load balancing per gestire tutti i servers. 

### Server Farm 
insieme di macchine fisiche che condividono il carico lavorativo. Le server farm hanno un alto lviello di downsizing proprio per loro natura. 
Possibili progettazioni di una Render Farm: 

- **RACS (Reliable Array of Cloned Services)**,cloning : a sua volta diviso 
	- Shared - nothing = dati tutti replicati, ottimo per read-only intensive applications. 
	- Cluster = shared - disk = le macchine condividono la memoria. 
- **RAPS (Reliable Array of Partitioned Service)**,partitioning : 
	cloning of the partitions: l'ibrido delle altre due, di base clono le singole partizioni per avere rindondanza. 

### Cloud Computing 
Architetture applicative accessibili da ovunque nel mondo attraverso la rete. Si basa sul concetto di **virtualizzazione** . 
Con il cloud computing abbiamo quindi un servizio on demand che ci permette di allocare - deallocare risorse in base alle nostre esigenze. E soprattutto pay as you go. 

- **Infrastructure as a Service** = completo controllo delle VM.
- **Platform as a Service** = controllo delle proprie applicazioni
- **Software as a Service** = solo applicazione, posso quindi configurare solo i parametri di tale applicazione. (ese: i vari cloud storage Dropbox, Onedrive, GDrive ecc. ecc.).

![SAS](images/SAS.png)

Il cloud potrà quindi essere:

- **Private Cloud** = solo una organizzazione
- **Community Cloud** = poche organizzazioni con interessi comuni
- **Public Cloud** = servizio fornite a tutto il pubblico. Costi molto limitati. 
- **Hybrid Cloud** = una combo delle precedenti. 
Ogni azienda/attività potrà scegliere se gestire l'architettura fisica del SI internamente, parzialmente fuori azienda,  esternamente affidandosi a un'offerta cloud che potrà essere Iaas, Paas, Saas.


### Insourcing e Outsourcing 

Si può anche possedere direttamente i server fisici o appoggiarsi a enti esterni (outsourcing) sempre facendo riferimento ai tipi di cloud e servizi possibili. 
Possiamo distinguere 6 livelli, dall'insourcing al outsourcing completo.

![](images/insourcing%20e%20outsourcing.jpg)

> Ricordati che l'insourcing/outsourcing è diverso da make/buy 

## Sicurezza dei sistemi informativi 

Sicurezza per i dati, la nostra risorsa piú preziosa. 
Dobbiamo proteggere i dati da minacce fisiche, logiche e accidentali (magari bug di softwares o errori umani).

### Proprietà della sicurezza
La sicurezza ha 4 proprietá fondamentali: 

- **Integralitá**: il messaggio non viene modificato nel suo tragitto mittente-destinatario. 
- **Autenticitá**: il messaggio deve dimostrarmi la sua autenticitá.
- **Riservatezza**: il messaggio deve arrivare solo al destinatario. 
- **Disponibilitá**: il sistema deve sempre garantire disponibilitá all'utente.

### Attacchi di rete 

- **Hijacking**: man in the middle (attacca l'integralitá)
- **Spoofing**: ci si finge qualcun altro (attacca l'autenticitá)
- **Sniffing**: si ascolta in modalitá passiva i messaggi (attacca riservatezza)
- **Flooding**: attacchi DOS (attacca la disponibilitá)

### Attacchi Applicativi 

- trojan 
- backdoor 
- ransomware 
- spyware

### Crittografia simmetrica e asimmetrica 

- **Chiave simmetrica**: si usa una chiave che ha sia A e B per cifrare i messaggi
- **Chiave asimmetrica**: la chiave non viene mai scambiata ma i messaggi si cifrano comunque, usando due chiavi: 
	- chiave privata
	- chiave pubblica
 Solo la chiave pubblica puó decifrare un messaggio generato dalla privata. 

### Impronta e firma digitale 
La firma digitale é utilizzata per verificare l'integralitá e consiste in una funzione di hash. 
> La firma digitale é la cifratura da parte del mittente (con la sua chiave privata) del digest del messaggio. 

![Pasted image 20220128103750](images/Pasted%20image%2020220128103750.png)

La firma digitale la verifico con la chiave pubblica. Il senso è che una volta verificato il messaggio con la chiave pubblica, solo l'ente che possiede la chiave privata può aver scritto quel messaggio (l'hash del messaggio è unico).

### Certificati digitale 
Garantisce l'autenticitá della chiave pubblica. I certificati vengono gestiti da sistemi detti **Public Key Infrastructure** (PKI), che si occupano di emettere e revocare i **PKC** (Certificato a Chiave Pubblica) attraverso certificate authority **CA** e registration authority **RA**.
Tali enti hanno strutture gerarchice ad albero per garantire soliditá. 
La Certification Authority rilascia certificati non la Registration Authority.

Un fattore critico dunque é come conservare tali chiavi private:

- hardware
- software
ma anche come scambiarsele, prima di utilizzarle:
- out-of-bound: si usa un canale esterno al canale utilizzato per comunicare
- ente esterno 
- crittografia asimmetrica: si usa infatti l'asimmetrica (basata sulle chiavi pubbliche) per scambiarsi il messaggio contenente le chiavi private in modo sicuro. 

### Regole e politiche d'accesso

Due possibili classificazioni dei sistemi in base a come viene gestita la sicurezza:

- **sistema aperto**: tutto ció che non é esplicitato si puó fare
- **sistema chiuso**: tutto ció che non é esplicitato non si puó fare 

Oltre a questa macro classificazione vengono anche considerati altri livelli di sicurezza.
Vengono effettuati diversi controlli d'accesso basati su **regole**. Le regole d'accesso da parte di autorità seguono tutte lo schema: (subject,object,right,constraint) . 
Oltre a queste regole d'accesso possiamo poi definire della politiche di accesso:

### Politiche d'accesso

1) **DAC** - Discrezionale, cioé il proprietario di un oggetto puó dare il permesso di modificare tale oggetto 
2) **MAC** - Mandatorio, tutto é classificato automaticamente da un ente centrale. I propentari non possono autorizzare altri proprietari. 

Le regole d'accesso coinvolgono: 

- soggetti: 
	- persone,gruppi,app
- oggetti:
	- databases, tabelle varie
- diritti: 
	- tipi di azioni consentiti
- vincoli:
	- ulteriori regole e condizioni da applicare ai diritti

#### MAC 
Mentre il DAC si basa sul concetto di proprietá, il mandatorio si basa tutto sulla classificazione di oggetti e soggetti.
Idea generale: 
Tipi di classificazione degli oggetti: 

- unclassified
- confidential 
- secret 
- top secret 

2 regole:

1) **NO READ UP**: Ogni soggetto puó vedere solo gli oggetti di livello uguale o inferiore. 
2) **NO WRITE DOWN**: Ogni soggetto puó scrivere solo nelle classi maggiori o uguali alla sua. 

Viene quindi mantenuto un database multi livello, che mostra i dati in base alla classe di appartenenza. 

### Firewall 
Fondamentale per filtrare l'unico punto di contatto con il mondo esterno. Il Firewall peró deve essere configurato correttamente:

- Packet inspection/filtering
- Application Gateway 

#### IDS - Intrusion Detection System 
sensori che continuano a monitorare attraverso log. E ulteriori analisi sui vari dati raccolti. 
Tutti gli IDS fanno funzione di **allerting and response** ma si distinguono se hanno una risposta attiva o semplicemente avvisano e basta.

## Archimate
![Pasted image 20220127160925](images/Pasted%20image%2020220127160925.png)

![archimateRelazioni](images/archimateRelazioni.jpg)

Punto di contatto tra Archimate e BOAT: 

![Pasted image 20220127162001](images/Pasted%20image%2020220127162001.png)

Il device è **fisico** . 

![Pasted image 20220127162106](images/Pasted%20image%2020220127162106.png)



![Pasted image 20220127162049](images/Pasted%20image%2020220127162049.png)


![Pasted image 20220127162216](images/Pasted%20image%2020220127162216.png)

Attenzione i collegamenti (path) non sono linee! Stiamo ragionando a livello fisico .. la fibra è diversa dal ethernet o dallo spago! 

Esempio di DW scritto in Archimate:

![Pasted image 20220127162456](images/Pasted%20image%2020220127162456.png) 

(normalmente all'esame specifichiamo bene la struttura interna del nodo server).
Tipi di Double-Tiered:


![Pasted image 20220127163224](images/Pasted%20image%2020220127163224.png)

![Pasted image 20220127163047](images/Pasted%20image%2020220127163047.png)

Tipi di virtualizzazione:

![Pasted image 20220127163639](images/Pasted%20image%2020220127163639.png)

Classico server virtuale: 

![Pasted image 20220127163808](images/Pasted%20image%2020220127163808.png)

Struttura standard per punto di contatto internet/rete aziendale

![Pasted image 20220128123842](images/Pasted%20image%2020220128123842.png)


