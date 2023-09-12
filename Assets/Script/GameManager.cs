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
    [SerializeField] CameraMovement cameraMovement;
    
    private int score;

    public void Awake()
    {
        uiManager.StartWindow();
        player.gameObject.SetActive(false);
        cameraMovement.enabled = false;
    }
    public void NewFloorPosition(int x,int y)
    {
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        enemyManager.EnemySpawn( x, y);
    }

    public void PlayerTakeDamage(int damage)
    {
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        player.TakeDamage(damage);
        uiManager.UpdatePlayerHelath(player.GetPlayerHealth());
    }

    public void NewGame()
    {
        cameraMovement.enabled = true;
        cameraMovement.ResetState();
        uiManager.NewGame();
        player.gameObject.SetActive(true);
        floor.CreateFloor();
        player.ResetState();
        uiManager.UpdatePlayerHelath(player.GetPlayerHealth());
        score = 0;
        uiManager.UpdateScore(score);
        enemyManager.ResetState();
    }
    
    public void AddScore(int _score)
    {
        score += _score;
        uiManager.UpdateScore(score);
    }
    public void GameOver()
    {
        player.gameObject.SetActive(false);
        uiManager.GamOver();
        enemyManager.DestroyEnemies();
        floor.DestroyFloors();
        cameraMovement.enabled = false;
    }
  
    public Vector3 GetPlayerPosition()
    {
        return player.gameObject.transform.position;
    }

    
}
