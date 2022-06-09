
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class GameManager : MonoBehaviour
{
    public DiceLauncher launcher;
    public float seatDistance;
    public float seatHeight;
    public GameObject player;
    [FormerlySerializedAs("AIplayer")] public GameObject aiPlayer;
    public GameObject menuUI;
    public GameObject inGameUI;
    public string humanUsername;
    private int _numPlayers;
    private int _numOfTiles = 12;
    private List<GameObject> _playersPlaying;
    private List<GameObject> _playersOut;
    private GameObject _currentPlayer;
    private int _sumValue;
    private int _sumSelectedTiles;

    public void Awake()
    {
        launcher = this.GetComponent<DiceLauncher>();
    }

    public void StartGame()
    {
        _playersPlaying = new List<GameObject>(_numPlayers);
        _playersOut = new List<GameObject>();
        //main player
        var posTiles = new Vector3(0, seatHeight, -seatDistance);
        var humanPlayer = Instantiate(player, posTiles, Quaternion.identity);
        humanPlayer.GetComponent<Player>().startPlaying(this, _numOfTiles, humanUsername);
        _playersPlaying.Add(humanPlayer);


        //left player
        if (_numPlayers == 4)
        {
            posTiles = new Vector3(-seatDistance, seatHeight, 0);
            var leftPlayer = Instantiate(aiPlayer, posTiles, Quaternion.LookRotation(-posTiles));
            leftPlayer.GetComponent<PlayerAI>().startPlaying(this, _numOfTiles, "Monte");
            _playersPlaying.Add(leftPlayer);
        }

        //front player 
        posTiles = new Vector3(0, seatHeight, seatDistance);
        var frontPlayer = Instantiate(aiPlayer, posTiles, Quaternion.LookRotation(-posTiles));
        frontPlayer.GetComponent<PlayerAI>().startPlaying(this, _numOfTiles, "Carlo");
        _playersPlaying.Add(frontPlayer);

        //right player 
        if (_numPlayers == 4)
        {
            posTiles = new Vector3(seatDistance, seatHeight, 0);
            var rightPlayer = Instantiate(aiPlayer, posTiles, Quaternion.LookRotation(-posTiles));
            rightPlayer.GetComponent<PlayerAI>().startPlaying(this, _numOfTiles, "Sir Tree");
            _playersPlaying.Add(rightPlayer);
        }
        
        _currentPlayer = _playersPlaying[0];
        this.transform.position = _currentPlayer.transform.position;
        this.transform.rotation = _currentPlayer.transform.rotation;
        StartCoroutine(launcher.turnStart(3f));
    }
    
    public void DicesStopped(int sum)
    {
        _sumValue = sum;
        UpdatingPlayerTiles();
    }

    private void UpdatingPlayerTiles()
    {
        ArrayList selectableTiles = legalMoves.compute(_currentPlayer.GetComponent<Player>().GetTiles(), _sumValue, _sumSelectedTiles);
        if (selectableTiles.Count > 0)
        {
            _currentPlayer.GetComponent<Player>().EnableSelect(true);
            _currentPlayer.GetComponent<Player>().SetPlayerSelectables(selectableTiles,_sumValue,_sumSelectedTiles);
        }
        else if (_sumSelectedTiles == _sumValue) //the player have selected all the tiles necessary to reach the dices sum, he ended his turn
        {
            _sumSelectedTiles = 0;
            _currentPlayer.GetComponent<Player>().EnableSelect(false);
            if (_currentPlayer.GetComponent<Player>().GetTiles().Count == 0) //Check in case of immediate win
            {
                var allPlayers = _playersPlaying;
                foreach (GameObject p in allPlayers) PlayerGameOver(p); //immediate win, immediate Game Over for everyone
            }
            else
            {
                if(_playersPlaying.Count>0)ChangePlayer();
            }
        }
        else //the player hasn't enough tiles to reach the dices sum, game over for the player
        {
            _currentPlayer.GetComponent<Player>().EnableSelect(false);
            PlayerGameOver(_currentPlayer);
            if(_playersPlaying.Count>0)ChangePlayer();
        }
    }
    
    private void PlayerGameOver(GameObject eliminatedPlayer)
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
        GameObject winner = _playersOut[0];
        foreach (GameObject p in _playersOut)
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
        if (currentIndex != _playersPlaying.Count - 1) //circular array 
            _currentPlayer = _playersPlaying[currentIndex + 1];
        else
            _currentPlayer = _playersPlaying[0];

        launcher.transform.position = _currentPlayer.transform.position;
        launcher.transform.rotation = _currentPlayer.transform.rotation;
        launcher.enabled = true;
        StartCoroutine(launcher.turnStart(0.5f));
    }

    public void SelectTile(int selectedTile)
    {
        _sumSelectedTiles += selectedTile;
        UpdatingPlayerTiles();
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
}