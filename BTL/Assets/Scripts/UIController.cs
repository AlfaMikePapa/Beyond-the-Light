using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3;
    public Sprite fullHeart, halfHeart, emptyHeart;



    private void Awake()
    {
        instance = this;
    }

    public void UpdateHealthUI()
    {

        switch (PlayerHealthController.instance.playerCurrentHealth)
        {
            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;

                break;

            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfHeart;

                break;

            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;

                break;

            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;

                break;

            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            default:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;
        }
    }
}