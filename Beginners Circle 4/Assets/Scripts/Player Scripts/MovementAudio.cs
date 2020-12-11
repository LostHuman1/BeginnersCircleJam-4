using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAudio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.instance.Play("Running");
        }
        else
        {
            AudioManager.instance.Stop("Running");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.jump);
        }

    }
}
