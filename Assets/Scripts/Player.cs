using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameMan;
    public GameObject tile;
    public int numOfTiles;
    public float tileBreadth = 3f;
    private int score;
    private string username = "HumanPlayer";
    protected ArrayList tiles;
    protected GameObject[] tilesObj;
    protected ArrayList selectableTiles;
    protected int remainingValue;
    protected bool selectEnabled;

    public void startPlaying(GameManager gameManager, int numberOfTiles, string userName,bool testingMatch){
        score = 99;
        this.gameMan = gameManager;
        this.numOfTiles = numberOfTiles;
        this.username = userName;
        tiles = new ArrayList(numberOfTiles);
        tilesObj = new GameObject[numberOfTiles];
        InstantiateTiles(testingMatch);
    }

    protected void InstantiateTiles(bool isTesting)
    {
        float offset = (1.1f * (numOfTiles + 1) * tileBreadth) / 2f;
        for (int i = 1; i <= numOfTiles; i++)
        {
            if (!isTesting) // in the TestBench this is not necessary
            {
                Vector3 tilePos = transform.position + transform.right * (i * 1.1f * tileBreadth - offset);
                tilesObj[i - 1] = Instantiate(tile, tilePos, transform.rotation);
                tilesObj[i - 1].GetComponent<Transform>().Rotate(40f, 0f, 0f);
                tilesObj[i - 1].GetComponent<Tile>().SetTextNum(i);
                tilesObj[i - 1].GetComponent<Tile>().setOwner(this);
                StartCoroutine(tilesObj[i - 1].GetComponent<Tile>().spawningAnimation()); //cool tile intro animation
            }
            tiles.Add(i);
        }
        selectableTiles = new ArrayList();
        selectEnabled = false;
    }
    
    public void TileSelected(int number)
    {
        tiles.Remove(number);
        gameMan.SelectTile(number);
    }

    public void SetPlayerSelectables(ArrayList selectableTiles,int remainingValue)
    {
        this.remainingValue = remainingValue;
        this.selectableTiles = selectableTiles;
    }

    public void EnableSelect(bool v)
    {
        selectEnabled = v;
    }

    public bool IsSelecting()
    {
        return selectEnabled;
    }

    public virtual ArrayList GetTiles()
    {
        return tiles;
    }

    public ArrayList GetSelectableTiles()
    {
        return selectableTiles;
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

    public virtual int returnTileTestBench()
    {
        return -1;
    }

    public virtual PlayerStats returnStats()
    {
        return null;
    }

    public virtual void increaseWins()
    {
        return;
    }

    public virtual void updateScoreStatistics(int newScore)
    {
        return;
    }

    public virtual void keepStatistics()
    {
        return;
    }
    
}