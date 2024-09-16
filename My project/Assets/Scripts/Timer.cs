using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour

{
    [Header("Score Text")]
    public TextMeshProUGUI scoreText;
    public int score = 0;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundrethsDecimal, "0.00");
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentTime > 2.5 && currentTime < 3.5)
            {
                Add300();
                Debug.Log("Perfect");
            }
            else if (currentTime > 1 && currentTime <= 2.5)
            {
                Add100();
                Debug.Log("Good");
            }
            else if (currentTime >= 3.5 && currentTime < 5)
            {
                Add100();
                Debug.Log("Good");
            }
            else
            {
                Add30();
                Debug.Log("Okay");
            }
        }
    }
    public void Add300()
    {
        score += 150;
        scoreText.text = score.ToString();
    }

    public void Add100()
    {
        score += 50;
        scoreText.text = score.ToString();
    }

    public void Add30()
    {
        score += 15;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = 0;
            SetTimerText();
            //currentTime = timerLimit;
            //timerText.color = Color.red;
            //enabled = false;
        }

        SetTimerText();
    }

    

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }

}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}