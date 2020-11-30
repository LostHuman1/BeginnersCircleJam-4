using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetHighscore : MonoBehaviour
{
    [SerializeField] private InputField usernameInput;
    private string Name;
    /// <summary>
    /// Set username
    /// </summary>
    public void SetName()
    {
        Name = usernameInput.text;
        //HighScore.AddNewHighscore(Name, Score);
    }
    /// <summary>
    /// Clear Inputfield
    /// </summary>
    public void ClearText()
    {
        usernameInput.text = "";
    }
}
