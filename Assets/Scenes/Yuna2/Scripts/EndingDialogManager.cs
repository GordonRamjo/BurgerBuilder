using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDialogManager : MonoBehaviour
{
    public TextMeshProUGUI endtx;
    private string[] endingDialog = new string[] { "Congratulations!!\nYou're pretty good ^^", "It's the real game now!\nComplete the two missions", "Get your head in the game.\nGood luck!" };
    private int endingDialogNum = 0;
    public Canvas endingUICanvas;
    private bool isFirstExecute = false;
    AudioTutorialController audioController;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioTutorialController>();
    }

    public void initEndingDialog()
    {
        audioController.SfxPlay(AudioTutorialController.SfxTutorial.GORDAN);
        isFirstExecute = true;
    }

    void Update()
    {
        if (isFirstExecute)
        {
            isFirstExecute = false;
            if (endingDialogNum < endingDialog.Length)
            {
                StartCoroutine(_endingTyping());
            }
            else if (endingDialogNum == endingDialog.Length)
            {
                endingUICanvas.enabled = false;
            }
        }
    }

    IEnumerator _endingTyping()
    {
        endtx.text = "";
        Debug.Log("5");
        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= endingDialog[endingDialogNum].Length; i++)
        {
            endtx.text = endingDialog[endingDialogNum].Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        endingDialogNum++;
        isFirstExecute = true;
    }
}
