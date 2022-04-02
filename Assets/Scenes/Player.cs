using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject tile;
    private ArrayList tiles;
    private GameObject[] tilesObj;
    
    void Start()
    {
        tiles = new ArrayList(9);
        tilesObj = new GameObject[9];
        for (int i = 1; i <= 9; i++)
        {
            Vector3 tilePos = new Vector3(this.transform.position.x + i * 3.3f, this.transform.position.y,
                this.transform.position.z);
            tiles.Add(i);
            tilesObj[i-1] = Instantiate(tile, tilePos, Quaternion.identity);
            tilesObj[i-1].GetComponent<Transform>().Rotate(45f,0f,0f);
            tilesObj[i-1].GetComponent<Tile>().SetTextNum(i);
        }
    }


    public void FlipTile(int number)
    {
        tiles.Remove(number);
        tilesObj[number-1].GetComponent<Tile>().FlipTile();
    }

    
}
