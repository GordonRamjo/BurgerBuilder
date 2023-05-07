using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PattyController : MonoBehaviour
{
    bool flag = false;
    public Patty patty;

    // Start is called before the first frame update
    void Start()
    {
        patty = new Patty();
        // Debug.Log("Start");
        // Debug.Log((Patty.State)patty.state);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log((Patty.State)patty.state);

        if (!flag)
        {
            flag = true;
            // 4초 뒤
            StartCoroutine("After4Second");
            
            // 7초 뒤
            StartCoroutine("After7Second");
        }
    }

    IEnumerator After4Second()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        // Debug.Log("After4Second");
        patty.After4Second();
        // Debug.Log((Patty.State)patty.state);
    }

    IEnumerator After7Second()
    {
        yield return new WaitForSecondsRealtime(7.0f);
        // Debug.Log("After7Second");
        patty.After7Second();
        // Debug.Log((Patty.State)patty.state);
    }
}
