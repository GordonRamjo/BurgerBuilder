using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Menu.InitMenu(); // �޴� ����
        RandomMenu.InitMenu(); // �����޴� ����

        // �޴�

        // �⺻���� ; Menu.BasicBurger 
        // ����ġ����� : Menu.DoubleCheeseBurger
        // ġ����� : Menu.CheeseBurger
        // ������Ƽ���� : Menu.DoublePattyBurger
        // �������� : Menu.VeggieBurger

        // ���� �޴�

        // ������� : RandomMenu.BlackBurger
        // ��Ƽ�� : RandomMenu.JustPatty
        // ���� : RandomMenu.JustBread

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
