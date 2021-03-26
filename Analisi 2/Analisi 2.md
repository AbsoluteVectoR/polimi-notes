# Analisi 2

14/09

## **approfondimenti sulla parte di topologia**

disuguaglianza di Cauchy-Schwarz:

$$|<x,y>|  \space \leq \space ||x|| *||y||$$

 *il prodotto assoluto del prodotto scalare di due elementi è minore o uguale al prodotto delle norme*

**punto interno** = é un punto il cui intorno é completamente contenuto nell'insieme. (un estremo non puó essere interno, ma di frontiera).

**punto esterno** = punto interno al complementare. 

**punto di frontiera** = un punto in cui qualsiasi intorno ha un punto appartenente all'insieme e un punto appartenente al complementare. 

**insieme aperto** = un insieme nel quale tutti i punti sono interni.

**insieme chiuso** = il complementare di un insieme aperto.

**insieme limitato** = se esiste una palla di raggio finito che lo contiene tutto.

**insieme illimitato** = non esiste una palla di raggio finito che lo contiene tutto.

**punto di accumulazione** = un punto x0 in cui ogni palla(x0) ha un'intersezione con l'insieme non nulla.

**punto isolato** = punto x0 in cui esiste almeno una palla(x0) che non presenta intersezioni con l'insieme.

EDO: *Equazione Differenziale Ordinaria*

ODE: *Ordinary Differential Equation*

Equazione che coinvolge una funzione di una variabile e le sue derivate di ordine qualsiasi. 

Una EDO si dice in forma normale se 'esplicitata' rispetto a una delle derivate. ??

Nel caso di una EDO del primo ordine in forma normale basta semplicemente risolvere un integrale, anche se 'risolvere una EDO' non significa calcolare un integrale, ma trovare y conoscendo delle informazioni su y' .

# EDO del primo ordine

### EDO A VARIABILI SEPARABILI

$$y'(x) = g(x)*y(x)$$

Soluzione nulla c'é sempre per le EDO a variabili separabili. 

Controllare anche la soluzione costante. **Se esiste una g(D) = 0 allora y(x) = D é soluzione !** 

Controllare anche la soluzione costante. **Se esiste una g(D) = 0 allora y(x) = D é soluzione !** 

### EDO LINEARI

$$y'(x) + a(x)y(x) = b(x) $$

la cui soluzione: 

$$y(x) = e^{-A(x)}(\int b(x)*e^{A(x) } dx + c)$$

### EDO non lineari

$$y'(x) = \frac {P(x,y(x))}{Q(x,y(x)}$$

le risolvi usando questa sostituzione:

$$z(x) = \frac{y(x)}{x}$$

### EDO di bernulli

$$y'(x) = a(x)y(x) + b(x)y(x)^{\alpha}$$

le risolvi usando questa sostituzione:

$$z(x) = \frac{1}{y(x)^{\alpha - 1}}$$

# EDO del secondo ordine lineari

Affrontiamo solo le EDO del secondo ordine a coefficienti costanti.

Omogenee:

$$ay''(x) + by'(x) + cy(x) = 0$$

polinomio caratteristico: 

$$\Delta > 0  \\ y(x) = c_1e^{\lambda _1 x} + c_2 e^{\lambda _2 x} $$

$$\Delta = 0 \\ y(x) = e^{ \lambda x}(c_1 + c_2 x)$$

$$ \Delta < 0 \\ y(x) = e^{ \alpha x} (c_1 cos ( \beta x) + c_2 sin ( \beta x))$$

con autovalori, nel caso di autovalori complessi, nella forma:

$$\alpha \pm \beta i$$

# Soluzioni particolari - *metodo di somiglianza*

Soluzione particolare di forma esponenziale:

$$f(x) = Ae^{\alpha x }$$

 nel caso di una radice = alpha : 

$$f(x) =  xAe^{\alpha x }$$

