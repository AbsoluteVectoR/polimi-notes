# Fondamenti di Automatica

# lezione 01

Gestione e studio dei problemi di controllo. 

Un problema di controllo lo si ha tutte le volte che voglio imporre un comportamento. 

Caratteristiche di un problema di controllo:

- sistema fisico
- variabili di controllare
- variabili su cui agire per controllare
- l'andamento desiderato delle variabili che vogliamo controllare

Problemi di automazione: diversi campi, tutti affrontati con la stessa metodologia.

Diversi approcci per controllare: 

- Anello aperto ad azione diretta (feed forward)

![Fondamenti%20di%20Automatica%20bdbf60c195a949bdafc5612d6b1ab17a/Untitled.png](Fondamenti%20di%20Automatica/FDA%20immagini/Untitled.png)

- Anello aperto ad azione diretta con controllo del disturbo, *stessa figura ma con controllo disturbo*
- Anello chiuso Feedback/Retroazione (senza controllo disturbo)

![Fondamenti%20di%20Automatica%20bdbf60c195a949bdafc5612d6b1ab17a/Untitled%201.png](Fondamenti%20di%20Automatica/FDA%20immagini/Untitled%201.png)

- Anello chiuso Feedback (con controllo disturbo)

Come si può notare la differenza tra anello chiuso/aperto è la presenza o meno della possibilità di 'misurare' la variabile controllata, in modo da avere un feedback costante della variabile che stiamo cercando di controllare. 

*esempi vari negli appunti a mano* 

# Lezione 02

Sistemi dinamici e non dinamici: 

- DINAMICI: anche conoscendo l'ingresso puntualmente (istante per istante) u(t) non riusciamo a ricavere y(t)
- NON DINAMICI: ci basta sapere u(t) per ricavare la nostra uscita y(t)

In generale dinamici sono tutti quei sistemi in cui oltre a sapere l'andamento degli ingressi ci serve sapere anche gli stati iniziali delle cosidette variabili di stato.

*vari esempi negli appunti a mano*

SISTEMI DINAMICI a Tc (tempo continuo) e SISO (Single Input Single Output) sono i sistemi iche più spesso affronteremo e incontreremo. 

$$x_1(t) = \phi(x_1(t_0) , x_2(t_0) ... x_n(t_0),u[t_0,t],t)$$

$$y(t) = \gamma(x_1(t),...,x_n(t),u(t),t)$$

Come si può osservare dalle equazioni qua  sopra un sistema dinamico può essere scritto ad esempio in questo modo, cioè definendo prima tutte le equazioni che governano le variabili di stato e dopo esplicitare l'uscita (che ci interessa) come una funzione delle funzioni di stato, degli ingressi e del tempo. 

DEFINIZIONI (*SD = Sistema DInamico*)

- **SD LINEARE**: le funzioni phi e gamma sono lineari.
- **SD STAZIONARIO o TEMPO-INVARIANTE**: le funzioni phi  e gamma (entrambe!) non dipendono **direttamente** dal tempo, ma solo indirettamente attraverso u(t)
- **SD STRETTAMENTE PROPRIO**: la funzione y(t) dipende solo da variabili di stato e non dagli ingressi. Ovviamente indirettamente anche dagli ingressi, in quanto le variabili di stato dipenderanno sicuramente dagli ingressi.

Noi useremo sd LTI (Lineari in x e u , e tempo-invarianti) e posso sempre scrivere un mio sd in rappresentazione matriciale. 

$$\begin{cases} x'(t) = Ax(t) + bu(t)  \\ y(t) = c(x(t)) + du(t) \end{cases}$$

Dove A può essere una matrice (nel caso id più variabili di stato) , b un vettore e c  un vettore. 

# Lezione 03

## Equilibrio

L'equilibrio di un SD si definisce tale quando, il sistema sottoposto a un u(t) costante e partendo da un preciso stato t0 o k0 (a seconda del caso Tempo Discreto o Tempo Continuo) si avrà una funzione di stato costante. 

Nel caso TC (tempo continuo): 

significa che $x'(t) = Ax(t) + bu(t) = 0$ 

Nel caso a TD:

significa che $x(t) = Ax(t) + bu(t)$ cioè 'quello di adesso è uguale a quello di prima' 

### Lagrange x Movimento SD

Il movimento di un SD in TD: 

$$⁍$$

Dove $A^kx(k_0)$  si dice movimento libero, cioè che non dipende dagli ingressi ma soltanto dallo stato iniziale. 

Il movimento di un SD a TC:

$$x(t) = e^{At}x(t_0) + \int_{t_0}^t e^{A(t - \tau)}bu(\tau) d\tau$$

