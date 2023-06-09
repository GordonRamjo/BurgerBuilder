using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBinTutorial : MonoBehaviour
{
    GuideDialogManager guideDialogManager;
    AudioTutorialController audioController;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioTutorialController>();
        guideDialogManager = GameObject.Find("Dialog").GetComponent<GuideDialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audioController.SfxPlay(AudioTutorialController.SfxTutorial.WASTE);

        if (other.gameObject.layer == LayerMask.NameToLayer("Patty"))
        {
            guideDialogManager.UpdateGuideDialog();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("TopBun") || other.gameObject.layer == LayerMask.NameToLayer("Tomato") || other.gameObject.layer == LayerMask.NameToLayer("Onion") || other.gameObject.layer == LayerMask.NameToLayer("Lettuce") || other.gameObject.layer == LayerMask.NameToLayer("Cheese") || other.gameObject.layer == LayerMask.NameToLayer("BottomBun") || other.gameObject.layer == LayerMask.NameToLayer("Coke") || other.gameObject.layer == LayerMask.NameToLayer("Fries"))
        {
            Destroy(other.gameObject);
        }
    }
}
