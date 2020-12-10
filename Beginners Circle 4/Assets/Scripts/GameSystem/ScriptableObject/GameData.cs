using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/GameData")]
public class GameData : ScriptableObject
{
    [Range(0, 180)]
    [Tooltip("Time limit per level")]
    public float[] maxTime;
    [Tooltip("Max score per level")]
    public float[] maxScore;
}
