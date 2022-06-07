using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public float UCB;
    private ArrayList _tiles;
    private List<State> childrens;
    private int _remaining;
    private int _visits;
    private int allTimeScores;

    public State(ArrayList tiles, int remainingValue)
    {
        
    }
    
    
}
