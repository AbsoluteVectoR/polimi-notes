using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrategy : Player
{
    private bool _computing;
    private bool _computed;
    private Queue bestMove;


    public override int returnTileTestBench()
    {
        var selected = (int)selectableTiles[0]; 
        tiles.Remove(selected);
        return selected; //selectable tiles is set by TestBench
    }
    
    
    
    
    
    
}