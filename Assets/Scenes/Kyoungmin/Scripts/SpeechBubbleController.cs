using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubbleController : MonoBehaviour
{
    public SpriteRenderer menuImg;
    public TextMeshPro tmpText;
    
    public void ChangeMenuImg(Sprite s)
    {
        menuImg.sprite = s;
    }
    
    public void ChangeText(string msg)
    {
        tmpText.text = msg;
    }

    public void ChangeSize(float size) //��ǳ�� �۾� ũ�� �����ϴ� �Լ�
    {
        tmpText.fontSize = size;
    }
    
    private void Awake()
    {
        menuImg = GameObject.Find("MenuImg").GetComponent<SpriteRenderer>();
        tmpText = GameObject.Find("Message").GetComponent<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
