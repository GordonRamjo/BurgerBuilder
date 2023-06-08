using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTutorial : MonoBehaviour
{
    AudioTutorialController audioController;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioTutorialController>();
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
            audioController.SfxPlay(AudioTutorialController.SfxTutorial.PATTY);
            other.gameObject.GetComponent<PattyTutorialController>().isStart = true;
            other.gameObject.GetComponent<PattyTutorialController>().isBaking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "patty")
        {
            Debug.Log("Stop Patty Bake");
            audioController.SfxStop(AudioTutorialController.SfxTutorial.PATTY);
            other.gameObject.GetComponent<PattyTutorialController>().isBaking = false;
            Debug.Log("IsBacking : false");
        }
    }
}
