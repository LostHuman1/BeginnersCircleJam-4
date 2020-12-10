using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector3 lastCheckPoint;

    [SerializeField] private GameData gameData;
    private int levelNum = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);    
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
}
