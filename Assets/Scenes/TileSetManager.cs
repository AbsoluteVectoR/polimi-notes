using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileSetManager : MonoBehaviour
{
    public bool[] tiles;
    private GameObject[] tilesObj;
    public GameObject tile;
    void Start()
    {
        tiles = new bool[9];
        tilesObj = new GameObject[9];
        for (int i = 1; i <= 9; i++)
        {
            Vector3 tilePos = new Vector3(this.transform.position.x + i * 3.3f, this.transform.position.y,
                this.transform.position.z);
            tilesObj[i-1] = Instantiate(tile, tilePos, Quaternion.identity);
            tilesObj[i-1].GetComponent<Transform>().Rotate(45f,0f,0f);
            tiles[i - 1] = false;
            tilesObj[i-1].GetComponent<Tile>().SetTextNum(i);
        }
    }

    
}
