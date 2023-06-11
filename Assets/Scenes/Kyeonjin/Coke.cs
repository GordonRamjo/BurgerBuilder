using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Coke : MonoBehaviour
{

    public bool set = false;
    public bool fix = false;
    public GameObject cokeArea;
    public Transform burger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        burger = GameObject.Find("Burger").transform;
    }

    public void CokeOnTray()
    {
        if (set)
        {
            this.gameObject.transform.position = new Vector3(cokeArea.transform.position.x, cokeArea.transform.position.y, cokeArea.transform.position.z);
            this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            this.GetComponent<XRGrabInteractable>().enabled = false;
            this.gameObject.transform.SetParent(burger);
            fix = true;
        }
    }
}