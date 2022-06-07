using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class mcts : MonoBehaviour
{
    private ArrayList _selectableTiles;
    private int _remainingValue;
    private List<State> _tree;
    private int _allTimeSimulations;
    private const float C = 1.4142135624f; //sqrt(2) 
    private int _maximumScore;
    private PlayerAI _caller;

    public IEnumerator computeBestMove(PlayerAI caller,ArrayList selectableTiles, int remainingValue,int maximumScore)
    {
        _caller = caller;
        yield return new WaitForSeconds(3f);
        _selectableTiles = selectableTiles;
        _remainingValue = remainingValue;
        _maximumScore = maximumScore;
        buildStateSpace();
        ArrayList bestMove = selectableTiles;
        //selection
        //expansion
        //simulation
        //backpropagation
        adviceBestMove(bestMove);
    }

    private int randomLaunch()
    {
        int valueDices = (int)Random.Range(1f, 6.99f);
        valueDices += (int)Random.Range(1f, 6.99f);
        return valueDices;
    }

    private void buildStateSpace()
    {
        Debug.Log(_maximumScore);
        _tree = new List<State>();
        foreach (var legalMove in _selectableTiles)
        {
            State s = new State(_selectableTiles, _remainingValue);
            _tree.Add(s);
        }
    }

    public float UCB(int allTimeScore, int visits, int parentVisits)
    {
        if (visits == 0 || parentVisits == 0) return 0f;
        float ucb = (float)(allTimeScore / (_maximumScore * visits) + C * Math.Sqrt(Math.Log(parentVisits) / visits));
        return ucb;
    }


    private void adviceBestMove(ArrayList bestMove)
    {
        _caller.takeAdvice(bestMove);
    }
}
