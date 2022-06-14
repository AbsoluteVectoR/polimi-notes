using System.Collections;
using System.Collections.Generic;

public class State 
{
    private double _ucb;
    private readonly ArrayList _tiles;
    private readonly State _parent;
    private readonly List<State> _children;
    private readonly HashSet<int> _played;
    private int _simulations;
    private int _allTimeScores;
    private readonly ArrayList _unexpandedChildren;

    public State(State parent, ArrayList possibleExpansions, ArrayList tiles, HashSet<int> played)
    {
        _parent = parent;
        _ucb = float.MaxValue;
        _tiles = tiles;
        _played = played;
        _simulations = 0;
        _allTimeScores = 0;
        _children = new List<State>();
        _unexpandedChildren = possibleExpansions;
    }

    public bool isFullExpanded()
    {
        return (_tiles.Count == 0 || _unexpandedChildren.Count == 0);
    }

    public void newExpandedChild(int expandedLaunch)
    {
        _unexpandedChildren.Remove(expandedLaunch);
    }

    public ArrayList returnUnexpandedLaunches()
    {
        return _unexpandedChildren;
    }
    
    public void incrementSimulations()
    {
        _simulations++;
    }
    

    public void incrementScore(int addedScore)
    {
        _allTimeScores += addedScore;
    }

    public double getUcb()
    {
        return _ucb;
    }

    public void setUcb(double newUcb)
    {
        _ucb = newUcb;
    }

    public int getAllTimeScore()
    {
        return _allTimeScores;
    }

    public int getSimulations()
    {
        return _simulations;
    }

    public List<State> getChildren()
    {
        return _children;
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
        _children.Add(newChild);
    }
    
}
