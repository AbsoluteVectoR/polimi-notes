using System;
using System.Collections;
using UnityEngine;

public class PlayerAI : Player
{
    
    private void Update()
    {
        if (!selectEnabled) return;
        var tileToSelect = (int)_selectableTiles[0];
        _tilesObj[tileToSelect-1].GetComponent<Tile>().Flip();
    }
}
