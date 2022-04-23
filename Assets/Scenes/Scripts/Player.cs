using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameMan;
    public GameObject tile;
    public int numOfTiles = 9;
    public float tileBreadth = 3f;
    private ArrayList _tiles;
    private GameObject[] _tilesObj;
    private ArrayList _selectableTiles;
    public bool selectEnabled;
    public int score;
    public String nickname = "HumanPlayer";
    void Start()
    {
        score = 9999;
        gameMan = GameManager.Instance;
        numOfTiles = gameMan.numOfTiles;
        _tiles = new ArrayList(numOfTiles);
        _tilesObj = new GameObject[numOfTiles];
        float offset = (1.1f * (numOfTiles + 1) * tileBreadth) / 2f;
        for (int i = 1; i <= numOfTiles; i++)
        {
            var tr = this.transform.position;
            Vector3 tilePos = tr + this.transform.right * (i * 1.1f * tileBreadth - offset);
            _tiles.Add(i);
            _tilesObj[i - 1] = Instantiate(tile, tilePos, this.transform.rotation);
            _tilesObj[i - 1].GetComponent<Transform>().Rotate(45f, 0f, 0f);
            _tilesObj[i - 1].GetComponent<Tile>().SetTextNum(i);
            _tilesObj[i - 1].GetComponent<Tile>().setOwner(this);
        }
        _selectableTiles = new ArrayList();
        selectEnabled = false;
    }

    public bool FlipTile(int number)
    {
        if (!_selectableTiles.Contains(number) || !selectEnabled) return false;
        _tiles.Remove(number);
        gameMan.SelectTile(number);
        return true;
    }

    public void SetPlayerSelectables(ArrayList selectableTiles)
    {
        _selectableTiles = selectableTiles;
    }

    public void EnableSelect(bool v)
    {
        selectEnabled = v;
    }

    public ArrayList GetTiles()
    {
        return _tiles;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
    
    public int GetScore()
    {
        return score;
    }
}