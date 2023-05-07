using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick_StartMenu : MonoBehaviour
{
    //Lobby Scene Panel Object들
    public GameObject StartMenu;  //현재 화면
    public GameObject StageMenu;  //Start 버튼으로 접근
    public GameObject ExitMenu;   //Exit 버튼으로 접근
    public GameObject OptionMenu; //옵션(톱니바퀴) 버튼으로 접근

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
