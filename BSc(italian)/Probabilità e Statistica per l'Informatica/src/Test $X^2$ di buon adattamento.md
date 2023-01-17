# Test $X^2$ di buon adattamento
I test statistici che servono a verificare se un modello probabilistico è compatibile con i dati sono detti test di buon adattamento.
Dato $f_i$ le frequenze osservate di ciascuna modalità, $p_i$ le probabilità teoriche di ciascuna modalità e $n$ la numerosità del campione e k il numero delle modalità/classi del campione.
$$X^2 = \sum ^k _{i=1}\frac{(f_i - np_i)}{np_i}$$
Rifiuto $H_0$ se $X^2 \ge X^2_{v,\alpha}$ (dove $\alpha$ è la significatività e $v$ sono $k-1$).