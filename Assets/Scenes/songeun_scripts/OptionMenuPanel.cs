using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class OptionMenuPanel : MonoBehaviour
    {
        public GameObject StageMenu;  //현재 화면
        public GameObject OptionMenu;   //Exit 버튼으로 접근
        public AudioLobbyController audioLobbyController;

        public void yes_btn_Clicked()
        {
            //yes -> 게임 데이터 저장 후 종료
            audioLobbyController.ButtonClick = true;

            DataManager.dataManager.ResetGameData();
           DataManager.dataManager.SaveGameData();
           SceneManager.LoadScene("Lobby");
        }
        public void no_btn_Clicked()
        {
            audioLobbyController.ButtonClick = true;
            //no -> StartMenu 패널로 돌아가기
            OptionMenu.SetActive(false);
            StageMenu.SetActive(true);
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}