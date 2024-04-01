using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int scoreKing;
    public int scorePig;
    public int winScore=100;
    public TMP_Text uIScoreKing;
    public TMP_Text uIScorePig;
    public TMP_Text uIWinTextCont;
    public GameObject uIWinLose;

    public Animator camAnimator;

    public static GameManager instance;
    public SceneManagement sceneManagement;
    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }


    public void Score(string sideWallName)
    {
        if (sideWallName == "SideWallKing")
        {
            scorePig += 10;
            uIScorePig.text = scorePig.ToString();
            ScoreCheck();
            camAnimator.SetTrigger("goShake");
        } 
        else 
        {
            scoreKing += 10;
            uIScoreKing.text = scoreKing.ToString();
            ScoreCheck();
            camAnimator.SetTrigger("goShake");
        }
    }

    private void Delay()
    {
        sceneManagement.ChangeScene("Menu");
    }
    private void ScoreCheck()
    {
        if (scoreKing == winScore) 
        {
            uIWinLose.SetActive(true);
            uIWinTextCont.text = "King Win!";
            Invoke("Delay",2.0f);
        }
        else if (scorePig == winScore)
        {
            uIWinLose.SetActive(true);
            uIWinTextCont.text = "Pig Win!";
            Invoke("Delay",2.0f);
        }
        
    }

}
