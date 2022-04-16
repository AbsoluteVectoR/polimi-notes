using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject tile;
    private ArrayList _tiles;
    private GameObject[] _tilesObj;
    private ArrayList _selectableTiles;
    private int _sumValue;
    public int _sumSelectedTiles;
    public int numOfTiles = 9;
    public float tileBreadth = 3f;
    void Start()
    {
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

    }


    public bool FlipTile(int number)
    {
        if (_selectableTiles.Contains(number))
        {
            _tiles.Remove(number);
            _sumSelectedTiles += number;
            _selectableTiles = ComputeSelectable(_tiles);
            return true;
        }
        return false;
    }

    public void setSum(int sum)
    {
        _sumValue = sum;
        _sumSelectedTiles = 0;
        _selectableTiles = ComputeSelectable(_tiles);
    }
    
    private ArrayList ComputeSelectable(ArrayList arraySelectable)
    {
        var tmp = arraySelectable;
        var array = new ArrayList();

        if (tmp.Contains(_sumValue - _sumSelectedTiles)) array.Add(_sumValue - _sumSelectedTiles);
        for(int i = 1; i<=(_sumValue-i);i++)
        {
            if (!tmp.Contains(i)) continue;
            if (i + _sumSelectedTiles == _sumValue) if (!array.Contains(i)) array.Add(i);
            for (var x = i + 1; x <= (_sumValue-i); x++)
            {
                if (!tmp.Contains(x)) continue;
                if (i + x + _sumSelectedTiles == _sumValue)
                {
                    if (!array.Contains(x)) array.Add(x);
                    if (!array.Contains(i)) array.Add(i);
                }
                else
                {
                    for (var y = x + 1; y <= (_sumValue - y); y++)
                    {
                        if (!tmp.Contains(y)) continue;
                        if (i + x + y + _sumSelectedTiles != _sumValue) continue;
                        if (!array.Contains(x)) array.Add(x);
                        if (!array.Contains(i)) array.Add(i);
                        if (!array.Contains(y)) array.Add(y);
                    }
                }
            }
        }

        if (array.Count != 0) return array;
        if (_sumSelectedTiles == _sumValue)
        {
            Debug.Log("OK");
            //selected = true;
        }
        else
        {
            Debug.Log("ko");
        }
        return array;
    }
}