using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameMaster gm;

    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.respawnPoint = transform.position;
    }
}
