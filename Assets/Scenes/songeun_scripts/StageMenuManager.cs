using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StageMenuManager : MonoBehaviour
    {
        public GameObject StageMenu;  //현재 화면 
        public GameObject StartMenu;  //뒤로가기 버튼으로 접근
        public GameObject OptionMenu; //옵션(톱니바퀴) 버튼으로 접근

        public GameObject[] stageButton = new GameObject[3];

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

        public int selectedStageNum;

        public GameData gameData;

        public void stageButton_selected() {
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            Debug.Log("clicked " + selected);
           
            //stage 0 선택시
            if (selected == stageButton[0])
            {
                selectedStageNum = 0;
            }

            //stage 1 선택시
            if (selected == stageButton[1])
            {
                //stage 0 클리어 안 됐으면 pop up 
                if //(!DataManager.Instance.data.isCleared[0])
                    (!gameData.isCleared[1])
                {
                    Debug.Log("Clear stage 0 first!");
                }
                else
                {
                    selectedStageNum = 1;
                }
            }

            //stage 2 선택시
            if (selected == stageButton[2])
            {
                //stage 1 클리어 안 됐으면 pop up 
                if //(!DataManager.Instance.data.isCleared[1])
                    (gameData.isCleared[2])
                {
                    Debug.Log("Clear stage 1 first!");
                }
                else
                {
                    selectedStageNum = 2;
                }
            }

            Debug.Log(selectedStageNum);

            foreach (GameObject btn in stageButton)
            {
                if (btn == stageButton[selectedStageNum])
                {
                    btn.transform.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    btn.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }


        public void enter_btn_selected()
        {
            //스테이지 선택 안한 상태일 시 거부
            if (selectedStageNum == -1)
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
            /*
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
            */

            if (gameData.playedResult == false)
            {
                resultText.text = resultDialog[3];
            }
            else
            {
                resultText.text = resultDialog[gameData.playedStageNum];
            }
            resultPopUp.SetActive(true);
        }

        // Start is called before the first frame update
        void Start()
        {
            /*
            resultPopUp.SetActive(false);

            //스테이지 종료 후 로딩되는 경우
            if (isAfterStage) {
                ShowGameResult();

                isAfterStage = false;
            }
            */

            //스테이지 플레이 후 로비에 돌아왔을 시
            if (gameData.playedStageNum != -1)
            {
                ShowGameResult();

            }

            gameData.playedStageNum = -1;
            //게임 데이터 로딩
            //DataManager.Instance.LoadGameData();
            //DataManager.Instance.data.isCleared[0] = true;

            //'선택된 스테이지 없음'로 초기화
            selectedStageNum = -1;

            for (int i = 0; i <=2 ; i++)
            {
                //클리어 된 스테이지는 Completed 도장 띄워놓기
                if //(DataManager.Instance.data.isCleared[i])
                    (gameData.isCleared[i])
                {
                    stageButton[i].transform.GetChild(2).gameObject.SetActive(true);
                }

                //클리어 못한 스테이지 있을 시 해당되는 스테이지 lock 처리
                else
                {
                    lockStage(2);

                    if (i == 0)
                    {
                        lockStage(1);
                    }
                    break;
                }
            }


        }

        void lockStage(int stageNum) //스테이지 잠금 함수
        {
            //버튼 이미지 회색 처리
            stageButton[stageNum].GetComponent<RawImage>().color = Color.gray;
            //자물쇠 활성화 (스테이지 버튼의 자식 obj 3번)
            stageButton[stageNum].transform.GetChild(3).gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}