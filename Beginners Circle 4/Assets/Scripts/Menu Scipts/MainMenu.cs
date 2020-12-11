using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static float MouseSensitivity = 50f;
    public static float BGMVolume = 1f;
    public static float SEVolume = 1f;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        BGMVolume = volume;
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
    public void SetSEVolume(float volume)
    {
        audioMixer.SetFloat("SEVolume", Mathf.Log10(volume) * 20);
        SEVolume = volume;
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
    public void SetMouseSensitivity(float sensitivity)
    {
        MouseSensitivity = sensitivity;
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
    public void QuitGame()
    {
        Application.Quit();
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
}