using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public bool isSetMenu;
    public bool isRandomMenu;
    public bool isSuccess;
    public GameObject destination;
    public Animator customerAnimator;
    public GameObject stageManager;

    Customer()
    {
        //생성 시 초기화
        isSetMenu = false;
        isRandomMenu = false;
        isSuccess = false;
    }
    bool IsSetMenu() //세트메뉴 확률(33%)
    {
        int result = Random.Range(1, 4);
        if (result == 3) return true;
        else return false;
    }
    bool IsRandomMenu() //랜덤메뉴 확률(33%)
    {
        int result = Random.Range(1, 4);
        if (result == 3) return true;
        else return false;
    }
    void move() //도착지점까지 이동
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 0.005f);
    }
    void makeOrder() //주문하기
    {
        //해당 손님 오브젝트에 Order 컴포넌트 추가
        gameObject.AddComponent<Order>();
    }
    void Awake()
    {
        //세트,랜덤 메뉴인지 결정.
        isSetMenu = IsSetMenu();
        isRandomMenu = IsRandomMenu();
        //도착지점과,스테이지 매니저 찾아서 할당.
        destination = GameObject.Find("DestinationPoint");
        stageManager = GameObject.Find("StageManager");
    }
    void evaluate() //손님이 음식 평가하는 함수
    {
        //평가에 대한 코드..
        //평가가 성공적인 경우, 해당 손님의 isSuccess 변수를 true로 변경
        isSuccess = true;
        //성공했을 때의 파티클 반응과 같은 추가적인 코드..
        
    }
    void Update()
    {
        move();
        //손님이 도착(주문)지점에 도착하면
        if(transform.position == destination.transform.position && !customerAnimator.GetBool("isStop"))
        {
            //걷기 -> 정지 애니메이션으로 변경
            customerAnimator.SetBool("isStop", true);
            //주문하기
            makeOrder();
        }
        //손님에게 올바른 음식이 전달되었을 경우(isSuccess = true)
        //StageManager에게 다음 손님을 맞이해도 된다는 신호주기.
        if (isSuccess)
        {
            gameObject.SetActive(false);
            stageManager.GetComponent<StageManager>().isNextCustomer = true;
            Debug.Log("isSuccess");
        }
            
    }

}
