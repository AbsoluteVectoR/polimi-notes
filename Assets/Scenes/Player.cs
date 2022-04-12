using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject tile;
    private ArrayList _tiles;
    private GameObject[] _tilesObj;
    
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
            _tilesObj[i-1] = Instantiate(tile, tilePos, Quaternion.identity);
            _tilesObj[i-1].GetComponent<Transform>().Rotate(45f,0f,0f);
            _tilesObj[i-1].GetComponent<Tile>().SetTextNum(i);
            _tilesObj[i-1].GetComponent<Tile>().setOwner(this);
        }
    }


    public bool FlipTile(int number)
    {
        if (_tiles.Contains(number))
        {
            _tiles.Remove(number);
            return true;
        }
        
        return false;
    }

    
}
