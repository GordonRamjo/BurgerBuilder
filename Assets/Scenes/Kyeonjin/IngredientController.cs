using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    // �� ��ῡ ������ ��ũ��Ʈ

    public Hamburger.Ingredient ingredient; // ��� ����
    public GameObject plateObject; // �÷���Ʈ gameObject

    void Put() // ��Ḧ �÷���Ʈ�� ���δ� �Լ�
    {
        plateObject = GameObject.Find("Plate");
        plateObject.GetComponent<Plate>().IngredientAdd(ingredient);
    }
}
