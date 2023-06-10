using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public bool isSetMenu; //세트 메뉴 여부
    public bool isRandomMenu; //랜덤 메뉴여부
    public Stack<int> hamburger; //햄버거 메뉴
    //아래의 두 변수는 스테이지에 따라 달라짐
    int availBasicMenuCnt; //가능한 기본 메뉴 수
    int availRandomMenuCnt; //가능한 랜덤 메뉴 수
    public StageManager stageManager; //스테이지 매니저 오브젝트
    private string hamburgerName; //햄버거 이름
    private Sprite menuImg; //메뉴 스프라이트
    private string orderMsg; //주문 메세지
    private Sprite[] basicMenuImgs; //기본 메뉴 스프라이트 배열
    private Sprite[] randomMenuImgs; //랜덤 메뉴 스프라이트 배열
    private Sprite[] basicSetMenuImgs; //기본 세트 메뉴 스프라이트 배열
    private Sprite[] randomSetMenuImgs; //랜덤 세트 메뉴 스프라이트 배열
    private SpeechBubbleController SBC;
    public int count;

    //기본 메뉴들 중 선택
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
    //랜덤 메뉴들 중 선택
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
        BasicMenu.InitMenu(); // 기본메뉴 설정
        RandomMenu.InitMenu(); // 랜덤메뉴 설정
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        availBasicMenuCnt = stageManager.availBasicMenuCnt; //사용 가능 기본 메뉴 수 가져오기
        availRandomMenuCnt = stageManager.availRandomMenuCnt; //사용 가능 랜덤 메뉴 수 가져오기
        basicMenuImgs = stageManager.basicMenuImgs;
        randomMenuImgs = stageManager.randomMenuImgs;
        basicSetMenuImgs = stageManager.basicSetMenuImgs;
        randomSetMenuImgs = stageManager.randomSetMenuImgs;
        //랜덤 여부에 따라, 햄버거 메뉴를 기본 메뉴 중 선택 or 랜덤 메뉴 중 선택

        //hamburger.Clear();

        if (isRandomMenu)
        {
            hamburger = ChooseRandomMenu((int)Random.Range(1, availRandomMenuCnt + 1));
            //Debug.Log("랜덤햄버거");
        }
        else
        {
            hamburger = ChooseBasicMenu((int)Random.Range(1, availBasicMenuCnt + 1));
            //Debug.Log("기본햄버거");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        SBC = GameObject.Find("SpeechBubble(Clone)").GetComponent<SpeechBubbleController>(); //말풍선 가져오기
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
                //진상 버거인 경우 말풍선 글씨 크기 줄이기
                SBC.ChangeSize(1.3f);
            }
            else
            {
                //말풍선 글씨 크기 원상복구
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
