using System;
using System.Collections;
using UnityEngine;

public class PlayerAI : Player
{
    private void Update()
    {
        if (!selectEnabled) return; //selectEnabled is true when the Game Manager receive the result of the dices from the DicesLauncher 
        var tileToSelect = (int)_selectableTiles[0]; //at the moment select the first tile in the selectable tiles, that is computed by GameManager
        _tilesObj[tileToSelect-1].GetComponent<Tile>().Flip(); 
    }
}
