using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        //HamburgerIngredient ingredient;
        public GameObject ingredient; //player가 잡고 있는 재료 컴포넌트
        
        public void Catch() { 
            //ingredient = ?
        }

        public void throwAway() {
            Destroy(this.ingredient);
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