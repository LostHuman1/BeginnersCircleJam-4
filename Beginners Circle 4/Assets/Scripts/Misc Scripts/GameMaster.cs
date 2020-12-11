using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector3 respawnPoint;
    public bool isRespawning = false;
    public bool isEndGame = false;

    [SerializeField] private GameData gameData;
    private int levelNum = 0;
    private int nowScore = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (transform.position.y < -70)
        {
            Respawn();

            
        }
        UpdateScore();
        if(isEndGame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void UpdateScore()
    {
        if (gameData.maxScore[levelNum] <= 0) return;
        gameData.maxScore[levelNum] -= Time.deltaTime;
        nowScore = (int)gameData.maxScore[levelNum];
    }
    public float GetTime()
    {
        return gameData.maxTime[levelNum];
    }

    public int GetScore()
    {
        return nowScore;
    }
    public void Respawn()
    {
        this.transform.position = respawnPoint;
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
