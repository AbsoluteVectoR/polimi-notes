-module(main).
-export([add/2,car/1,cdr/1,map/2]).

add(A,B) -> A + B.
car([X|_]) -> X.
cdr([X|Xs]) -> Xs.

map(_, []) -> [];
map(F,[X|Xs]) -> [F(X) | map(F,Xs)].


