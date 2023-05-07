using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClick_StageMenu : MonoBehaviour
{
    public GameObject StageMenu;  //���� ȭ�� 
    public GameObject StartMenu;  //�ڷΰ��� ��ư���� ����
    public GameObject OptionMenu; //�ɼ�(��Ϲ���) ��ư���� ����

    int stageNum;

    //stageNum�� ����Ʈ�� 0�� stage�� ���õ��� ���� ���·� ó���ϱ� ����, �� ���������� stageNum�� +1 ����.
    //�� stage0�� stageNum�� 1, stage1�� stageNum�� 2, stage2�� stageNum�� 3
    public void stage0_btn_selected()
    {
        //�̹� ���õ� �������� �ٽ� ���ý� ���
        if (stageNum == 1)
        {
            stageNum = 0;
            //��ư ��Ȱ��ȭ �ð� �ǵ�� �ڵ� �߰� ����
        }

        //�������� 0 ����
        else
        {
            stageNum = 1;
            //��ư Ȱ��ȭ �ð� �ǵ�� �ڵ� �߰� ����
        }
    }
    public void stage1_btn_selected()
    {
        //�̹� ���õ� �������� �ٽ� ���ý� ���
        if (stageNum == 2)
        {
            stageNum = 0;
            //��ư ��Ȱ��ȭ �ð� �ǵ�� �ڵ� �߰� ����
        }

        //��������0 unlock �����̸� �������� 1 ����
        else if (DataManager.Instance.data.isUnlock[0])
        {
            stageNum = 2;
            //��ư Ȱ��ȭ �ð� �ǵ�� �ڵ� �߰� ����
        }

        //�ƴϸ� ���� �ź�
        else
        {
            //�ӽ� �ڵ� (�ȳ�â���� ���� ����)
            print("Clear stage 0 first!");
        }

    }
    public void stage2_btn_selected()
    {
        //�̹� ���õ� �������� �ٽ� ���ý� ���
        if (stageNum == 3)
        {
            stageNum = 0;
            //��ư ��Ȱ��ȭ �ð� �ǵ�� �ڵ� �߰� ����
        }

        //��������0 unlock �����̸� �������� 1 ����
        else if (DataManager.Instance.data.isUnlock[0])
        {
            stageNum = 3;
            //��ư Ȱ��ȭ �ð� �ǵ�� �ڵ� �߰� ����
        }

        //�ƴϸ� ���� �ź�
        else
        {
            //�ӽ� �ڵ� (�ȳ�â���� ���� ����)
            print("Clear stage 1 first!");
        }
    }

    public void enter_btn_selected()
    {
        //�������� ���� ���� ������ �� �ź�
        if (stageNum == 0) 
        { 
            //�ӽ� �ڵ� (�ȳ�â���� ���� ����)
            print("select stage!"); 
        }

        //������ �������� �ε� (�� �������� ������ "Stage+��ȣ"��� ����)
        else
        {
            SceneManager.LoadScene("Stage" + stageNum);
        }
     }

    public void back_btn_selected()
    {
        StageMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

    public void option_btn_selected()
    {
        StageMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
