using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private float maxTime;
    private float seconds;
    private float minutes;
    // Start is called before the first frame update
    void Start()
    {
        seconds = 0f;
        minutes = 0f;
        maxTime = GameMaster.instance.GetTime();
    }

    // Update is called once per frame
    void Update()
    {
        maxTime -= Time.deltaTime;
        DisplayTime(maxTime);
    }
    void DisplayTime(float time)
    {
        time += 1;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
