using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private EnemyManager enemyManager;
    private PlayerMovement player;
    [SerializeField] UiManager uiManager;
    
    private int score;
    private int YFloorPosition;
    private int XFloorPosition;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.uiManager.gameObject);
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        //GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //NewGame();
        SceneManager.LoadScene(0);
    }
    public void NewFloorPosition(int x,int y)
    {
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        XFloorPosition = x;
        YFloorPosition = y;
        enemyManager.EnemySpawn( x, y);
    }

    public void PlayerTakeDamage(int damage)
    {
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        player.takeDamage(damage);
        uiManager.UpdatePlayerHelath(player.GetPlayerHealth());
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        uiManager.NewGame();
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        ResetGame();
    }
    
    public void AddScore(int _score)
    {
        score += _score;
        uiManager.UpdateScore(score);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
        uiManager.GamOver();
    }
    private void ResetGame()
    {
        score = 0;
        player.SetPlayerHealth();
    }
}
