using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTutorialController : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    
    public enum SfxTutorial { PATTY, GRAB, DROP, WASTE, WALK, SUCCESS};

    // Start is called before the first frame update
    void Start()
    {
        // BGM
        bgmPlayer.Play();

        // SFX
        for (int i = 0; i < 6; i++)
            sfxPlayer[i].clip = sfxClip[i];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SfxPlay(SfxTutorial type)
    {
        Debug.Log("Play" + type);
        sfxPlayer[(int)type].Play();
    }
}
