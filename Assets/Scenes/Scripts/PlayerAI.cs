using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private bool _computing;
    private bool _computed;
    private ArrayList bestMove;
    private void Update()
    {
        if (!selectEnabled) return; //selectEnabled is true when the Game Manager receive the result of the dices from the DicesLauncher 
        if (_computing) return;
        if (_computed)
        {
            int tileToSelect = (int)bestMove[0];
            _tilesObj[tileToSelect-1].GetComponent<Tile>().Flip(); 
        }
        else
        {
            mcts oracle = new mcts();
            StartCoroutine(oracle.computeBestMove(this,_selectableTiles, _remainingValue, gameMan.maximumScore()));
            _computing = true;
        }
    }


    public void takeAdvice(ArrayList bestMove)
    {
        this.bestMove = bestMove;
        _computing = false;
        _computed = true;
    }
}
