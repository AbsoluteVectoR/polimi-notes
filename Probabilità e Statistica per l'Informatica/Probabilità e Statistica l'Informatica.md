# Probabilità e Statistica l'Informatica

# Lezione 01

dati ↔ modello

Con i dati faccio il modello, con il modello riguardo i dati e continuo a perfezionare in un ciclo

Mattone elementare della logica probabilistica: evento

$E \in \Omega$  dove $\Omega$  è l'insieme universale dei casi elementari. 

$A \cup B$  indica che si verifica o A o B

$A \cap B$  indica che si verifica sia A che B

$A \backslash B$  indica che si verifica A ma non B 

$A \triangle B$ indica che $(A \backslash B) \cup (B \backslash A)$

Legge di De Morgan interpretata con apice 'c' .. cioè la negazione è il complementare dell'evento. 

La misura di Probabilità è una funzione che associa un evento a un numero. 

La funzione probabilità ha le seguenti proprietà: 

- P è compreso tra 0 e 1
- P($\Omega$) è 1
- Gli eventi sono a 2 a 2 incompatibili, cioè disgiunti. $\sum \cup E_n = \sum P(E_n)$

Def: probabilità uniforme = ogni evento ha la stessa probabilità di accadere 

cioè $P(E) = \frac{|E|}{|\Omega|}$ 

in gergo: casi favorevoli / casi possibili 

# Lezione 02

$$P(A) + P(A^c)=1$$

***Importante la formula inversa!!***

$$P(A) \cup P(B) = P(A) + P(B) - P(A\cap B)$$

### Fattoriale e permutazioni

n! cioè tutte le possibili permutazioni, cioè disposizioni (senza ovviamente la ripetizione).

Ese: in quanti modi posso disporre 4 lettere? 4*3*2*1 = 24 

La prima lettera la posso scegliere tra n possibilità, la seconda tra n-1 ...

### Coefficiente binomiale

$$\binom n k = \frac {n!}{k!(n-k)!}$$

Ci permette di contare tutti i possibili sottoinsiemi di cardinalità k da un insieme di cardinalità n . Ovviamente a livello insiemistico $\{ a,b\}=\{b,a\}$ di conseguenza è ovvio anche capire che il coefficiente binomiale non considera l'ordine e di conseguenza vede elementi come *ab* e *ba* come lo stesso. 

### Indipendenza Stocastica

$$P(A \cap B) = P(A)P(B)$$

Due elementi stocasticamente indipendenti hanno questa relazione. 

La cui generalizzazione risulta intuitivamente:

$$P(A \cap B \cap C) = P(A)P(B)P(C)$$

ma attenzione! La relazione sopra vale solo se valgono le condizioni a 2 a 2:

$$P(A \cap C ) = P(A)P(C)$$

$$P(A \cap B) = P(A)P(B)$$

$$P(B \cap C) = P(B)P(C)$$

### Probabilità condizionata

$$P(A\cap B) = P(A | B)P(B)$$

La probabilità condizionata di A rispetto a B è la probabilità che si verifichi A sapendo che si è verificato B. 

Da questa relazione abbiamo un importante risultato, il teorema di Bayes: 

### Teorema di Bayes

$$P(B|A) = \frac{P(A|B)P(B)}{P(A)}$$

e sappiamo anche che 

$$P(B|A) = 1 - P(B^c,A)$$

Questa relazione vale **SOLO** per l'elemento condizionato, non il condizionante!!!

Il teorema di Bayes ha poi un'ulteriore generalizzazione:

$$P(A) = \sum P(A|B_i)P(B_i)$$

# Lezione 03

### Formula di fattorizzazione

$$P(A\cap B) = P(A | B)P(B)$$

A quanto pare la formula della probabilità condizionata di un evento rispetto ad un altro evento è una 'formula di fattorizzazione' , buona a sapersi. 

In effetti risulta effettivamente buona da sapere in piccolo esercizietti. 

### Indipendenza condizionale

$$P(A \cup B|E) = P(A|E)P(B|E)$$

Come suggerisce il nome questa formula sta ad indicare la indipendenza condizionale. Cioè A e B sono sempre **dipendenti** eccetto per la condizione E. In tal caso allora sono indipendenti .. 

appunto una indipendenza condizionata da E. 

# Lezione 04

### Da adesso in poi non parliamo più di eventi ma di variabili aleatorie

Concetto semplice ma di difficile e sottile comprensione, fondamentale per il resto del corso. 

