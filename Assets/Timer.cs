using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public float timeRemaining = 120;
    public bool timeIsRunning;
    public GameObject DeathUI;
    // Start is called before the first frame update
    void Start()
    {
        
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                DeathUI.SetActive(true);   
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);   
        float seonds = Mathf.FloorToInt(timeToDisplay % 60);   
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seonds);
    }
}
