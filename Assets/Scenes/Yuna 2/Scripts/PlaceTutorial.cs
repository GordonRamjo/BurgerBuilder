using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BottomBun"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = true;
            Debug.Log("BottomBun");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Patty"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = true;
            Debug.Log("Patty");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tomato"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = true;
            Debug.Log("Tomato");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Lettuce"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = true;
            Debug.Log("Lettuce");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("TopBun"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = true;
            Debug.Log("TopBun");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Coke"))
        {
            other.gameObject.GetComponent<Coke>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            other.gameObject.GetComponent<Fries>().set = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BottomBun"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = false;
            Debug.Log("BottomBun");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Patty"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = false;
            Debug.Log("Patty");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tomato"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = false;
            Debug.Log("Tomato");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Lettuce"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = false;
            Debug.Log("Lettuce");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("TopBun"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = false;
            Debug.Log("TopBun");
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Coke"))
        {
            other.gameObject.GetComponent<Coke>().set = false;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            other.gameObject.GetComponent<Fries>().set = false;
        }
    }
}
