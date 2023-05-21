using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public bool isSetMenu;
    public bool isRandomMenu;
    public bool isSuccess; //응대가 성공적인지 여부
    public bool isEvaluationEnd; //평가 끝 여부
    public GameObject destination;
    public Animator customerAnimator;
    public StageManager stageManager;
    public GameObject speechBubble; //말풍선 오브젝트
    private GameObject speechBubbleInstance;

    Customer()
    {
        //생성 시 초기화
        isSetMenu = false;
        isRandomMenu = false;
        isSuccess = false;
        isEvaluationEnd = false;
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
        speechBubbleInstance = Instantiate(speechBubble); //말풍선 생성하기
   
    }
    void reOrder() //주문 재요구하기
    {
        //실패 파티클 정지하기
        stageManager.failParticleSys1.Stop();
        stageManager.failParticleSys2.Stop();
        string orderMsg = gameObject.GetComponent<Order>().getOrderMsg();
        speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText(orderMsg);
    }
    void Awake()
    {
        //세트,랜덤 메뉴인지 결정.
        isSetMenu = IsSetMenu();
        isRandomMenu = IsRandomMenu();
        destination = GameObject.Find("DestinationPoint");
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        speechBubble = stageManager.speechBubble; //말풍선 접근하기
    }
    void evaluate() //손님이 음식 평가하는 함수
    {
        //평가에 대한 코드..
        //평가가 성공적인 경우, 해당 손님의 isSuccess 변수를 true로 변경
        isSuccess = true;
        stageManager.successParticleSys.Play();
        //성공했을 때의 파티클 반응과 같은 추가적인 코드..
        isEvaluationEnd = true;
    }
    void disappear()
    {
        Destroy(gameObject); //손님 오브젝트 삭제
        Destroy(speechBubbleInstance); //손님의 말풍선 삭제
        //StageManager에게 다음 손님을 맞이해도 된다는 신호주기.
        stageManager.isNextCustomer = true;
        Debug.Log("isSuccess");
        stageManager.successParticleSys.Stop();
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
        
        
        if (isEvaluationEnd)
        {
            //손님에게 올바른 음식이 전달되었을 경우(isSuccess = true)
            if (isSuccess)
            {
                stageManager.successParticleSys.Play();
                isEvaluationEnd = false; //반복적으로 반응하지 않도록 false로 변경
                Invoke("disappear", 2f);
                //응대한 손님 수 추가
                stageManager.completeCustomerCnt = stageManager.completeCustomerCnt + 1;
                //UI 업데이트하기
                stageManager.curCnt.text = string.Format("{0}", stageManager.completeCustomerCnt);

            }
            else //올바르지 않은 음식이 전달 된 경우
            {
                //실패 파티클 실행하기
                stageManager.failParticleSys1.Play();
                stageManager.failParticleSys2.Play();
                isEvaluationEnd = false; //반복적으로 반응하지 않도록 false로 변경
                speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText("It's not the food I ordered. Please make it again.");
                Invoke("reOrder", 4f);
                Debug.Log("음식이 이상해");
            }
        }
         
    }

}
