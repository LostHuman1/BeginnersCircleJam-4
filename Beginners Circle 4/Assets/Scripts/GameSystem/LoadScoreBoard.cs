using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadResultScene());
    }

    IEnumerator LoadResultScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("ResultScene");
    }
}
