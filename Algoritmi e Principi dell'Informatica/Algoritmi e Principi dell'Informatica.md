# Algoritmi e Principi dell'Informatica

# Lezione 1

Linguaggi. Linguaggi ovunque. 

Ma cos'è un linguaggio? Un oggetto matematico formato da: 

- alfabeto (segni/simboli)
- stringhe formate dagli elementi del alfabeto (sequenze ordinate)

A che cazzo servono i linguaggi se faccio ingegneria informatica? Linguaggi come estrema astrazione. Ad esempio le stringhe possono essere formate non da lettere, ma simboli che rappresentano ad esempio le azioni che fa un programma. Altro esempio è scrivere un problema che ci affligge in un determinato linguaggio e cercare le soluzioni-stringhe appartenenti al linguaggio delle soluzioni corrette. 

Dobbiamo poi definire la concatenazione di stringhe, la quale nella sua versione generalizzata si identifica come concatenazione di linguaggi. 

# Lezione 02

## Automi a stati finiti (ASF , FSA)

Astrazione del mio calcolo, che opera su un certo linguaggio e le sue stringhe. 

Tempo discreto, cioè quantizzato a passi. Passi che ci permettono di spostarci in un sistema finito di stati. 

Qualsiasi problema/comportamento scrivibile come una sequenza finita di stati può essere modellizzato da un FSA (Finite State Automaton).

Un FSA è composto da: 

- Q , un insieme di stati finito
- I , un alfabeto d'ingresso
- $\delta$ , una funzione $\delta (Q,I) \rightarrow Q$
- F, l'insieme di stati finali
- q0 , stato iniziale (unico)

Se l'FSA è un traduttore/trasduttore di linguaggi avrà anche una funzione $\gamma (Q,I) \rightarrow O^*$  dove O è un linguaggio di uscita. 

### Pumping Lemma

Importante teorema che ci dice che se digerisco una stringa S, la quale $|S| > |Q|$ (dove |Q| è la cardinalità/numero degli stati della FSA) , allora posso digerire digerire un linguaggio infinito (fatto cioè di infinite stringhe di lunghezza finita). 

# Lezione 03

Possiamo fare l'intersezione e l'unione di automi. L'intersezione è una specie di 'combinazione' degli stati.  Persino il complemento, il cui procedimento operativo consiste in: 

- scrivere la FSA completa (cioè esplicitare tutti gli stati 'pozzo' , cioè di errore)
- invertire gli stati finali con tutti gli altri

*parte da approfondire* ^ ^

### FSA belli fino a quando non bisogna riconoscere $a^nb^n$

Linguaggi dove viene richiesta 'una memoria' creano problemi. Ad esempio a e b potrebbero essere ad esempio [ ] . Con un FSA non possiamo assicurarci che le [ sono presenti nella stessa quantità delle ] . 

## Automi a Pila

Stessa cosa degli FSA ma dotati di una pila infinita con però un inizio. Possiamo impilare quello che vogliamo, ma possiamo operare solo sulla cima. Una memoria così distruttiva.. lettura = distruzione. 

AP → PDA = Push-Down Automaton 

# Lezione 04

L'AP non è chiuso rispetto nè l'unione nè l'intersezione. Però il complemento è chiuso(procedura analoga al FSA, ma più complicata causa la possibilità, con gli AP, di poter accettare le $\epsilon$  stringhe, cioè elementi vuoti).

### La pila può fare $a^nb^nc^md^m$ e $a^n b^mc^md^n$  ma non $a^nb^nc^n$ poichè ha una memoria distruttiva.

Questo è gran sbatti ed è dovuto al funzionamento della pila. L'approccio per risolvere questo genere di problemi è impilare tutti 'i placeholders' che indicana la 'a' e poi nel momento in cui leggo le b far saltare i vari placeholders. Il problema è che se poi ho anche da contare un eventuale carattere c non riesco. Ho distrutto tutta la memoria per assicurarmi che b fossero presenti nella stessa quantità delle a. Pazienza abbiamo le MACCHINE DI TOURING.

## MACCHINA DI TOURING

### Un modello per elaborarli tutti

Sostituisco la pila con 3 nastri (input, memoria, output). Non sono 3 pile distruttive, sono 3 nastri su cui posso 'navigare'. 

La MT è quindi composta da: 

- OC, Organo di Controllo analogo a FSA e AP che mi permette di spostarmi tra i vari stati
- I , solito alfabeto, in realtà ce ne potrebbe essere uno per ciascun nastro
- valore 'blank' con cui posso lasciare il 'vuoto' sul nastro
- 'testina' con cui mi muovo sui nastri

Le mosse della MT diventano quindi più articolate poichè leggo un carattere in input, posso sostituire un carattere nei vari nastri e posso spostare la testina (sx, dx, stop).

Per convenzione gli stati finali sono tutti pozzo, cioè non ci sono transizioni che ci fanno uscire dagli stati finali. 

# Lezione 05

Un bel esempio di MT, oltre a poter risolvere problemi quali $a^nb^nc^n$  è 'l'incrementatore decimale' . La unione, intersezione e il complemento per MT ci sono e sono chiuse eccetto l'ultima. Il complemento infatti può essere fatto solo se non ci sono cicli. Nel caso non ci fossero faccio il solito scambio: iniziali ↔ finali.

L'unione la posso vedere come 'il parallelo' di due macchine di Touring, l'intersezione come 'la serie'. 

