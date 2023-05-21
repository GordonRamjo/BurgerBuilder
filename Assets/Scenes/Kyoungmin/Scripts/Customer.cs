using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public bool isSetMenu;
    public bool isRandomMenu;
    public bool isSuccess; //���밡 ���������� ����
    public bool isEvaluationEnd; //�� �� ����
    public GameObject destination;
    public Animator customerAnimator;
    public StageManager stageManager;
    public GameObject speechBubble; //��ǳ�� ������Ʈ
    private GameObject speechBubbleInstance;

    Customer()
    {
        //���� �� �ʱ�ȭ
        isSetMenu = false;
        isRandomMenu = false;
        isSuccess = false;
        isEvaluationEnd = false;
    }
    bool IsSetMenu() //��Ʈ�޴� Ȯ��(33%)
    {
        int result = Random.Range(1, 4);
        if (result == 3) return true;
        else return false;
    }
    bool IsRandomMenu() //�����޴� Ȯ��(33%)
    {
        int result = Random.Range(1, 4);
        if (result == 3) return true;
        else return false;
    }
    void move() //������������ �̵�
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 0.005f);
    }
    void makeOrder() //�ֹ��ϱ�
    {
        //�ش� �մ� ������Ʈ�� Order ������Ʈ �߰�
        gameObject.AddComponent<Order>();
        speechBubbleInstance = Instantiate(speechBubble); //��ǳ�� �����ϱ�
   
    }
    void reOrder() //�ֹ� ��䱸�ϱ�
    {
        //���� ��ƼŬ �����ϱ�
        stageManager.failParticleSys1.Stop();
        stageManager.failParticleSys2.Stop();
        string orderMsg = gameObject.GetComponent<Order>().getOrderMsg();
        speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText(orderMsg);
    }
    void Awake()
    {
        //��Ʈ,���� �޴����� ����.
        isSetMenu = IsSetMenu();
        isRandomMenu = IsRandomMenu();
        destination = GameObject.Find("DestinationPoint");
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        speechBubble = stageManager.speechBubble; //��ǳ�� �����ϱ�
    }
    void evaluate() //�մ��� ���� ���ϴ� �Լ�
    {
        //�򰡿� ���� �ڵ�..
        //�򰡰� �������� ���, �ش� �մ��� isSuccess ������ true�� ����
        isSuccess = true;
        stageManager.successParticleSys.Play();
        //�������� ���� ��ƼŬ ������ ���� �߰����� �ڵ�..
        isEvaluationEnd = true;
    }
    void disappear()
    {
        Destroy(gameObject); //�մ� ������Ʈ ����
        Destroy(speechBubbleInstance); //�մ��� ��ǳ�� ����
        //StageManager���� ���� �մ��� �����ص� �ȴٴ� ��ȣ�ֱ�.
        stageManager.isNextCustomer = true;
        Debug.Log("isSuccess");
        stageManager.successParticleSys.Stop();
    }
    void Update()
    {
        move();
        //�մ��� ����(�ֹ�)������ �����ϸ�
        if(transform.position == destination.transform.position && !customerAnimator.GetBool("isStop"))
        {
            //�ȱ� -> ���� �ִϸ��̼����� ����
            customerAnimator.SetBool("isStop", true);
            //�ֹ��ϱ�
            makeOrder();
        }
        
        
        if (isEvaluationEnd)
        {
            //�մԿ��� �ùٸ� ������ ���޵Ǿ��� ���(isSuccess = true)
            if (isSuccess)
            {
                stageManager.successParticleSys.Play();
                isEvaluationEnd = false; //�ݺ������� �������� �ʵ��� false�� ����
                Invoke("disappear", 2f);
                //������ �մ� �� �߰�
                stageManager.completeCustomerCnt = stageManager.completeCustomerCnt + 1;
                //UI ������Ʈ�ϱ�
                stageManager.curCnt.text = string.Format("{0}", stageManager.completeCustomerCnt);

            }
            else //�ùٸ��� ���� ������ ���� �� ���
            {
                //���� ��ƼŬ �����ϱ�
                stageManager.failParticleSys1.Play();
                stageManager.failParticleSys2.Play();
                isEvaluationEnd = false; //�ݺ������� �������� �ʵ��� false�� ����
                speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText("It's not the food I ordered. Please make it again.");
                Invoke("reOrder", 4f);
                Debug.Log("������ �̻���");
            }
        }
         
    }

}
