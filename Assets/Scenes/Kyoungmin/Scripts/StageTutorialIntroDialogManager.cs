using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageTutorialIntroDialogManager : MonoBehaviour
{
    public TextMeshProUGUI tx;
    private string[] introDialog = new string[] { "Before you start the game,\nThere's something you need to know", "These will help you succeed in the game.", "From now on,\nLook around with the guide" };
    private int introDialogNum = 0;
    private Canvas introUICanvas;
    private GameObject guide;
    public StageTutorialGuideDialogManager guideDialogManager;
    private bool isFirstExecute = false;

    // Start is called before the first frame update
    void Start()
    {
        introUICanvas = GameObject.Find("IntroUICanvas").GetComponent<Canvas>();
        guide = GameObject.Find("GuideCanvas");
        guide.SetActive(false);
        StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstExecute)
        {
            isFirstExecute = false;
            if (introDialogNum < introDialog.Length)
            {
                StartCoroutine(_typing());
            }
            else if (introDialogNum == introDialog.Length)
            {
                introUICanvas.enabled = false;
                guide.SetActive(true);
                guide.transform.GetChild(2).gameObject.SetActive(false);
                guide.transform.GetChild(3).gameObject.SetActive(false);
                guide.transform.GetChild(4).gameObject.SetActive(false);
                guideDialogManager.initGuideDialog();
            }
        }
    }

    IEnumerator _typing()
    {
        tx.text = "";

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= introDialog[introDialogNum].Length; i++)
        {
            tx.text = introDialog[introDialogNum].Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2f);

        introDialogNum++;
        isFirstExecute = true;
    }
}