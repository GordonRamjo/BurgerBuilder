using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    AudioController audioController; // ���� ����

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioController>(); // ���� ����
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
            audioController.PATTY = true;
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
            audioController.StopPatty();
        }
    }
}