nel caso di entrambe le radici = alpha :

$$f(x) = x^2 A e^{\alpha x}$$

_____________________________________________________________________________________________________

Soluzione particolare di forma polinomiale:

$$f(x) = Ax^n + Bx^{n-1} ....$$

 nel caso di un c = 0 : 

$$f(x) =  Ax^{n+1} + Bx^n + Cx^{n-1} ..$$

altrimenti fare un due volte un integrale.

_____________________________________________________________________________________________________

Soluzione particolare di forma trigonometrica:

$$f(x) = Acos(\alpha x) + Bsin(\alpha x)$$

 nel caso di un b=0 e alpha = sqrt(c/a): 

$$f(x) =  x(c_1 cos(\alpha x) + Bsin( \alpha x))$$

# EDO e Oscillatori  Armonici

Le edo differenziali possono rappresentare delle oscillazioni. 

La oscillazione è data da equazioni del secondo ordine del tipo:

$$y''(t) + \omega ^ 2 y(t) = 0 $$

*edo non smorzata e non forzata*

$$y''(t) + 2 \mu y'(x) + \omega ^ 2 y(t) = 0 $$

*edo smorzata e non forzata*

il termine noto delle edo prende il nome di forzante.

$$y''(t) + 2 \mu y'(x) + \omega ^ 2 y(t) = \alpha cos (v x)$$

*il termine 2u che indica la 'smorzatura' può essere interpretato come ad esempio un attrito*

17/09

Per il principio di struttura possiamo dimostrare che le soluzioni di una EDO lineare omogenea é uno spazio vettoriale. 

Principio di sovrapposizione ci dice che se due funzioni sono soluzioni anche una loro combinazione lineare é soluzione. 

Abbiamo poi guardato l'integrale generale per le equazioni lineari non omogenee.

L'integrale dell'equazione non omogenea NON é uno spazio vettoriale!

Infatti la soluzione nulla non é soluzione!

Le equazioni lineari non omogenee NON possono avere soluzione nulla. 

Ma possono  avere soluzione costante .. infatti c'é da controllarla.  

21/09

# EDO del primo ordine non lineari risolubili esplicitamente

Il teorema di struttura e di sovrapposizione valgono solo per le EDO lineari omogenee!!! 

Prova sempre la ricerca delle soluzioni costanti. Per intenderci tutte le soluzioni che annullano la variabile x. 

Cose che sappiamo fare:

Edo del primo ordine lineari (omogenee e non omogenee).

Non lineari stile variabili separabili, omogenee, bernoulli.

Sulle altre EDO del primo ordine possiamo solo fare uno studio qualitativo.

