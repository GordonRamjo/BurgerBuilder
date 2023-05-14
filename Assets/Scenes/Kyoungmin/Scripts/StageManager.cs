using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int stageNumber; //현재 스테이지 수
    public int totalCustomerCnt; //스테이지 총 손님 수
    private int remainCustomerCnt; //남아있는 손님 수
    public bool isNextCustomer; //다음 손님이 주문 시작 가능 여부
    public bool isStageClear; //스테이지 클리어(모든 손님 응대 완료) 여부
    public GameObject currentCustomer; //현재 응대 중인 손님을 가르키는 변수
    public GameObject customer; //반복 생성할 손님 오브젝트
    public GameObject speechBubble; //주문 말풍선 오브젝트
    Queue<GameObject> customerList = new Queue<GameObject>(); //손님 리스트 큐 생성
    public int availBasicMenuCnt; //스테이지에서 이용 가능한 기본 메뉴 수
    public int availRandomMenuCnt; //스테이지에서 이용 가능한 랜덤 메뉴 수
    public Sprite[] basicMenuImgs; //기본메뉴 스프라이트 배열
    public Sprite[] randomMenuImgs; //랜덤메뉴 스프라이트 배열
    void Awake()
    {
        //필요 변수 초기화
        remainCustomerCnt = totalCustomerCnt;
        isNextCustomer = false;
        isStageClear = false;
        //스테이지 총 손님 수만큼 손님 생성 함수 호출
        for (int i=0; i<totalCustomerCnt; i++)
        {
            GenerateCustomer();
        }
        
    }
    void Start()
    {
        //스테이지 시작 시, 큐에서 첫 손님 빼기
        DequeueCustomer();
    }
    void Update()
    {
        //다음 손님 응대가 가능하고 남아있는 손님 수가 0명 이상인 경우
        if (isNextCustomer && remainCustomerCnt >= 0)
        {
            DequeueCustomer(); //큐에서 손님 빼기
            isNextCustomer = false; //지금 막 손님 응대를 시작했으니, 다음 손님 응대는 불가능함.
        }
        //남아있는 손님 수가 0명 미만이고, 아직 스테이지 클리어가 되지 않았다면
        if(remainCustomerCnt < 0 && !isStageClear)
        {
            Debug.Log("STAGE CLEAR");
            isStageClear = true; //스테이지 클리어 여부를 참으로 설정
        }
    }
    void GenerateCustomer() //손님을 생성하는 함수
    {
        GameObject instance = Instantiate(customer);
        //생성한 손님을 손님 대기줄 큐에 추가함.
        customerList.Enqueue(instance);
        //생성한 손님을 비활성화
        instance.SetActive(false);
    }
    void DequeueCustomer() //손님 대기줄 큐에서 손님을 빼기(응대 시작하기)
    {
        if(remainCustomerCnt > 0)
        {
            //큐에서 손님을 빼서 현재 응대 손님 변수에 담음.
            currentCustomer = customerList.Dequeue();
            //손님을 활성화
            currentCustomer.SetActive(true);
        }
        remainCustomerCnt--; //새로운 손님 응대를 시작했으니, 남아있는 손님 수 한명 감소
        Debug.Log(remainCustomerCnt);
    }
    
}
