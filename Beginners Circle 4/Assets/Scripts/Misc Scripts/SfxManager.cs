using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip buttonPress;
    public AudioClip checkpoint;
    public AudioClip jump;
    public AudioClip running;
    public AudioClip youDied;

    public static SfxManager sfxMusic;

    private void Awake()
    {
        {
            if (sfxMusic != null && sfxMusic != this)
            {
                Destroy(this.gameObject);
                return;
            }

            sfxMusic = this;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}