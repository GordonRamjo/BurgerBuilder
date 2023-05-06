using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public bool isSetMenu;
    public bool isRandomMenu;

    void Awake()
    {
        isSetMenu = gameObject.GetComponent<Customer>().isSetMenu;
        isRandomMenu = gameObject.GetComponent<Customer>().isRandomMenu;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
