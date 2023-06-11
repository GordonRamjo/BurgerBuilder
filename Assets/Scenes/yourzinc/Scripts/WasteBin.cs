using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBin : MonoBehaviour
{
    AudioController audioController; // ���� ����

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("SoundCube").GetComponent<AudioController>(); // ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Burger"))
        {
            // �ش� Ojbect ����
            Debug.Log("��� �����ϱ�");
            Destroy(other.gameObject);
            audioController.TRASH = true;
        }
    }
}
