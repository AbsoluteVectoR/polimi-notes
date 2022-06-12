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
    private List<State> _childrens;
    private HashSet<int> _played;
    private int _visits;
    private int _allTimeScores;
    private ArrayList _unexpandedChildren;
    private bool completelyExpanded;

    public State(State parent, ArrayList possibleExpansions, ArrayList tiles, HashSet<int> played)
    {
        _parent = parent;
        _UCB = float.MaxValue;
        _tiles = tiles;
        _played = played;
        _visits = 0;
        _allTimeScores = 0;
        _childrens = new List<State>();
        _unexpandedChildren = possibleExpansions;
        completelyExpanded = false;
    }

    public bool isFullExpanded()
    {
        return completelyExpanded;
    }

    public void newExpandedChild(int expandedLaunch)
    {
        _unexpandedChildren.Remove(expandedLaunch);
        if (_unexpandedChildren.Count == 0)
        {
            completelyExpanded = true;
        }
    }

    public ArrayList returnUnexpandedLaunches()
    {
        return _unexpandedChildren;
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

    public void setUcb(float newUcb)
    {
        _UCB = newUcb;
    }

    public int getAllTimeScore()
    {
        return _allTimeScores;
    }

    public int getVisits()
    {
        return _visits;
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

    public HashSet<int> getPlayed()
    {
        return _played;
    }

    public void addChild(State newChild)
    {
        _childrens.Add(newChild);
    }
    
}
