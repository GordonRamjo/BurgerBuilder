using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRecipePaper : MonoBehaviour
{
    public static bool selectRecipePaper;
    // Start is called before the first frame update
    void Start()
    {
        selectRecipePaper = false;
    }
    public void select()
    {
        selectRecipePaper = true;
    }
}
