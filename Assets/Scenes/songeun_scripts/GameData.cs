using System;

[Serializable] // 직렬화

public class Data
{
    // 각 스테이지 해금 여부를 저장하는 배열
    public bool[] isCleared = new bool[3];
}