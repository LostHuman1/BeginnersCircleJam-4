using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static float MouseSensitivity = 15f;
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
