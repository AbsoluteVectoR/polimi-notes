using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DiceLauncher dlauncher;
    public float seatDistance;
    public float diceLaunchDistance;
    public int numPlayers = 4;
    public GameObject player;
    private float _seatHeight;
    private ArrayList _players;

    public enum statetype
    {
        menu = 0,
        pickingupDices = 1,
        rolling = 2,
        checkingDicesSum = 3,
        choosingTiles = 4,
        nextPlayer = 5,
        gameOver = 6
    }

    public statetype state;

    private void Start()
    {
        _seatHeight = 6;
        dlauncher = DiceLauncher.instance;
        state = statetype.menu;
        _players = new ArrayList(numPlayers);
        //main player
        var mainP = 
            Instantiate(player, new Vector3(0, _seatHeight, -seatDistance), Quaternion.identity);
        _players.Add(mainP);
        //left player
        if (numPlayers == 4)
        {
            var leftP =
                Instantiate(player, new Vector3(-seatDistance, _seatHeight, 0), Quaternion.identity);
            _players.Add(leftP);
        }
        //front player 
        var frontP = 
            Instantiate(player, new Vector3(0, _seatHeight, seatDistance), Quaternion.identity);
        _players.Add(frontP);
        
        //right player 
        if (numPlayers == 4)
        {
            var rightP = 
                Instantiate(player, new Vector3(seatDistance, _seatHeight, 0), Quaternion.identity);
            _players.Add(rightP);
        }
    }
}