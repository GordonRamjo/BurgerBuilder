using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BasicMenu.InitMenu(); // 기본메뉴 설정
        RandomMenu.InitMenu(); // 랜덤메뉴 설정

        // 메뉴

        // 기본버거 ; BasicMenu.BasicBurger 
        // 더블치즈버거 : BasicMenu.DoubleCheeseBurger
        // 치즈버거 : BasicMenu.CheeseBurger
        // 더블패티버거 : BasicMenu.DoublePattyBurger
        // 베지버거 : BasicMenu.VeggieBurger

        // 랜덤 메뉴

        // 진상버거 : RandomMenu.BlackBurger
        // 패티만 : RandomMenu.JustPatty
        // 빵만 : RandomMenu.JustBread

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
