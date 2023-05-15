using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    public GameObject DropArea;
    Vector3 offset;
    //public string destTag;
    public int set = 0;

    /*
    private void OnMouseUp()
    {
        if (set == 0)
        {
            var rayOrigin = Camera.main.transform.position;
            var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
            {
                if (hitInfo.transform.tag == "Tray")
                {
                    Debug.Log("reached ray");
                    set = 1;
                    transform.position = new Vector3(DropArea.transform.position.x, DropArea.transform.position.y, DropArea.transform.position.z);
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ; ;
                }
            }
            transform.GetComponent<Collider>().enabled = true;
        }
    }*/

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void OnMouseDown()
    {
        if (set == 0)
        {
            offset = transform.position - MouseWorldPosition();
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (set == 0)
        {
            if (other.gameObject.name == "Tray")
            {
                Debug.Log("collision detected");
                set = 1;
                this.transform.position = new Vector3(DropArea.transform.position.x, DropArea.transform.position.y, DropArea.transform.position.z);
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

                //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }

            if (other.gameObject.name == "TrashCan")
            {
                Destroy(this.gameObject);
            }

            transform.GetComponent<Collider>().enabled = true;
        }

    }*/

    private void OnMouseDrag()
    {
        if (set == 0)
        {
            transform.position = MouseWorldPosition() + offset;

            var rayOrigin = Camera.main.transform.position;
            var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
            {
                if (hitInfo.transform.tag == "Tray")
                {
                    Debug.Log("reached ray");
                    set = 1;
                    transform.position = new Vector3(DropArea.transform.position.x, DropArea.transform.position.y, DropArea.transform.position.z);
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ; ;
                }
            }
            transform.GetComponent<Collider>().enabled = true;
        }
        //transform.position = MouseWorldPosition() + offset;
        

    }
}


    

