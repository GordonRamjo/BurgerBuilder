using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingABell : MonoBehaviour
{
    public static bool ring;
    public Transform burger;

    // Start is called before the first frame update
    void Start()
    {
        ring = false;
    }

    public void Ring()
    {
        ring = true;
        Debug.Log(ring);
    }

    
    
}
