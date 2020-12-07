using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static float MouseSensitivity = 50f;
    public static float Volume = 1f;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("BGVolume", Mathf.Log10(volume)*20);
        Volume = volume;
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
