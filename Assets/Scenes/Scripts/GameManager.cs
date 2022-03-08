using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DiceLauncher dlauncher;
    public float SeatDistance;
    private float SeatHeight;
    public enum statetype
    {
        TurnPlayer1 = 1,
        TurnPlayer2 = 2, 
        TurnPlayer3 = 3,
        TurnPlayer4 = 4
    }

    public statetype state;

    private void Start()
    {
        SeatHeight = SeatDistance;
        dlauncher = DiceLauncher.instance;
        state = statetype.TurnPlayer1;
    }

    void Update()
    {
        
        switch(state)
        {
            case statetype.TurnPlayer1:
                dlauncher.transform.position = new Vector3(0, SeatHeight, -SeatDistance);
                break;
            case statetype.TurnPlayer2:
                dlauncher.transform.position = new Vector3(-SeatDistance, SeatHeight, 0);
                break;
            case statetype.TurnPlayer3:
                dlauncher.transform.position = new Vector3(0, SeatHeight, SeatDistance);
                break;
            case statetype.TurnPlayer4:
                dlauncher.transform.position = new Vector3(SeatDistance, SeatHeight, 0);
                break;
            
        }
    }
}