Le EDO possono avere applicazioni di modellizazione della realtá (tipo crescita di popolazioni, vedi equazione logistica (che è una edo di bernulli). 

28/09

# Serie di funzioni

Successioni delle somme parziali dati dalla f(x), cioé una serie i cui 'addendi' sono funzioni e non numeri. Perché? Puoi esprimere una funzione qualsiasi con una serie di funzioni magari piú semplici da trattare della prima. 

Una serie di funzioni ha come risultato una funzione, se valutata in un punto é quindi un numero.

La convergenza puntuale, stabilito una x0, si ha quando la serie converge a f(x0) per quella x0. La serie puó quindi convergere puntualmente alla funzione in un punto x0 o in un intervallo A, che viene detto dominio di convergenza puntuale della serie. 

La convergenza assoluta si ha invece quando a convergere é la serie di termine generale |f| . 

Esempi tipo la serie geometrica x^n , o l'armonica generalizzata. 

Convergenza totale, cioé il valore del termine generale con il modulo é minore di una successione che converge (una specie di teorema del confronto).

1/10

# Serie di potenze

Una **serie di potenze** reale é una serie di funzioni nella forma 

$$an(x-x_0)^n $$

Ogni serie di potenze, ha raggio di convergenza (nullo, infinito o (x-x0) < R ) 

**dimostrazione convergenza:**

Abbiamo due modi per calcolare il raggio di convergenza. L'**inverso del metodo del rapporto** e l'**inverso del metodo della radice**.  Il limite dá direttamente R. 

La serie converge sempre per ogni intervallo dentro il raggio di convergenza MA non sappiamo nulla nei loro estremi. Infatti nel caso volessi esprimere l'intervallo di convergenza, per capire se é aperto o chiuso, dovrei valutare singolarmente gli estremi. *Se gli estremi  sono una serie convergente, allora posso dire che l'intervallo é chiuso.*

Una serie di potenze é estremamente regolare, derivabile e integrabile. 

Derivata e primitiva (tra x0 e x) corrispondono alla rispettiva derivata e primitiva (tra x0 e x) della somma. 

POLINOMIO DI TAYLOR : successione delle derivate per potenza. 

Ottenibile con la serie troncata e un resto, ad esempio Peano (o piccolo della potenza a cui si é arrivati).

SERIE DI TAYLOR : serie di potenze reale vera e propria. 

La serie di taylor puó avere raggio di convergenza nullo o infinito o finito. 

IN GENERALE LA SERIE DI TAYLOR NON CONVERGE A f(x) per ogni x appartente al raggio di convergenza. 

*serie esponenziale é la serie di taylor di e^x* 

$$e^x → \frac{x^n}{n!}$$

serie logaritmica é la serie di taylor di -ln(1-x) 

$$ln(1-x) → \frac{x^n}{n}$$

5/10

Esistono anche serie di potenze in campo complesso, possiamo sempre studiare il raggio di convergenza con i soliti metodi. 

Esistono dei polinomi trigonometrici .. cioé polinomi composti dalle sommatorie di seni e coseni. 

Utilizzando il polinomio di taylor possiamo dismostrare che nella serie esponenziale ci sono i polinomi di taylor del seno e del coseno e dimostrare cosí la FORMULA DI EULERO. 

$$e^{ix} = cos(x) + i sin(x) $$

Serie di Fourier, é una serie utilizzata per approssimare funzioni periodiche. Le funzioni non per forza devono essere regolari ... possono addirittura essere discontinue! 

La serie di Fourier ci restituisce un polinomio trigonometrico. 

Note particolari per integrali di sin e cos moltiplicati tra loro tra -pi e + pi :

$$\int_{-\pi}^{\pi} cos(nx)sin(kx) = 0 $$

$$\int_{-\pi}^{\pi} cos(nx)cos(nx) = \pi$$

$$\int_{-\pi}^{\pi} sin(nx)sin(nx) = \pi $$

8/10

Come si calcono i coefficienti di una serie di Fourier? (formule)

Dimostrazione supponendo di poter scambiare integrale con la serie (non sempre si puó fare).

Ricorda che puoi semplificare i conti .. 

se é dispari solo seni

se é pari solo coseni

Convergenza puntuale della serie di Fourier (basta che la funzione sia regolare a tratti, e che sia continua e derivabile, con definiti i limiti sx e dx sia della f che della derivata). NB: definiti i limiti sx e dx ... non per forza uguali. 

Se i limiti sx e dx della f non sono uguali (cioè non è continua), allora la serie di Fourier convergerà alla media aritmetica tra i due limiti.

Ad ogni modo risulta corretto dire che nel caso di una funzione periodica con periodo 2pigreco la sua serie di fourier converge puntualmente. Se la f è continua in tutto il periodo, allora la serie  convergerà puntualmente a f in ogni punto.

12/10

**Teorema regolaritá somma di Fourier**: *Se la serie con termine la somma dei valori assoluti di Ak e Bk é convergente .. allora anche la serie di Fourier converge.*

Inoltre se la serie con termine generale la somma dei valori assoluti moltiplicata per n é convergente  ... allora é anche derivabile ed é possibile derivare termine a termine. 

Quest'ultimo punto può essere iterato, infatti se converge la serie con termine generale la somma di n^2 per la somma dei valori assoluti 

**Teorema convergenza in norma quadratica:** *(la distanza tra f(x) e F di fourier elevata al quadrato e integrata tra -pigreco e pigreco) = 0*

**Disuguaglianza di Bessel = Uguaglianza di Parseval** :

$$\frac{1}{\pi} \int _{-\pi} ^\pi f(x) ^2 \geq 2a_o^2 + \sum _{n=1} ^\infty (a_k^2 + b_k^2)$$

Volendo puoi portare una serie di Fourier in forma esponenziale. Usando le equivalenze che derivano dalla formula di eulero. 

15/10

# CURVE IN R^ n

Parametrizzazione di una curva .. é la scrittura di una curva con un solo parametro per semplificare calcoli. Gli esampi canonici sono la sostituzione con sen e cos nelle circonferenze e elissi ... in generale vale che: x = t , y = f(t) ;

Curva regolare se ammette una parametrizzazione la cui derivata é continua e che non si annulla mai (completamente, nell'intervallo aperto). 

Curva semplice se non assume mai due volte lo stesso valore.

Il sostegno di una curva é l'immagine della curva stessa. 

Versore tangente a una curva dato dalla derivata della parametrizzazione fratto la sua norma.(normalizzato).

**La lunghezza di una curva é l'integrale della norma della derivata della curva.** 

Integrale di una funzione lungo una curva:

Parametrizzi con la curva la funzione, la moltiplichi per la norma della derivata (lunghezza).

19/10

Curva regolare a tratti ... curva regolare ad eccezione di un numero finito di valori.

La lunghezza di una curva regolare a tratti non é un problema e si puó fare.. separi gli integrali per gli intervallini in cui é continua... *l'integrale uccide la discontinuitá* .

Riparametrizzazione della curva: *Riparametrizzando la curva si conserva la lunghezza della curva. La lunghezza di una curva é l'integrale della norma di una derivata ... utilizzando la nozione di riparametrizzazione possiamo fare la composizione di derivata per dimostrarlo (dimostrazione 10).*

22/10 

**Limite di funzione a due variabili.** Definizione che rimane invariata. Ma ci si puó avvicinare lungo la curva da piú direzioni ... quindi si aprono scenari nuovi (infiniti modi per avvicinarsi a un punto).

Le coordinate polari (cioé x = r cos (x) e y = r sin (x))si puó fare la verifica delle rette. Cioé si ottiene una funzione che dipende da r e dall'angolo. Facendo il limite di r → 0 si puó risolvere il limite.

Se il limite L é finito si puó quindi verificare la formula del limite $|g(r,\alpha) - L| \le h(r)$  con h(r) una funzione che converge a 0 (perchè si facciamo sempre il limite in coordinate polari che converge a zero, altrimenti le dobbiamo fare traslate).

Se invece si vuole dimostrare la falsitá di un limite.. basta trovare due curve che vanno a due limiti diversi, facendo quindi due limiti di due funzioni in una sola variabile. 

Con l'introduzione dei limiti possiamo parlare anche di continuitá delle funzioni a due variabili ... nozione che rimane la stessa all'analoga in R ... cioé che il limite tenda proprio a f(x) per ogni punto appartenente a f(x). 

26/10/20 

# **Derivate parziali**

Definizione di derivata rimane invariato (su una sola variabile). 

$$f_{(x,y)} = \lim\limits_{h\rightarrow0}\frac{f(x+h,y) - f(x,y)}{h}$$

Così che possiamo definire il gradiente di un punto, cioè il vettore che ha per componenti le derivate. Il gradiente ci permette di ottenere la derivata direzionale. Cioè dato un vettore *v* possiamo determinare come varia la *f* lungo quella direzione. 

# Derivata direzionale

Derivata direzionale: 

$$\lim {h→0}  \frac{f(x_o + hv_1 , y_o + hv_2 ) - f(x_o, y_o)}{h}$$

A differenza della derivata parziale, che su un'unica componente la derivata direzionale è su tutte le componenti, dove (v1,v2) è il vettore direzione lungo cui vogliamo calcolare la derivata.

# **Gradiente**

Il Gradiente è un vettore che indica la pendenza della funzione in un determinato punto.

$$\nabla f(x,y)= (\frac{df(x,y)}{dx} , \frac {df(x,y)}{dy})$$

Un'alternativa più simpatica al limite per calcolare la derivata direzionale è la **regola del gradiente**. 

$$dv (a) = < \nabla (a),v>$$

Derivata direzionale di a lungo v. 

**Regola del gradiente:** facendo il prodotto scalare con un altro vettore riusciamo a trovare la 'pendenza' lungo quella direzione della nostra funzione. Se tale prodotto scalare ci restituisce la norma del gradiente. Allora significa che stiamo guardando il vettore su cui la funzione ha massima pendenza. 

# Differenziabilità

Se n=1 per avere un'approssimazione della funzione tramite Taylor è sufficiente sapere che la funzione è derivabile. In n≥2 questo non è vero. 

Definiamo quindi la differenziabilità, cioè quella condizione per cui è possibile trovare una approssimazione della nostra funzione. 

La funzione che meglio approssima la funzione è data da: 

$$f(X,Y ) = f(x_o,y_o) + <\nabla f(x_o, y_o) , ({x - x_o})({y - y_o}) > + o(||(x,y) - (x_o,y_o)||)$$

**Condizione sufficiente di differenziabilità** è che ciascuna derivata praziale sia continua, cioè che la funzione appartenga a C' (continua,ammette derivata, e la derivata è continua).

**Condizione sufficiente di differenziabilità** è che ciascuna derivata praziale sia continua, cioè che la funzione appartenga a C' (continua,ammette derivata, e la derivata è continua).

Per verificare che sia differenziale, però mi basta una derivata parziale continua! *la calcoli e poi guardi la continuità.*

Se una funzione è differenziabile in un punto, allora so che in quel punto esistono tutte le infinite derivate direzionali.

Altro modo per verificare che sia differenziabile:

$$\lim _{(h_1 , h_2) \rightarrow (0,0)} \frac{f(x_o + h_1,y_o + h_2) - f(x_o,y_o) \space - <\Delta f(x_o, y_o) , \vec h > }{||\vec h ||}$$

# **Iperpiano tangente**

Iperpiano tangente è quel piano su cui giace la retta tangente alla funzione. L'iperpiano è uguale alla prima parte della funzione di approssimazione. L'iperpiano in dimensione 1 è la retta tangente, in dimensione 2 è un piano tangente. 

Condizione necessaria di differenziabilità. 

 Equazione iperpiano: 

$$I(x,y) = f(x_o,y_o) + <\nabla f(x,y),(x - x_o , y - y_o)>$$

**Teo (dimostrazione con [Schwartz](https://it.wikipedia.org/wiki/Disuguaglianza_di_Cauchy-Schwarz))... che ci dice che se è differenziabile, allora f è continua.** 

quindi: 

differenziabile → continua 

differenziabile → derivabile 

derivabile → continua per quella variabile (continua in generale se per tutte le variabili)

derivabile → non per forza differenziabile 

29/10/20 

Derivazione di funzioni composte ... la posso fare se le funzioni sono rispettivamente *f* differenziabile e *r(t)* parametrizzazione di curva regolare. Inoltre:

$$F'(t) = < \nabla(r(t)) , r'(t) > $$

Derivata direzionale come derivata della funzione composta (? dim)

Ortogonalità tra gradiente e insieme di livello k, con r(t) sostegno di una curva regolare (che rappresenta il nostro insieme di livello). 

$$< \nabla(r(t)) , r'(t) > \ = 0$$

Calcolo differenziali per funzioni di più variabili a valori vettoriali. (?)

Matrice Jacobiana come matrice le cui componenti sono derivate parziali di una funzione a più variabili. 

Il Jacobiano è il determinante della matrice jacobiana (nel caso fosse quadrata) e rappresenta la migliore approssimazione di una funzione a più variabili in un punto. 

2/11/20 

Introdotte le derivate parziali seconde. 

E quindi anche della matrice Hassiana , matrici i cui elementi sono le derivate parziali seconde di una funzione a più variabili.

 Se si calcola la Hessiana in punto ... si ha una matrice di numeri se si calcola con x e y variabili si ha una matrice di funzioni.

Per il teorema di Schwartz , la Hassiana è simmetrica. Dunque ci sono componenti che (nonostante vengono da ordini di esecuzione di derivate diversi) sono uguali. 

**FORMULA DI TAYLOR II ORDINE** *con peano*

$$P_{taylor}(x_o + h, y_o + k) = f(x_0 + h, y_0 + k) \space + <\nabla(x_0,y_0), (h,k) > + \frac{1}{2}  (h,k) * H(x_o,y_o) * ({h},{k}) + o(h^2 + k^2)$$

con H(x0,y0) *hessiana e*(h k) * H(x0,y0) * (h,k)  *forma quadratica*. 

Le forme quadratiche possono essere:

**definite positive** *autovalori positivi  , determinante positivo* 

**definite negative** *autovalori negativi , determinante positivio* 

**semidefinite positive** *autovalore = 0, gli altri positivi , determinante nullo* 

**semidefinite negative** *autovalore = 0 , gli altri negativi , determinante nullo*

**indefinite** *a cazzoo , determinante negativo* 

5/11 

# **Introduzione all'ottimizzazione per studiare punti di minimo e punti di massimo.**

**Teo. di Weierstrass:** un insieme CHIUSO e limitato e continuo ha sicuramente punti di minimo e punti di massimo.

**Teo di Fermat:** (x0,y0) punto critico allora avrà gradiente = 0 

*Il piano tangente a un punto critico sarà un piano parallelo al piano x/y .. cioè ''orizzontale''.*

Un punto critico di f, che non è un punto di estremo è un punto di sella. 

Classificazione punti critici:

*q* forma quadratica indotta dalla hessiana.

**MINIMO:**

1) *q* è definita positiva (autovalori tutti positivi)

2)il determinante della Hessiana > 0 e la derivata seconda dx del punto è positiva 

**MASSIMO:**

1) *q* è definita negativa (autovalori tutti negativi) 

2) la Hessiana ha det. positivo e la derivata seconda in dx è negativa 

