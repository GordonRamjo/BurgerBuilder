using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "patty")
        {
            Debug.Log("Start Patty Bake");
            other.gameObject.GetComponent<PattyController>().isStart = true;
            other.gameObject.GetComponent<PattyController>().isBaking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "patty")
        {
            Debug.Log("Stop Patty Bake");
            other.gameObject.GetComponent<PattyController>().isBaking = false;
            Debug.Log("IsBacking : false");
        }
    }
}
