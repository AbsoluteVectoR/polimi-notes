using System;
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
    void Start()
    {
        _tiles = new ArrayList(numOfTiles);
        _tilesObj = new GameObject[numOfTiles];
        for (int i = 1; i <= numOfTiles; i++)
        {
            Transform tr = this.transform;
            Vector3 tilePos = new Vector3(tr.position.x + i * 3.3f, tr.position.y,
                tr.position.z);
            _tiles.Add(i);
            _tilesObj[i - 1] = Instantiate(tile, tilePos, Quaternion.identity);
            _tilesObj[i - 1].GetComponent<Transform>().Rotate(45f, 0f, 0f);
            _tilesObj[i - 1].GetComponent<Tile>().SetTextNum(i);
            _tilesObj[i - 1].GetComponent<Tile>().setOwner(this);
        }

        
        _sumValue = 12;
        _tiles.Remove(4);
        _tiles.Remove(5);
        _sumSelectedTiles = 0;
        _selectableTiles = ComputeSelectable(_tiles);
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

    private ArrayList ComputeSelectable(ArrayList arraySelectable)
    {
        ArrayList tmp = arraySelectable;
        ArrayList array = new ArrayList();
        Debug.Log("sum é "+ _sumSelectedTiles);
        
        if (tmp.Contains(_sumValue - _sumSelectedTiles))
        {
            array.Add(_sumValue - _sumSelectedTiles);
        }
        
        for(int i = 1; i<=(_sumValue-i);i++){
            if (tmp.Contains(i))
            {
                if (i + _sumSelectedTiles == _sumValue)
                {
                    if (!array.Contains(i)) array.Add(i);
                }
                
                for (int x = i + 1; x <= (_sumValue-i); x++)
                {
                    if (tmp.Contains(x))
                    {
                        if (i + x + _sumSelectedTiles == _sumValue)
                        {
                            if (!array.Contains(x)) array.Add(x);
                            if (!array.Contains(i)) array.Add(i);
                        }
                        else
                        {
                            for (int y = x + 1; y <= (_sumValue - y); y++)
                            {
                                if (tmp.Contains(y))
                                {
                                    if (i + x + y + _sumSelectedTiles == _sumValue)
                                    {
                                        if (!array.Contains(x)) array.Add(x);
                                        if (!array.Contains(i)) array.Add(i);
                                        if (!array.Contains(y)) array.Add(y);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            Debug.Log("ITERAZIONE NUMERO " + i);
            foreach (int numero in array)
            {
                Debug.Log(numero);
            }
            
        }
        return array;
    }
}