using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    StageManager stageManager;
    public float limitTime;
    public TMP_Text timerText;
    int min;
    float sec;
    // Start is called before the first frame update

    private void Awake()
    {
        min = (int)limitTime / 60;
        sec = limitTime % 60;
        timerText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stageManager.isTimeOver)
        {
            if (limitTime > 0)
            {
                limitTime -= Time.deltaTime;
                min = (int)limitTime / 60;
                sec = limitTime % 60;
                timerText.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
            }
            else
            {
                
                stageManager.isTimeOver = true;
                timerText.text = string.Format("00:00");
                Debug.Log("TIME OVER");
            }
        }
        
    }
}