**PUNTO DI SELLA:**

1) *q* è !!indefinita!! 

2) la Hessiana ha det. negativo 

# Classificazione punti critici con Hessiana

*più comoda del criterio sulla forma quadratica*

- MINIMO:

    1) determinante Hessiano > 0 

    2) prima componente dell'Hessiana > 0

- MASSIMO:

    1) determinante Hessiano > 0 

    2) prima componente dell'Hessiana < 0

- PUNTO DI SELLA

    1) determinante Hessiano < 0 

C*on det=0 o con una q semidefinita (cioè uno degli autovalori è uguale a 0) allora non si combina nulla.*

Con det=0 posso mettermi a sostituire nella funzione f(x,y) delle funzioni sparate da me .. ma questo mi aiuta solo se vedo che da una parte è sempre maggiore di 0 e dall'altra sempre minore → sella . 

*Altrimenti se trovo maggiore/maggiore o minore/minore non posso concludere nulla*

12/11

**Convessità delle funzioni** : ogni segmento è 'contenuto' nella porzione di spazio delimitato dalla funzione. 

Se f è convessa e f ha punto critico .. allora sarò sicuramente di minimo .. perchè 'cresce' all'infinito. 

# Ottimizzazione vincolata

Dato un vincolo Z, un punto si dice massimo/minimo vincolato solo se esso è maggiore/minore  rispetto a TUTTI i punti appartenenti al vincolo della funzione. 

