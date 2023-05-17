using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuideDialogManager : MonoBehaviour
{
    public TextMeshProUGUI guide;
    public RawImage image;
    private string[] guideDialog = new string[] { "���� �⺻ ���Ÿ� ����� ���Ŵ�", "����뿡�� �ٴڿ� ���� ����\nƮ���̿� �÷���", "��Ƽ�� �׸��� �÷�\n5�� ���� ������", "Ÿ���ȱ�! �������뿡 ������", "�ٽ� ��Ƽ�� 3�� ���� ����\n�� ���� �÷���", "���ϳ�, ���� �丶�並 �÷���", "������ ����߸� �÷���", "�������̴�! ���� �÷���"};
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
