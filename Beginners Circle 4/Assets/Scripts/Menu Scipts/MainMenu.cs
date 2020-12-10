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
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        BGMVolume = volume;
    }
    public void SetSEVolume(float volume)
    {
        audioMixer.SetFloat("SEVolume", Mathf.Log10(volume) * 20);
        SEVolume = volume;
    }
    public void SetMouseSensitivity(float sensitivity)
    {
        MouseSensitivity = sensitivity;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
