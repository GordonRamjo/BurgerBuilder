using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{
    public int stageNumber; //���� �������� ��
    public int totalCustomerCnt; //�������� �� �մ� ��
    private int remainCustomerCnt; //�����ִ� �մ� ��
    public int completeCustomerCnt; //���� �Ϸ��� �մ� ��
    public bool isNextCustomer; //���� �մ��� �ֹ� ���� ���� ����
    public bool isStageClear; //�������� Ŭ����(��� �մ� ���� �Ϸ�) ����
    public bool isTimeOver; //�ð� ���� ����
    public GameObject currentCustomer; //���� ���� ���� �մ��� ����Ű�� ����
    public GameObject[] customers = new GameObject[5]; //�ݺ� ������ �մ� ������Ʈ
    public GameObject speechBubble; //�ֹ� ��ǳ�� ������Ʈ
    Queue<GameObject> customerList = new Queue<GameObject>(); //�մ� ����Ʈ ť ����
    public int availBasicMenuCnt; //������������ �̿� ������ �⺻ �޴� ��
    public int availRandomMenuCnt; //������������ �̿� ������ ���� �޴� ��
    public Sprite[] basicMenuImgs = new Sprite[5]; //�⺻�޴� ��������Ʈ �迭
    public Sprite[] randomMenuImgs = new Sprite[3]; //�����޴� ��������Ʈ �迭
    public Sprite[] basicSetMenuImgs = new Sprite[5]; //�⺻��Ʈ�޴� ��������Ʈ �迭
    public Sprite[] randomSetMenuImgs = new Sprite[3]; //������Ʈ�޴� ��������Ʈ �迭
    public ParticleSystem successParticleSys;
    public ParticleSystem failParticleSys1;
    public ParticleSystem failParticleSys2;
    public TMP_Text totalCnt;
    public TMP_Text curCnt;
    public GameObject smokeParticleSys; //���� ��ƼŬ �ý��� ������
    public GameObject pattyUI; //pattyUI ������

    //public PlayResult gameData;
    public GameObject blackPanel;


    void Awake()
    {
        //�ʿ� ���� �ʱ�ȭ
        remainCustomerCnt = totalCustomerCnt;
        isNextCustomer = false;
        isStageClear = false;
        //�������� �� �մ� ����ŭ �մ� ���� �Լ� ȣ��
        for (int i = 0; i < totalCustomerCnt; i++)
        {
            GenerateCustomer(i);
        }
        //UI �ʱ�ȭ
        curCnt.text = string.Format("{0:D2}", 0);
        //�����ؾ��ϴ� �� �մ� �� �ʱ�ȭ�ϱ�
        totalCnt.text = string.Format("/{0:D2}", totalCustomerCnt);

        StartCoroutine(FadeIn());
    }


    void Start()
    {
        //�������� ���� ��, ť���� ù �մ� ����
        DequeueCustomer();
    }
    void Update()
    {
        if (!isTimeOver)
        {
            //���� �մ� ���밡 �����ϰ� �����ִ� �մ� ���� 0�� �̻��� ���
            if (isNextCustomer && remainCustomerCnt >= 0)
            {
                DequeueCustomer(); //ť���� �մ� ����
                isNextCustomer = false; //���� �� �մ� ���븦 ����������, ���� �մ� ����� �Ұ�����.
            }
            //�����ִ� �մ� ���� 0�� �̸��̰�, ���� �������� Ŭ��� ���� �ʾҴٸ�
            if (remainCustomerCnt < 0 && !isStageClear)
            {
                Debug.Log("STAGE CLEAR");
                isStageClear = true; //�������� Ŭ���� ���θ� ������ ����
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


    void GenerateCustomer(int i) //�մ��� �����ϴ� �Լ�
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
        //������ �մ��� �մ� ����� ť�� �߰���.
        customerList.Enqueue(instance);
        //������ �մ��� ��Ȱ��ȭ
        instance.SetActive(false);
    }
    void DequeueCustomer() //�մ� ����� ť���� �մ��� ����(���� �����ϱ�)
    {
        if (remainCustomerCnt > 0)
        {
            //ť���� �մ��� ���� ���� ���� �մ� ������ ����.
            currentCustomer = customerList.Dequeue();
            //�մ��� Ȱ��ȭ
            currentCustomer.SetActive(true);
        }
        remainCustomerCnt--; //���ο� �մ� ���븦 ����������, �����ִ� �մ� �� �Ѹ� ����
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