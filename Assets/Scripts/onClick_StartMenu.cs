using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick_StartMenu : MonoBehaviour
{
    //Lobby Scene Panel Object��
    public GameObject StartMenu;  //���� ȭ��
    public GameObject StageMenu;  //Start ��ư���� ����
    public GameObject ExitMenu;   //Exit ��ư���� ����
    public GameObject OptionMenu; //�ɼ�(��Ϲ���) ��ư���� ����

    public void start_btn_clicked()
    {
        StartMenu.SetActive(false);
        StageMenu.SetActive(true);
    }
    public void exit_btn_clicked()
    {
        StartMenu.SetActive(false);
        ExitMenu.SetActive(true);
    }
    public void option_btn_clicked()
    {
        StartMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
