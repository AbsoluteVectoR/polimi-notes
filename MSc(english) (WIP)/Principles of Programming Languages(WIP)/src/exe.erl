%-module(main).
%-export([add/2,car/1,cdr/1,map/2]).

add(A,B) -> A + B.
car([X|_]) -> X.
cdr([X|Xs]) -> Xs.

map(_, []) -> [];
map(F,[X|Xs]) -> [F(X) | map(F,Xs)].

filterr(F, [H|T]) ->
    case F(H) of
        true  -> [H|filterr(F, T)];
        false -> filterr(F, T)
    end;
filterr(F, []) -> [].

%parallel versions


% parallel map
pmap(F, L) ->
    Ps = [ spawn(?MODULE, execute, [F, X, self()]) || X <- L],
    [receive 
         {Pid, X} -> X
     end || Pid <- Ps].

execute(F, X, Pid) ->
    Pid ! {self(), F(X)}.



%same as pmap but we have to discard

pfilter(F, L) ->
    Ps = [ spawn(?MODULE, execute, [F, X, self()]) || X <- L],
    lists:foldl(fun (P,Vo) ->
               receive
                  {P,true, X} -> Vo ++ [X];
                  {P,false,_} -> Vo
                end end, [], Ps).

execute(F, X, Pid) ->
    case F(X) of
        true  -> Pid ! {self(), true,X};
        false -> Pid ! {self(), false,X}
    end.