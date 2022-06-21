using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class mcts
{
    private int _remainingValue;
    private int _allTimeSimulations;
    private const float C = 1.41f; //sqrt(2) for ucb 
    private int _maximumScore;
    private PlayerAI _caller;
    private ArrayList _tilesRoot;
    private int _totalSim;

    public IEnumerator computeBestMove(PlayerAI caller, int maximumScore, ArrayList tiles, int sumDices)
    {
        _totalSim = 1;
        _caller = caller;
        _tilesRoot = tiles;
        _maximumScore = maximumScore;
        State root = buildRootNode(sumDices);
        State bestMove = null;
        if (root.getChildren().Count == 1)
        {
            bestMove = root.getChildren()[0];
        }
        else
        {
            while (_totalSim < 150000)
            {
                var selected = selection(root);
                var expanded = expansion(selected);
                var newScore = simulation(expanded);
                backpropagation(expanded, newScore);
                _totalSim++;
                if (_totalSim % 1500 == 0) yield return null;
            }

            double bestUcb = double.MinValue;
            foreach (State possibleMove in root.getChildren())
            {
                if (possibleMove.getUcb() > bestUcb)
                {
                    bestMove = possibleMove;
                    bestUcb = bestMove.getUcb();
                }
            }
        }

        adviceBestMove(bestMove);
    }

    private State buildRootNode(int sumDices)
    {
        State root = new State(null, _tilesRoot, null, sumDices);
        ArrayList legalMovesRoot = LegalMoves.computeSets(_tilesRoot, sumDices);
        foreach (HashSet<int> possibleMove in legalMovesRoot)
        {
            var newChildRoot = new State(root, tilesAfterMove(_tilesRoot, possibleMove), possibleMove, sumDices);
            root.addChild(newChildRoot);
        }

        return root;
    }


    private int randomLaunch()
    {
        var valueDices = Random.Range(1, 7);
        valueDices += Random.Range(1, 7);
        return valueDices;
    }

    private float Ucb(State state)
    {
        var sims = state.getSimulations();
        var parentSims = state.getParent().getSimulations();
        if (sims == 0 || parentSims == 0) return float.MaxValue;
        var allTimeScore = state.getAllTimeScore();
        return ((float)allTimeScore / (_maximumScore * sims) + C * (float)Math.Sqrt((Math.Log(parentSims)) / sims));
    }

    private void adviceBestMove(State bestMove)
    {
        Debug.Log("simulations on this move:" + bestMove.getSimulations());
        Debug.Log("ucb score:" + bestMove.getUcb());
        _caller.takeAdvice(bestMove.getPlayed());
    }

    private State selection(State selectedState)
    {
        State bestChild = null;
        var bestUcb = float.MinValue;

        if (selectedState.getChildren().Count == 0) return selectedState;

        foreach (var child in selectedState.getChildren())
        {
            var newUcb = Ucb(child);
            child.setUcb(newUcb);
            if (newUcb < bestUcb) continue;
            bestChild = child;
            bestUcb = newUcb;
        }

        if (!bestChild.isFullExpanded()) return bestChild;

        return selection(bestChild);
    }

    private State expansion(State stateToExpand)
    {
        var childToExpandFound = false;
        ArrayList possibleMoves = null;
        var randomSumDices = randomLaunch();
        
        while (!stateToExpand.isFullExpanded() && !childToExpandFound) //it's guaranteed that a newChild is expanded and returned
        {
            var unexpandedMoves = stateToExpand.returnUnexpandedLaunches();
            randomSumDices = randomLaunch();
            if (unexpandedMoves.Contains(randomSumDices)) //this means that is not already full expanded this dicesSum
            {
                possibleMoves = (ArrayList)unexpandedMoves[randomSumDices]; 
                if (possibleMoves.Count == 0) //first time that this random launch is considered 
                {
                    possibleMoves = LegalMoves.computeSets(stateToExpand.getTiles(), randomSumDices);
                    stateToExpand.newExpandedLaunch(randomSumDices, possibleMoves); //the state updates the random launch and the possibleMoves
                }
                
                if (possibleMoves.Count > 0)
                {
                    childToExpandFound = true;
                }
            }
        }

        if (!childToExpandFound) return stateToExpand;
        
        
        var randomExpansion = Random.Range(0, possibleMoves.Count); //random selecting a possible move
        var selection = (HashSet<int>)possibleMoves[randomExpansion];
        stateToExpand.newExpandedMove(randomSumDices, selection); //updating the unexpandedMove in the node
        var newChild = new State(stateToExpand, tilesAfterMove(stateToExpand.getTiles(), selection),
            selection, randomSumDices);
        stateToExpand.addChild(newChild);
        return newChild;
    }
    


private int simulation(State simulatedChild)
{
    while (true)
    {
        var tiles = simulatedChild.getTiles();
        var launch = randomLaunch();
        var possibleMoves = LegalMoves.computeSets(simulatedChild.getTiles(), launch);
        if (possibleMoves.Count == 0) break;
        HashSet<int> randomMove =
            (HashSet<int>)possibleMoves[(int)Random.Range(0f, possibleMoves.Count - 0.00001f)];
        var moveResult = tilesAfterMove(tiles, randomMove);
        simulatedChild = new State(simulatedChild, moveResult, randomMove, launch);
    }

    int score = _maximumScore;
    foreach (int tileNotFlipped in simulatedChild.getTiles())
    {
        score -= tileNotFlipped;
    }

    return score;
}

private void backpropagation(State expandedState, int scoreLastSimulation)
{
    while (expandedState.getParent() != null) //root 
    {
        expandedState.incrementSimulations();
        expandedState.incrementScore(scoreLastSimulation);
        expandedState = expandedState.getParent();
    }

    expandedState.incrementSimulations(); //root total simulations
}


private ArrayList tilesAfterMove(ArrayList array, HashSet<int> moveSet)
{
    ArrayList tilesAfterMove = new ArrayList();
    foreach (int tile in array)
    {
        if (moveSet.Contains(tile)) continue;
        tilesAfterMove.Add(tile);
    }

    return tilesAfterMove;
}
}