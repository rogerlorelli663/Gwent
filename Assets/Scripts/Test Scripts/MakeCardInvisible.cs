using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeCardInvisible: MonoBehaviour
{

    CardHolder cardHolder;

    public void Update()
    {
        if (cardHolder.GetCard() == null)
        {
            foreach (Transform child in cardHolder.GetCard().transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void Start()
    {
        cardHolder = FindObjectOfType<CardHolder>();
    }
}
