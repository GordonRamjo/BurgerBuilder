using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogManager : MonoBehaviour
{
    public TextMeshProUGUI tx;
    public TextMeshProUGUI spacetx;
    private string[] introDialog = new string[] { "반갑다 !\n최고의 버거 빌더가\n되고 싶다고 ?", "내가 주는\n미션을 통과하면,\n다시 생각해보겠다 !", "지금부터 딱 한 번만\n설명할테니 빠짐없이\n새겨 듣도록." };
    private string spaceDialog = "[Space] 키를 눌러 주세요";
    private int introDialogNum = 0;
    private Canvas introUICanvas;

    // Start is called before the first frame update
    void Start()
    {
        introUICanvas = GameObject.Find("IntroUICanvas").GetComponent<Canvas>();
        StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            introDialogNum++;

            if (introDialogNum < introDialog.Length)
            {
                StartCoroutine(_typing());
            } else if (introDialogNum == introDialog.Length)
            {
                introUICanvas.enabled = false;
            }
        }
    }

    IEnumerator _typing()
    {
        tx.text = "";
        spacetx.text = "";

        yield return new WaitForSeconds(1f);

        for (int i = 0; i <= introDialog[introDialogNum].Length; i++)
        {
            tx.text = introDialog[introDialogNum].Substring(0, i);

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        spacetx.text = spaceDialog;
    }
}