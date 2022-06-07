using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameMan;
    public GameObject tile;
    public int numOfTiles = 9;
    public float tileBreadth = 3f;
    private int score;
    private string username = "HumanPlayer";
    private ArrayList _tiles;
    protected GameObject[] _tilesObj;
    protected ArrayList _selectableTiles;
    protected int _remainingValue;
    protected bool selectEnabled;
    


    public void startPlaying(GameManager gameMan, int numOfTiles, string username){
        score = 99;
        this.gameMan = gameMan;
        this.numOfTiles = numOfTiles;
        this.username = username;
        _tiles = new ArrayList(numOfTiles);
        _tilesObj = new GameObject[numOfTiles];
        InstantiateTiles();
    }

    protected void InstantiateTiles()
    {
        float offset = (1.1f * (numOfTiles + 1) * tileBreadth) / 2f;
        for (int i = 1; i <= numOfTiles; i++)
        {
            Vector3 tilePos = transform.position + transform.right * (i * 1.1f * tileBreadth - offset);
            _tiles.Add(i);
            _tilesObj[i - 1] = Instantiate(tile, tilePos, transform.rotation);
            _tilesObj[i - 1].GetComponent<Transform>().Rotate(40f, 0f, 0f);
            _tilesObj[i - 1].GetComponent<Tile>().SetTextNum(i);
            _tilesObj[i - 1].GetComponent<Tile>().setOwner(this);
            StartCoroutine(_tilesObj[i - 1].GetComponent<Tile>().spawningAnimation()); //cool tile intro animation
        }
        _selectableTiles = new ArrayList();
        selectEnabled = false;
    }
    
    public void TileSelected(int number)
    {
        gameMan.SelectTile(number);
        _tiles.Remove(number);
    }

    public void SetPlayerSelectables(ArrayList selectableTiles, int remainingValue)
    {
        _remainingValue = remainingValue;
        _selectableTiles = selectableTiles;
    }

    public void EnableSelect(bool v)
    {
        selectEnabled = v;
    }

    public bool IsSelecting()
    {
        return selectEnabled;
    }

    public ArrayList GetTiles()
    {
        return _tiles;
    }

    public ArrayList GetSelectableTiles()
    {
        return _selectableTiles;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
    
    public int GetScore()
    {
        return score;
    }

    
    public string GetUsername()
    {
        return username;
    }
}