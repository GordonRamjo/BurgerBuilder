using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public bool isSetMenu; //��Ʈ �޴� ����
    public bool isRandomMenu; //���� �޴�����
    public Stack<int> hamburger; //�ܹ��� �޴�
    //�Ʒ��� �� ������ ���������� ���� �޶���
    int availBasicMenuCnt; //������ �⺻ �޴� ��
    int availRandomMenuCnt; //������ ���� �޴� ��
    public StageManager stageManager; //�������� �Ŵ��� ������Ʈ
    private string hamburgerName; //�ܹ��� �̸�
    private Sprite menuImg; //�޴� ��������Ʈ
    private string orderMsg; //�ֹ� �޼���
    private Sprite[] basicMenuImgs; //�⺻ �޴� ��������Ʈ �迭
    private Sprite[] randomMenuImgs; //���� �޴� ��������Ʈ �迭
    private Sprite[] basicSetMenuImgs; //�⺻ ��Ʈ �޴� ��������Ʈ �迭
    private Sprite[] randomSetMenuImgs; //���� ��Ʈ �޴� ��������Ʈ �迭
    private SpeechBubbleController SBC;
    public int count;

    //�⺻ �޴��� �� ����
    Stack<int> ChooseBasicMenu(int r)
    {
        Debug.Log(r);
        switch (r)
        {
            case 1:
                hamburgerName = "BasicBurger";
                count = 5;
                if (isSetMenu)
                    menuImg = basicSetMenuImgs[0];
                else
                    menuImg = basicMenuImgs[0];
                return BasicMenu.BasicBurger;
            case 2:
                hamburgerName = "DoubleCheeseBurger";
                count = 9;
                if (isSetMenu)
                    menuImg = basicSetMenuImgs[1];
                else
                    menuImg = basicMenuImgs[1];
                return BasicMenu.DoubleCheeseBurger;
            case 3:
                hamburgerName = "CheeseBurger";
                count = 4;
                if (isSetMenu)
                    menuImg = basicSetMenuImgs[2];
                else
                    menuImg = basicMenuImgs[2];
                return BasicMenu.CheeseBurger;
            case 4:
                hamburgerName = "DoublePattyBurger";
                count = 10;
                if (isSetMenu)
                    menuImg = basicSetMenuImgs[3];
                else
                    menuImg = basicMenuImgs[3];
                return BasicMenu.DoublePattyBurger;
            case 5:
                hamburgerName = "VeggieBurger";
                count = 7;
                if (isSetMenu)
                    menuImg = basicSetMenuImgs[4];
                else
                    menuImg = basicMenuImgs[4];
                return BasicMenu.VeggieBurger;
            default:
                hamburgerName = "Basicburger";
                count = 5;
                if (isSetMenu)
                    menuImg = basicSetMenuImgs[0];
                else
                    menuImg = basicMenuImgs[0];
                return BasicMenu.BasicBurger; ;
        }
    }
    //���� �޴��� �� ����
    Stack<int> ChooseRandomMenu(int r)
    {
        Debug.Log(r);
        switch (r)
        {
            case 1:
                hamburgerName = "BlackBurger";
                count = 14;
                orderMsg = "I'm just gonna say it once. Add patty, cheese, patty, cheese, onion, tomato, lettuce, patty, cheese, onion, tomato, lettuce in a buns.";
                if (isSetMenu)
                    menuImg = randomSetMenuImgs[0];
                else
                    menuImg = randomMenuImgs[0];
                return RandomMenu.BlackBurger;
            case 2:
                hamburgerName = "JustPatty";
                count = 1;
                orderMsg = "Well, just bake me a patty. You know the right amount of grilling, right?";
                if (isSetMenu)
                    menuImg = randomSetMenuImgs[1];
                else
                    menuImg = randomMenuImgs[1];
                return RandomMenu.JustPatty;
            case 3:
                hamburgerName = "JustBread";
                count = 2;
                orderMsg = "I heard the bread here is so good. Give it to me.";
                if (isSetMenu)
                    menuImg = randomSetMenuImgs[2];
                else
                    menuImg = randomMenuImgs[2];
                return RandomMenu.JustBread;
            default:
                hamburgerName = "BlackBurger";
                count = 14;
                if (isSetMenu)
                    menuImg = randomSetMenuImgs[0];
                else
                    menuImg = randomMenuImgs[0];
                return RandomMenu.BlackBurger;
        }
    }
    public string getOrderMsg()
    {
        return orderMsg;
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
        basicSetMenuImgs = stageManager.basicSetMenuImgs;
        randomSetMenuImgs = stageManager.randomSetMenuImgs;
        //���� ���ο� ����, �ܹ��� �޴��� �⺻ �޴� �� ���� or ���� �޴� �� ����

        //hamburger.Clear();

        if (isRandomMenu)
        {
            hamburger = ChooseRandomMenu((int)Random.Range(1, availRandomMenuCnt + 1));
            //Debug.Log("�����ܹ���");
        }
        else
        {
            hamburger = ChooseBasicMenu((int)Random.Range(1, availBasicMenuCnt + 1));
            //Debug.Log("�⺻�ܹ���");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        SBC = GameObject.Find("SpeechBubble(Clone)").GetComponent<SpeechBubbleController>(); //��ǳ�� ��������
        if (!isRandomMenu)
        {
            if (isSetMenu)
            {
                orderMsg = hamburgerName + " Please.\n" + "Also, Coke and French Fries too.";
            }
            else
            {
                orderMsg = hamburgerName + " Please.";
            }
        }
        else
        {
            if (isSetMenu)
            {
                orderMsg = orderMsg + " Also, Coke and French Fries too.";
            }
            if (hamburgerName == "BlackBurger")
            {
                //���� ������ ��� ��ǳ�� �۾� ũ�� ���̱�
                SBC.ChangeSize(1.3f);
            }
            else
            {
                //��ǳ�� �۾� ũ�� ���󺹱�
                SBC.ChangeSize(1.5f);
            }

        }
        SBC.ChangeMenuImg(menuImg);
        SBC.ChangeText(orderMsg);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
