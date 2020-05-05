using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardFromHand : MonoBehaviour
{
    private GameState Player;
    private CardSelector cardSelector;

    private void Start()
    {
        cardSelector = GetComponent<CardSelector>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Player == null)
            {
                Player = GameObject.Find("PlayerGameState").GetComponent<GameState>();
            }
            if(!Player.isPlayersTurn())
            {
                return;
            }
            GameObject card = GetClickedCard();
            if(card != null)
            {
                if (card.transform.parent.tag.Contains("Enemy Hand"))
                {
                    return;
                }
                if (ClickedCardIsInHand(card) && cardSelector.IsCardSelectableAndInCardPile())
                {
                    SaveClickedCardInHand(card);
                    CreateCardSelector();
                }
            }
        }
    }

    private void SaveClickedCardInHand(GameObject card)
    {
        FindObjectOfType<CardHolder>().SaveCard(card);
    }

    private bool ClickedCardIsInHand(GameObject card)
    {
        if(card.transform.parent.gameObject.GetComponent<CardPile>().GetCardPileType() == CardPile.CardPileType.HAND_PILE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private GameObject GetClickedCard()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        RaycastHit2D[] objectsOnMousePosition = Physics2D.RaycastAll(mousePosition, Vector2.zero);
        
        foreach (RaycastHit2D objectHit in objectsOnMousePosition)
        {
            if(objectHit.collider.gameObject.GetComponent<Card>() != null)
            {
                return objectHit.collider.gameObject;
            }
        }
        return null;
    }

    private void CreateCardSelector()
    {
        cardSelector.CreateSelectedCardInstance();
        cardSelector.MakeOriginalCardInvisible();
        cardSelector.AnimateCardToCardSelector();
    }
}
