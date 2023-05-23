using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuideDialogManager : MonoBehaviour
{
    public TextMeshProUGUI guide;
    public RawImage image;
    private string[] guideDialog = new string[] { "Pick up a bottom bread\nthen place it on tray", "Grill a patty for 5 seconds", "It's burnt! Throw it in the trash", "Bake a patty for 3 seconds\nand place on bread", "Good job. Now put a tomato on top", "Next, put lettuce on top", "Last but not least,\nput the bread on top" };
    public Texture2D[] images;
    private int guideDialogNum = 0;
    private Canvas guideUICanvas;

    void Start()
    {

    }

    public void UpdateGuideDialog()
    {
        guideDialogNum++;

        if (guideDialogNum < guideDialog.Length)
        {
            Debug.Log("guideDialogNum" + guideDialogNum);
            image.texture = images[guideDialogNum];
            guide.text = guideDialog[guideDialogNum];
        }
        else if (guideDialogNum == guideDialog.Length)
        {
            guideUICanvas = GameObject.Find("GuideCanvas").GetComponent<Canvas>();
            guideUICanvas.enabled = false;
        }
    }
}