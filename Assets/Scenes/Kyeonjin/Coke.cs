using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Coke : MonoBehaviour
{

    public bool set = false;
    public GameObject cokeArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CokeOnTray()
    {
        if (set)
        {
            this.gameObject.transform.position = new Vector3(cokeArea.transform.position.x, cokeArea.transform.position.y, cokeArea.transform.position.z);
            this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            this.GetComponent<XRGrabInteractable>().enabled = false;
        }
    }
}

