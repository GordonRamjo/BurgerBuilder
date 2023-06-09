using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuideDialogManager : MonoBehaviour
{
    public TextMeshProUGUI guide;
    public RawImage image;
    private string[] guideDialog = new string[] { "Pick up a bottom bread\nthen place it on tray", "Grill a patty for 10 seconds", "It's burnt! Throw it in the trash", "Bake a patty for 5 seconds\nand place on bread", "Good job. Now put a tomato on top", "Next, put lettuce on top", "Put the bread on top", "It's a set menu.\nPlace cola.", "Last but not least,\nPlace fries at the front"};
    public Texture2D[] images;
    private int guideDialogNum = 0;
    private Canvas guideUICanvas;
    public GameObject ending;
    public EndingDialogManager endingDialogManager;

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
            image.texture = images[guideDialogNum];
            guide.text = guideDialog[guideDialogNum];
        }
        else if (guideDialogNum == guideDialog.Length)
        {
            guideUICanvas = GameObject.Find("GuideCanvas").GetComponent<Canvas>();
            guideUICanvas.enabled = false;
            ending.SetActive(true);
            endingDialogManager.initEndingDialog();
        }

        guideDialogNum++;
    }

    IEnumerator _wait()
    {
        yield return new WaitForSeconds(4f);
        image.texture = images[guideDialogNum];
        guide.text = guideDialog[guideDialogNum];
        guideDialogNum++;
    }
}