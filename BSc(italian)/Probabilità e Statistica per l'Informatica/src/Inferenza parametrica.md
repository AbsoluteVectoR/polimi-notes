# Inferenza parametrica

Dire qualcosa (FARE INFERENZA) sui parametri incogniti, usando
i dati (OSSERVAZIONI CAMPIONARIE).

# Stima puntuale 

Gli stimatori puntuali forniscono, per ogni realizzazione campionaria, un solo valore come “stima” del parametro incognito $\theta$ (o di una sua funzione $k(\theta)$). Lo stimatore è quindi una v.a. (o vettore aleatorio) e la stima è un numero (o un vettore di numeri).

 ## Distorsione di uno stimatore
 Il **bias** è  la differenza tra il valore atteso dello stimatore e il parametro.
 $$bias = \mathbb E(\hat \theta ) -\theta$$
 
  Quando uno stimatore **non** è distorto, allora si dice corretto.
  $$\mathbb E ( \hat \theta ) - \theta = 0 $$
 Uno stimatore può essere anche **asintoticamente non distorto**. Cioè è distorto magari, ma il limite del valore atteso dello stimatore per n-osservazioni che tendono ad infinito è uguale al parametro.
 
  ### errore quadratico medio MSE 
 $$MSE(\hat \theta) = \mathbb{E}[(\hat \theta - \tau(\theta))^2]$$
 Ma anche (decomposizione): 
 $$MSE(\hat \theta)=Var(\hat \theta)+(bias(\hat \theta,\theta))^2$$
Preferire lo stimatore con errore quadratico medio più basso.
 
## Consistenza 

### Consistenza debole
Uno stimatore $\hat \theta$ si dice debolmente consistente quando: $$\lim _ {n \rightarrow \infty} P_{\theta}(|\hat \theta - \theta|>\epsilon)\rightarrow 0$$
### consistenza in media 2
$$\lim _ {n \rightarrow \infty} \mathbb E _ \theta [(\hat \theta - \theta)^2]\rightarrow 0$$

Se  la successione di stimatori è consistente in media quadratica allora è anche debolmente consistente. 

 ### consistenza forte
$$\mathbb P (\lim _{n \rightarrow \infty} \hat \theta =\theta)=1$$
