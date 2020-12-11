using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public static BGMusic bgMusic;

    private void Awake()
    {
        {
            if (bgMusic != null && bgMusic != this)
            {
                Destroy(this.gameObject);
                return;
            }

            bgMusic = this;
            DontDestroyOnLoad(this);
        }
    }
}
