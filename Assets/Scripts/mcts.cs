using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class mcts
{
    private const float C = 1.41f; //sqrt(2) for ucb 
    private int _maximumScore;
    private PlayerAI _caller;
    private ArrayList _tilesRoot;
    private State root;

    //compute best move only when there is at least one move
    public IEnumerator computeBestMove(PlayerAI caller, int mctsIterations, int maximumScore, ArrayList tilesRoot, int sumDices){
        _maximumScore = maximumScore;
        root = new State(null, tilesRoot, null);
        for(int i = 2; i<=12;i++)root.expandPlay(i); //it's not necessary for the root node exploring alternatives dice launches 

        //generate children root
        var possibleMoves = LegalMoves.computeSets(tilesRoot, sumDices);
        var bestMove = (HashSet<int>)possibleMoves[0]; 
        
        if (possibleMoves.Count > 1){
            foreach (HashSet<int> possibleMove in possibleMoves)
            {
                var newChild = new State(root, tilesAfterPlay(tilesRoot,possibleMove), possibleMove);
                root.addChild(newChild);
            }

            while (root.getSimulations() < mctsIterations)
            {
                var selected = selection(root);
                var expanded = expansion(selected);
                var simulated = simulation(expanded);
                backup(simulated);
                if (root.getSimulations() % 2000 == 0)
                {
                    Debug.Log("");
                    yield return null;
                }
            }
            
            float highestWinRate = -1f;
            foreach (State child in root.getChildren())
            {
                var winRate = computeWinRate(child);
                if (winRate > highestWinRate)
                {
                    highestWinRate = winRate;
                    bestMove = child.getPlayed();
                }
            }
            Debug.Log("Win rate of selected move: "+highestWinRate);
        }
        
        caller.takeAdvice(bestMove);
    }

    private State selection(State state)
    {
        var selected = state;
        while (selected.isFullExpanded()&&selected.getChildren().Count>0) selected = findBestChild(selected);
        return selected;
    }
    private State expansion(State state)
    {
        if (state.isFullExpanded()) return state;
        
        var randomPlay = (int)state.getUnexpandedPlays()[Random.Range(0, state.getUnexpandedPlays().Count)];
        state.expandPlay(randomPlay);
        var possibleMoves = LegalMoves.computeSets(state.getTiles(), randomPlay);
        if (possibleMoves.Count == 0) return state;
        var childrenToSimulate = new ArrayList();
        foreach (HashSet<int> possibleMove in possibleMoves)
        {
            var newChild = new State(state, tilesAfterPlay(state.getTiles(), possibleMove), possibleMove);
            state.addChild(newChild);
            childrenToSimulate.Add(newChild);
        }
        state = (State)childrenToSimulate[Random.Range(0, childrenToSimulate.Count)];
        return state;
    }
    private State simulation(State state)
    {
        int sumDices = randomLaunch();
        while (true)
        {
            var possibleMoves = LegalMoves.computeSets(state.getTiles(), sumDices);
            if (possibleMoves.Count > 0)
            {
                var randomMove = (HashSet<int>)possibleMoves[Random.Range(0, possibleMoves.Count)];
                var tilesAfterPlay = this.tilesAfterPlay(state.getTiles(), randomMove);
                state = new State(state, tilesAfterPlay, randomMove);
            }
            else return state;
        }
    }
    private void backup(State state)
    {
        var newScore = computeScore(state);
        while (state.getParent() != null)
        {
            state.addScore(newScore);
            state.increaseSimulations();
            state = state.getParent();
        }
        state.increaseSimulations();
    }
    private int computeScore(State leaf)
    {
        var score = _maximumScore;
        foreach (int tile in leaf.getTiles()) score -= tile;
        return score;
    }
    private int randomLaunch()
    {
        var dicesValue = Random.Range(1, 7);
        dicesValue+=Random.Range(1, 7);
        return dicesValue;
    }
    private State findBestChild(State state)
    {
        var maxUcb = float.MinValue;
        var bestOne = state;
        foreach (State child in state.getChildren())
        {
            var newUcb = computeUcb(child);
            if (newUcb > maxUcb)
            {
                maxUcb = newUcb;
                bestOne = child;
            }
        }

        return bestOne;
    }
    private float computeUcb(State state)
    {
        if (state.getSimulations() == 0) return float.MaxValue;
        if(state.getParent().getSimulations()==0) return float.MaxValue;
        var newWinRate = computeWinRate(state);
        var newUcb = newWinRate + 1.41f * (float)Math.Sqrt(Math.Log(state.getParent().getSimulations()) / state.getSimulations());
        state.ucb = newUcb;
        return newUcb;
    }

    private float computeWinRate(State state)
    {
        if(state.getParent().getSimulations()==0) return 0f;
        var newWinRate = (float)state.getHeritageScore() / (_maximumScore * state.getSimulations());
        state.winRate = newWinRate;
        return newWinRate;
    }
    
    private ArrayList tilesAfterPlay(ArrayList tiles, HashSet<int> move)
    {
        var tilesAfterMove = new ArrayList();
        foreach (var tile in tiles)
        {
            if (!move.Contains((int)tile)) tilesAfterMove.Add(tile);
        }
        return tilesAfterMove;
    }
    
}