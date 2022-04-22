using System.Collections;
using System.ComponentModel.Design.Serialization;
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
    void Start()
    {
        gameMan = GameManager.Instance;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        _tiles = new ArrayList(numOfTiles);
        _tilesObj = new GameObject[numOfTiles];
        float offset = (1.1f*(numOfTiles+1)*tileBreadth) / 2f;
        for (int i = 1; i <= numOfTiles; i++)
        {
            var tr = this.transform.position;
            Vector3 tilePos = tr + this.transform.right * (i * 1.1f * tileBreadth - offset);
            //Vector3 tilePos = new Vector3(tr.x + i * 1.1f*tileBreadth - offset, tr.y,
            //  tr.z); 
            
            _tiles.Add(i); 
            _tilesObj[i - 1] = Instantiate(tile, tilePos, this.transform.rotation );
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
        selectEnabled = false;
        return true;
    }

    public void SetPlayerSelectables(ArrayList selectableTiles)
    {
        selectEnabled = true;
        _selectableTiles = selectableTiles;
    }

    public ArrayList getTiles()
    {
        return _tiles;
    }
    
}