using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseObj;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BGMVolumeSlider;
    [SerializeField] private Slider SEVolumeSlider;
    [SerializeField] private Slider sensitivitySlider;
    public static bool IsGamePause = false;
    private void Awake()
    {
        BGMVolumeSlider.value = MainMenu.BGMVolume;
        SEVolumeSlider.value = MainMenu.SEVolume;
        sensitivitySlider.value = MainMenu.MouseSensitivity;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (PauseObj.activeSelf) PauseObj.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsGamePause = false;
        if (!MenuPanel.activeSelf) MenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }
    void Pause()
    {
        if (!PauseObj.activeSelf) PauseObj.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        IsGamePause = true;
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }
    public void SetSEVolume(float volume)
    {
        audioMixer.SetFloat("SEVolume", Mathf.Log10(volume) * 20);
    }
    public void SetMouseSensitivity(float sensitivity)
    {
        MainMenu.MouseSensitivity = sensitivity;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayButtonSFX()
    {
        SfxManager.sfxMusic.audioSource.PlayOneShot(SfxManager.sfxMusic.buttonPress);
    }
}
