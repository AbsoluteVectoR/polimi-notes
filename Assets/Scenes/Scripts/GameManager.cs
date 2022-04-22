using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.WSA;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DiceLauncher launcher;
    public float seatDistance;
    public float diceLaunchDistance;
    public int numPlayers = 4;
    public GameObject player;
    public float seatHeight;
    public List<GameObject> players;
    public GameObject currentPlayer;
    private int _sumValue;
    private int _sumSelectedTiles;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        players = new List<GameObject>(numPlayers);
        //main player
        var posTiles = new Vector3(0, seatHeight, -seatDistance);
        players.Add(Instantiate(player, posTiles, Quaternion.identity));
        
        //left player
        if (numPlayers == 4)
        {
            posTiles = new Vector3(-seatDistance, seatHeight, 0);
            players.Add(Instantiate(player, posTiles, Quaternion.LookRotation(-posTiles)));
        }
        //front player 
        posTiles = new Vector3(0, seatHeight, seatDistance);
        players.Add(Instantiate(player, posTiles, Quaternion.LookRotation(-posTiles)));
        
        //right player 
        if (numPlayers == 4)
        {
            posTiles = new Vector3(seatDistance, seatHeight, 0);
            players.Add(Instantiate(player, posTiles, Quaternion.LookRotation(-posTiles)));
        }

        launcher = this.GetComponent<DiceLauncher>();
        currentPlayer = players[0];
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
        ArrayList selectableTiles = ComputeSelectable(currentPlayer.GetComponent<Player>().getTiles());
        if (selectableTiles.Count > 0)
        {
            currentPlayer.GetComponent<Player>().SetPlayerSelectables(selectableTiles);
        }
        else if(_sumSelectedTiles == _sumValue)
        {
            _sumSelectedTiles = 0;
            nextPlayer();
        }
        else
        {
            Debug.Log("KO");
        }
    }

    private void nextPlayer()
    {
        int currentIndex = players.IndexOf(currentPlayer);
        if (currentIndex != numPlayers - 1)
            currentPlayer = players[currentIndex + 1];
        else
            currentPlayer = players[0];
        
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

        foreach (int i in array)
        {
            Debug.Log(i);
        }
        
        return array;
    }
    
}