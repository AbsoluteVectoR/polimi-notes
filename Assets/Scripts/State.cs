using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;

public class State 
{
    private float _ucb;
    private readonly ArrayList _tiles;
    private readonly State _parent;
    private readonly List<State> _children;
    private readonly HashSet<int> _played;
    private int _simulations;
    private int _allTimeScores;
    private readonly Hashtable _unexpandedChildren;
    private int _sumDices;

    public State(State parent, ArrayList tiles, HashSet<int> played, int sumDices)
    {
        _sumDices = sumDices;
        _parent = parent;
        _ucb = float.MaxValue;
        _tiles = tiles;
        _played = played;
        _simulations = 0;
        _allTimeScores = 0;
        _children = new List<State>();
        _unexpandedChildren = new Hashtable();
        for (int i = 2; i <= 12; i++)
        {
            _unexpandedChildren.Add(i,new ArrayList()); 
        }
    }

    public int getSumDices()
    {
        return _sumDices;
    }
    
    public bool isFullExpanded()
    {
        if (_tiles.Count == 0) return true;

        if (_unexpandedChildren.Count > 0) return false; 
        
        return true;
    }

    public void newExpandedLaunch(int launchDices, ArrayList possibleMoves)
    {
        if (possibleMoves.Count > 0)
        {
            _unexpandedChildren[launchDices]=possibleMoves;
        }
        else
        {
            _unexpandedChildren.Remove(launchDices);
        }
    }

    public void newExpandedMove(int launchDices, HashSet<int> expandedMove)
    {
        var arrayOfPossibleMoves = (ArrayList)_unexpandedChildren[launchDices];
        arrayOfPossibleMoves.Remove(expandedMove);
        if (arrayOfPossibleMoves.Count == 0) _unexpandedChildren.Remove(launchDices);
    }
    
    public Hashtable returnUnexpandedLaunches()
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

    public void setUcb(float newUcb)
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