*NB: A è una matrice e in modo analogo al caso a TD $e^{At}x(t_0)$ è il movimento libero.*

*integrale di matrice → integrale elemento per elemento*


## qua ricorda di aggiungere la parte del MF 

# Lezione 04

Linearizzazione ??? ← studiare e approfondire

## Stabilità degli equilibri:

- equilibrio stabile: equilibrio ''classico'' .. ingressi costanti → uscite costanti
- equilibrio asintoticamente stabile: equilibrio ''più forte'' , per $t \rightarrow \infty$ , esempio semplice ma efficace è la pallina in fondo alla coppa con attrito, appena provi a spostarla tornerà al punto di equilibrio.

La stabilità è una proprietà del sistema e dipende da $e^{At}$  cioè dalla matrice A. 

Se $e^{At} \space \space \space t \rightarrow \infty$ :  

- converge a 0: AS
- converge a un numero: S
- diverge: I

In pratica:

Gli autovalori della matrice A: 

- $Re \{\lambda _i \} < 0$    AS
- $Re \{\lambda _i \} \le 0$    S o I
- $Re \{\lambda _i \} > 0$   I

Ancora più in pratica: 

- Det(A) = 0 I
- Tr(A) > 0   I
- Coefficienti del polinomio caratteristico (secondo grado) concordi ma non nulli, condizione necessaria e sufficiente per AS
- Coefficineti del p. c. (terzo grado o di più) concordi ma non nulli, condizione necessaria per AS

# Lezione 05

Ancora ancora più in pratica: 

### Tabella di Routh:

![Fondamenti%20di%20Automatica%20bdbf60c195a949bdafc5612d6b1ab17a/Untitled%202.png](Fondamenti%20di%20Automatica/FDA%20immagini/Untitled%202.png)

Ad ogni cambio di segno degli elementi della prima colonna corrisponde un autovalore positivo di A → quindi instabile. 

In pratica riassunto: *usa la tabella di Routh per evitare la diagonalizzazione, guarda sempre la prima colonna, appena trovi un elemento con segno discorde dagli altri di fermi e dici che il SD in quel punto d'equilibrio è instabile*

## Segnali e Trasformate (Laplace e Fourier)

Sistemi dinamici nel dominio del tempo quando hanno equazioni differenziali sono sbatti da gestire. 

Utilizziamo le trasformate per passare al dominio delle frequenze, nel quale i legami differenziali possono essere espressi come semplici legami algebrici.. semplificandoci quindi la vita. 

trasformata di Fourier:

$$V(t) = \int _{-\infty}^{+\infty} v(t)e^{- j \omega t} d t$$

antitrasformata di Fourier: 

$$v(t) = \frac{1}{2 \pi j}\int _{-\infty}^{+\infty} V(t)e^{j \omega t} d t$$

trasformata di Laplace:

$$V(t) = \int _{-\infty}^{+\infty} v(t)e^{-st}
 ds$$

antitrasformata di Laplace:

$$v(t) = \frac{1}{2 \pi j} \int _\gamma V(t)*e^{st}ds$$

dove s = k + jw ed è un numero complesso.

NB: *nell'antitrasformata l'integrale è di linea! La trasformata di Fourier è un caso particolare di quella di Laplace. La TDF è quindi contenuta nella TDL, e se una funzione ammette TDF ammetterà sicuramente la TDL ma non viceversa!*

Noi useremo principalmente quella di Laplace. 

La quale gode di un paio di proprietà comode: 

- **operatore lineare**
- $L[\frac{dv(t)}{d(t)}] = sL[v(t)] - v(t_0)$ **proprietà della derivata**
- $L[\int _{t_0} ^t v(t)] = \frac{1}{s}L[v(t)]$ **proprietà integrale**
- $L[v(t-k)] = e^{-jk}L[v(t)]$ **proprietà ritardo**

## Teorema Valore Iniziale

$$v(0) = \lim _{s \rightarrow \infty} sV(s)$$

## Teorema Valore Finale

$$\lim _{s \rightarrow 0} sV(s) = \lim _{t \rightarrow \infty} v(t)$$

# Lezione 06
Funzione di trasferimento $$G(s)=c(sI-A)^{-1}b+d$$ caratterizza il comportamento di un sistema, e descrive la relazione tra ingresso ed uscita. 
Nel caso di un SD SISO la G(s) è sempre fratta con $Grado \space numeratore \le Grado \space Denominatore$.
E qui, in questo particolare caso (che ci capiterà sempre) entra in gioco la trasformata di Heaviside, cioè una particolare trasformata applicabile alla TDL razionali fratte. 
Un po' di nomenclatura per chi è del mestiere: 
- radici di N(s) li chiameremo **zeri**
- radici di D(s) li chiameremo **poli**

