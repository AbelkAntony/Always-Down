using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startbutton;
    [SerializeField] GameObject gameName;
    [SerializeField] GameObject life;
    [SerializeField] TextMeshProUGUI lifeValue;
    [SerializeField] GameObject score;
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject gameOver;
    
    public void StartWindow()
    {
        
        startbutton.SetActive(true);
        gameName.SetActive(true);
        life.SetActive(false);
        lifeValue.gameObject.SetActive(false);
        score.SetActive(false);
        scoreValue.gameObject.SetActive(false);
        gameOver.SetActive(false);
    }

    public void NewGame()
    {
        startbutton.SetActive(false);
        gameName.SetActive(false);
        life.SetActive(true);
        lifeValue.gameObject.SetActive(true);
        score.SetActive(true);
        scoreValue.gameObject.SetActive(true);
        gameOver.SetActive(false);
    }
    public void GamOver()
    {
        life.SetActive(true);
        lifeValue.gameObject.SetActive(true);
        score.SetActive(true);
        scoreValue.gameObject.SetActive(true);
        gameOver.SetActive(true);
        Invoke("StartWindow", 4f);
    }

    public void UpdatePlayerHelath(int playerHealth)
    {
        lifeValue.text = playerHealth.ToString();
    }
    public void UpdateScore(int score)
    {
        scoreValue.text = score.ToString();
    }
}
