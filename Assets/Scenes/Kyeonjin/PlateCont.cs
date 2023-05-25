using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCont : MonoBehaviour
{
    public static Hamburger hamburger = new Hamburger(); // �ܹ���
    public bool cola = false; // �ݶ�
    public bool frenchFried = false; // ����Ƣ��
    public bool pattyState = true; // ��Ƽ ���� ����


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(hamburger.hamburger.Count);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Burger"))
        {
            if (collision.gameObject.GetComponent<BurgerIng>().fix == true)
            {
                if (collision.gameObject.transform.tag == "TopBun")
                {
                    Debug.Log("TopBunStacked");
                    AddIngredient(Hamburger.Ingredient.UpperBread);
                    Debug.Log(hamburger.hamburger.Peek());
                }

                else if (collision.gameObject.transform.tag == "Tomato")
                {
                    Debug.Log("TomatoStacked");
                    AddIngredient(Hamburger.Ingredient.Tomato);
                    Debug.Log(hamburger.hamburger.Peek());
                }

                else if (collision.gameObject.transform.tag == "patty")
                {
                    AddPatty(collision.gameObject.GetComponent<PattyController>().patty);
                    //Debug.Log(collision.gameObject.GetComponent<PattyController>().patty.state);
                    AddIngredient(Hamburger.Ingredient.Patty);
                    Debug.Log("PattyStacked");
                    Debug.Log(hamburger.hamburger.Peek());
                }

                else if (collision.gameObject.transform.tag == "Onion")
                {
                    Debug.Log("OnionStacked");
                    AddIngredient(Hamburger.Ingredient.Onion);
                    Debug.Log(hamburger.hamburger.Peek());
                }

                else if (collision.gameObject.transform.tag == "Lettuce")
                {
                    Debug.Log("LettuceStacked");
                    AddIngredient(Hamburger.Ingredient.Lettuce);
                    Debug.Log(hamburger.hamburger.Peek());
                }

                else if (collision.gameObject.transform.tag == "Cheese")
                {
                    Debug.Log("CheeseStacked");
                    AddIngredient(Hamburger.Ingredient.Cheese);
                    Debug.Log(hamburger.hamburger.Peek());
                }

                else if (collision.gameObject.transform.tag == "BottomBun")
                {
                    Debug.Log("BottomBunStacked");
                    AddIngredient(Hamburger.Ingredient.BottomBread);
                    Debug.Log(hamburger.hamburger.Peek());
                }

            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            if (collision.gameObject.GetComponent<Fries>().fix == true)
            {
                AddFrenchFried();
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Coke"))
        {
            if (collision.gameObject.GetComponent<Coke>().fix == true)
            {
                AddCola();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        // 1. Ư�� gameObject �� ������ ���׿��� plate �� ������ ��� (collision ����?)

        // a. gameObject == ingredient �� ���

        // AddIngredient()

        // a-1. Ư�� ingredient �� Patty �� ���

        // AddPatty(Patty patty)

        // b. gameObject == cola �� ���

        // AddCola()

        // c. gameObject == frenchFried �� ���

        // AddFrenchFried()


        // 2. Plate �� Garbage �� ���� ��� (Collision ����?) 

        // Discard()

    }

    // �ܹ��ſ� ��� �߰�
    public void AddIngredient(Hamburger.Ingredient ingredient)
    {
        hamburger.Add(ingredient);
    }

    // �ݶ� �߰�
    public void AddCola()
    {
        cola = true;
    }

    // ����Ƣ�� �߰�
    public void AddFrenchFried()
    {
        frenchFried = true;
    }

    public void AddPatty(Patty patty)
    {
        if (patty.state != Patty.State.Medium)
        {
            pattyState = false;
        }
    }

    // �÷���Ʈ ����
    public void Discard()
    {
        hamburger.DeleteAll();
        Destroy(gameObject); // ���� Plate �� ���̰� ��
    }


}
