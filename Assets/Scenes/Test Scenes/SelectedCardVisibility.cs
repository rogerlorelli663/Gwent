using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCardVisibility : MonoBehaviour
{
    private CardSelector cardSelector;
    
    void Start()
    {
        cardSelector = GetComponent<CardSelector>();
    }

    void Update()
    {
        if (cardSelector.GetOriginalCard() != null)
        {
            if (cardSelector.GetSelectedCard() != null)
            {
                MakeCardInvisible();
            }
            else if (cardSelector.GetSelectedCard() == null)
            {
                MakeCardVisible();
            }
        }
    }

    private void MakeCardInvisible()
    {
        foreach (Transform child in cardSelector.GetOriginalCard().transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void MakeCardVisible()
    {
        foreach (Transform child in cardSelector.GetOriginalCard().transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
