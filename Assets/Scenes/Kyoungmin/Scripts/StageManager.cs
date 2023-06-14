using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{
    public int stageNumber; //현재 스테이지 수
    public int totalCustomerCnt; //스테이지 총 손님 수
    private int remainCustomerCnt; //남아있는 손님 수
    public int completeCustomerCnt; //응대 완료한 손님 수
    public bool isNextCustomer; //다음 손님이 주문 시작 가능 여부
    public bool isStageClear; //스테이지 클리어(모든 손님 응대 완료) 여부
    public bool isTimeOver; //시간 오버 여부
    public GameObject currentCustomer; //현재 응대 중인 손님을 가르키는 변수
    public GameObject[] customers = new GameObject[5]; //반복 생성할 손님 오브젝트
    public GameObject speechBubble; //주문 말풍선 오브젝트
    Queue<GameObject> customerList = new Queue<GameObject>(); //손님 리스트 큐 생성
    public int availBasicMenuCnt; //스테이지에서 이용 가능한 기본 메뉴 수
    public int availRandomMenuCnt; //스테이지에서 이용 가능한 랜덤 메뉴 수
    public Sprite[] basicMenuImgs = new Sprite[5]; //기본메뉴 스프라이트 배열
    public Sprite[] randomMenuImgs = new Sprite[3]; //랜덤메뉴 스프라이트 배열
    public Sprite[] basicSetMenuImgs = new Sprite[5]; //기본세트메뉴 스프라이트 배열
    public Sprite[] randomSetMenuImgs = new Sprite[3]; //랜덤세트메뉴 스프라이트 배열
    public ParticleSystem successParticleSys;
    public ParticleSystem failParticleSys1;
    public ParticleSystem failParticleSys2;
    public TMP_Text totalCnt;
    public TMP_Text curCnt;
    public GameObject smokeParticleSys; //연기 파티클 시스템 프리팹
    public GameObject pattyUI; //pattyUI 프리팹

    //public PlayResult gameData;
    public GameObject blackPanel;


    void Awake()
    {
        //필요 변수 초기화
        remainCustomerCnt = totalCustomerCnt;
        isNextCustomer = false;
        isStageClear = false;
        //스테이지 총 손님 수만큼 손님 생성 함수 호출
        for (int i = 0; i < totalCustomerCnt; i++)
        {
            GenerateCustomer(i);
        }
        //UI 초기화
        curCnt.text = string.Format("{0:D2}", 0);
        //응대해야하는 총 손님 수 초기화하기
        totalCnt.text = string.Format("/{0:D2}", totalCustomerCnt);

        StartCoroutine(FadeIn());
    }


    void Start()
    {
        //스테이지 시작 시, 큐에서 첫 손님 빼기
        DequeueCustomer();
    }
    void Update()
    {
        if (!isTimeOver)
        {
            //다음 손님 응대가 가능하고 남아있는 손님 수가 0명 이상인 경우
            if (isNextCustomer && remainCustomerCnt >= 0)
            {
                DequeueCustomer(); //큐에서 손님 빼기
                isNextCustomer = false; //지금 막 손님 응대를 시작했으니, 다음 손님 응대는 불가능함.
            }
            //남아있는 손님 수가 0명 미만이고, 아직 스테이지 클리어가 되지 않았다면
            if (remainCustomerCnt < 0 && !isStageClear)
            {
                Debug.Log("STAGE CLEAR");
                isStageClear = true; //스테이지 클리어 여부를 참으로 설정
                Debug.Log(stageNumber);
                DataManager.dataManager.data.isClear[stageNumber] = true;
                DataManager.dataManager.SaveGameData();

                //StartCoroutine(FadeOut());
                //Invoke("back", 3f);
                backtoStageMenu();
            }
        }
        else
        {
            //StartCoroutine(FadeOut());
            //Invoke("back", 3f);
            //backtoStageMenu(3);
            backtoStageMenu();
        }

    }


    void GenerateCustomer(int i) //손님을 생성하는 함수
    {
        GameObject instance;
        switch (i % 5)
        {
            case 0:
                instance = Instantiate(customers[0]);
                break;
            case 1:
                instance = Instantiate(customers[1]);
                break;
            case 2:
                instance = Instantiate(customers[2]);
                break;
            case 3:
                instance = Instantiate(customers[3]);
                break;
            case 4:
                instance = Instantiate(customers[4]);
                break;
            default:
                instance = Instantiate(customers[0]);
                break;
        }
        //생성한 손님을 손님 대기줄 큐에 추가함.
        customerList.Enqueue(instance);
        //생성한 손님을 비활성화
        instance.SetActive(false);
    }
    void DequeueCustomer() //손님 대기줄 큐에서 손님을 빼기(응대 시작하기)
    {
        if (remainCustomerCnt > 0)
        {
            //큐에서 손님을 빼서 현재 응대 손님 변수에 담음.
            currentCustomer = customerList.Dequeue();
            //손님을 활성화
            currentCustomer.SetActive(true);
        }
        remainCustomerCnt--; //새로운 손님 응대를 시작했으니, 남아있는 손님 수 한명 감소
        Debug.Log(remainCustomerCnt);
    }

    public IEnumerator FadeIn()
    {
        Debug.Log("Fade In");
        float fadeCount = 0;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            blackPanel.GetComponent<Image>().color = new Color(0, 0, 0, fadeCount);
        }
        blackPanel.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        Debug.Log("Fade Out");
        blackPanel.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            blackPanel.GetComponent<Image>().color = new Color(0, 0, 0, fadeCount);
        }
    }


    void backtoStageMenu()
    {
        PlayResult.playedStageNum = stageNumber;
        PlayResult.playedStageClear = isStageClear;
        if (isStageClear)
        {
            DataManager.dataManager.data.isClear[stageNumber] = true;
            DataManager.dataManager.SaveGameData();
        }

        SceneManager.LoadScene("Lobby");
    }
}