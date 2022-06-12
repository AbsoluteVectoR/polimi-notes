using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Scenes.Scripts;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class mcts
{
    private int _remainingValue;
    private int _allTimeSimulations;
    private const float C = 1.4142135624f; //sqrt(2) 
    private int _maximumScore;
    private PlayerAI _caller;
    private ArrayList _possibleExpansionState;

    public IEnumerator computeBestMove(PlayerAI caller, int maximumScore, ArrayList selectableTiles, int sumDices)
    {
        _caller = caller;
        yield return new WaitForSeconds(0.1f); //temporary 
        _maximumScore = maximumScore;
        _possibleExpansionState = new ArrayList();
        for (int i = 2; i <= 12; i++) _possibleExpansionState.Add(i); //'constant' arraylist needed for expansion phase

        State root = buildRootNode(selectableTiles,sumDices);
        
        var selected = selection(root,float.MinValue);
        var expanded = expansion(selected);
        var newScore = simulation(expanded);
        backpropagation(expanded,newScore);
        
        //Queue<int> bestMove = new Queue<int>();
        

        adviceBestMove();
    }

    private State buildRootNode(ArrayList selectableTiles,int sumDices)
    {
        State root = new State(null, _possibleExpansionState, selectableTiles, null);
        ArrayList legalMovesRoot = LegalMoves.computeSets(selectableTiles, sumDices);
        foreach (HashSet<int> possibleMove in legalMovesRoot)
        {
            var newChildRoot = new State(root, _possibleExpansionState, 
                tilesAfterMove(selectableTiles,possibleMove), possibleMove);
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

    private float Ucb(State state)
    {
        var allTimeScore = state.getAllTimeScore();
        var visits = state.getVisits();
        var parentVisits = 1;
        if (state.getParent() != null)
        {
            parentVisits = state.getParent().getVisits();
        }
        if (visits == 0 || parentVisits == 0) return float.MinValue;
        float ucb = (float)(allTimeScore / (_maximumScore * visits) + C * Math.Sqrt(Math.Log(parentVisits) / visits));
        return ucb;
    }
    
    private void adviceBestMove()
    {
        _caller.takeAdvice();
    }

    private State selection(State selectedState, float bestUcb)
    {
        if (selectedState.getChildren().Count > 0)
        {
            foreach (var state in selectedState.getChildren())
            {
                if (state.getUcb() >= bestUcb) selectedState = state;
            }
            return selection(selectedState,bestUcb);
        }
        return selectedState;
    }

    private State expansion(State stateToExpand)
    {
        stateToExpand.incrementVisits();
        var tiles = stateToExpand.getTiles();
        State newChild = null;
        while (!stateToExpand.isFullExpanded()) 
        {
            if (stateToExpand.getTiles().Count==0) return stateToExpand; //leaf node
            ArrayList unexpanded = stateToExpand.returnUnexpandedLaunches();
            float rangePossibleChild = unexpanded.Count + 0.9999f; 
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
        return stateToExpand;
    }
    
    public int simulation(State simulatedChild)
    {
        var tiles = simulatedChild.getTiles();
        var possibleMoves = new ArrayList();
        while (true)
        {
            var launch = randomLaunch();
            possibleMoves = LegalMoves.computeSets(simulatedChild.getTiles(), launch);
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
            expandedState.incrementVisits();
            expandedState.incrementScore(scoreLastSimulation);
            var newUcb = Ucb(expandedState);
            expandedState.setUcb(newUcb);
            expandedState = expandedState.getParent();
        }
    }


    private ArrayList tilesAfterMove(ArrayList array,HashSet<int> moveSet)
    {
        foreach (int tile in moveSet)
        {
            array.Remove(tile);
        }
        return array;
    }
}