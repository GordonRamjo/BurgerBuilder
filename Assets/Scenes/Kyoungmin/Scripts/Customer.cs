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
    public int eval;
    public bool isSet;
    Light mainLight; //������ ����
    Light spotLight; //����մ� ����
    public Transform burger;

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
        mainLight = GameObject.Find("������ ����").GetComponent<Light>();
        spotLight = GameObject.Find("Spot Light").GetComponent<Light>();
        burger = GameObject.Find("Burger").transform;

    }
    void evaluate() //�մ��� ���� ���ϴ� �Լ�
    {
        eval = 1;
        Debug.Log("eval");

        Debug.Log("Order count : " + this.GetComponent<Order>().count);
        Debug.Log("Plate count : " + PlateCont.hamburger.hamburger.Count);

        if (isSetMenu == PlateCont.cola && isSetMenu == PlateCont.frenchFried && PlateCont.pattyState)
        {
            if (this.GetComponent<Order>().count == PlateCont.hamburger.hamburger.Count)
            {
                Debug.Log("�񱳽���");
                for (int i = 0; i < this.GetComponent<Order>().count; i++)
                {
                    if (this.gameObject.GetComponent<Order>().hamburger.Peek() == PlateCont.hamburger.hamburger.Peek())
                    {
                        Debug.Log("order" + this.gameObject.GetComponent<Order>().hamburger.Peek() + " " + i);
                        Debug.Log("plate" + PlateCont.hamburger.hamburger.Peek() + " " + i);
                        //Debug.Log("basic" + BasicMenu.BasicBurger.Peek());
                        this.gameObject.GetComponent<Order>().hamburger.Pop();
                        PlateCont.hamburger.hamburger.Pop();
                    }

                    else
                    {
                        eval = 0;
                        break;
                    }
                }

                if (eval == 1)
                {
                    isSuccess = true;
                }
            }
            else
            {
                eval = 0;
            }
        }
        else
        {
            eval = 0;
        }

        /*
        //�򰡿� ���� �ڵ�..
        //�򰡰� �������� ���, �ش� �մ��� isSuccess ������ true�� ����
        isSuccess = true;
        stageManager.successParticleSys.Play();
        //�������� ���� ��ƼŬ ������ ���� �߰����� �ڵ�..
        */

        isEvaluationEnd = true;

        PlateCont.Discard();

        foreach (Transform child in burger)
        {
            Destroy(child.gameObject);
        }
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
        //���� �մ� ���� ��, ������ ������� �ϰ� ������ �Ʒ� �ڵ忡�� �ּ� ������
        if (isRandomMenu /*&& !customerAnimator.GetBool("isStop")*/)
        {
            mainLight.color = Color.black;
            spotLight.intensity = 15;
        }
        else
        {
            mainLight.color = Color.white;
            spotLight.intensity = 0;
        }
        //�մ��� ����(�ֹ�)������ �����ϸ�
        if (transform.position == destination.transform.position && !customerAnimator.GetBool("isStop"))
        {
            //�ȱ� -> ���� �ִϸ��̼����� ����
            customerAnimator.SetBool("isStop", true);
            //�ֹ��ϱ�
            makeOrder();
        }
        if (RingABell.ring == true && customerAnimator.GetBool("isStop"))
        {
            RingABell.ring = false;
            evaluate();
        }


        if (isEvaluationEnd)
        {
            //�մԿ��� �ùٸ� ������ ���޵Ǿ��� ���(isSuccess = true)
            if (isSuccess)
            {
                stageManager.successParticleSys.Play();
                if (isRandomMenu)
                {
                    speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText("Well, you're pretty good.");
                }
                else
                {
                    speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText("I Love it :)");
                }
                isEvaluationEnd = false; //�ݺ������� �������� �ʵ��� false�� ����
                Invoke("disappear", 2f);
                //������ �մ� �� �߰�
                stageManager.completeCustomerCnt = stageManager.completeCustomerCnt + 1;
                //UI ������Ʈ�ϱ�
                stageManager.curCnt.text = string.Format("{0:D2}", stageManager.completeCustomerCnt);

            }
            else //�ùٸ��� ���� ������ ���� �� ���
            {
                //���� ��ƼŬ �����ϱ�
                stageManager.failParticleSys1.Play();
                stageManager.failParticleSys2.Play();
                isEvaluationEnd = false; //�ݺ������� �������� �ʵ��� false�� ����
                if (isRandomMenu)
                {
                    speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText("What are you doing?\nAre you ignoring me?");
                }
                else
                {
                    speechBubbleInstance.GetComponent<SpeechBubbleController>().ChangeText("It's not the food I ordered. Please make it again.");
                }

                Invoke("reOrder", 4f);
                Debug.Log("������ �̻���");
            }
        }

    }

}