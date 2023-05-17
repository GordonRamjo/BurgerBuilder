using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuideDialogManager : MonoBehaviour
{
    public TextMeshProUGUI guide;
    public RawImage image;
    private string[] guideDialog = new string[] { "First, make a basic burger", "Pick up a bottom bread from the container\nthen place it on tray", "Grill a patty for 5 seconds", "It's burnt! Throw it in the trash", "Bake a patty for 3 seconds and place on bread", "Good job. Now put a tomato on top", "Next, put lettuce on top", "Last but not least, put the bread on top" };
    public Texture2D[] images;
    private int guideDialogNum = 0;
    private Canvas guideUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        guideUICanvas = GameObject.Find("GuideCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            guideDialogNum++;

            if (guideDialogNum < guideDialog.Length)
            {
                image.texture = images[guideDialogNum];
                guide.text = guideDialog[guideDialogNum];
            }
            else if (guideDialogNum == guideDialog.Length)
            {
                guideUICanvas.enabled = false;
            }
        }
    }
}