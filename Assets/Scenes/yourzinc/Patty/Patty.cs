using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty
{
    public enum State { Rare, Medium, Burned }; // 안 익음, 익음, 탐

    public State state; // 상태

    public bool StartBake = false; // 조리 시작 

    // 생성자
    public Patty()
    {
        state = State.Rare;
    }

    // 익음
    public void Medium()
    {
        this.state = State.Medium; 
    }

    // 탐
    public void Burned()
    {
        this.state = State.Burned; 
    }
}
