using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBin : MonoBehaviour
{
    AudioController audioController; // 사운드 설정

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioController>(); // 사운드 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Burger"))
        {
            // 해당 Ojbect 삭제
            Debug.Log("재료 삭제하기");
            Destroy(other.gameObject);
            audioController.TRASH = true;
        }
    }
}
