using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty
{
    public enum State { Rare, Medium, Burned }; // 안 익음, 익음, 탐

    public State state; // 상태

    // 생성자
    public Patty()
    {
        state = State.Rare;
    }

    // 4초 뒤
    public void After4Second()
    {
        this.state = State.Medium; // 익음
    }

    // 7초 뒤
    public void After7Second()
    {
        this.state = State.Burned; // 탐
    }
}
