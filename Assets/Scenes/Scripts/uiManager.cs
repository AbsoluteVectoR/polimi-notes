using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiManager : MonoBehaviour
{
    public GameObject titleObj;
     public GameObject inGameCanvas;
    private TextMeshProUGUI titleGUI;

    public GameObject numOfPlayerObj;
    public GameObject numOfTilesObj;

    public GameObject nicknameInput;

    private TMPro.TMP_InputField  nicknameInputField;

    public GameObject gameMan;
    private GameManager game;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        game = gameMan.GetComponent<GameManager>();
        titleGUI = titleObj.GetComponent<TextMeshProUGUI>();
        titleGUI.alpha = 1f;
        numOfPlayerObj.SetActive(false);
        numOfTilesObj.SetActive(false);
        nicknameInput.SetActive(false);
        nicknameInputField = nicknameInput.GetComponent<TMP_InputField>();
        //Start of the game
        StartCoroutine(startMenu());

       

        
    }

    private IEnumerator startMenu(){
        yield return new WaitForSeconds(0.5f);
        var opacity = 1f;
        while(opacity>=0f){
            opacity-=0.023f; 
            titleGUI.alpha=opacity; 
            yield return new WaitForSeconds(0.01f);
            }
        //starting input field
        nicknameInput.SetActive(true);
        nicknameInputField.Select();
    }


    public void inputFieldDeselected(){
     string nickname = nicknameInputField.text;
     if(!nickname.Equals("Insert nickname")&&!nickname.Equals("")){
        game.setHumanNickname(nickname);
        StartCoroutine(nicknameEntered());
     }
    }


    private IEnumerator nicknameEntered(){
        //starting input field
        nicknameInput.SetActive(false);
        yield return new WaitForEndOfFrame();
        numOfPlayerObj.SetActive(true);
    }

    public void set2PlayersButtonAction(){
        game.setNumOfPlayers(2);
        enableNumOfTiles();
    }

    public void set4PlayersButtonAction(){
        game.setNumOfPlayers(4);
        enableNumOfTiles();
    }


    private void enableNumOfTiles(){
        numOfPlayerObj.SetActive(false);
        numOfTilesObj.SetActive(true);
    }

    public void set9TilesButtonAction(){
        game.setNumOfTiles(9);
        StartCoroutine(startGame());
    }

    public void set12TilesButtonAction(){
        game.setNumOfTiles(12);
        StartCoroutine(startGame());
    }


    private IEnumerator startGame(){
        numOfTilesObj.SetActive(false);
        game.StartGame();
        yield return new WaitForSeconds(3f);
        inGameCanvas.SetActive(true);
    }

}
