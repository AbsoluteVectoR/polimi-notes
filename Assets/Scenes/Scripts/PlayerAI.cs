using System;
using System.Collections;
using UnityEngine;

public class PlayerAI : Player
{
    void Start()
    {
        score = 9999;
        gameMan = GameManager.Instance;
        numOfTiles = gameMan.numOfTiles;
        _tiles = new ArrayList(numOfTiles);
        _tilesObj = new GameObject[numOfTiles];
        InstantiateTiles();
    }
    
    private void Update()
    {
        if (!selectEnabled) return;
        var tileToSelect = (int)_selectableTiles[0];
        _tilesObj[tileToSelect-1].GetComponent<Tile>().Flip();
    }
}
