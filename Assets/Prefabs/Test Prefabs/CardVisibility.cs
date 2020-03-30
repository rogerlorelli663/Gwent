using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardVisibility : MonoBehaviour
{
    private CardHolder cardHolder;
    void Start()
    {
        cardHolder = FindObjectOfType<CardHolder>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(cardHolder != null)
            {
                if(cardHolder.GetCard() == gameObject)
                {
                    MakeCardInvisible();
                }
                else
                {
                    MakeCardVisible();
                }
            }
            else
            {
                Debug.Log("requires a card holder placement.");
            }
        }
    }

    private void MakeCardVisible()
    {
        foreach (Transform child in cardHolder.GetCard().transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void MakeCardInvisible()
    {
        foreach (Transform child in cardHolder.GetCard().transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
