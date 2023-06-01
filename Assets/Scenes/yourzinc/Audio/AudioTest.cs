using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    AudioController audioController;
    public bool PATTY = false;
    public bool CUSTMER_ANGRY = false;
    public bool SIREN = false; 
    public bool GRAB = false;
    public bool DROP = false;
    public bool TRASH = false;
    public bool WALKING = false;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PATTY)  {
            PATTY = false;
            audioController.SfxPlay(AudioController.Sfx.PATTY);
        }
        if (CUSTMER_ANGRY)
        {
            CUSTMER_ANGRY = false;
            audioController.SfxPlay(AudioController.Sfx.CUSTMER_ANGRY);
        }
        if (SIREN)
        {
            SIREN = false;
            audioController.SfxPlay(AudioController.Sfx.SIREN);
        }
        if (GRAB)
        {
            GRAB = false;
            audioController.SfxPlay(AudioController.Sfx.GRAB);
        }
        if (DROP)
        {
            DROP = false;
            audioController.SfxPlay(AudioController.Sfx.DROP);
        }
        if (TRASH)
        {
            TRASH = false;
            audioController.SfxPlay(AudioController.Sfx.TRASH);
        }
        if (WALKING)
        {
            WALKING = false;
            audioController.SfxPlay(AudioController.Sfx.WALKING);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Click Detected");
        audioController.SfxPlay(AudioController.Sfx.PATTY);
    }
}
