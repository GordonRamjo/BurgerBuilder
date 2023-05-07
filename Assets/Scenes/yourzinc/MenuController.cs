using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Menu.InitMenu(); // 메뉴 설정
        RandomMenu.InitMenu(); // 랜덤메뉴 설정

        // 메뉴

        // 기본버거 ; Menu.BasicBurger 
        // 더블치즈버거 : Menu.DoubleCheeseBurger
        // 치즈버거 : Menu.CheeseBurger
        // 더블패티버거 : Menu.DoublePattyBurger
        // 베지버거 : Menu.VeggieBurger

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
