using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaceTutorial : MonoBehaviour
{
    private LayerMask[] defaultBurgerList;
    private int ingredientNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultBurgerList = new LayerMask[]
        {
            LayerMask.NameToLayer("BottomBun"),
            LayerMask.NameToLayer("Patty"),
            LayerMask.NameToLayer("Tomato"),
            LayerMask.NameToLayer("Lettuce"),
            LayerMask.NameToLayer("TopBun")
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BottomBun"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = true;
        } 
        else if (other.gameObject.layer == LayerMask.NameToLayer("Patty"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tomato"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Lettuce"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("TopBun"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Coke"))
        {
            other.gameObject.GetComponent<Coke>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            other.gameObject.GetComponent<Fries>().set = true;
        }

        if (defaultBurgerList[ingredientNum] == other.gameObject.layer)
        {
            other.GetComponent<XRGrabInteractable>().enabled = false;
            Debug.Log("ภ฿ตส");
            ingredientNum++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BottomBun"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = false;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Patty"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = false;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tomato"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = false;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Lettuce"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = false;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("TopBun"))
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = false;
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