Per trovare un massimo vincolato ho due metodologie: 

1) SOSTITUZIONE= *è particolarmente semplice e facile sostituire una delle due variabili con il vincolo:* quindi trovo una funzione ad una sola variabile. Pongo la derivata = 0 e trovo quindi i punti critici.

2) MOLTIPLICATORI LAGRANGIANI= faccio un sistema a 3 incognite con il vincolo e il gradiente della funzione uguale al gradiente del vincolo moltiplicato per un parametro. Se il parametro è uguale a 0 per un punto, sappiamo che quel punto è un punto stazionario. 

NB: il metodo dei moltiplicatori funziona solo dove il gradiente del vincolo ≠ 0.

NB: se sto studiando una ragione delimitata da un vincolo (e quindi devo cercare i punti non solo sul vincolo ma nel vincolo), devo:

1) ottimizzazione libera e cercare i punti critici globali, a quel punto se li trovo, controllo che siano dentro la regione delimitata dal vincolo.

2) li vado a cercare proprio sul vincolo.

19/11

# Calcolo integrale per funzioni a due variabili.

L'integrale di una funzione a 2 variabili lungo una curva r(t) → geometricamente (f che vive in R3) è come se prendessi l'area sottesa alla funzione .. compresa tra l'asse x e la funzione r(t).

