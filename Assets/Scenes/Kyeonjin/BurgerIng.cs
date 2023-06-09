using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BurgerIng : MonoBehaviour
{
    public bool set = false;
    public bool fix = false;
    public GameObject burgerArea;
    public Transform burger;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        burgerArea = GameObject.Find("BurgerArea");
        burger = GameObject.Find("Burger").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BurgerOnTray()
    {
        if (set)
        {
            this.gameObject.transform.position = new Vector3(burgerArea.transform.position.x, burgerArea.transform.position.y, burgerArea.transform.position.z);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;


            fix = true;
            if (this.gameObject.tag == "TopBun")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.UpperBread);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.topbun -= 1;
            }
            else if (this.gameObject.tag == "Tomato")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.Tomato);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.tomato -= 1;
            }
            else if (this.gameObject.tag == "patty")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.Patty);
                PlateCont.AddPatty(this.gameObject.GetComponent<PattyController>().patty);
                Debug.Log(this.gameObject.GetComponent<PattyController>().patty.state);
                Debug.Log(PlateCont.pattyState);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.patty -= 1;
            }
            else if (this.gameObject.tag == "Onion")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.Onion);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.onion -= 1;
            }
            else if (this.gameObject.tag == "Lettuce")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.Lettuce);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.lettuce -= 1;
            }
            else if (this.gameObject.tag == "Cheese")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.Cheese);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.cheese -= 1;
            }
            else if (this.gameObject.tag == "BottomBun")
            {
                PlateCont.AddIngredient(Hamburger.Ingredient.BottomBread);
                //Debug.Log(PlateCont.hamburger.hamburger.Peek());
                //Debug.Log(PlateCont.hamburger.hamburger.Count);
                Refill.bottombun -= 1;
            }

            this.GetComponent<XRGrabInteractable>().enabled = false;
            this.gameObject.transform.SetParent(burger);
        }
    }
}