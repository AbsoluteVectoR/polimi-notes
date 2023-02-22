# Stima intervallare IC
Per quantificare il grado di precisione associato alla stima puntuale di un parametro $\theta$   si ricorre alla cosiddetta stima intervallare, cioè si costruisce un intervallo di valori in cui si ha una elevata fiducia che cada il valore incognito del parametro. Gli estremi dell'intverallo sono calcolati per mezzo del campione dei dati osservati. 

## Quantità pivotale
Sia Q la quantità pivotale per la costruzione di intervalli di confidenza. Allora: $$P_{\theta}(q_1<Q<q_2)$$
dove $q_1$ e $q_2$ dipendono dal livello di confidenza $\alpha$ ma non dal parametro $\theta$.
Ci sono intervalli bilateri e unilateri. 
IC più stretto implica più precisione. 

**Intervalli di confidenza per la media $\mu$:**
Applicato nel caso di una popolazione normale:
- varianza $\sigma$ nota (Z):
$$P(\mu \in(\bar X _n \pm z_{1 - \alpha /2}\frac{\sigma}{\sqrt n}))=1-\alpha$$
- varianza $\sigma$ incognita (T):$$P(\mu \in(\bar X _n \pm t_{1 - \alpha /2}\frac{S_n}{\sqrt n}))=1-\alpha$$
*NB: in caso di campione numoroso, il caso della T di Student è approssimabile da una normale*

**Intervalli di confidenza per la varianza $\sigma$ :**
Applicato nel caso di una popolazione normale:
-  media $\mu$ nota:
$$P(\frac{S^2(n)}{X^2_{1-\alpha/2,n}}<\sigma^2<\frac{S^2(n)}{X^2_{\alpha/2,n}})=1-\alpha/2$$
- media $\mu$ incognita :
$$P(\frac{S^2(n-1)}{X^2_{1-\alpha/2,n-1}}<\sigma^2<\frac{S^2(n-1)}{X^2_{\alpha/2,n-1}})=1-\alpha/2$$

**Proporzione $p$ di una popolazione bernoulliana**
$$P(\hat p - \frac{\sqrt{\hat p (1-\hat p)}}{n}z_{1-\alpha/2} < p < \hat p + \frac{\sqrt{\hat p (1-\hat p)}}{n}z_{1-\alpha/2})=1-\alpha$$

**Parametro $\lambda$ di una popolazione poissoniana**
$$P(\bar X - \frac{\sqrt{\bar X}}{n}z_{1-\alpha/2} < p < \bar X + \frac{\sqrt{\bar X}}{n}z_{1-\alpha/2})=1- \alpha$$

**Parametro $\lambda$ di una popolazione esponenziale**
$$P(\frac{1}{2n\bar X}X^2_{\alpha/2,2n}<\lambda<\frac{1}{2n \bar X}X^2_{\alpha /2,2n})$$
