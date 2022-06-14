using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandom : Player
{
    private bool _computing;
    private bool _computed;
    private Queue bestMove;
    
    public new int returnTileTestBench()
    {
        return (int)selectableTiles[0]; //selectable tiles is set by TestBench
    }
}