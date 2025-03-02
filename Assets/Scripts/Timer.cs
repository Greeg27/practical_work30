using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int seconds;
    [SerializeField] TMP_Text timer;
    [SerializeField] GameObject timerOverPanel;

    private int _seconds;

    public void Start()
    {
        _seconds = seconds;
        TimerPrint();
        Time.timeScale = 1;
        StartCoroutine(TimerCountdown());
    }

    IEnumerator TimerCountdown()
    {
        while (_seconds > 0)
        {
            yield return new WaitForSeconds(1);

            _seconds -= 1;
            TimerPrint();
        }
        Time.timeScale = 0;
        timerOverPanel.SetActive(true);
    }

    private void TimerPrint()
    {
        timer.text = TimeSpan.FromSeconds(_seconds).ToString();
    }
}
