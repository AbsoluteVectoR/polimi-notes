using System.Collections.Generic;

    public class PlayerAI : Player
    {
        private bool _computing;
        private bool _computed;
        private Queue<int> bestMove;
    
    
        private void Update()
        {
            if (!selectEnabled) return; //selectEnabled is true when the Game Manager receive the result of the dices from the DicesLauncher 
            if (_computing) return;
            if (_computed) //when computed playerAI knows which are the best moves and play them 
            {
                var tileToSelect = (int)selectableTiles[0]; //at the moment select the first tile in the selectable tiles, that is computed by GameManager 
                    tilesObj[tileToSelect-1].GetComponent<Tile>().Flip();
            }
            else
            {
                mcts oracle = new mcts();
                var sumDices = remainingValue;
                StartCoroutine(oracle.computeBestMove(this,gameMan.maximumScore(),tiles, sumDices));
                _computing = true;
            }
        }

        public void takeAdvice()
        {
            _computing = false;
            _computed = true;
        }
    
    }

