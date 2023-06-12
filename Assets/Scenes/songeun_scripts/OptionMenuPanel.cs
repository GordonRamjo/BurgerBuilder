using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class OptionMenuPanel : MonoBehaviour
    {
        public GameObject StageMenu;  //현재 화면
        public GameObject OptionMenu;   //Exit 버튼으로 접근

        public void yes_btn_Clicked()
        {
            //yes -> 게임 데이터 저장 후 종료
           DataManager.dataManager.ResetGameData();
           SceneManager.LoadScene("Lobby");
        }
        public void no_btn_Clicked()
        {
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