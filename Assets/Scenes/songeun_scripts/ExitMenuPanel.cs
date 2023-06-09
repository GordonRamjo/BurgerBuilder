﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExitMenuPanel : MonoBehaviour
    {
        public GameObject StartMenu;  //현재 화면
        public GameObject ExitMenu;   //Exit 버튼으로 접근
        public AudioLobbyController audioLobbyController;

        public void yes_btn_Clicked()
        {
            audioLobbyController.ButtonClick = true;
            //yes -> 게임 데이터 저장 후 종료
            DataManager.dataManager.SaveGameData();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        public void no_btn_Clicked()
        {
            audioLobbyController.ButtonClick = true;
            //no -> StartMenu 패널로 돌아가기
            ExitMenu.SetActive(false);
            StartMenu.SetActive(true);
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