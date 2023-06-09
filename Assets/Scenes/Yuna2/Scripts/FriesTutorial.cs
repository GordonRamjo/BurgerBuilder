using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FriesTutorial : MonoBehaviour
{
    public bool set = false;
    public GameObject friesArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            FriesOnTray();
        }
    }

    private void FriesOnTray()
    {
        this.gameObject.transform.position = new Vector3(friesArea.transform.position.x, friesArea.transform.position.y, friesArea.transform.position.z);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        this.GetComponent<XRGrabInteractable>().enabled = false;
    }
}