using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Burger"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = true;
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Burger"))
        {
            other.gameObject.GetComponent<BurgerIng>().set = false;
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
