using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BurgeringTutorial : MonoBehaviour
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
        if (set)
        {
            IngredientOnTray();
        }
    }

    private void IngredientOnTray()
    {
        Debug.Log("»Æ¿Œ");
        this.gameObject.transform.position = new Vector3(burgerArea.transform.position.x, burgerArea.transform.position.y, burgerArea.transform.position.z);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }
}