Con l'introduzione di variabili aleatorie possiamo quindi parlare di Funzioni: 

- funzione di ripartizione discreta $F(X) =P(X<x)$
    - monotona
    - $\lim_{x\to-\infty} F(X) = 0$
    - $\lim_{x\to+\infty} F(X) = 1$
    - continuità da destra $\lim_{y\to x+} F(Y) = F(X)$
- funzione di densità discreta  $f(X) = P(X=x)$
    - detta anche di massa, talvolta indicata con p(x)
    - $p(x) = F(X) - F(X^-)$

### Legge di Bernoulli

X ha legge bernoulliana di parametro p , se è una var. aleatoria con densità discreta definita da:

$$f(x) = \begin{cases} p^x(1-p)^{1-x} \space se \space x=0,1 \\ 0 \space \space \space \space \space \space altrimenti\end{cases}$$

## Distribuzione binomiale

Dato un processo di Bernoulli, esso può essere definito binomiale. La sua distribuzione viene definita da: 

$$P(k)=\binom{n}{k}p^k(1-p)^{n-k}$$

Da interpretare come la probabilità di k successi con n tentativi. 

NB: Processo di Bernoulli ci dice proprio che noi stiamo valutando una variabile che è o ''positiva'' o ''negativa'' o ''1'' o ''0'' ... ''successo'' ''fallimento'' . Quindi il successo ha un certa probabilità p, il fallimento 1-p.

# Lezione 05

## Legge di Poisson

X var. aleatoria si dice che rispetta la legge di Poisson se ha distribuzione che rispetta la relazione:

$$P(X) = \frac{\lambda ^x}{n!}e^{-\lambda}$$

Sta roba risulta rilevante poichè essa può approssimare asintoticamente la distribuzione binomiale. Prende infatti il  nome di 'distribuzione degli eventi rari' poichè tale approssimazione è giustificata nei casi in cui i parametri n e p siano rispettivamente molto grande e molto piccolo. 

## Media, Valore Atteso o Speranza Matematica

$$E(X) = \sum_{i=1} x_if(x)$$

Si commenta da solo, profanamente la si può vedere come 'media pesata delle probabilità' e corrisponde ad appunto il valore che ci si aspetta. Con un po' di fantasia può essere visto come il 'baricentro' di un.. stronzata varie.

### Indicatrice evento

$$I(A) = \begin{cases} 0 \space \space \space quando  \space \omega   \not\in A \\ 1 \space \space \space quando \space \omega \in A \end{cases}$$

## Distribuzione Geometrica

domanda: "qual è la probabilità di avere il **PRIMO** successo in una serie di n tentativi al k-esimo tentativo?"

risposta:

$$P(X=k)=p(1-p)^{k-1}$$

# Lezione 06

### Distribuzione Ipergeometrica

domanda:"qual è la probabilità di trovare k volte con n tentativi (senza reinserimento) solo r elementi in un insieme fatto di r+b elementi?"

risposta:

$$P(X=k)=\frac{\binom{r}{k}\binom{b}{n-k}}{\binom{r+b}{n}}$$

Ese: Io voglio estrarre k=3 palline di tipo r=rosse. ci sono 7 di tipo b=bianco e ho un totale di n tentivi.. r+b sono le palline iniziali ma ricorda che a ogni tentativo non reinserisco la pallina presa. 

# Variabili Aleatorie Assolutamente Continue

Level Up del caso discreto per tutti i problemi nel quale abbiamo a che fare con var. aleatorie di infiniti valori continue e non discreti (ese: temperatura, bho )

Abbiamo tutte le funzioni precedentemente riportate nel caso discreto: 

- Funzione di ripartizione

    $$F(X<x)=\int_{-\infty}^{x}f(t)dt$$

- Funzione di densità

$$F(X)' = f(x)$$

Ora funzioni di densità di probabilità continue notevoli:

### Legge uniforme del continuo
La più semplice: **uniforme** su un insieme, ovvero che attribuisce la stessa probabilità a tutti i punti appartenenti ad un dato intervallo \[a,b\] contenuto nell'insieme.
In generale per a>b si ha che $$f_x(x) =\frac{1}{a-b}$$
Mentre la sua funzione di ripartizione F(x) , cioè P(X<=x) è 
$$F(x)=x$$
### Distribuzione esponenziale
 
$$f(x) = \begin{cases} \lambda e^{-\lambda x} \space \space \space x \ge 0 \\ 0 \space \space \space \space \space \space \space \space \space \space \space x <0 \end{cases}$$

