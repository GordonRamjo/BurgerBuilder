using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Menu
{
    public static Stack<int> BasicBurger = new Stack<int>();
    public static Stack<int> DoubleCheeseBurger = new Stack<int>();
    public static Stack<int> CheeseBurger = new Stack<int>();
    public static Stack<int> DoublePattyBurger = new Stack<int>();
    public static Stack<int> VeggieBurger = new Stack<int>();

    /**
     * TODO : EmptyObject�� StartManager Script ���� start() ���� Menu.InitMenu() ȣ��
     */

    public static void InitMenu()
    {
        // �⺻����
        BasicBurger.Push((int)Hamburger.Ingredient.BottomBread); // ���Ʒ�
        BasicBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        BasicBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        BasicBurger.Push((int)Hamburger.Ingredient.Lettuce); // �����
        BasicBurger.Push((int)Hamburger.Ingredient.UpperBread); // ����

        // ����ġ�����
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.BottomBread); // ���Ʒ�
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Onion); // ���� 
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Lettuce); // ����
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.Lettuce); // �����
        DoubleCheeseBurger.Push((int)Hamburger.Ingredient.UpperBread); // ����

        // ġ�����
        CheeseBurger.Push((int)Hamburger.Ingredient.BottomBread); // ���Ʒ�
        CheeseBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        CheeseBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        CheeseBurger.Push((int)Hamburger.Ingredient.UpperBread); // ����

        // ������Ƽ����
        DoublePattyBurger.Push((int)Hamburger.Ingredient.BottomBread); // ���Ʒ�
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Lettuce); // ����
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Pickle); // ��Ŭ
        DoublePattyBurger.Push((int)Hamburger.Ingredient.Onion); // ����
        DoublePattyBurger.Push((int)Hamburger.Ingredient.UpperBread); // ���� 

        // ��������
        VeggieBurger.Push((int)Hamburger.Ingredient.BottomBread); // ���Ʒ�
        VeggieBurger.Push((int)Hamburger.Ingredient.Lettuce); // ����
        VeggieBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        VeggieBurger.Push((int)Hamburger.Ingredient.Onion); // ����
        VeggieBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        VeggieBurger.Push((int)Hamburger.Ingredient.Lettuce); // ����
        VeggieBurger.Push((int)Hamburger.Ingredient.UpperBread); // ����
    }
}

public class RandomMenu
{
    public static Stack<int> BlackBurger = new Stack<int>();
    public static Stack<int> JustPatty = new Stack<int>();
    public static Stack<int> JustBread = new Stack<int>();

    /**
    * TODO : EmptyObject�� StartManager Script ���� start() ���� RandomMenu.InitMenu() ȣ��
    */

    public static void InitMenu()
    {
        // �������
        BlackBurger.Push((int)Hamburger.Ingredient.BottomBread); // �� �Ʒ���
        BlackBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        BlackBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        BlackBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        BlackBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        BlackBurger.Push((int)Hamburger.Ingredient.Onion); // ����
        BlackBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        BlackBurger.Push((int)Hamburger.Ingredient.Lettuce); // �����
        BlackBurger.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ
        BlackBurger.Push((int)Hamburger.Ingredient.Cheese); // ġ��
        BlackBurger.Push((int)Hamburger.Ingredient.Onion); // ����
        BlackBurger.Push((int)Hamburger.Ingredient.Tomato); // �丶��
        BlackBurger.Push((int)Hamburger.Ingredient.Lettuce); // �����
        BlackBurger.Push((int)Hamburger.Ingredient.UpperBread); // �� ����

        // ��Ƽ�� �ּ���
        JustPatty.Push((int)Hamburger.Ingredient.Patty); // ��Ƽ

        // ���� �ּ���
        JustBread.Push((int)Hamburger.Ingredient.BottomBread); // �� �Ʒ���
        JustBread.Push((int)Hamburger.Ingredient.UpperBread); // �� ����
    }
}