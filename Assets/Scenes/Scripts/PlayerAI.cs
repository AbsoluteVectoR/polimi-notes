using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAI : Player
    {
        private bool _computing;
        private bool _computed;
        private Queue bestMove;
    
    
        private void Update()
        {
            if (!selectEnabled) return; //selectEnabled is true when the Game Manager receive the result of the dices from the DicesLauncher 
            if (_computing) return;
            if (_computed) //when computed playerAI knows which are the best moves and play them 
            {
                int tileToSelect = (int) bestMove.Dequeue();
                tilesObj[tileToSelect-1].GetComponent<Tile>().Flip();
                if (bestMove.Count == 0) _computed = false; //my turn has finished
            }
            else
            {
                mcts oracle = new mcts();
                var sumDices = remainingValue;
                StartCoroutine(oracle.computeBestMove(this,gameMan.maximumScore(),tiles, sumDices));
                _computing = true;
            }
        }

        public void takeAdvice(HashSet<int> bestMove)
        {
            this.bestMove = new Queue();
            foreach (int tile in bestMove)
            {
                this.bestMove.Enqueue(tile);
                Debug.Log(tile);
            }
            _computing = false;
            _computed = true;
        }
    
    }

