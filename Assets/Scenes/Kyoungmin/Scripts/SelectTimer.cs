using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTimer : MonoBehaviour
{
    public static bool selectTimer;
    // Start is called before the first frame update
    void Start()
    {
        selectTimer = false;
    }
    public void Timer()
    {
        selectTimer = true;
    }

}