$$\int_a^b \! f(r(t))||r(t)|| \mathrm {d}t $$

dove *a* *b* sono due punti della *r(t).*

Le regioni semplici sono porzioni di piano comprese tra due funzioni. 

Possiamo calcolare l'area di regioni semplici sia rispetto a y sia rispetto a x con integrali doppi. 

$$\int_a^b \int_{g_1(x)}^{g_2(x)} \! f(x,y) \mathrm{d}y \mathrm{d}x$$

*il primo integrale che faccio è sempre rispetto al range della rispettiva variabile → devo calcolare la "fettina" tra g1(x) e g2(x) ? bene allora faccio in dy con estremi le due funzioni limitanti*

Per gli integrale di funzioni ''verticali'' stessa roba invertita. *Prima faccio dx con estremi le due funzioni. Poi ottengo le "fettine" orizzontali in funzione di y. Poi le integro lungo la "pila" verticale*

23/11

**Cambiamento di coordinate nel piano**, in particolare le coordinate polari ci permettono di semplificare i conti per quanto riguarda integrali a due dimensioni. 

coordinate polari: 

$$ z = cos(\theta) \\x = sin(\theta)cos(\phi) \\y=sin(\theta)sin(\phi)$$

$$J(coordinate \space polari) = r^2 sin(\theta)$$

