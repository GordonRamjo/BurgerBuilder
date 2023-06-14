using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioLobbyController : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;

    public bool BGM = false;
    public bool StageButton = false;
    public bool EnterButton = false;
    public bool LockButton = false;
    public bool StageClear = false;
    public bool StageFail = false;
    public bool BBB = false;


    public enum Sfx { StageButton, EnterButton, LockButton, StageClear, StageFail, BBB};

    // Start is called before the first frame update
    void Start()
    {
        // SFX
        for (int i = 0; i < 6; i++)
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
        if (StageButton)
        {
            StageButton = false;
            SfxPlay(Sfx.StageButton);
        }
        if (EnterButton)
        {
            EnterButton = false;
            SfxPlay(Sfx.EnterButton);
        }
        if (LockButton)
        {
            LockButton = false;
            SfxPlay(Sfx.LockButton);
        }
        if (StageClear)
        {
            StageClear = false;
            SfxPlay(Sfx.StageClear);
        }
        if (StageFail)
        {
            StageFail = false;
            SfxPlay(Sfx.StageFail);
        }
        if (BBB)
        {
            BBB = false;
            SfxPlay(Sfx.BBB);
        }
    }

    public void SfxPlay(Sfx type)
    {
        Debug.Log("Play " + type);
        sfxPlayer[(int) type].Play();
    }

}
