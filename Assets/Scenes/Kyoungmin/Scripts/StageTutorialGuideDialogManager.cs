using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageTutorialGuideDialogManager : MonoBehaviour
{
    public TextMeshProUGUI guide;
    private string[] guideDialog = new string[] { "Look at the timer up there.\nWhen the timer reaches zero, the game goes over.\nSelect the timer!", 
        "Look to the right.\nIt will show you the number of hamburgers you need to make and the number of hamburgers you currently make.\nSelect the Object!",
        "Turn around and look at the recipe papers on the back.\nIf you're confused with the recipe, look at this paper.\nSelect the any paper!",
        "Look at the bell on the counter.\nHit the bell when you're done cooking.\nIt's over. Hit the bell and the game will start."};
    private int guideDialogNum = 0;
    private Canvas guideUICanvas;

    void Start()
    {
    }

    public void initGuideDialog()
    {
        StartCoroutine(_wait());
    }

    public void UpdateGuideDialog()
    {
        if (guideDialogNum < guideDialog.Length)
        {
            guide.text = guideDialog[guideDialogNum];
        }
        else if (guideDialogNum == guideDialog.Length)
        {
            guideUICanvas = GameObject.Find("GuideCanvas").GetComponent<Canvas>();
            guideUICanvas.enabled = false;
        }

        guideDialogNum++;
    }

    IEnumerator _wait()
    {
        yield return new WaitForSeconds(4f);
        guide.text = guideDialog[guideDialogNum];
        guideDialogNum++;
    }
}