**ricordati che nel jacobiano c'è l'angolo usato per l'asse z** !!!

Introduciamo quindi gli integrali doppi per regioni semplici (riconosci se la regione semplice rispetto a x o rispetto a y). Integrali doppi rispetto  a regioni sferiche possono essere risolti facendo la sostituzione con le coordinate polari e aggiungendo il jacobiano. 

Integrali possono anche essere divisi in subintegrali suddividendo il dominio. 

Ci sono anche gli integrali tripli, integrali di funzioni che vivono in R3 e vanno in R4. 

Gli integrali tripli li posso risolvere:

- integro per fili, facendo prima un integrale a una dimensione e poi uno doppio.
- integro per strati, facendo prima un integrale doppio e poi uno a una dimensione.

Infine posso fare un integrale triplo usando le coordinate sferiche (1 raggio e 2 angoli). 

In quel caso avremo un jacobiano particolare e delle sostituzioni specifiche da ricordare.

26/11

MASSA: avendo una funzione *dens* continua densità, di un solido (definito da una regione *REG*). 

$$M_{(regione)} = \int \int \int _ {regione} dens(x,y,z) dxdydz$$

CENTRO DI MASSA: (*baricentro)*  integrando la singola variabile per la funzione densità (in 3 dimensioni) e normalizzare il tutto per la massa totale. 