La distribuzione esponenziale ha come $E(X)=\frac{1}{\lambda}$ mentre ha come varianza $var(X)=\frac{1}{\lambda ^2}$
NB: la varianza sarà definita nella Lezione 09.
### Legge Gaussiana

$$f(x) = \frac{e^{-(\frac{(x - 2\mu)^"}{2\sigma^2}}}{\sqrt{2\pi\sigma^2}}$$

con $\mu$ valore atteso, mentre $\sigma$ la varianza.
La legge Gaussiana di notevole importanza infatti come funzione di densità di probabilità prende il nome di distribuzione normale. Semplice modello per fenomeni complessi. 
# Lezione 07
La distribuzione normale gaussiana è simmetrica rispetto al valore atteso $\mu$ 

### Funzione di sopravvivenza 
Utilizzata soprattutto per studiare la vita l'usura o il rodaggio d componenti, ma anche la mortalità di organismi. 
$$S(x)=1-F(X)=P(X>x)$$
Possiamo quindi descrivere comportamenti come l' **assenza di memoria** , cioè che la probabilità di sopravvivere fino a un tempo _t+s_, sapendo che tale oggetto è sopravvissuto fino al tempo _t_, è uguale alla probabibilità di un oggetto nuovo. 
**assenza di memoria**
$$S(t+s)|S(t)>S(s)$$
**usura**
$$S(t+s)|S(t)<S(s)$$
**rodaggio**
$$S(t+s)|S(t)>S(s)$$

# Lezione 08
modellizzare una misurazione di una variabile aleatoria?
### Modello scala posizione
$$X=\mu + \sigma \epsilon$$
Dove $\mu$ è la misura d'interesse , $\sigma$ è la precisione di misura e $\epsilon$ è la variabile aleatoria che indica l'errore di misura. 
La funzione di ripartizione risulta essere: $$F_{\mu,\sigma}= F_{\epsilon}(\frac{x-\mu}{\sigma})$$
### Valore atteso di una variabile ass. continua
$$E[X]=\int_{-\infty}^{+\infty} xf(x)dx$$
in analogia con (ricordiamo) il caso discreto:
$$E[x]=\sum_x x_ip_i$$

Importante proprietà del valore atteso è la linearità. 
$$E[aX +b]=aE[X]+b$$
NB: Il valore atteso di una costante, è una costante.
quindi, per il caso del modello scala posizione:
$$E[x]=\mu+\sigma E[\epsilon]$$
altra proprietà degne di nota del valore atteso:
$$se \space P(a \le x \le b) \space allora \space a \le E(x) \le b$$
### Introduzione trasformazioni variabili aleatorie
Le trasformazioni tra variabili aleatorie sono v.a. definite $y=g(x)$ , cioè funzioni di v.a. .

# Lezione 09
Finchè la trasformazione è invertibile e cioè g(x) è monotona, non c'è nessun problema, infatti le relazioni sono come te lo aspetti. Quando invece g non è invertibile bisogna fare qualche magheggio in più, ad esempio suddividi in intervalli la funzione. 
Ad ogni modo il ragionamento da applicare è lo stesso della composizione di funzioni, bisogna ragionare su domini e sulle relazione tra le varie variabili aleatorie. 
Distingueremo il caso discreto e il caso continuo.
Per quanto riguarda le trasformazioni nel **caso discreto**:
si ha densità:
$$f_y(y^*_j)=\sum_{i=g(x_i)=y_j^* } f_x(x_i)$$
e ripartizione come:
$$F(Y)=F(g(x))=P(g(x)<y)=P(x<g^{-1}(y)) =F_x(g^{-1}(y))$$

Per quanto riguarda le trasformazioni nel **caso continuo**:
$$f_y(y)=\i
    DA CONTINUNARE$$
    
Valore atteso per le trasformazioni 

Varianza
La varianza è definita come $$Var(x)=E((x-m)^2)$$ dove $m=E(X)$ . Si tratta quindi del valore atteso della 'distanza quadratica' tra la v.a. x e la sua media/valore atteso. 
**caso discreto**: $$Var(x)=\sum_x (x-m)^2f(x)$$
**caso continuo**:$$Var(x)=\int_{-\infty}^{+\infty}(x-m)^2f(x)dx$$

Deviazione standard: $\sigma_x = \sqrt{Var(x)}$

# Lezione 10
