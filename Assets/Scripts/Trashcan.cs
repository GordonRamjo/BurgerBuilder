using System.Collections;
using UnityEngine;

namespace Assets.Scripts


{
    public class Trashcan : MonoBehaviour
    //trashcan object에 적용할 스크립트
    {
        public GameObject player = GameObject.Find("Player");

        void throwAway() {
            //trashcan 선택 시 실행. player가 잡고 있는 ingredient 삭제
            player.GetComponent<Player>().throwAway();

            /* 유나님 코드의 player 클래스 기반으로 throwAway() 함수 추가 
            class Player(){
                HamburgerIngredient ingredient; //player가 집고 있는 재료 컴포넌트
            ...
                throwAway(){
                    Destory(this.ingredient); //player가 집은 재료 컴포넌트 삭제
                }
            }
             */
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}