$$x = \frac {\int \int \int _ {regione} x*dens(x,y,z) dxdydz} {M(regione)}$$

$$y = \frac {\int \int \int _ {regione} y*dens(x,y,z) dxdydz} {M(regione)}$$

$$z = \frac {\int \int \int _ {regione} z*dens(x,y,z) dxdydz} {M(regione)}$$

MOMENTO D'INERZIA: come l'integrale della distanza al quadrato rispetto ad un asse, moltiplicata per la funzione densità.  

$$Inertia_{(regione)} = \int \int \int _ {regione} (distanzasse)^2 dens(x,y,z)dxdydz$$

dove distanzasse *al quadrato* può essere ad esempio: x^2 + y^2 (*rispetto all'asse z*)

*Richiamo ulteriore delle funzioni differenziali*

# Esistenza e unicità locale del problema di Cauchy.

Teorema importantissimo e sottile. 

Unicità **locale** della soluzione?? 

27/11

Per equazioni differenziali lineari a coefficienti costanti l'applicazione del teorema di esitenza e unicità è automatico. 

3/12

Qualunque EDO di ordine n può essere scritto in forma matriciale, cioè un sistema con n incognite. 

*esempio:*

y''(x) + y'(x) + 3y(x) = 9x 

$$\begin{pmatrix} y'_1(x) \\ y'_2(x)\end{pmatrix} = \begin{pmatrix} 0 & 1 \\  -3 & -1\end{pmatrix} \begin{pmatrix} y_1(x) \\ y_2(x)\end{pmatrix} + \begin{pmatrix} 0 \\ 9x \end{pmatrix}$$
					
con $$y(x) = y1(x) $$
$$y2(x) = y1'(x)$$

# Teo. di esistenza e unicità GLOBALE per il problema di Cauchy

....

Principio di struttura e sovrapposizione per i sistemi omogenei.

Matrice Wronskiana, matrice formata dalle soluzioni del sistema differenziale.

*per dimostrare che i vettori delle soluzioni del sistema diff. sono linearmente indipendenti basta trovare un determina della Wronskiana diverso da 0*

10/12

Struttura integrale generale per sistemi differenziali lineari NON OMOGENEI.

Basandoci sempre su matrici per rappresentare sistemi abbiamo così potuto parlare di diagonalizzazione della matrice A per risolvere il sistema e trovare quindi l'integrale generale. 

la mia soluzione in 

$$B(x) = c_1e^{\lambda _1  x} v_{\lambda} + c_2 e^{\lambda _2 x} u_{\lambda _2}$$

Teorema 18 con dimostrazione. 

14/12 

# Sistemi complessi e differenziali

equazione autonoma:

$$y'(x) = f(y(x)) $$

Se y'(x) e y(x) sono vettori allora l'equazione diventa un sistema autonomo.

Questi sistemi hanno soluzioni rappresentabili nel piano delle fasi.

I punti di equilibrio sono particolarmente importanti nel nostro studio e si classificano in: Punti stabili e instabili. 

Questi punti di equilibrio sono  gli zeri della mia funzione f(x0):

$$x_0 \space \space | \space \space f(x_0) = 0$$

A questo punto possiamo fare uno studio qualitativo del sistema complesso, osservando come variano le soluzioni al variare di C e al avvicinarsi ai punti di equilibrio.

Classifichiamo la forma del grafico nel piano delle fasi in: 

1) a sella (le semirette degli autovettori sono gli assi)

2) nodo a 2 tangenti (le semirette generate dagli autovettori a 'X' )

3) elissi strane *(date da autovalori immaginari)*