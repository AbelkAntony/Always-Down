using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] PlayerMovement player;
    [SerializeField] UiManager uiManager;
    [SerializeField] FloorManager floor;
    
    private int score;
    private int YFloorPosition;
    private int XFloorPosition;

    public void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(this.uiManager.gameObject);
        uiManager.StartWindow();
        player.gameObject.SetActive(false);
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
        uiManager.UpdatePlayerHelath(player.GetPlayerHealth());
    }

    public void NewGame()
    {
        
        uiManager.NewGame();
        player.gameObject.SetActive(true);
        floor.CreateFloor();
        //player = GameObject.FindAnyObjectByType<PlayerMovement>();
        //enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        score = 0;
        uiManager.UpdateScore(score);
    }
    
    public void AddScore(int _score)
    {
        score += _score;
        uiManager.UpdateScore(score);
    }
    public void GameOver()
    {
        //SceneManager.LoadScene(0);
        player.gameObject.SetActive(false);
        uiManager.GamOver();
        enemyManager.DestroyEnemies();
        floor.DestroyFloors();
        
    }
  
}
