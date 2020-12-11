using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayHighscore : MonoBehaviour
{
    [System.Serializable]
    public struct UserScore
    {
        public Text username;
        public Text score;
    }
    public UserScore[] Score;
    HighScore highScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Score.Length; i++)
        {
            Score[i].score.text = "Fetching...";
        }

        highScoreManager = GetComponent<HighScore>();
        StartCoroutine(RefreshHighscore());
        
    }
    public void OnHighscoresDownloaded(Highscore[] highscorelist)
    {
        for (int i = 0; i < Score.Length; i++)
        {
            if (i >= highscorelist.Length) break;
            if (highscorelist.Length > 0)
            {
                Score[i].username.text = (i + 1) + "." + highScoreManager.highscoresList[i].username;
                Score[i].score.text = highScoreManager.highscoresList[i].score.ToString();
            }
        }
    }
    IEnumerator RefreshHighscore()
    {
        while(true)
        {
            highScoreManager.DownloadHighscore();
            yield return new WaitForSeconds(30);
        }
    }
}
