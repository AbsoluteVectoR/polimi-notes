# Test delle ipotesi
## singola popolazione
### Ipotesi statistica 
Un'ipotesi statistica è un'affermazione riguardo la media o la varianza di una determinata distribuzione.

### Ipotesi nulla $H_0$
Un'ipotesi nulla/alternativa è una coppia di ipotesi nel quale la veridicità di una ipotesi sui campioni esclude l'altra.

### Ipotesi semplice e composta. 
Un'ipotesi semplice è un'ipotesi la quale, se vera con i nostri campioni, ci permette di descrivere completamente la nostra distribuzione. Composta viceversa.

### Errore di prima specie e di seconda specie. 
Un **errore di prima specie** è quando consideriamo $H_0$ non compatibile con i nostri dati ma in realtà è vera. 
Un **errore di seconda specie** è quando accettiamo l'ipotesi $H_0$ compatibile con la popolazione ma in realtà è falsa. 
Consideriamo gli errori di prima specie più gravi degli errori di seconda. 

### P-value 
P-value è il valore più basso di $\alpha$ per cui **non accettiamo la nostra ipotesi $H_1$**, quindi per $\alpha$ maggiori del p-value continueremo a non accettare l'ipotesi.

Un P-value quasi uguale a zero significa che siamo praticamente certi di non sbagliare rifiutando
l’ipotesi $H_0$. Un P-value molto maggiore indica invece che a qualsiasi livello
ragionevole di significatività, non rifiutiamo l’ipotesi nulla; in questo caso si può anche dire che il
test ci porta ad accettare l’ipotesi.
Il P-value può essere difficile da calcolare con precisione usando le tavole, quindi negli esercizi ci limiteremo a fare stime intervallari di quest'ultime (in un software ovviamente possiamo facilmente trovare una stima puntuale).

### Curva OC
$\beta$ è definita come la probabilità di accettare l'ipotesi **nulla** in funzione del parametro che stiamo testando. 
Di conseguenza se il parametro incognita soddisfa l'ipotesi alternativa, la curva OC rappresenta una probabilità d'errore di II specie.

### Potenza del test
$\pi(\theta)=1 - \beta$ è la funzione in funzione del parametro incognito $\theta$ che è definita come la probabilità di rifiutare l'ipotesi nulla e quindi accettare l'ipotesi alternativa.
*La potenza del test è la possibilità di rigettare l'ipotesi nulla quando è giusto farlo ( cioe' quando $H_0$ è falsa ).* 
**Esempio:** *Nel caso in l'ipotesi alternativa viene soddisfatta per $T_0 >t$*
 $\pi(\theta)=P_{\theta}(T_o>t_{\theta})$ con $\theta = \frac{\Theta }{\Theta _0}$

La potenza del test aumenta quanto maggiore è il numero dei soggetti del campione.  
La potenza del test aumenta passando da un $\alpha$ di 0.05 a uno di 0.1 ma così facendo aumenta anche il rischio di rigettare una ipotesi nulla vera.

### Test Z
Test su media di una popolazione gaussiana con varianza nota.

### Test T
test su media una popolazione gaussiana con varianza incognita.

### Test X
test su varianza con media incognita. 
