using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    Hamburger hamburger = new Hamburger(); // 햄버거
    bool cola = false; // 콜라
    bool frenchFried = false; // 감자튀김
    bool pattyState = true; // 패티 굽기 정도

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1. 특정 gameObject 를 선택한 상테에서 plate 를 선택한 경우 (collision 설정?)

        // a. gameObject == ingredient 인 경우

        // AddIngredient()

        // a-1. 특정 ingredient 가 Patty 인 경우

        // AddPatty(Patty patty)

        // b. gameObject == cola 인 경우

        // AddCola()

        // c. gameObject == frenchFried 인 경우

        // AddFrenchFried()


        // 2. Plate 가 Garbage 랑 만난 경우 (Collision 설정?) 

        // Discard()
    }

    // 햄버거에 재료 추가
    public void AddIngredient(Hamburger.Ingredient ingredient)
    {
        hamburger.Add(ingredient); 
    }

    // 콜라 추가
    public void AddCola()
    {
        cola = true;
    }

    // 감자튀김 추가
    public void AddFrenchFried()
    {
        frenchFried = true;
    }

    public void AddPatty(Patty patty)
    {
        if (patty.state != Patty.State.Medium)
        {
            pattyState = false;
        }
    }

    // 플레이트 삭제
    public void Discard()
    {
        hamburger.DeleteAll();
        Destroy(gameObject); // 현재 Plate 안 보이게 함
    }

}
