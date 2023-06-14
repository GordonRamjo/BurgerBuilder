using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class OptionMenuPanel : MonoBehaviour
    {
        public GameObject StageMenu;  //���� ȭ��
        public GameObject OptionMenu;   //Exit ��ư���� ����
        public AudioLobbyController audioLobbyController;

        public void yes_btn_Clicked()
        {
            //yes -> ���� ������ ���� �� ����
            audioLobbyController.ButtonClick = true;

            DataManager.dataManager.ResetGameData();
           DataManager.dataManager.SaveGameData();
           SceneManager.LoadScene("Lobby");
        }
        public void no_btn_Clicked()
        {
            audioLobbyController.ButtonClick = true;
            //no -> StartMenu �гη� ���ư���
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