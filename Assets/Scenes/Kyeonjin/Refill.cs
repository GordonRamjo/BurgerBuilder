using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : MonoBehaviour
{
    public static int bottombun, topbun, patty, lettuce, tomato, cheese, onion;
    public GameObject bottombuns, topbuns, patties, lettuces, tomatoes, cheeses, onions;
    public Transform bbplate, tbplate, pplate, lplate, tplate, cplate, oplate;

    // Start is called before the first frame update
    void Start()
    {
        bottombun = 5;
        topbun = 4;
        patty = 5;
        lettuce = 5;
        tomato = 5;
        cheese = 5;
        onion = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(bottombun == 0 )
        {
            bottombun = 5;
            Instantiate(bottombuns, bbplate);
        }

        else if(topbun == 0)
        {
            topbun = 4;
            Instantiate(topbuns, tbplate);
        }

        else if(patty == 0)
        {
            patty = 5;
            Instantiate(patties, pplate);
        }

        else if(lettuce == 0)
        {
            lettuce = 5;
            Instantiate(lettuces, lplate);
        }

        else if(tomato == 0)
        {
            tomato = 5;
            Instantiate(tomatoes, tplate);
        }

        else if(cheese == 0)
        {
            cheese = 5;
            Instantiate(cheeses, cplate);
        }

        else if(onion == 0)
        {
            onion = 5;
            Instantiate(onions, oplate);
        }
    }
}
