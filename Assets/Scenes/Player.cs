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

    void Start()
    {
        _tiles = new ArrayList(9);
        _tilesObj = new GameObject[9];
        for (int i = 1; i <= 9; i++)
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

        _tiles.Remove(5);
        _sumValue = 6;
        _sumSelectedTiles = 0;
        _selectableTiles = ComputeSelectable(_tiles);
    }


    public bool FlipTile(int number)
    {
        if (_selectableTiles.Contains(number))
        {
            _tiles.Remove(number);
            _selectableTiles = ComputeSelectable(_tiles);
            _sumSelectedTiles += number;
            return true;
        }

        return false;
    }

    private ArrayList ComputeSelectable(ArrayList arraySelectable)
    {
        ArrayList tmp = arraySelectable;
        ArrayList array = new ArrayList();
        for (int i = 0; i <= _sumValue; i++)
        {
            if (tmp.Contains(i))
            {
                //Double combination
                int possibleCouple = (i + _sumSelectedTiles);
                if (tmp.Contains(_sumValue - possibleCouple))
                {
                    if (!array.Contains(i)) array.Add(i);
                    if (!array.Contains(_sumValue - possibleCouple)) array.Add(possibleCouple);
                }
                else if (possibleCouple == _sumValue)
                {
                    if (!array.Contains(i)) array.Add(i);
                }

                //Triple combination
                for (int x = i + 1; x <= _sumValue; x++)
                {
                    if (tmp.Contains(x))
                    {
                        int possibleTriplet = (_sumSelectedTiles + i + x);
                        if (tmp.Contains(_sumValue - possibleTriplet) && possibleTriplet != i && possibleTriplet != x)
                        {
                            if (!array.Contains(i)) array.Add(i);
                            if (!array.Contains(x)) array.Add(x);
                            if (!array.Contains(_sumValue - possibleTriplet)) array.Add(_sumValue - possibleTriplet);
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