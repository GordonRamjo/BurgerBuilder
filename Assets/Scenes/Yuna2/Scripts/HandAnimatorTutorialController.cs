using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimatorTutorialController : MonoBehaviour
{
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private InputActionProperty gripAction;
    private Animator anim;
    private bool isFirstExecute = true;
    AudioTutorialController audioController;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioController = GameObject.Find("SoundCube").GetComponent<AudioTutorialController>();
    }

    private void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();
        float gripValue = gripAction.action.ReadValue<float>();

        anim.SetFloat("Trigger", triggerValue);
        anim.SetFloat("Grip", gripValue);

        if (gripValue > 0.9 && isFirstExecute)
        {
            isFirstExecute = false;
            audioController.SfxPlay(AudioTutorialController.SfxTutorial.GRAB);
        }
        else if (gripValue > 0 && gripValue < 0.1 && !isFirstExecute)
        {
            isFirstExecute = true;
            audioController.SfxPlay(AudioTutorialController.SfxTutorial.DROP);
        }
    }
}
