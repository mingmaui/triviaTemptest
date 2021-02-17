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

    private float countDown;

    private void GameStart() {
        instance = this;
    }

    private void TimerSet(){
        timeCounter.text = "25.00";
    }

    public void TimerStart(){
        timerActive = true;
        countDown = 5f;

        StartCoroutine(TimerGoing());
    }

    public void TimerEnd(){
        timerActive = false;

        //temporaryGameOver
        GameObject.FindWithTag("gameTag").SetActive(false);
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