using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    StageManager stageManager;
    public float limitTime;
    // Start is called before the first frame update

    private void Awake()
    {
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
                Debug.Log("남은 시간 : " + Mathf.Round(limitTime));
            }
            else
            {
                
                stageManager.isTimeOver = true;
                Debug.Log("TIME OVER");
            }
        }
        
    }
}
