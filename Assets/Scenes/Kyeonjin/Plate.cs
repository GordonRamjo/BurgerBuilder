// Plate.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour

{
    Hamburger hamburger = new Hamburger(); // �ܹ���
    bool Cola = false;
    bool FrenchFried = false;
    //PatteState patteState;

    public void IngredientAdd(Hamburger.Ingredient ingredient)
    {
        hamburger.Add(ingredient); // �ܹ��ſ� ��� �߰�
    }

    public void Discard()
    {
        hamburger.DeleteAll(); // �ܹ��� ����
        Destroy(gameObject); // ���� Plate ����
    }
}