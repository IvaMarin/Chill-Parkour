using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour

{
    [SerializeField]private int timeRemaining = 20;
    private TextMeshProUGUI displayTime;
    private bool isTimerStarted = false;

    private Color defaultColor;

    private Color stressColor;
    // private Coroutine cr;
    private void Start()
    {
        displayTime = GetComponent<Transform>().GetChild(1).gameObject.GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>();
            // .gameObject.GetComponent<TextMeshProUGUI>();
        // Debug.Log(GetComponent<Transform>().GetChild(1).gameObject.GetComponent<Transform>().GetChild(0));
        // Debug.Log(displayTime);
        // Debug.Log(timeRemaining);

        stressColor = new Color(255, 89, 86);
        
        defaultColor = new Color(255, 223, 172);
        DisplayTime(timeRemaining);
        displayTime.overrideColorTags = true;
        displayTime.faceColor = defaultColor;
    }
    
    void Update()
    {
        if (isTimerStarted == false)
        {
            isTimerStarted = true;
            StartCoroutine(DoStep(timeRemaining));
        }
    }
    
    IEnumerator DoStep (int seconds) {
        int counter = seconds;
        DisplayTime(counter);
        while (counter > 0) {
            yield return new WaitForSeconds (1);
            counter--;
            DisplayTime(counter);
        }
        SceneManager.LoadScene("SeaPort");
    }
    
    void DisplayTime(float timeToDisplay)
    {
    //     timeToDisplay += 1;
        // Debug.Log(Color.red);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        displayTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (seconds <= 5)
        {
            if (seconds % 2 == 1)
            {
                displayTime.overrideColorTags = true;
                displayTime.faceColor = Color.red;
            }
            else
            {
                displayTime.overrideColorTags = true;
                displayTime.faceColor = stressColor;
            }
        }
    }
}

