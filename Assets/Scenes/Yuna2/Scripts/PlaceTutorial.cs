using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaceTutorial : MonoBehaviour
{
    public GuideDialogManager guideDialogManager;
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Coke"))
        {
            other.gameObject.GetComponent<CokeTutorial>().set = true;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            other.gameObject.GetComponent<FriesTutorial>().set = true;
        }
        else
        {
            if (other.gameObject.layer == defaultBurgerList[ingredientNum])
            {
                other.gameObject.GetComponent<BurgeringTutorial>().set = true;
                other.GetComponent<XRGrabInteractable>().enabled = false;
                ingredientNum++;
                guideDialogManager.UpdateGuideDialog();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coke"))
        {
            other.gameObject.GetComponent<CokeTutorial>().set = false;
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            other.gameObject.GetComponent<FriesTutorial>().set = false;
        }
        else
        {
            other.gameObject.GetComponent<BurgeringTutorial>().set = false;
        }
    }
}
