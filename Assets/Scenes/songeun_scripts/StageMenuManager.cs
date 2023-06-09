using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StageMenuManager : MonoBehaviour
    {
        public GameObject StageMenu;  //현재 화면 
        public GameObject StartMenu;  //뒤로가기 버튼으로 접근
        public GameObject OptionMenu; //옵션(톱니바퀴) 버튼으로 접근
        public GameObject stage1_btn;
        public GameObject stage2_btn;

        public bool isAfterStage; //로비 진입 or 스테이지 종료 후 진입 여부
        public bool AllClear = false; //올클리어 최초 달성 여부
        public GameObject resultPopUp;
        public int afterStageResult; //0: fail  1: Stage1 clear  2: Stage2 clear
        public TextMeshProUGUI resultText;
        private string[] resultDialog = { "Stage 0 Clear !", 
                                          "Stage 1 Clear !", 
                                          "Stage 2 Clear !",
                                          "Try Again!" 
                                        };
        
        AudioSource audioSource;
        public AudioClip ClearSound;
        public AudioClip FailSound;
        public AudioClip AllClearSound;

        int selectedStageNum;

        //stageNum의 디폴트값 0을 stage가 선택되지 않은 상태로 처리하기 위해, 각 스테이지의 stageNum을 +1 했음.
        //즉 stage0의 stageNum은 1, stage1의 stageNum은 2, stage2의 stageNum은 3
        public void stage0_btn_selected()
        {
            //이미 선택된 스테이지 다시 선택시 취소
            if (selectedStageNum == 1)
            {
                selectedStageNum = 0;
                //버튼 비활성화 시각 피드백 코드 추가 예정
            }

            //스테이지 0 선택
            else
            {
                selectedStageNum = 1;
                //버튼 활성화 시각 피드백 코드 추가 예정
                //stage0_btn.GetComponent<RawImage>().color = Color.white;
            }
        }
        public void stage1_btn_selected()
        {
            //이미 선택된 스테이지 다시 선택시 취소
            if (selectedStageNum == 2)
            {
                selectedStageNum = 0;
                //버튼 비활성화 시각 피드백 코드 추가 예정
            }

            //스테이지0 unlock 상태이면 스테이지 1 선택
            else if (DataManager.Instance.data.isUnlock[0])
            {
                selectedStageNum = 2;
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
            if (selectedStageNum == 3)
            {
                selectedStageNum = 0;
                //버튼 비활성화 시각 피드백 코드 추가 예정
            }

            //스테이지0 unlock 상태이면 스테이지 1 선택
            else if (DataManager.Instance.data.isUnlock[0])
            {
                selectedStageNum = 3;
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
            if (selectedStageNum == 0)
            {
                //임시 코드 (안내창으로 변경 예정)
                print("select stage!");
            }

            //선택한 스테이지 로드 (각 스테이지 씬명이 "Stage+번호"라고 가정)
            else
            {
                SceneManager.LoadScene("Stage" + selectedStageNum);
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

        public void ShowGameResult() {
            //최초 올클리어 시 이펙트
            if (afterStageResult == 2 && AllClear == false)
            {
                resultText.text = resultDialog[2];
                AllClear = true;
                return;
            }

            resultText.text = resultDialog[afterStageResult];
            resultPopUp.SetActive(true);
            audioSource.Play();
            //LeanTween.scale(resultPopUp, new Vector3(0.3f, 0.3f, 0.3f), 3f).setEase(LeanTweenType.easeOutElastic);
        }

        // Start is called before the first frame update
        void Start()
        {
            resultPopUp.SetActive(false);
            DataManager.Instance.LoadGameData();
            //DataManager.Instance.data.isUnlock[1] = true;

            //스테이지 종료 후 로딩되는 경우
            if (isAfterStage) {
                ShowGameResult();

                isAfterStage = false;
            }

            if (!DataManager.Instance.data.isUnlock[1])
            {
                stage1_btn.transform.GetChild(1).GetComponent<RawImage>().color = Color.gray;
                stage1_btn.transform.GetChild(2).gameObject.SetActive(true);
            }
            if (!DataManager.Instance.data.isUnlock[2])
            {
                stage2_btn.transform.GetChild(1).GetComponent<RawImage>().color = Color.gray;
                stage2_btn.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}