using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaceTutorial : MonoBehaviour
{
    GuideDialogManager guideDialogManager;
    AudioTutorialController audioController;
    private LayerMask[] defaultBurgerList;
    private int ingredientNum = 0;
    private PattyState pattyState;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioTutorialController>();
        guideDialogManager = GameObject.Find("Dialog").GetComponent<GuideDialogManager>();

        defaultBurgerList = new LayerMask[]
        {
            LayerMask.NameToLayer("BottomBun"),
            LayerMask.NameToLayer("Patty"),
            LayerMask.NameToLayer("Tomato"),
            LayerMask.NameToLayer("Lettuce"),
            LayerMask.NameToLayer("TopBun"),
            LayerMask.NameToLayer("Coke"),
            LayerMask.NameToLayer("Fries")
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coke") && other.gameObject.layer == defaultBurgerList[ingredientNum])
        {
            audioController.SfxPlay(AudioTutorialController.SfxTutorial.SUCCESS);
            other.gameObject.GetComponent<CokeTutorial>().set = true;
            ingredientNum++;
            guideDialogManager.UpdateGuideDialog();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Fries") && other.gameObject.layer == defaultBurgerList[ingredientNum])
        {
            audioController.SfxPlay(AudioTutorialController.SfxTutorial.SUCCESS);
            other.gameObject.GetComponent<FriesTutorial>().set = true;
            guideDialogManager.UpdateGuideDialog();
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Patty"))
        {
            if (pattyState == PattyState.Medium && other.gameObject.layer == defaultBurgerList[ingredientNum])
            {
                audioController.SfxPlay(AudioTutorialController.SfxTutorial.SUCCESS);
                other.gameObject.GetComponent<BurgeringTutorial>().set = true;
                ingredientNum++;
                guideDialogManager.UpdateGuideDialog();
            }
        }
        else {
            if (other.gameObject.layer == defaultBurgerList[ingredientNum])
            {
                audioController.SfxPlay(AudioTutorialController.SfxTutorial.SUCCESS);
                other.gameObject.GetComponent<BurgeringTutorial>().set = true;
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

    public void GetPattyState(PattyState state)
    {
        pattyState = state;
        Debug.Log("Patty State: " + pattyState);
    }
}
