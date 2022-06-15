using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scenes.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using static System.String;
using Random = UnityEngine.Random;


public class TestBench : GameManager
{
    private List<Player> _playing;
    private List<Player> _out;
    private Player _current;
    public int numOfRandomPlayers = 4;
    public int numOfAi = 4;

    public void Start()
    {
        numPlayers = numOfRandomPlayers + numOfAi; 
        
        _playing = new List<Player>(numPlayers);
        _out = new List<Player>();

        for (int i = 0; i < numPlayers; i++)
        {
            Player p = null;
            if (i < numOfRandomPlayers)
            {
                GameObject newPlayer = new GameObject("Random");
                p = newPlayer.AddComponent<PlayerRandom>();
                _playing.Add(p);   
            }
            else
            {
                GameObject newPlayer = new GameObject("AI");
                p = newPlayer.AddComponent<PlayerAI>();
                _playing.Add(p);  
            }
            p.keepStatistics();
            p.startPlaying(this, numOfTiles, "testbench",true);
        }

        _out = new List<Player>();
        _current = _playing[Random.Range(0, _playing.Count)];
        StartCoroutine(bench());
    }


    private IEnumerator bench()
    {
        int numberMatches = 100;
        sumValue = Random.Range(1, 6) + Random.Range(1, 6);
        while (numberMatches > 0)
        {
            while (_playing.Count>0)
            {
                while(sumSelectedTiles<sumValue)
                {
                    var playersAlive = _playing.Count();
                    UpdatingPlayerTiles(); //this is also responsible to playerChange and gameover
                    sumSelectedTiles = 0;
                    if (playersAlive != _playing.Count()) break; // player lose!
                    int selected = 0;
                    while (selected == 0)
                    {
                        //Debug.Log(_current);
                        sumValue = Random.Range(1, 6) + Random.Range(1, 6); //random launch
                        yield return new WaitForSeconds(0.1f);
                        selected = _current.returnTileTestBench();
                        if (selected != 0)
                        {
                            Debug.Log( _current.GetType() + " played "+selected);
                        }
                    }
                    sumSelectedTiles += selected;
                }
            }
            Debug.Log("FINISHED");
            foreach (var p in _out)
            {
                Debug.Log(p.GetType() + "won "+p.returnStats().getRatioWins()*100 +" % of total matches");
                Debug.Log(" with average score of "+ p.returnStats().getAverageScore());
            }
            numberMatches--;
            _playing = _out;
            _out = new List<Player>();
            foreach (var p in _playing)
            {
                p.startPlaying(this,numOfTiles,"test",true);
            }
            _current = _playing[Random.Range(0, _playing.Count)];
        }
    }

    private void UpdatingPlayerTiles()
    {
        ArrayList selectableTiles = LegalMoves.compute(_current.GetComponent<Player>().GetTiles(), sumValue, sumSelectedTiles);
        if (selectableTiles.Count > 0)
        {
            _current.GetComponent<Player>().SetPlayerSelectables(selectableTiles,sumValue-sumSelectedTiles);
        }
        else if (sumSelectedTiles == sumValue) //the player have selected all the tiles necessary to reach the dices sum, he ended his turn
        {
            sumSelectedTiles = 0;
            if (_current.GetComponent<Player>().GetTiles().Count == 0) //Check in case of immediate win
            {
                var allPlayers = _playing;
                foreach (var p in allPlayers) PlayerGameOver(p); //immediate win, immediate Game Over for everyone
            }
            else
            {
                if(_playing.Count>0)ChangePlayer();
            }
        }
        else //the player hasn't enough tiles to reach the dices sum, game over for the player
        {
            var deletedPlayer = _current;
            if (_playing.Count - 1 > 0) ChangePlayer();
            PlayerGameOver(deletedPlayer);
        }
    }
    
    private void PlayerGameOver(Player eliminatedPlayer)
    {
        var score = 0;
        var tiles = eliminatedPlayer.GetTiles();
        foreach (int number in tiles) score += number; //counting the score
        score = sum(numOfTiles) - score;
        eliminatedPlayer.SetScore(score);
        eliminatedPlayer.newScore(score);
        _playing.Remove(eliminatedPlayer);
        _out.Add(eliminatedPlayer);
        Debug.Log(eliminatedPlayer.GetType() + " game over with score: " + eliminatedPlayer.GetScore());
        if (_playing.Count == 0) GameOver();
    }

    private void GameOver()
    {
        Player winner = _out[0];
        foreach (Player p in _out)
        {
            var playerScore = p.GetScore();
            var winnerScore = winner.GetScore();
            if (playerScore > winnerScore)
            {
                winner = p;
            }
        }
        winner.increaseWins();
    }

    private void ChangePlayer()
    {
        int currentIndex = _playing.IndexOf(_current);
        _current = _playing[(currentIndex + 1)%(_playing.Count)]; //circular array
    }
    

}