using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCardOntoCardPile : MonoBehaviour
{

    private CardSelector cardSelector;

    void Start()
    {
        cardSelector = GetComponent<CardSelector>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject cardPile = GetClickedCardPile();
            if (cardPile != null && cardSelector.IsCardPlaceableAndInCardSelector())
            {
                AddCardToCardPile(cardPile);
                cardSelector.DeleteSelectedCardInstance();
            }
        }
    }

    private GameObject GetClickedCardPile()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        RaycastHit2D[] objectsOnMousePosition = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        foreach (RaycastHit2D objectHit in objectsOnMousePosition)
        {
            if (objectHit.collider.gameObject.GetComponent<CardPile>() != null)
            {
                return objectHit.collider.gameObject;
            }
        }
        return null;
    }

    private void AddCardToCardPile(GameObject cardPile) 
    {
        cardSelector.AnimateCardToCardPile(cardPile);
        cardPile.GetComponent<CardPile>().TransferCardToCardPile(cardSelector.GetOriginalCard());
    }
}
