using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandom : Player
{
    private bool _computing;
    private bool _computed;
    private Queue bestMove;

    public override int returnTileTestBench()
    {
        var selected = (int)selectableTiles[Random.Range(0, selectableTiles.Count)];
        tiles.Remove(selected);
        return selected; //selectable tiles is set by TestBench
    }
    
    
}