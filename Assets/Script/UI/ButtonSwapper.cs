using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.UI
{
    public class ButtonSwapper : MonoBehaviour
    {
        // Start is called before the first frame update
        private bool swapSprite;
        [SerializeField] Image buttonImage;

        [SerializeField] Sprite firstImage;
        [SerializeField] Sprite secondImage;
        [SerializeField] Image contentImage;
        

        

        void Start()
        {
            swapSprite = false;
        }

        public void SwapSprite()
        {
            if(swapSprite == false)
            {
                buttonImage.sprite = firstImage;
                contentImage.gameObject.SetActive(false);
                swapSprite = true;
            }else if(swapSprite == true)
            {
                buttonImage.sprite = secondImage;
                contentImage.gameObject.SetActive(true);
                swapSprite = false;
            }
        }
    }
}
