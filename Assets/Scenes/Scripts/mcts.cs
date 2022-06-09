using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class mcts
{
    private ArrayList _movesSets;
    private int _remainingValue;
    private List<State> _tree;
    private int _allTimeSimulations;
    private const float C = 1.4142135624f; //sqrt(2) 
    private int _maximumScore;
    private int _sumDices;
    private int _sumSelectedTiles;
    private PlayerAI _caller;

    public IEnumerator computeBestMove(PlayerAI caller, int maximumScore, ArrayList selectableTiles, int sumDices,
        int sumSelectedTiles)
    {
        _caller = caller;
        yield return new WaitForSeconds(0.1f); //temporary 
        _movesSets = legalMoves.computeSets(selectableTiles,sumDices);
        _sumDices = sumDices;
        _sumSelectedTiles = sumSelectedTiles;
        _maximumScore = maximumScore;

        buildStateSpace(selectableTiles);
        var selected = selection();
        var expanded = expansion(selected);
        var newScore = simulation(expanded);
        backpropagation(expanded,newScore);
        
        Queue<int> bestMove = new Queue<int>();
        

        //adviceBestMove(bestMove);
    }

    private int randomLaunch()
    {
        int valueDices = (int)Random.Range(1f, 6.99f);
        valueDices += (int)Random.Range(1f, 6.99f);
        return valueDices;
    }

    private void buildStateSpace(ArrayList selectableTilesOfRoot)
    {
        _tree = new List<State>();
        foreach (HashSet<int> legalSet in _movesSets)
        {
            State s = new State(null, selectableTilesOfRoot, _remainingValue, legalSet.ToArray()[0]);
            _tree.Add(s);
        }
        //delete redundant states 
        var treePruned = new List<State>();
        foreach (State state in _tree)
        {
            Boolean alreadyIn = false;
            foreach (State statePruned in treePruned)
            {
                if (statePruned.getPlayed() != state.getPlayed()) continue;
                alreadyIn = true;
                break;
            }
            if(!alreadyIn)treePruned.Add(state);
        }
        _tree = treePruned;
    }

    private float Ucb(int allTimeScore, int visits, int parentVisits)
    {
        if (visits == 0 || parentVisits == 0) return 0f;
        float ucb = (float)(allTimeScore / (_maximumScore * visits) + C * Math.Sqrt(Math.Log(parentVisits) / visits));
        return ucb;
    }


    private void adviceBestMove(Queue<int> bestMove)
    {
        _caller.takeAdvice(bestMove);
    }

    private State selection()
    {
        State selectedState = null;
        var bestUCB = float.MinValue;
        foreach (var state in _tree)
        {
            if (state.getUcb() > bestUCB) selectedState = state;
        }
        return selectedState;
    }

    private State expansion(State selectedOne)
    {
        selectedOne.incrementVisits();
        if (selectedOne.getRemainingValue() == 0) return selectedOne; //leaf node
        State expandedChild = selectedOne;
        while (expandedChild.getRemainingValue() == 0)
        {
            if (expandedChild.getChildren().Count == 0)
            {
                var move =
                    (int)legalMoves.compute(expandedChild.getTiles(), _sumDices, _sumDices)[0];

                var moveResult = expandedChild.getTiles();
                moveResult.Remove(move);
                expandedChild = new State(expandedChild, moveResult, expandedChild.getRemainingValue() - move, move);
            }
            else
            {
                expandedChild = expandedChild.getChildren()[0];
            }
            expandedChild.incrementVisits();
        }
        return expandedChild;
    }


    public int simulation(State simulatedChild)
    {
        while (simulatedChild.getTiles().Count!=0)
        {
            var randomDiceLaunch = randomLaunch();
            var possibleMoves = new ArrayList();
            do
            {
                possibleMoves =
                    legalMoves.compute(simulatedChild.getTiles(), randomDiceLaunch, randomDiceLaunch-simulatedChild.getRemainingValue());
                if (possibleMoves.Count == 0) break;
                var randomMove = (int)possibleMoves[(int)Random.Range(0f, possibleMoves.Count-0.00001f)];
                var moveResult = simulatedChild.getTiles();
                moveResult.Remove(randomMove);
                simulatedChild = new State(simulatedChild, moveResult, simulatedChild.getRemainingValue() - randomMove,
                    randomMove);
            } while (simulatedChild.getRemainingValue() > 0);

            if (possibleMoves.Count == 0) break;
        }

        int remainingTilesSum = 0;
        foreach (int remainingTile in simulatedChild.getTiles())
        {
            remainingTilesSum += remainingTile;
        }

        return _maximumScore - remainingTilesSum;
    }

    private void backpropagation(State expandedState, int scoreLastSimulation)
    {
        while (expandedState.getParent() != null)
        {
            expandedState.incrementScore(scoreLastSimulation);
            var newUCB = Ucb(expandedState.getAllTimeScore(), expandedState.getVisits(), expandedState.getParent().getVisits());
            expandedState.setUcb(newUCB);
        }
    }
}