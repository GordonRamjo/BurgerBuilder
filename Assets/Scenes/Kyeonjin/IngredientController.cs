using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{
    // 각 재료에 적용할 스크립트

    public Hamburger.Ingredient ingredient; // 재료 정보
    public GameObject plateObject; // 플레이트 gameObject

    void Put() // 재료를 플레이트에 놔두는 함수
    {
        plateObject = GameObject.Find("Plate");
        plateObject.GetComponent<Plate>().IngredientAdd(ingredient);
    }
}
