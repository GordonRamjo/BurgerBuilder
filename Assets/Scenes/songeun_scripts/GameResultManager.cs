using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
    public GameObject GameResult;
    //public TextMeshProUGUI result;
    private string Success = "Good job!\r\nYou are a Good\r\nBurger Builder!";
    private string Fail = "Oh no!\r\nYou've failed to be a\r\nBurger Builder!";
    public GameObject replay_btn;
    public GameObject back2lobby_btn;
    public int stageNumber;
    public bool isClear;
   

    // Start is called before the first frame update
    public void Start()
    {
        //GameResult.transform.LeanScale
    }

    // Update is called once per frame
    public void Open(bool isClear)
    {
        string result;
        if (isClear)
        {
            result = Success;
        }
        else
        {
            result = Fail;
        }

        GameResult.GetComponent<TextMeshPro>().text = result;
        GameResult.SetActive(true);
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