Idea della trasformata di Heaviside è di riscrivere la G(s) come somma di addendi facili da trasformare con la $TDL^{-1}$.
# Lezione 07
L'instabilità è una proprietà del sistema, certe volte un sistema diverge per qualsiasi ingresso, altre volte solo per determinati ingressi. 
*un po' di esercizi* .. 
trovare stabilità = controlla gli autovalori di A, puoi anche non calcolarli e guardare i magheggi che abbiamo visto nei precedenti capitoli. In linea generale: autovalore con parte reale positiva implica instabilità.

# Lezione 08 
*altri esercizi* e introduzione degli schemi a blocchi. Possiamo esprimere i SD come schemi a blocchi, nei quali ogni blocco rappresenta una G(s) e quindi un sotto SD. Ogni blocco può essere poi suddiviso in ulteriori blocchi, i quali sono gli addendi che compongono la G(s). 
NB: non c'è un prima o un dopo negli schemi a blocchi. Bisogna vedere il tutto come un'unica equazione e non pensare più in ottica temporale. 

# Lezione 09
Matrice di Jordan. Sapevamo che con un autovalore con parte reale positiva si aveva l'instabilità. Ma con parte reale di un autovalore nulla?? Non abbiamo detto nulla, perchè per uscirne da questo ultimo caso ci serve la Matrice di Jordan. 
Per cascun autovalore con parte reale = 0 e con dimensione miniblocco $\ge 1$ bisogna controllare gli elementi del miniblocco:
- se elemento $e^{\lambda t}$ limitato allora **SEMPLICEMENTE STABILE**
- se elemento $t^ke^{\lambda t}$ divergenti allora **INSTABILE**

NB: per avere il sistema stabile serve che il più grande miniblocco del autovalore con $Re\{\lambda_i\}=0$ abbia dimensione 1.

# Lezione 10
Raggiungibilità e Osservabili del sistema. 
Teo. di Cayley-Hamilton = un discreto macello di dimostrazione che ci permette di ottenere un risultato importante.
Come determino se un sistema è completamente raggiungibile?
Il rango di questa matrice (quadrata nel caso SISO) deve essere il massimo, cioè non deve essere singolare, cioè non deve avere determinante nullo per essere completamente raggiungibile.
$$M_r=\begin{pmatrix} b & Ab\end{pmatrix}$$
Come determino se un sistema è completamente osservabile?
Il rango di questa matrice deve essere massimo, il determinante non deve essere nullo, non deve essere singolare per essere completamente osservabile:
$$M_o=\begin{pmatrix} c' & A'c'\end{pmatrix}$$

# Lezione 11
forme canoniche?? riguardare 
G(s) minima _>_ dim. A = grado den. G(s) -> Raggiungibile e osservabile. 

### Sistemi interconnessi
Riprendono il concetto di SD rappresentati con schemi a blocchi,uniremo solo blocchi R & O (cioè uniremo solo SD con G(s) coprime tra loro, cioè che non hanno fattori comuni tra numeri e denominatori, cioè devono essere minime e senza cancellazioni).
Detto questo possiamo dire che il sistema complessivo è stabile asintoticamente solo se ciascun blocco è AS. Il fatto che ciascun blocco è AS implica che anche il sistema complessivo è AS solo se è un SD senza retroazione. Infatti le G(s) inizialmente coprime, potrebbero moltiplicandosi/addizionandosi tra loro avere dei fattori comuni e quindi portare a un sistema interconnesso non AS.

# Lezione 12
Risposta esponenziale.
$$ y(t)=Ye^{\lambda t}$$
con $$x(0)=(\lambda I-A)^{-1}bU$$ $$u(t)=Ue^{\lambda t} \space$$

ma $\lambda$ non deve essere autovalore di A.
- Se $\lambda$ è zero di G(S) allora ottengo y(t)=0 ( proprietà **bloccante degli zeri**)
- Se SD AS, allora $y(t)\rightarrow \infty =G(\lambda)u(t)$

# Lezione 13
Risposta sinusoidale, teo fondamentale risposta in frequenza.
$$y(t)=|G(jw)|Usin(wt + faseG(jw))$$
con $$u(t)=Usin(wt)$$
ma $\pm j\omega$ non devono essere autovalori di A.
- se AS, allora $y(t) \rightarrow \infty = |G(j\omega)|Usin(wt + faseG(jw))$

# Lezione 14
### diagrammi di Bode 
Tracciamento diagrammi di bode
DBM DBF

# Lezione 15

# Lezione 16
esercizi ..se non ho avuto cancellazione durante il calcolo della G(s) -> allora significa che è sia raggiungibile che osservabile.
