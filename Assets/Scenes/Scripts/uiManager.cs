using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiManager : MonoBehaviour
{
    public GameObject leftPlayerName;
    public GameObject leftPlayerScore;
    public GameObject rightPlayerName;
    public GameObject rightPlayerScore;
    public GameObject humanPlayerName;
    public GameObject humanPlayerScore;
    public GameObject upPlayerName;
    public GameObject upPlayerScore;
    public GameObject winnerTitle;
    public GameObject tieTitle;
    public GameObject gameManObj;
    private ArrayList names;
    private ArrayList scores; 

    public void Start(){
        winnerTitle.SetActive(false);
        tieTitle.SetActive(false);
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
            var text = score.GetComponent<TextMeshProUGUI>().text;
            var canvas = score.GetComponent<CanvasGroup>();
            if (text.Equals("99")) canvas.alpha = 0f;
            else StartCoroutine(fadeIn(canvas));
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

    public void updateScores(List<GameObject> playersOut){
        foreach(GameObject player in playersOut){
            Player playerOut = player.GetComponent<Player>();
            if (playerOut.GetUsername().Equals("Monte")){
                leftPlayerScore.GetComponent<TextMeshProUGUI>().text=playerOut.GetScore().ToString();
            }
            else if(playerOut.GetUsername().Equals("Carlo")){
                upPlayerScore.GetComponent<TextMeshProUGUI>().text=playerOut.GetScore().ToString();
            }
            else if(playerOut.GetUsername().Equals("Sir Tree")){
                upPlayerScore.GetComponent<TextMeshProUGUI>().text=playerOut.GetScore().ToString();
            }
            else{
                humanPlayerScore.GetComponent<TextMeshProUGUI>().text=playerOut.GetScore().ToString();
            }
        }
        scoreHider();
    }

    public void declareWinner(string winnerUsername)
    {
        winnerTitle.SetActive(true);
        winnerTitle.GetComponent<TextMeshProUGUI>().text = winnerTitle.GetComponent<TextMeshProUGUI>().text + winnerUsername + "!";
        StartCoroutine(fadeIn(winnerTitle.GetComponent<CanvasGroup>()));
    }
    
    public void declareTie()
    {
        tieTitle.SetActive(true);
        StartCoroutine(fadeIn(winnerTitle.GetComponent<CanvasGroup>()));
    }

    private IEnumerator fadeIn(CanvasGroup canvas){
        var opacity = 0f;
        while(opacity<=1f){
            opacity+=0.033f;
            canvas.alpha=opacity; 
            yield return new WaitForSeconds(0.01f);
        }
    }
}
