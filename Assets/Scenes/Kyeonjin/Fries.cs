using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Fries : MonoBehaviour
{
    public bool set = false;
    public bool fix = false;
    public GameObject friesArea;
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

    public void FriesOnTray()
    {
        if (set)
        {
            this.gameObject.transform.position = new Vector3(friesArea.transform.position.x, friesArea.transform.position.y, friesArea.transform.position.z);
            this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            this.GetComponent<XRGrabInteractable>().enabled = false;
            this.gameObject.transform.SetParent(burger);
            fix = true;
        }
    }
}
