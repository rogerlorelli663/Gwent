using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelector : MonoBehaviour, IPointerClickHandler
{
    Card card;
    void Start()
    {
        card = GetComponent<Card>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && card.GetCardPileLocation() == CardPile.CardPileType.PLAYER1_HAND_PILE)
        {
            FindObjectOfType<CardHolder>().SaveCard(gameObject);
        }
    }
}
