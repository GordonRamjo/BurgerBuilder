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
    public StageManager stageManager; //�������� �Ŵ��� ������Ʈ
    private string hamburgerName; //�ܹ��� �̸�
    private Sprite menuImg; //�޴� ��������Ʈ
    private string orderMsg; //�ֹ� �޼���
    private Sprite[] basicMenuImgs;
    private Sprite[] randomMenuImgs;
    private SpeechBubbleController SBC;

    //�⺻ �޴��� �� ����
    Stack<int> ChooseBasicMenu(int r)
    {
        switch (r)
        {
            case 1:
                hamburgerName = "BasicBurger";
                menuImg = basicMenuImgs[0];
                return BasicMenu.BasicBurger;
            case 2:
                hamburgerName = "DoubleCheeseBurger";
                menuImg = basicMenuImgs[1];
                return BasicMenu.DoubleCheeseBurger;
            case 3:
                hamburgerName = "CheeseBurger";
                menuImg = basicMenuImgs[2];
                return BasicMenu.CheeseBurger;
            case 4:
                hamburgerName = "DoublePattyBurger";
                menuImg = basicMenuImgs[3];
                return BasicMenu.DoublePattyBurger;
            case 5:
                hamburgerName = "VeggieBurger";
                menuImg = basicMenuImgs[4];
                return BasicMenu.VeggieBurger;
            default:
                hamburgerName = "Basicburger";
                menuImg = basicMenuImgs[0];
                return BasicMenu.BasicBurger; ;
        }
    }
    //���� �޴��� �� ����
    Stack<int> ChooseRandomMenu(int r)
    {
        switch (r)
        {
            case 1:
                hamburgerName = "BlackBurger";
                menuImg = randomMenuImgs[0];
                return RandomMenu.BlackBurger;
            case 2:
                hamburgerName = "JustPatty";
                menuImg = randomMenuImgs[1];
                return RandomMenu.JustPatty;
            case 3:
                hamburgerName = "JustBread";
                menuImg = randomMenuImgs[2];
                return RandomMenu.JustBread;
            default:
                hamburgerName = "BlackBurger";
                menuImg = randomMenuImgs[3];
                return RandomMenu.BlackBurger;
        }
    }
    void Awake()
    {
        isSetMenu = gameObject.GetComponent<Customer>().isSetMenu;
        isRandomMenu = gameObject.GetComponent<Customer>().isRandomMenu;
        BasicMenu.InitMenu(); // �⺻�޴� ����
        RandomMenu.InitMenu(); // �����޴� ����
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        availBasicMenuCnt = stageManager.availBasicMenuCnt; //��� ���� �⺻ �޴� �� ��������
        availRandomMenuCnt = stageManager.availRandomMenuCnt; //��� ���� ���� �޴� �� ��������
        basicMenuImgs = stageManager.basicMenuImgs;
        randomMenuImgs = stageManager.randomMenuImgs;
        //���� ���ο� ����, �ܹ��� �޴��� �⺻ �޴� �� ���� or ���� �޴� �� ����
        if (isRandomMenu)
        {
            hamburger = ChooseRandomMenu((int)Random.Range(1,availRandomMenuCnt+1));
            //Debug.Log("�����ܹ���");
        }
        else
        {
            hamburger = ChooseBasicMenu((int)Random.Range(1, availBasicMenuCnt+1));
            //Debug.Log("�⺻�ܹ���");
        }
        //Debug.Log(hamburger);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isSetMenu)
        {
            Debug.Log("�ݶ�� ����Ƣ�赵 �ּ���.");
        }
        SBC = GameObject.Find("SpeechBubble(Clone)").GetComponent<SpeechBubbleController>(); //��ǳ�� �����ϱ�

        SBC.ChangeMenuImg(menuImg);
        /*
        SBC.ChangeText();
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
