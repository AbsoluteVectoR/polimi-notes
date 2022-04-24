using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application = UnityEngine.Application;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DiceLauncher launcher;
    public float seatDistance;
    public float diceLaunchDistance;
    public int numPlayers = 4;
    public int numOfTiles = 12;
    public GameObject player;
    public GameObject AIplayer;
    public float seatHeight;
    public List<GameObject> playersPlaying;
    public List<GameObject> playersOut;
    public GameObject currentPlayer;
    private int _sumValue;
    private int _sumSelectedTiles;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        
        playersPlaying = new List<GameObject>(numPlayers);
        
        //main player
        var posTiles = new Vector3(0, seatHeight, -seatDistance);
        playersPlaying.Add(Instantiate(player, posTiles, Quaternion.identity));
        
        //left player
        if (numPlayers == 4)
        {
            posTiles = new Vector3(-seatDistance, seatHeight, 0);
            playersPlaying.Add(Instantiate(AIplayer, posTiles, Quaternion.LookRotation(-posTiles)));
        }
        //front player 
        posTiles = new Vector3(0, seatHeight, seatDistance);
        playersPlaying.Add(Instantiate(AIplayer, posTiles, Quaternion.LookRotation(-posTiles)));
        
        //right player 
        if (numPlayers == 4)
        {
            posTiles = new Vector3(seatDistance, seatHeight, 0);
            playersPlaying.Add(Instantiate(AIplayer, posTiles, Quaternion.LookRotation(-posTiles)));
        }

        launcher = this.GetComponent<DiceLauncher>();
        currentPlayer = playersPlaying[0];
        launcher.launcherTransform = currentPlayer.transform;
        launcher.enabled = true;
        launcher.turnStart();
    }


    public void DicesStopped(int sum)
    {
        _sumValue = sum;
        UpdatingPlayerTiles();
    }
    
    private void UpdatingPlayerTiles()
    {
        ArrayList selectableTiles = ComputeSelectable(currentPlayer.GetComponent<Player>().GetTiles());
        if (selectableTiles.Count > 0)
        {
            currentPlayer.GetComponent<Player>().EnableSelect(true);
            currentPlayer.GetComponent<Player>().SetPlayerSelectables(selectableTiles);
        }
        else if(_sumSelectedTiles == _sumValue)
        {
            _sumSelectedTiles = 0;
            currentPlayer.GetComponent<Player>().EnableSelect(false);
            if (currentPlayer.GetComponent<Player>().GetTiles().Count == 0)
            {
                playersOut.Add(currentPlayer); //immediate win
                currentPlayer.GetComponent<Player>().SetScore(0);
                GameOver();
            }
            ChangePlayer();
        }
        else
        {
            currentPlayer.GetComponent<Player>().EnableSelect(false);
            PlayerGameOver(); 
        }
    }


    public void PlayerGameOver()
    {
        var eliminatedPlayer = currentPlayer;
        int score = 0;
        var tiles = eliminatedPlayer.GetComponent<Player>().GetTiles();
        foreach (int number in tiles) score += number;
        Debug.Log("KO, score: "+ score);
        if (playersPlaying.Count - 1 > 0)
        {
            ChangePlayer();
            playersPlaying.Remove(eliminatedPlayer);
            playersOut.Add(eliminatedPlayer);
        }
        else
        {
            playersPlaying.Remove(eliminatedPlayer);
            playersOut.Add(eliminatedPlayer);
            GameOver();
        }
    }

    private void GameOver()
    {
        GameObject winner = playersOut[0];
        foreach (GameObject player in playersOut)
        {
            var playerScore = player.GetComponent<Player>().GetScore();
            var winnerScore = winner.GetComponent<Player>().GetScore();
            if (playerScore < winnerScore)
            {
                winner = player;
            }
            else if(playerScore == winnerScore && player.GetComponent<Player>().nickname != winner.GetComponent<Player>().nickname)
            {
                Debug.Log("There is a tie! No winners!");
                return;
            }
        }
        
        Debug.Log("Our compliments to "+ winner.GetComponent<Player>().nickname+ " !");
    }
    
    private void ChangePlayer()
    {
        int currentIndex = playersPlaying.IndexOf(currentPlayer);
        if (currentIndex != playersPlaying.Count-1)
            currentPlayer = playersPlaying[currentIndex + 1];
        else
            currentPlayer = playersPlaying[0];
        
        launcher.launcherPosition = currentPlayer.transform.position;
        launcher.launcherTransform = currentPlayer.transform;
        launcher.enabled = true;
        launcher.turnStart();
    }
    
    public void SelectTile(int selectedTile)
    {
        _sumSelectedTiles += selectedTile;
        UpdatingPlayerTiles();
    }
    
    private ArrayList ComputeSelectable(ArrayList currentTiles)
    {
        var tmp = currentTiles;
        var array = new ArrayList();

        if (tmp.Contains(_sumValue - _sumSelectedTiles)) array.Add(_sumValue - _sumSelectedTiles);
        for(int i = 1; i<=(_sumValue-i);i++)
        {
            if (!tmp.Contains(i)) continue;
            if (i + _sumSelectedTiles == _sumValue) if (!array.Contains(i)) array.Add(i);
            for (var x = i + 1; x <= (_sumValue-i); x++)
            {
                if (!tmp.Contains(x)) continue;
                if (i + x + _sumSelectedTiles == _sumValue)
                {
                    if (!array.Contains(x)) array.Add(x);
                    if (!array.Contains(i)) array.Add(i);
                }
                else
                {
                    for (var y = x + 1; y <= (_sumValue - y); y++)
                    {
                        if (!tmp.Contains(y)) continue;
                        if (i + x + y + _sumSelectedTiles != _sumValue) continue;
                        if (!array.Contains(x)) array.Add(x);
                        if (!array.Contains(i)) array.Add(i);
                        if (!array.Contains(y)) array.Add(y);
                    }
                }
            }
        }
        return array;
    }
    
}