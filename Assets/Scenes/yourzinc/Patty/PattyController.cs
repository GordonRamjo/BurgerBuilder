using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PattyController : MonoBehaviour
{
    public Patty patty;
    public bool isStart = false;
    public bool isBaking = false;

    // Patty Material
    public Material[] RareMaterial;
    public Material[] MediumMaterial;
    public Material[] BurnMaterial;


    // Start is called before the first frame update
    void Start()
    {
        patty = new Patty();
        gameObject.GetComponent<MeshRenderer>().materials = RareMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart && isBaking)
        {
            if (patty.state == Patty.State.Rare)
            {
                // 5초 뒤
                StartCoroutine("After5Second");
            }
            else if (patty.state == Patty.State.Medium)
            {
                // 10초 뒤
                StartCoroutine("After10Second");
            }
        }
    }

    IEnumerator After5Second()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        if (isBaking)
        {
            Debug.Log("After5Second");
            patty.Medium();
            gameObject.GetComponent<MeshRenderer>().materials = MediumMaterial;
        }

    }

    IEnumerator After10Second()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        if (isBaking)
        {
            Debug.Log("After10Second");
            patty.Burned();
            gameObject.GetComponent<MeshRenderer>().materials = BurnMaterial;
        }
    }

}