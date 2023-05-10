using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogManager : MonoBehaviour
{
    public TextMeshProUGUI tx;
    private string[] introDialog = new string[] { "�ݰ���!\n�ְ��� ���� ������\n�ǰ� �ʹٰ�?", "�׷� �̼��� �ְڴ�!\n�̼��� �� ����ϸ�,\n�ְ��� ���ź�����\n�Ӹ��ϰڴ� !!!" };
    private int introDialogNum = 0;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}