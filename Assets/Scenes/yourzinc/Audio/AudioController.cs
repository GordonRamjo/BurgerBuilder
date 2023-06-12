using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;

    public bool BGM = false;
    public bool PATTY = false;
    public bool CUSTMER_ANGRY = false;
    public bool SIREN = false;
    public bool GRAB = false;
    public bool DROP = false;
    public bool TRASH = false;
    public bool WALKING = false;

    public enum Sfx { PATTY, CUSTMER_ANGRY, SIREN, GRAB, DROP, TRASH, WALKING };

    // Start is called before the first frame update
    void Start()
    {
        BGM = true;
        // SFX
        for (int i = 0; i <= 6; i++)
            sfxPlayer[i].clip = sfxClip[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (BGM)
        {
            BGM = false;
            bgmPlayer.Play(); // BGM
        }
        if (PATTY)
        {
            PATTY = false;
            SfxPlay(AudioController.Sfx.PATTY);
        }
        if (CUSTMER_ANGRY)
        {
            CUSTMER_ANGRY = false;
            SfxPlay(AudioController.Sfx.CUSTMER_ANGRY);
        }
        if (SIREN)
        {
            SIREN = false;
            SfxPlay(AudioController.Sfx.SIREN);
        }
        if (GRAB)
        {
            GRAB = false;
            SfxPlay(AudioController.Sfx.GRAB);
        }
        if (DROP)
        {
            DROP = false;
            SfxPlay(AudioController.Sfx.DROP);
        }
        if (TRASH)
        {
            TRASH = false;
            SfxPlay(AudioController.Sfx.TRASH);
        }
        if (WALKING)
        {
            WALKING = false;
            SfxPlay(AudioController.Sfx.WALKING);
        }
    }

    public void SfxPlay(Sfx type)
    {
        Debug.Log("Play " + type);
        sfxPlayer[(int) type].Play();
    }

    private void SfxStop(Sfx type)
    {
        Debug.Log("Stop " + type);
        sfxPlayer[(int)type].Stop();
    }

    public void StopPatty()
    {
        SfxStop(Sfx.PATTY);
    }

}
