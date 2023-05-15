using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public GameObject bun, area;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(bun);
            //Instantiate(bun, new Vector3(area.transform.position.x, area.transform.position.y, area.transform.position.z), Quaternion.identity);
        }
    }
}
