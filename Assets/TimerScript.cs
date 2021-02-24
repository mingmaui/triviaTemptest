using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections.Generic;


public class TimerScript: MonoBehaviour
{
    public TimerScript instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerActive;
    public TriviaScript ts;

    private float countDown;

    void Start(){
        TimerStart();
    }

    private void GameStart() {
        instance = this;
    }

    private void TimerSet(){
        timeCounter.text = "23.00";
    }

    public void TimerStart(){
        timerActive = true;
        countDown = 23f;

        StartCoroutine(TimerGoing());
    }

    public void TimerEnd(){
        timerActive = false;
        ts.showScore();
    }

    private IEnumerator TimerGoing(){
        
        while (timerActive)
        {
            countDown -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(countDown);
            string timePlayingStr = timePlaying.ToString("ss'.'ff");
            timeCounter.text = timePlayingStr;

            if(countDown < 0)
            {
                TimerEnd();
            }

            yield return null;
        }
    }
}