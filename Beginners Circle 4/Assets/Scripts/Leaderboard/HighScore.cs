using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
	const string privateCode = "cwCNAGZIjUyL9nvU1oMmhwMtmj-pcVlU6mKPYnApOCCA";
	const string publicCode = "5fc33615eb36fd27140bd60e";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;

	private void Awake()
	{
		AddNewHighscore("Kan", 50);
		AddNewHighscore("Katy", 40);
		AddNewHighscore("Kain", 30);
		DownloadHighscore();
	}
	public void AddNewHighscore(string username, int score)
	{
		StartCoroutine(UploadHighScore(username, score));
	}
	IEnumerator UploadHighScore(string username, int score)
	{
		UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
		yield return www.SendWebRequest();
		if (string.IsNullOrEmpty(www.error))
			print("Upload Successful");
		else
			print("Upload Error" + www.error);
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
			FormatHighscore(www.downloadHandler.text);
		else
			print("Upload Error" + www.error);
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
			print(highscoresList[i].username + ":" + highscoresList[i].score);
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