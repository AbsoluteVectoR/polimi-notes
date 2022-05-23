using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject leftPlayerName;
    public GameObject leftPlayerScore;
    public GameObject rightPlayerName;
    public GameObject rightPlayerScore;
    public GameObject humanPlayerName;
     public GameObject humanPlayerScore;
    public GameObject upPlayerName;
    public GameObject upPlayerScore;
   
    public GameObject gameManObj;
    private ArrayList names;
    private ArrayList scores; 

    public void Start(){
        names = new ArrayList();
        scores = new ArrayList();
        names.Add(leftPlayerName);
        names.Add(rightPlayerName);
        names.Add(upPlayerName);
        names.Add(humanPlayerName);
        scores.Add(leftPlayerScore);
        scores.Add(rightPlayerScore);
        scores.Add(upPlayerScore);
        scores.Add(humanPlayerScore);
        scoreHider();
    }

    private void scoreHider(){
        foreach(GameObject score in scores){
            var text = score.GetComponent<TextMeshProUGUI>();
            if(text.text.Equals("99"))text.alpha = 0f;
             else text.alpha=1f;  
        }
    }

    public void startMatch(){
        var gameMan = gameManObj.GetComponent<GameManager>();
           humanPlayerName.GetComponent<TextMeshProUGUI>().text=gameMan.getHumanNickname();
           if(gameMan.getNumOfPlayers()==2)
            {
                leftPlayerName.SetActive(false);
                rightPlayerName.SetActive(false);
            }
    }
}
