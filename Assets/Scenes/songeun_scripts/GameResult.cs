using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    public GameObject Stage1Success;
    public GameObject replay_btn;
    public GameObject back2lobby_btn;
    public int stageNumber;

    // Start is called before the first frame update
    public void Start()
    {
        transform.localScale = Vector3.zero;
        Invoke("Open", 2f);

    }

    // Update is called once per frame
    public void Open()
    {
        LeanTween.scale(Stage1Success, new Vector3(0.3f, 0.3f, 0.3f), 3f).setEase(LeanTweenType.easeOutElastic);
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
