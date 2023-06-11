using UnityEngine;

public class GameData : MonoBehaviour
{
    public bool[] isCleared = new bool[3];

    public int playedStageNum;
    public bool playedResult;

    void Start()
    {
        playedStageNum = -1;
        playedResult = false;
    }

    void Update()
    {
        
    }
}