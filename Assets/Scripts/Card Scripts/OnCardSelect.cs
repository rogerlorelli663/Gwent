using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnCardSelect : MonoBehaviour, IPointerClickHandler
{
    CardManager card;
    void Start()
    {
        card = GetComponent<CardManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && card.GetCardPileLocation() == CardPileManager.CardPileType.PLAYER1_HAND_PILE)
        {
            FindObjectOfType<CardHolder>().SaveCard(gameObject);
        }
    }
}
