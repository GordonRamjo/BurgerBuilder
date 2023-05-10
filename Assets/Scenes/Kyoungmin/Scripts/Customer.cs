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
    public StageManager stageManager;
    public GameObject speechBubble; //��ǳ�� ������Ʈ
    private GameObject speechBubbleInstance;

    Customer()
    {
        //���� �� �ʱ�ȭ
        isSetMenu = false;
        isRandomMenu = false;
        isSuccess = false;
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
        //�������� ���� ��ƼŬ ������ ���� �߰����� �ڵ�..
        
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
        //�մԿ��� �ùٸ� ������ ���޵Ǿ��� ���(isSuccess = true)
        //StageManager���� ���� �մ��� �����ص� �ȴٴ� ��ȣ�ֱ�.
        if (isSuccess)
        {
            Destroy(gameObject); //�մ� ������Ʈ ����
            Destroy(speechBubbleInstance); //�մ��� ��ǳ�� ����
            stageManager.isNextCustomer = true;
            Debug.Log("isSuccess");
        }
            
    }

}
