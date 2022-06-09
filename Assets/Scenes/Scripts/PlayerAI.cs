using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
{
    private bool _computing;
    private bool _computed;
    private Queue<int> bestMove;


    private void Update()
    {
        if (!selectEnabled) return;
        mcts oracle = new mcts();
        StartCoroutine(oracle.computeBestMove(this,gameMan.maximumScore(),_selectableTiles, _sumDices,_sumSelectedTiles));
        var tileToSelect = (int)_selectableTiles[0]; //at the moment select the first tile in the selectable tiles, that is computed by GameManager 
        _tilesObj[tileToSelect-1].GetComponent<Tile>().Flip();
    }

    /*
    private void Update()
    {
        if (!selectEnabled) return; //selectEnabled is true when the Game Manager receive the result of the dices from the DicesLauncher 
        if (_computing) return;
        if (_computed) //when computed playerAI knows which are the best moves and play them 
        {
            int tileToSelect = bestMove.Dequeue();
            _tilesObj[tileToSelect-1].GetComponent<Tile>().Flip();
            if (bestMove.Count == 0) _computed = false; //end of turn
        }
        else
        {
            mcts oracle = new mcts();
            StartCoroutine(oracle.computeBestMove(this,gameMan.maximumScore(),_selectableTiles, _sumDices,_sumSelectedTiles));
            _computing = true;
        }
    }
*/

    public void takeAdvice(Queue<int> bestMove)
    {
        this.bestMove = bestMove;
        _computing = false;
        _computed = true;
    }
    
}
