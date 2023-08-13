using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private EnemyManager enemyManager;
    private PlayerMovement player;
    [SerializeField] GameObject uiManager;
    
    private int score;
    private int YFloorPosition;
    private int XFloorPosition;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.uiManager);
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        //GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //NewGame();
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
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
    }
    
    public void AddScore()
    {

    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
