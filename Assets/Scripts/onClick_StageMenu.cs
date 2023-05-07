using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClick_StageMenu : MonoBehaviour
{
    public GameObject StageMenu;  //현재 화면 
    public GameObject StartMenu;  //뒤로가기 버튼으로 접근
    public GameObject OptionMenu; //옵션(톱니바퀴) 버튼으로 접근

    int stageNum;

    //stageNum의 디폴트값 0을 stage가 선택되지 않은 상태로 처리하기 위해, 각 스테이지의 stageNum을 +1 했음.
    //즉 stage0의 stageNum은 1, stage1의 stageNum은 2, stage2의 stageNum은 3
    public void stage0_btn_selected()
    {
        //이미 선택된 스테이지 다시 선택시 취소
        if (stageNum == 1)
        {
            stageNum = 0;
            //버튼 비활성화 시각 피드백 코드 추가 예정
        }

        //스테이지 0 선택
        else
        {
            stageNum = 1;
            //버튼 활성화 시각 피드백 코드 추가 예정
        }
    }
    public void stage1_btn_selected()
    {
        //이미 선택된 스테이지 다시 선택시 취소
        if (stageNum == 2)
        {
            stageNum = 0;
            //버튼 비활성화 시각 피드백 코드 추가 예정
        }

        //스테이지0 unlock 상태이면 스테이지 1 선택
        else if (DataManager.Instance.data.isUnlock[0])
        {
            stageNum = 2;
            //버튼 활성화 시각 피드백 코드 추가 예정
        }

        //아니면 셀렉 거부
        else
        {
            //임시 코드 (안내창으로 변경 예정)
            print("Clear stage 0 first!");
        }

    }
    public void stage2_btn_selected()
    {
        //이미 선택된 스테이지 다시 선택시 취소
        if (stageNum == 3)
        {
            stageNum = 0;
            //버튼 비활성화 시각 피드백 코드 추가 예정
        }

        //스테이지0 unlock 상태이면 스테이지 1 선택
        else if (DataManager.Instance.data.isUnlock[0])
        {
            stageNum = 3;
            //버튼 활성화 시각 피드백 코드 추가 예정
        }

        //아니면 셀렉 거부
        else
        {
            //임시 코드 (안내창으로 변경 예정)
            print("Clear stage 1 first!");
        }
    }

    public void enter_btn_selected()
    {
        //스테이지 선택 안한 상태일 시 거부
        if (stageNum == 0) 
        { 
            //임시 코드 (안내창으로 변경 예정)
            print("select stage!"); 
        }

        //선택한 스테이지 로드 (각 스테이지 씬명이 "Stage+번호"라고 가정)
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