La MT è *completa* , non ci sono problemi non esprimibili e modellizzabili con una MT. Inoltre una MT a singolo nastro è potente tanto quanto la MT con 3 nastri ... di base suddivido il mio nastro infinito in 3 zone, delimitate da un carattere a piacere. La complicanza sta solo nella gestione dei movimenti della testina, la quale tutte le volte si deve 'orientare'.

Di fatto una la macchina di Von Neumann , scritta come macchina che si serve di una RAM è completamente equivalente a una MT a singolo nastro. 

## Determinismo e non determinismo.

Una sequenza di mosse non deterministiche, implica che non sappiamo stabilire l'ordine in cui vengono fatte. Ci sono MT non deterministiche, e sono utili per risolvere tutti i problemi nel quale non ha importanza 'l'ordine' delle mosse. 

Il Non Determinismo è quindi il pilastro fondamentale per il **parallelismo**.

Ci sono anche FSA non deterministiche. Formalmente la differenza sta che la funzione $\delta (Q,I) \rightarrow non \space mappa   \space q  \space ma \space un \space insieme \{ q_0,q_1,q_2...\}$ cioè una mossa ci manda in un insieme di stati possibili, i quali eventualmente possono essere percorsi parallelamente. 

### Una FSA D è potente tanto quanto una FSA ND

### Una AP D è meno potente rispetto a una AP ND

Esatto! Un automa a pila non deterministico ha più espressività.. è come se aumentassi le pile. Ma non diventa potente tanto quanto una MT. 

### Una MT ND è un mostro, ma è potente tanto quanto una MT D

### Le MT D elaborano qualsiasi cosa

# Lezione 06

## Grammatiche Formali

Le grammatiche formali sono un insieme di regole. Hanno 2 alfabeti, un assioma (o simbolo iniziale) e un insieme di regole dette **produzioni sintattiche**.

### Relazione di derivazione

Produzione sintattica che produce da una stringa un'altra. Posso anche eseguirle in sequenza ottenendo quindi un linguaggio. Da L(G) ottengono il linguaggio L1.

Ci sono 4 tipi di grammatiche: 

- Tipo 0 = nessuna limitazione
- Tipo 1 = cardinalità della stringa a è minore della cardinalità della stringa b
- Tipo 2 = cardinilità di a = 1 (Context Free)
- Tipo 3 = regolari


# Lezione 07 
Le grammatiche sono modelli generativi di linguaggi, possiamo associare ciascuna grammatica al rispettivo automa riconoscitore del linguaggio generato:
- Tipo 0 $\rightarrow$ nessuna limitazione $\rightarrow$ MT
- Tipo 1 $\rightarrow$ limitazione cardinalità $\rightarrow$ MT
- Tipo 2 $\rightarrow$ context free $\rightarrow$ AP ND!
- Tipo 3 $\rightarrow$ grammatiche regolari $\rightarrow$ FSA

Una roba utile negli esercizi è proprio ricordarsi di queste relazioni per generare i linguaggi. Infatti il tipico esercizio 'trova la grammatica per generare questo linguaggio' può essere affrontato come 'che tipo di automa è in grado di riconoscere questo linguaggio? A questo tipo di automa che grammatica corrisponde?'. 

Regole più specifiche e dettagliate delle Grammatiche Regolari:
- |a| = 1
- b $\in V_t . V_n \cup V_t$ , nota che '.' intende la concatenzazione di stringhe
- b = $\epsilon$ sono nel caso in cui la stringa vuota è presente nel linguaggio
# Lezione 08 

Possiamo emulare una MT con una grammatica. Come? Ogni mossa è una derivazione, la derivazione ''finale'' verrà effettuata solo se la MT riconosce la stringa. 
Utilizzeremo la 'losanga' $\diamond$ per separare la stringa input con quella output:
input $\diamond$ output

# Lezione 09


# Lezione 10

# Lezione 11 
Quali problemi possiamo risolvere? Un botto di gente ha risposto a questa domanda. Noi essere umani siamo giunti alla conclusione che formalizzare i problemi con un linguaggio sia il miglior modo. Cioè trovare le soluzioni di un problema significa capire se una stringa $\in$ a un linguaggio o significa tradurla in un'altra stringa.
quindi:
problema di calcolo $\leftrightarrow$ problema di traduzione

### Tesi di  Church - Turing
 ##### Ogni problema calcolabile è descritto da una MT. 
 In 80 anni non abbiamo trovato controesempi di questa tesi (che per definizione di tesi non ha dimostrazione...).
 NB: esistono problemi non risolvibili algoritmicamente
 
 Enumerazione algoritmica: un algoritmo che mi trova tutte le corrispondenze biunivoche tra un certo insieme e l'insieme $\mathbb{N}$. 
 Cioè mi enumera gli elementi di un certo insieme. 
 L'insieme di tutte le MT è numerabile, infatti fissati il \#stati e il \#nastri , l'unica cosa che distingue le MT è la funzione $\sigma$ (transizione).
 
 Quindi da ora in poi vedremo le finite MT come delle funzioni $f_i$ .
 
 Esiste (almeno) una 
 ### Macchina di Touring Universale
 La MTU è una MT che può emulare qualsiasi altra MT. Essendo le MT finite, e fissato il \#stati e il \#nastri , ricevendo il numero corrispondente della MT la MTU può identificare la corrispondente funzione di transizione e quindi emulare la $MT_i$ . 
 Possiamo vedere il computer come una MTU, e una scheda già programmata come una MT. 
MTU nidificate -> macchine virtuali.