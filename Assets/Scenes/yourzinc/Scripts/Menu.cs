using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Menu
{

}

public class BasicMenu : Menu 
{
    public static Stack<int> BasicBurger = new Stack<int>();
    public static Stack<int> DoubleCheeseBurger = new Stack<int>();
    public static Stack<int> CheeseBurger = new Stack<int>();
    public static Stack<int> DoublePattyBurger = new Stack<int>();
    public static Stack<int> VeggieBurger = new Stack<int>();


    public static void InitMenu()
    {
        // 기본버거
        BasicBurger.Push((int)Hamburger.Ingredient.BottomBread); // 빵아래
        BasicBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        BasicBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        BasicBurger.Push((int)Hamburger.Ingredient.Lettuce); // 양상추
        BasicBurger.Push((int)Hamburger.Ingredient.UpperBread); // 빵위

        // 더블치즈버거
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.BottomBread); // 빵아래
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Onion); // 양파 
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Lettuce); // 상추
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Lettuce); // 양상추
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.UpperBread); // 빵위

        // 치즈버거
        CheeseBurger.Push((int)Hamburger.Ingredient.BottomBread); // 빵아래
        CheeseBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        CheeseBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        CheeseBurger.Push((int)Hamburger.Ingredient.UpperBread); // 빵위

        // 더블패티버거
        DoublePattyBurger.Push((int)Hamburger.Ingredient.BottomBread); // 빵아래
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Lettuce); // 상추
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Pickle); // 피클
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Onion); // 양파
        DoublePattyBurger.Push((int)Hamburger.Ingredient.UpperBread); // 빵위 

        // 베지버거
        VeggieBurger.Push((int)Hamburger.Ingredient.BottomBread); // 빵아래
        VeggieBurger.Push((int)Hamburger.Ingredient.Lettuce); // 상추
        VeggieBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        VeggieBurger.Push((int)Hamburger.Ingredient.Onion); // 양파
        VeggieBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        VeggieBurger.Push((int)Hamburger.Ingredient.Lettuce); // 상추
        VeggieBurger.Push((int)Hamburger.Ingredient.UpperBread); // 빵위
    }
}

public class RandomMenu : Menu
{
    public static Stack<int> BlackBurger = new Stack<int>();
    public static Stack<int> JustPatty = new Stack<int>();
    public static Stack<int> JustBread = new Stack<int>();


    public static void InitMenu()
    {
        // 진상버거
        BlackBurger.Push((int)Hamburger.Ingredient.BottomBread); // 빵 아랫면
        BlackBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        BlackBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        BlackBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        BlackBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        BlackBurger.Push((int)Hamburger.Ingredient.Onion); // 양파
        BlackBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        BlackBurger.Push((int)Hamburger.Ingredient.Lettuce); // 양상추
        BlackBurger.Push((int)Hamburger.Ingredient.Patty); // 패티
        BlackBurger.Push((int)Hamburger.Ingredient.Cheese); // 치즈
        BlackBurger.Push((int)Hamburger.Ingredient.Onion); // 양파
        BlackBurger.Push((int)Hamburger.Ingredient.Tomato); // 토마토
        BlackBurger.Push((int)Hamburger.Ingredient.Lettuce); // 양상추
        BlackBurger.Push((int)Hamburger.Ingredient.UpperBread); // 빵 윗면

        // 패티만 주세요
        JustPatty.Push((int)Hamburger.Ingredient.Patty); // 패티

        // 빵만 주세요
        JustBread.Push((int)Hamburger.Ingredient.BottomBread); // 빵 아랫면
        JustBread.Push((int)Hamburger.Ingredient.UpperBread); // 빵 윗면
    }
}