using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class StageTutorial : MonoBehaviour
{
    StageTutorialGuideDialogManager guideDialogManager;
    AudioTutorialController audioController;
    private bool isTimerTutorialEnd;
    private bool isHamburgerUIEnd;
    private bool isRecipePaperEnd;
    private bool isBellEnd;
    public GameObject timerImg;
    public GameObject uiImg;
    public GameObject recipeImg;
    public GameObject bellImg;
    private int order;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioTutorialController>();
        guideDialogManager = GameObject.Find("Dialog").GetComponent<StageTutorialGuideDialogManager>();
        order = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectTimer.selectTimer && !isTimerTutorialEnd && order == 0)
        {
            isTimerTutorialEnd = true;
            Debug.Log("Timer" + SelectTimer.selectTimer);
            guideDialogManager.UpdateGuideDialog();
            timerImg.SetActive(false);
            uiImg.SetActive(true);
            order++;

        }
        if(SelectHamburgerUI.selectHamburgerUI && !isHamburgerUIEnd && order == 1)
        {
            isHamburgerUIEnd = true;
            Debug.Log("HamburgerUI" + SelectHamburgerUI.selectHamburgerUI);
            guideDialogManager.UpdateGuideDialog();
            uiImg.SetActive(false);
            recipeImg.SetActive(true);
            order++;
        }
        if(SelectRecipePaper.selectRecipePaper && !isRecipePaperEnd && order == 2)
        {
            isRecipePaperEnd = true;
            Debug.Log("Recipe" + SelectRecipePaper.selectRecipePaper);
            guideDialogManager.UpdateGuideDialog();
            recipeImg.SetActive(false);
            bellImg.SetActive(true);
            order++;
        }
        if(RingABell.ring && !isBellEnd && order == 3)
        {
            isBellEnd = true;
            Debug.Log("Recipe" + RingABell.ring);
            guideDialogManager.UpdateGuideDialog();
            bellImg.SetActive(false);
            order++;
        }
        if(order == 4)
        {
            Debug.Log("튜토리얼 완료. 이제 게임을 시작해보자");
            SceneManager.LoadScene("Stage1");
        }
    }

}
