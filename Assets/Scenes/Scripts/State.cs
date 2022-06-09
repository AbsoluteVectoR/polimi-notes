using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class State 
{
    private float _UCB;
    private readonly ArrayList _tiles;
    private State _parent;
    private List<State> _childrens; // We could replace it with priority queue <- at the end 
    private readonly int _remainingValue;
    private int _played;
    private int _visits;
    private int _allTimeScores;
    
    public State(State parent,ArrayList tiles, int remainingValue, int played)
    {
        _parent = parent;
        _UCB = 0f;
        _tiles = tiles;
        _remainingValue = remainingValue;
        _played = played;
        _visits = 0;
        _allTimeScores = 0;
        _childrens = new List<State>(); 
    }

    public void incrementVisits()
    {
        _visits++;
    }

    public void incrementScore(int addedScore)
    {
        _allTimeScores += addedScore;
    }

    public float getUcb()
    {
        return _UCB;
    }

    public void setUcb(float newUCB)
    {
        _UCB = newUCB;
    }

    public int getAllTimeScore()
    {
        return _allTimeScores;
    }

    public int getVisits()
    {
        return _visits;
    }

    public int getRemainingValue()
    {
        return _remainingValue;
    }

    public List<State> getChildren()
    {
        return _childrens;
    }

    public State getParent()
    {
        return _parent;
    }

    public ArrayList getTiles()
    {
        return _tiles;
    }

    public int getPlayed()
    {
        return _played;
    }
    
}
