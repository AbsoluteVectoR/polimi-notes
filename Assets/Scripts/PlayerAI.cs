using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player
    {
        private bool _computing;
        private bool _computed;
        private Queue bestMove;
        private PlayerStats _stats;
        
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
                _computing = true;
                StartCoroutine(oracle.computeBestMove(this,gameMan.maximumScore(),tiles, sumDices));
            }
        }

        public void takeAdvice(HashSet<int> bestMove)
        {
            this.bestMove = new Queue();
            foreach (int tile in bestMove)
            {
                this.bestMove.Enqueue(tile);
            }
            _computing = false;
            _computed = true;
        }
        
        public override int returnTileTestBench()
        {
            if (_computing) return 0;
            if (_computed) //when computed playerAI knows which are the best moves and play them 
            {
                var tileToSelect = (int) bestMove.Dequeue();
                if (bestMove.Count == 0) _computed = false; //my turn has finished
                tiles.Remove(tileToSelect);
                return tileToSelect;
            }
            else
            {
                mcts oracle = new mcts();
                var sumDices = remainingValue;
                _computing = true;
                StartCoroutine(oracle.computeBestMove(this,gameMan.maximumScore(),tiles, sumDices));
                return 0;
            }
        }
        
        public override ArrayList GetTiles()
        {
            return tiles;
        }

        public override PlayerStats returnStats()
        {
            return _stats;
        }

        public override void increaseWins()
        {
            _stats.win();
        }

        public override void newScore(int newScore)
        {
            _stats.newScore(newScore);
        }
        
        public override void keepStatistics()
        {
            _stats = new PlayerStats();
        }
        
    }

