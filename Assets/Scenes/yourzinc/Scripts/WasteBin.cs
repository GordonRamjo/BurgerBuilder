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

            if(this.gameObject.tag == "TopBun")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.topbun -= 1;
                audioController.TRASH = true;
            }

            else if(other.gameObject.tag == "Tomato")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.tomato -= 1;
                audioController.TRASH = true;
            }

            else if(other.gameObject.tag == "patty")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.patty -= 1;
                audioController.TRASH = true;
            }

            else if(other.gameObject.tag == "Onion")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.onion -= 1;
                audioController.TRASH = true;
            }

            else if(other.gameObject.tag == "Lettuce")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.lettuce -= 1;
                audioController.TRASH = true;
            }

            else if(other.gameObject.tag == "Cheese")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.cheese -= 1;
                audioController.TRASH = true;
            }

            else if(other.gameObject.tag == "BottomBun")
            {
                Debug.Log("��� �����ϱ�");
                Destroy(other.gameObject);
                Refill.bottombun -= 1;
                audioController.TRASH = true;
            }
        }
    }
}
