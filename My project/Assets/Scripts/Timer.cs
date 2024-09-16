using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour

{
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
                Debug.Log("Perfect");
            }
            else if (currentTime > 1 && currentTime <= 2.5)
            {
                Debug.Log("Good");
            }
            else if (currentTime >= 3.5 && currentTime < 5)
            {
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("Miss");
            }
        }
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