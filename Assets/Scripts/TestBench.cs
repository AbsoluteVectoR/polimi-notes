
using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class TestBench : GameManager
{
    /*
    
    private int _numPlayers;
    public int _numOfTiles = 12;
    private List<Player> _playersPlaying;
    private List<Player> _playersOut;
    private Player _currentPlayer;
    private int _sumValue;
    private int _sumSelectedTiles;
    public int numOfRandomPlayers = 4;
    public int numOfAi = 4;

    public void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _numPlayers = numOfRandomPlayers + numOfAi; 
        
        _playersPlaying = new List<Player>(_numPlayers);
        _playersOut = new List<Player>();

        for (int i = 0; i < _numPlayers; i++)
        {
            Player p = null;
            if (i < numOfRandomPlayers)
            {
                GameObject newPlayer = new GameObject("Random");
                Instantiate(newPlayer, Vector3.zero, Quaternion.identity);
                p = newPlayer.AddComponent<PlayerRandom>();
                _playersPlaying.Add(p);   
            }
            else
            {
                GameObject newPlayer = new GameObject("AI");
                Instantiate(newPlayer, Vector3.zero, Quaternion.identity);
                p = newPlayer.AddComponent<PlayerAI>();
                _playersPlaying.Add(p);  
            }
            p.startPlaying(this, _numOfTiles, "testbench",true);
        }

        _playersOut = new List<Player>();

        _currentPlayer = _playersPlaying[Random.Range(0, _playersPlaying.Count)];
        
        while (_playersPlaying.Count>0)
        {
            
            _sumValue = Random.Range(1, 6) + Random.Range(1, 6);
            _sumSelectedTiles = 0;
            UpdatingPlayerTiles();
            while(_sumSelectedTiles<_sumValue)
            {
                
            }

        }
        
    }
    

    private void UpdatingPlayerTiles()
    {
        ArrayList selectableTiles = LegalMoves.compute(_currentPlayer.GetComponent<Player>().GetTiles(), _sumValue, _sumSelectedTiles);
        if (selectableTiles.Count > 0)
        {
            _currentPlayer.GetComponent<Player>().EnableSelect(true);
            _currentPlayer.GetComponent<Player>().SetPlayerSelectables(selectableTiles,_sumValue-_sumSelectedTiles);
        }
        else if (_sumSelectedTiles == _sumValue) //the player have selected all the tiles necessary to reach the dices sum, he ended his turn
        {
            _sumSelectedTiles = 0;
            if (_currentPlayer.GetComponent<Player>().GetTiles().Count == 0) //Check in case of immediate win
            {
                var allPlayers = _playersPlaying;
                foreach (var p in allPlayers) PlayerGameOver(p); //immediate win, immediate Game Over for everyone
            }
            else
            {
                if(_playersPlaying.Count>0)ChangePlayer();
            }
        }
        else //the player hasn't enough tiles to reach the dices sum, game over for the player
        {
            var deletedPlayer = _currentPlayer;
            deletedPlayer.GetComponent<Player>().EnableSelect(false);
            if(_playersPlaying.Count-1>0)ChangePlayer();
            PlayerGameOver(deletedPlayer);
        }
    }
    
    private void PlayerGameOver(Player eliminatedPlayer)
    {
        int score = 0;
        var tiles = eliminatedPlayer.GetComponent<Player>().GetTiles();
        foreach (int number in tiles) score += number; //counting the score
        score = sum(_numOfTiles) - score;
        eliminatedPlayer.GetComponent<Player>().SetScore(score);
        _playersPlaying.Remove(eliminatedPlayer);
        _playersOut.Add(eliminatedPlayer);
        if (_playersPlaying.Count == 0) GameOver();
        inGameUI.GetComponent<uiManager>().updateScores(_playersOut); //updates the scores
    }

    private void GameOver()
    {
        Player winner = _playersOut[0];
        foreach (Player p in _playersOut)
        {
            var playerScore = p.GetComponent<Player>().GetScore();
            var winnerScore = winner.GetComponent<Player>().GetScore();
            if (playerScore > winnerScore)
            {
                winner = p;
            }
            else if (playerScore == winnerScore &&
                     (p.GetComponent<Player>().GetUsername() != winner.GetComponent<Player>().GetUsername()))
            {
                inGameUI.GetComponent<uiManager>().declareTie();
                return;
            }
        }
        inGameUI.GetComponent<uiManager>().declareWinner(winner.GetComponent<Player>().GetUsername());
    }

    private void ChangePlayer()
    {
        int currentIndex = _playersPlaying.IndexOf(_currentPlayer);
        _currentPlayer = _playersPlaying[(currentIndex + 1)%(_playersPlaying.Count)]; //circular array
        launcher.transform.position = _currentPlayer.transform.position;
        launcher.transform.rotation = _currentPlayer.transform.rotation;
        launcher.enabled = true;
        StartCoroutine(launcher.turnStart(0.5f));
    }
    


    public void setNumOfPlayers(int num)
    {
        this._numPlayers = num;
    }

    public void setNumOfTiles(int num)
    {
        this._numOfTiles = num;
    }

    public void setHumanNickname(string username)
    {
        humanUsername = username;
    }

    public int getNumOfPlayers()
    {
        return _numPlayers;
    }

    public string getHumanNickname()
    {
        return humanUsername;
    }


    private static int sum(int numOfTiles)
    {
        int sum = 0;
        for (int x = 1; x <= numOfTiles; x++) sum += x;
        return sum;
    }

    public int maximumScore()
    {
        return sum(_numOfTiles);
    }

    public void newPlay()
    {
        StartCoroutine(menuUI.GetComponent<menuManager>().endPlay());
        foreach(GameObject tile in GameObject.FindGameObjectsWithTag("tile")) 
            Destroy(tile);
        foreach(GameObject p in GameObject.FindGameObjectsWithTag("Player")) 
            Destroy(p);
    }
    public void setDicesToDefaultPosition()
    {
        launcher.setDicesToDefaultPosition();
    }
    
    */
}