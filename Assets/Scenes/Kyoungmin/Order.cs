using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public bool isSetMenu; //��Ʈ �޴� ����
    public bool isRandomMenu; //���� �޴�����
    public static Stack<int> hamburger; //�ܹ��� �޴�
    //�Ʒ��� �� ������ ���������� ���� �޶���
    int availBasicMenuCnt; //������ �⺻ �޴� ��
    int availRandomMenuCnt; //������ ���� �޴� ��
    public GameObject stageManager; //�������� �Ŵ��� ������Ʈ

    //�⺻ �޴��� �� ����
    Stack<int> ChooseBasicMenu(int r)
    {
        switch (r)
        {
            case 1:
                return BasicMenu.BasicBurger;
            case 2:
                return BasicMenu.DoubleCheeseBurger;
            case 3:
                return BasicMenu.CheeseBurger;
            case 4:
                return BasicMenu.DoublePattyBurger;
            case 5:
                return BasicMenu.VeggieBurger;
            default:
                return BasicMenu.BasicBurger; ;
        }
    }
    //���� �޴��� �� ����
    Stack<int> ChooseRandomMenu(int r)
    {
        switch (r)
        {
            case 1:
                return RandomMenu.BlackBurger;
            case 2:
                return RandomMenu.JustPatty;
            case 3:
                return RandomMenu.JustBread;
            default:
                return RandomMenu.BlackBurger;
        }
    }
    void Awake()
    {
        isSetMenu = gameObject.GetComponent<Customer>().isSetMenu;
        isRandomMenu = gameObject.GetComponent<Customer>().isRandomMenu;
        BasicMenu.InitMenu(); // �⺻�޴� ����
        RandomMenu.InitMenu(); // �����޴� ����
        stageManager = GameObject.Find("StageManager"); //�������� �Ŵ��� ����Ű��
        availBasicMenuCnt = stageManager.GetComponent<StageManager>().availBasicMenuCnt; //��� ���� �⺻ �޴� �� ��������
        availRandomMenuCnt = stageManager.GetComponent<StageManager>().availRandomMenuCnt; //��� ���� ���� �޴� �� ��������

        //���� ���ο� ����, �ܹ��� �޴��� �⺻ �޴� �� ���� or ���� �޴� �� ����
        if (isRandomMenu)
        {
            hamburger = ChooseRandomMenu((int)Random.Range(1,availRandomMenuCnt+1));
            Debug.Log("�����ܹ���");
        }
        else
        {
            hamburger = ChooseBasicMenu((int)Random.Range(1, availBasicMenuCnt+1));
            Debug.Log("�⺻�ܹ���");
        }
        Debug.Log(hamburger);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isSetMenu)
        {
            Debug.Log("�ݶ�� ����Ƣ�赵 �ּ���.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
