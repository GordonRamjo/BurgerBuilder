using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger
{
    public enum Ingredient { BottomBread, UpperBread, Lettuce, Cheese, Onion, Tomato, Patty, Pickle };

    public Stack<int> hamburger = new();

    void Add(Ingredient ingredient)
    {
        hamburger.Push((int)ingredient);
    }

    void DeleteAll()
    {
        hamburger.Clear();
    }
}