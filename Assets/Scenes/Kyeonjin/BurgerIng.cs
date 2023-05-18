using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BurgerIng : MonoBehaviour
{
    public bool set = false;
    public GameObject burgerArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BurgerOnTray()
    {
        if (set)
        {
            this.gameObject.transform.position = new Vector3(burgerArea.transform.position.x, burgerArea.transform.position.y, burgerArea.transform.position.z);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
            this.GetComponent<XRGrabInteractable>().enabled = false;

        }
    }
}
