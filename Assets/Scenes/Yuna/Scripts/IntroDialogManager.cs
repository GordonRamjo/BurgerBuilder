using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogManager : MonoBehaviour
{
    public TextMeshProUGUI tx;
    public TextMeshProUGUI spacetx;
    private string[] introDialog = new string[] { "�ݰ��� !\n�ְ��� ���� ������\n�ǰ� �ʹٰ� ?", "���� �ִ�\n�̼��� ����ϸ�,\n�ٽ� �����غ��ڴ� !", "���ݺ��� �� �� ����\n�������״� ��������\n���� �赵��." };
    private string spaceDialog = "[Space] Ű�� ���� �ּ���";
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