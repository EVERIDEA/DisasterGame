using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarManager : MonoBehaviour
{
    public Image fillImg;
    float timeAmt = 120;
    float time;

    private void Start()
    {
        Time.timeScale = 1;
        time = timeAmt;
    }

    
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            fillImg.fillAmount = time / timeAmt;
            Global.Timer = time;
            Global.Duration = timeAmt;
        }
        else
        {
            time = 0;
            EventManager.TriggerEvent(new ResultEvents());
            Global.Timer = time;
            Global.Duration = timeAmt; 
        }
    }
}
