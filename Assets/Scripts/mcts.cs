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
    private const float C = 1.4142135624f; //sqrt(2) for ucb 
    private int _maximumScore;
    private PlayerAI _caller;
    private ArrayList _possibleExpansionState;
    private ArrayList _tilesRoot;
    private int _totalSim;
    public IEnumerator computeBestMove(PlayerAI caller, int maximumScore, ArrayList tiles, int sumDices)
    {
        _totalSim = 1;
        _caller = caller;
        _tilesRoot = tiles;
        _maximumScore = maximumScore;
        _possibleExpansionState = new ArrayList();
        for (int i = 2; i <= 12; i++) _possibleExpansionState.Add(i); //'constant' arraylist needed for expansion phase
        State root = buildRootNode(sumDices);
        State bestMove = null;
        if (root.getChildren().Count == 1)
        {
            bestMove = root.getChildren()[0];
        }
        else
        {
            while (_totalSim < 100000)
            {
                var selected = selection(root);
                var expanded = expansion(selected);
                var newScore = simulation(expanded);
                backpropagation(expanded,newScore);
                _totalSim++;
                if(_totalSim%300==0) yield return null;
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
        State root = new State(null, _possibleExpansionState, _tilesRoot, null);
        ArrayList legalMovesRoot = LegalMoves.computeSets(_tilesRoot, sumDices);
        foreach (HashSet<int> possibleMove in legalMovesRoot)
        {
            var newChildRoot = new State(root, _possibleExpansionState, 
                tilesAfterMove(_tilesRoot,possibleMove), possibleMove);
            root.addChild(newChildRoot);
        }
        return root;
    }
    
    
    private int randomLaunch()
    {
        int valueDices = (int)Random.Range(1f, 6.99f);
        valueDices += (int)Random.Range(1f, 6.99f);
        return valueDices;
    }

    private double Ucb(State state)
    {
        var allTimeScore = state.getAllTimeScore();
        var sims = state.getSimulations();
        if (sims == 0) return Double.MaxValue;
        double ucb = ((double)allTimeScore /(_maximumScore * sims) + C * Math.Sqrt((Math.Log(_totalSim))/ sims));
        return ucb;
    }
    
    private void adviceBestMove(State bestMove)
    {
        Debug.Log("simulations on this move:"+bestMove.getSimulations());
        Debug.Log("ucb score:"+bestMove.getUcb());
        _caller.takeAdvice(bestMove.getPlayed());
    }

    private State selection(State selectedState)
    {
        if (selectedState.getChildren().Count == 0) return selectedState;
        State bestChildNotExpanded = null;
        State bestChildCompletelyExpanded = null;
        var bestUcbExpanded = double.MinValue;
        var bestUcbNotExpanded = double.MinValue;
        
        foreach (var child in selectedState.getChildren())
        {
            //updating the ucb of child
            var newUcb = Ucb(child);
            child.setUcb(newUcb);
            //I find the best child not full expanded, meanwhile I always tracked the best child already expanded in case I already expand all children
            if (!child.isFullExpanded())
            {
                if (newUcb < bestUcbNotExpanded) continue;
                bestUcbNotExpanded = child.getUcb();
                bestChildNotExpanded = child;
            }
            else
            {
                if (newUcb < bestUcbExpanded) continue;
                bestUcbExpanded = child.getUcb();
                bestChildCompletelyExpanded = child;
            }
        }

        State bestChild = null;
        bestChild = bestChildNotExpanded ?? bestChildCompletelyExpanded; //if bestChildNotExpanded is null, I will select the best child already full expanded
        
        return selection(bestChild);
    }

    private State expansion(State stateToExpand)
    {
        var tiles = stateToExpand.getTiles();
        State newChild = null;
        while (!stateToExpand.isFullExpanded()) 
        {
            ArrayList unexpanded = stateToExpand.returnUnexpandedLaunches();
            float rangePossibleChild = unexpanded.Count - 0.01f; 
            //to expand only the UNEXPANDED ONES and not states already expanded
            int randomExpansion = (int)unexpanded[(int)Random.Range(0f, rangePossibleChild)]; 
            stateToExpand.newExpandedChild(randomExpansion);
            ArrayList expandedStates = LegalMoves.computeSets(stateToExpand.getTiles(),randomExpansion);
            foreach (HashSet<int> possibleMove in expandedStates)
            {
                var newExpanded = new State(stateToExpand, _possibleExpansionState, 
                    tilesAfterMove(tiles,possibleMove), possibleMove);
                stateToExpand.addChild(newExpanded);
                newChild = newExpanded;
            }
            if (newChild != null) break; //new state expanded from random move, it will be simulated if not null, otherwise continuing until full expansion 
        }

        if (newChild == null) return stateToExpand;
        return newChild;
    }
    
    public int simulation(State simulatedChild)
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
            simulatedChild = new State(simulatedChild, _possibleExpansionState, moveResult, randomMove);
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


    private ArrayList tilesAfterMove(ArrayList array,HashSet<int> moveSet)
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