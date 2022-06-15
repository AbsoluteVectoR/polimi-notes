using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandom : Player
{
    private bool _computing;
    private bool _computed;
    private Queue bestMove;
    private PlayerStats _stats;
    
    
    public override int returnTileTestBench()
    {
        tiles.Remove((int)selectableTiles[0]);
        return (int)selectableTiles[0]; //selectable tiles is set by TestBench
    }
    
    public override ArrayList GetTiles()
    {
        return tiles;
    }
    
    public override PlayerStats returnStats()
    {
        return _stats;
    }

    public override void increaseWins()
    {
        _stats.win();
    }

    public override void newScore(int newScore)
    {
        _stats.newScore(newScore);
    }
    
    public override void keepStatistics()
    {
        _stats = new PlayerStats();
    }
}