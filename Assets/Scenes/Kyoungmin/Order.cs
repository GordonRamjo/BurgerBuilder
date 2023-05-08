using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public bool isSetMenu; //세트 메뉴 여부
    public bool isRandomMenu; //랜덤 메뉴여부
    public static Stack<int> hamburger; //햄버거 메뉴
    //아래의 두 변수는 스테이지에 따라 달라짐
    int availBasicMenuCnt; //가능한 기본 메뉴 수
    int availRandomMenuCnt; //가능한 랜덤 메뉴 수
    public GameObject stageManager; //스테이지 매니저 오브젝트

    //기본 메뉴들 중 선택
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
    //랜덤 메뉴들 중 선택
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
        BasicMenu.InitMenu(); // 기본메뉴 설정
        RandomMenu.InitMenu(); // 랜덤메뉴 설정
        stageManager = GameObject.Find("StageManager"); //스테이지 매니저 가르키기
        availBasicMenuCnt = stageManager.GetComponent<StageManager>().availBasicMenuCnt; //사용 가능 기본 메뉴 수 가져오기
        availRandomMenuCnt = stageManager.GetComponent<StageManager>().availRandomMenuCnt; //사용 가능 랜덤 메뉴 수 가져오기

        //랜덤 여부에 따라, 햄버거 메뉴를 기본 메뉴 중 선택 or 랜덤 메뉴 중 선택
        if (isRandomMenu)
        {
            hamburger = ChooseRandomMenu((int)Random.Range(1,availRandomMenuCnt+1));
            Debug.Log("랜덤햄버거");
        }
        else
        {
            hamburger = ChooseBasicMenu((int)Random.Range(1, availBasicMenuCnt+1));
            Debug.Log("기본햄버거");
        }
        Debug.Log(hamburger);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isSetMenu)
        {
            Debug.Log("콜라와 감자튀김도 주세요.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
