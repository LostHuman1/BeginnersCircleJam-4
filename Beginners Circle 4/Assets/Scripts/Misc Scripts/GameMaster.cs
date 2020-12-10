using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector3 respawnPoint;
    public bool isRespawning = false;

    [SerializeField] private GameData gameData;
    private int levelNum = 0;

    private void Update()
    {
        if (transform.position.y < -70)
        {
            Respawn();
        }
    }

    void UpdateScore()
    {
        if (gameData.maxScore[levelNum] <= 0) return;
        gameData.maxScore[levelNum] -= Time.deltaTime;
    }
    public float GetTime()
    {
        return gameData.maxTime[levelNum];
    }

    public void Respawn()
    {
        this.transform.position = respawnPoint;
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
