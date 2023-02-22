# Metodi per la stima puntuale:

## Principio di sostituzione
Stimo il mio parametro con la 'sua versione empirica'. mi baso sulla legge forte dei grandi numeri, e pongo quindi la mia media empirica uguale al parametro da stimare. Funzione cumulata empirica, e quindi anche di sopravvivenza. Metodo che funziona nel mondo della fantasia. 
 
## Principio dei momenti
 Determinare il parametro $\theta$ univocamente dai momenti. Cioè cerchiamo il parametro che eguaglia i momenti 'teorici' con i momenti empirici. Ci troviamo quindi un sistema. 
 $$m_k = \frac{1}{n}\sum _{i+1}^n X_i^k$$
 L'idea è simile al metodo di sostituzione.
 
## MLE: Maximum likelihood estimation
 
Criterio della massima verosimiglianza. Si basa su determinare il $\theta$ che con maggior probabilità ha generato i dati osservati. 
La funzione di verosimiglianza: $$L(\theta,x)=\prod^n _i f(x_i)$$
Ma usiamo quasi sempre la log-verosimiglianza. $l(\theta,x)=ln(L(\theta,x))$
La log-verosimiglianza ha gli stessi punti di massimo di L ma ha alcuni vantaggi: i prodotti diventano somme e gli esponenti diventano moltiplicazioni. 
$$l(\theta,x)=\sum ^n _i ln(f(x_i)$$

- asintoticamente non distorta
- consistenza in media quadratica 
- asintoticamente gaussiana

#### Principio d'invarianza funzionale per gli MLE
Se $\hat\Theta$ è lo stimatore di $\theta$ allora lo stimatore di massima verosimiglianza per $\alpha = g(\theta)$ è $\hat \alpha=g(\hat \theta)$
