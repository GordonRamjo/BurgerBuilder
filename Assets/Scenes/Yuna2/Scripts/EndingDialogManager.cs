using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDialogManager : MonoBehaviour
{
    public TextMeshProUGUI ending;
    private string[] endingDialog = new string[] { "Congratulations!!\nYou're pretty good ^^", "It's the real game now!\nComplete the two missions", "Get your head in the game.\nGood luck!" };
    private int endingDialogNum = 0;
    private Canvas endingUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        endingUICanvas = GameObject.Find("EndingUICanvas").GetComponent<Canvas>();
        StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        if (endingDialogNum < endingDialog.Length)
        {
            StartCoroutine(_typing());
        }
        else if (endingDialogNum == endingDialog.Length)
        {
            endingUICanvas.enabled = false;
        }
    }

    IEnumerator _typing()
    {
        ending.text = "";

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= endingDialog[endingDialogNum].Length; i++)
        {
            ending.text = endingDialog[endingDialogNum].Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2f);

        endingDialogNum++;
    }
}
