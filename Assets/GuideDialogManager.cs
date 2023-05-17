using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuideDialogManager : MonoBehaviour
{
    public TextMeshProUGUI guide;
    public RawImage image;
    private string[] guideDialog = new string[] { "먼저 기본 버거를 만들어 볼거다", "재료통에서 바닥용 빵을 집어\n트레이에 올려라", "패티를 그릴에 올려\n5초 동안 구워라", "타버렸군! 쓰레기통에 버려라", "다시 패티를 3초 동안 굽고\n빵 위에 올려라", "잘하네, 이제 토마토를 올려라", "다음은 양상추를 올려라", "마지막이다! 빵을 올려라"};
    public Texture2D[] images;
    private int guideDialogNum = 0;
    private Canvas guideUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        guideUICanvas = GameObject.Find("Guide").GetComponent<Canvas>();
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
            } else if (guideDialogNum == guideDialog.Length)
            {
                guideUICanvas.enabled = false;
            }
        }
    }
}
