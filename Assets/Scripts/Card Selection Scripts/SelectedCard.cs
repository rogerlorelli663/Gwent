using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCard : MonoBehaviour
{
    private GameObject displayCard;
    private CardHolder cardHolder;

    public GameObject GetDisplayCard()
    {
        return displayCard;
    }

    public bool HasCard()
    {
        if(displayCard != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        cardHolder = FindObjectOfType<CardHolder>();
        displayCard = null;
    }

    private void Update()
    {
        if (cardHolder != null)
        {
            GameObject card = cardHolder.GetCard();
            if (displayCard == null && card != null)
            {
                displayCard = Instantiate(card);
                displayCard.transform.SetParent(gameObject.transform);
                MakeCardInvisible(card);
            }
            else if (displayCard != null && card == null)
            {
                Destroy(displayCard);
            }
        }
        else
        {
            Debug.Log("requires a card holder placement.");
        }
    }

    private void MakeCardInvisible(GameObject card)
    {
        foreach(Transform child in card.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
