using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int stageNumber; //���� �������� ��
    public int totalCustomerCnt; //�������� �� �մ� ��
    private int remainCustomerCnt; //�����ִ� �մ� ��
    public bool isNextCustomer; //���� �մ��� �ֹ� ���� ���� ����
    public bool isStageClear; //�������� Ŭ����(��� �մ� ���� �Ϸ�) ����
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
    void Awake()
    {
        //�ʿ� ���� �ʱ�ȭ
        remainCustomerCnt = totalCustomerCnt;
        isNextCustomer = false;
        isStageClear = false;
        //�������� �� �մ� ����ŭ �մ� ���� �Լ� ȣ��
        for (int i=0; i<totalCustomerCnt; i++)
        {
            GenerateCustomer(i);
        }
        
    }
    void Start()
    {
        //�������� ���� ��, ť���� ù �մ� ����
        DequeueCustomer();
    }
    void Update()
    {
        //���� �մ� ���밡 �����ϰ� �����ִ� �մ� ���� 0�� �̻��� ���
        if (isNextCustomer && remainCustomerCnt >= 0)
        {
            DequeueCustomer(); //ť���� �մ� ����
            isNextCustomer = false; //���� �� �մ� ���븦 ����������, ���� �մ� ����� �Ұ�����.
        }
        //�����ִ� �մ� ���� 0�� �̸��̰�, ���� �������� Ŭ��� ���� �ʾҴٸ�
        if(remainCustomerCnt < 0 && !isStageClear)
        {
            Debug.Log("STAGE CLEAR");
            isStageClear = true; //�������� Ŭ���� ���θ� ������ ����
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
        if(remainCustomerCnt > 0)
        {
            //ť���� �մ��� ���� ���� ���� �մ� ������ ����.
            currentCustomer = customerList.Dequeue();
            //�մ��� Ȱ��ȭ
            currentCustomer.SetActive(true);
        }
        remainCustomerCnt--; //���ο� �մ� ���븦 ����������, �����ִ� �մ� �� �Ѹ� ����
        Debug.Log(remainCustomerCnt);
    }
    
}
