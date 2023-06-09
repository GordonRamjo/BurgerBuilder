using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
    public GameObject GameResult;
    public TextMeshProUGUI resultText;
    //public TextMeshProUGUI result;
    private string Success1 = "Good job!\r\nYou are a Good\r\nBurger Builder!";
    private string Success2 = "Excellent!\r\nNow you are the\r\nBest Burger Builder!";
    private string Fail = "Oh no!\r\nYou've failed to be a\r\nBurger Builder!";
    
    
    public AudioClip ClearSound;
    public AudioClip FailSound;
    AudioSource audioSource;
    
    public GameObject replay_btn;
    public GameObject back2lobby_btn;
    public int stageNumber;


    // Start is called before the first frame update
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        //GameResult.transform.LeanScale
        GameResult.SetActive(false);
    }

    // Update is called once per frame
    public void Open(int stageNumber, bool isClear)
    {
        string result;
        AudioClip resultSound;

        if (isClear && stageNumber == 1)
        {
            result = Success1;
            audioSource.clip = ClearSound;
        }
        else if (isClear && stageNumber == 2)
        {
            result = Success2;
            audioSource.clip = ClearSound;
        }
        else
        {
            result = Fail;
            audioSource.clip = FailSound;
        }

        //GameResult.GetComponent<TextMeshProUGUI>().text = result;
        resultText.text = result;
        GameResult.SetActive(true);
        audioSource.Play();
        LeanTween.scale(GameResult, new Vector3(0.3f, 0.3f, 0.3f), 3f).setEase(LeanTweenType.easeOutElastic);

    }

    public void replay_btn_clicked()
    {
        SceneManager.LoadScene("Stage" + stageNumber);
    }

    public void back2lobby_btn_clicked()
    {
        SceneManager.LoadScene("StageMenu");
    }
}
