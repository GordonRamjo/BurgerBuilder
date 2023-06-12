using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHamburgerUI : MonoBehaviour
{
    public static bool selectHamburgerUI;
    // Start is called before the first frame update
    void Start()
    {
        selectHamburgerUI = false;
    }
    public void select()
    {
        selectHamburgerUI = true;
    }
}
