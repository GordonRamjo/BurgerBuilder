// Plate.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour

{
    Hamburger hamburger = new Hamburger(); // 햄버거
    bool Cola = false;
    bool FrenchFried = false;
    //PatteState patteState;

    public void IngredientAdd(Hamburger.Ingredient ingredient)
    {
        hamburger.Add(ingredient); // 햄버거에 재료 추가
    }

    public void Discard()
    {
        hamburger.DeleteAll(); // 햄버거 삭제
        Destroy(gameObject); // 현재 Plate 삭제
    }
}