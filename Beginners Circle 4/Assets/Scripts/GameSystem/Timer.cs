using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private float oldseconds;
    private float seconds;
    private float minutes;
    // Start is called before the first frame update
    void Start()
    {
        oldseconds = 0f;
        seconds = 0f;
        minutes = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60f)
        {
            minutes += 1;
            seconds -= 60f;
        }
        if ((int)seconds != (int)oldseconds)
        {
            timeText.text = minutes.ToString("00")+ ":" + seconds.ToString("00");
        }
        oldseconds = seconds;
    }
}
