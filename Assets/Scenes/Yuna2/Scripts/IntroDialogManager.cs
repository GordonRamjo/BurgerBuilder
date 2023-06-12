using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogManager : MonoBehaviour
{
    public TextMeshProUGUI tx;
    private string[] introDialog = new string[] { "So you wanna be\nthe best burger builder?", "If you pass the mission,\nI'll reconsider!", "From now on,\nI'll explain once,\nso listen carefully." };
    private int introDialogNum = 0;
    private Canvas introUICanvas;
    private GameObject guide;
    private GameObject ending;
    public GuideDialogManager guideDialogManager;
    private bool isFirstExecute = false;

    // Start is called before the first frame update
    void Start()
    {
        introUICanvas = GameObject.Find("IntroUICanvas").GetComponent<Canvas>();
        guide = GameObject.Find("GuideCanvas");
        guide.SetActive(false);
        ending = GameObject.Find("EndingUICanvas");
        ending.SetActive(false);
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