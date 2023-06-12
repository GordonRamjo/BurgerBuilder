using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class OptionMenuPanel : MonoBehaviour
    {
        public GameObject StageMenu;  //���� ȭ��
        public GameObject OptionMenu;   //Exit ��ư���� ����

        public void yes_btn_Clicked()
        {
            //yes -> ���� ������ ���� �� ����
           DataManager.dataManager.ResetGameData();
           SceneManager.LoadScene("Lobby");
        }
        public void no_btn_Clicked()
        {
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