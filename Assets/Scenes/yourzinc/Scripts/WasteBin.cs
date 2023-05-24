using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteBin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(other.gameObject);
        }
    }
}
