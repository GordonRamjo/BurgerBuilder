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
        public GameObject blackPanel;

        public GameObject[] stageButton = new GameObject[6];

        public bool isAfterStage; //로비 진입 or 스테이지 종료 후 진입 여부
        public bool AllClear = false; //올클리어 최초 달성 여부
        public GameObject resultPopUp;
        public int afterStageResult; //0: fail  1: Stage1 clear  2: Stage2 clear
        public TextMeshProUGUI resultText;
        private string[] resultDialog = { "Stage 0 Clear !",
                                          "Stage 1 Clear !",
                                          "Now you are the Best Burger Builder!",
                                          "Try Again!"
                                        };

        public AudioLobbyController audioLobbyController;

        public int selectedStageNum;


        public void stageButton_selected() {
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            Debug.Log("clicked " + selected);
            audioLobbyController.StageButton = true;

            //stage 0 선택시
            if (selected == stageButton[0])
            {
                selectedStageNum = 0;
            }

            //stage 1 선택시
            if (selected == stageButton[1])
            {
                //stage 0 클리어 안 됐으면 pop up 
                if (!DataManager.dataManager.data.isClear[0])
                //(!GameData.isClear[0])
                {
                    Debug.Log("Clear stage 0 first!");
                    audioLobbyController.LockButton = true;
                    selectedStageNum = -1;
                }
                //stage 1 클리어 못했으면 가이드 화면 띄우기
                else if (!DataManager.dataManager.data.isClear[1])
                {
                    selectedStageNum = 5;
                }
                //stage 1 클리어 후 리플레이면 바로 stage 1으로
                else
                {
                    selectedStageNum = 1;
                }
            }

            //stage 2 선택시
            if (selected == stageButton[2])
            {
                //stage 1 클리어 안 됐으면 pop up 
                if (!DataManager.dataManager.data.isClear[1])
                //(!GameData.isClear[1])
                {
                    Debug.Log("Clear stage 1 first!");
                    audioLobbyController.LockButton = true;
                    selectedStageNum = -1;
                }
                else
                {
                    selectedStageNum = 2;
                }
            }

            Debug.Log("selected stage " + selectedStageNum);

            //현재 선택한 스테이지만 표시 띄우기
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
                audioLobbyController.LockButton = true;
                //임시 코드 (안내창으로 변경 예정)
                print("select stage!");
            }

            //선택한 스테이지 로드 (각 스테이지 씬명이 "Stage+번호"라고 가정)
            else
            {

                // Fade fade = new Fade();
                //Fade.blackPanel = blackPanel;
                StartCoroutine(FadeOut());
                //SceneManager.LoadScene("Stage" + selectedStageNum);
                Invoke("MoveScene", 3f);
            }
        }

        public void MoveScene()
        {
            Debug.Log("move scene");
            SceneManager.LoadScene("Stage" + selectedStageNum);
        }

        public void back_btn_selected()
        {
            audioLobbyController.StageButton = true;
            StageMenu.SetActive(false);
            StartMenu.SetActive(true);
        }

        public void option_btn_selected()
        {
            audioLobbyController.StageButton = true;
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

            if (PlayResult.playedStageClear == false)
            {
                resultText.text = resultDialog[3];
                audioLobbyController.StageFail = true;
            }
            else
            {
                if (PlayResult.playedStageNum == 2)
                {
                    audioLobbyController.BBB = true;
                    
                }
                else
                {
                    resultText.text = resultDialog[PlayResult.playedStageNum];
                    audioLobbyController.StageClear = true;
                }

            }
            resultPopUp.SetActive(true);
            Invoke("DeactivatePopUp", 3f);
        }

        public void DeactivatePopUp()
        {
            resultPopUp.SetActive(false);
        }

        public IEnumerator FadeOut()
        {
            Debug.Log("Fade Out");
            blackPanel.SetActive(true);
            float fadeCount = 0;
            while (fadeCount < 1.0f)
            {
                fadeCount += 0.02f;
                yield return new WaitForSeconds(0.01f);
                blackPanel.GetComponent<Image>().color = new Color(0, 0, 0, fadeCount);
            }
        }
    

        void Start()
        { 

            //게임 데이터 로딩
            DataManager.dataManager.LoadGameData();
            //DataManager.dataManager.data.isClear[0] = true;
            //audioLobbyController.StageFail = false;

            //스테이지 플레이 후 로비에 돌아왔을 시 게임 결과 업데이트
            if (PlayResult.playedStageNum != -1)
            {
                StartMenu.SetActive(false);
                StageMenu.SetActive(true);
                Debug.Log(PlayResult.playedStageNum);
                Debug.Log(PlayResult.playedStageClear);
                audioLobbyController.BGM = false;
                ShowGameResult();
                PlayResult.playedStageNum = -1;
            }
            else
            {
                audioLobbyController.BGM = true;
            }
            selectedStageNum = -1;

            //스테이지 해금 업데이트
            for (int i = 0; i <=2 ; i++)
            {
                //클리어 된 스테이지는 Completed 도장 띄워놓기
                if (DataManager.dataManager.data.isClear[i])
                {
                    stageButton[i].transform.GetChild(2).gameObject.SetActive(true);
                }

                //클리어 못한 스테이지 있을 시 해당되는 스테이지 lock 처리
                else
                {
                    if (i <= 1)
                    {
                        lockStage(i + 1);
                    }
                }
            }

            //사운드
            audioLobbyController = GameObject.Find("SoundCube").GetComponent<AudioLobbyController>();
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