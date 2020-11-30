using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
    //Code for manage score
	const string privateCode = "cwCNAGZIjUyL9nvU1oMmhwMtmj-pcVlU6mKPYnApOCCA";
	const string publicCode = "5fc33615eb36fd27140bd60e";
    //Scoreboard webURL
	const string webURL = "http://dreamlo.com/lb/";
    //Highscore data array
	public Highscore[] highscoresList;
    static HighScore instance;
    //
    DisplayHighscore displayHighscore;
	private void Awake()
    {
        instance = this;
        displayHighscore = GetComponent<DisplayHighscore>();
	}
    /// <summary>
    /// Add new score
    /// </summary>
    /// <param name="username">User's name</param>
    /// <param name="score">User's score</param>
	public static void AddNewHighscore(string username, int score)
	{
		instance.StartCoroutine(instance.UploadHighScore(username, score));
	}
    /// <summary>
    /// Add username and score to database
    /// </summary>
    /// <param name="username">name of the user</param>
    /// <param name="score">user's score</param>
    /// <returns></returns>
	IEnumerator UploadHighScore(string username, int score)
	{
		UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
		yield return www.SendWebRequest();
        
        if (string.IsNullOrEmpty(www.error))
        { 
            print("Upload Successful");
            DownloadHighscore();
        }
		else
        {
            print("Upload Error" + www.error);
        }
	}
	public void DownloadHighscore()
	{
		StartCoroutine(DownloadHighScoreFromDatabase());
	}
	IEnumerator DownloadHighScoreFromDatabase()
	{
		UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/pipe/");
		www.downloadHandler = new DownloadHandlerBuffer();
		yield return www.SendWebRequest();
        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscore(www.downloadHandler.text);
            displayHighscore.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Upload Error" + www.error);
        }
	}
	void FormatHighscore(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		for(int i = 0; i < entries.Length; ++i)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
#if UNITY_EDITOR
            print(highscoresList[i].username + ":" + highscoresList[i].score);
#endif
        }
	}
}
public struct Highscore
{
	public string username;
	public int score;
	public Highscore(string _username,int _score)
	{
		username = _username;
		score = _score;
	}
}