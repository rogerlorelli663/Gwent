using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    [SerializeField] private CardPileType cardPileType = CardPileType.NO_TYPE;

    public enum CardPileType
    {
        NO_TYPE = 0,
        HAND_PILE = 1,
        DISCARD_PILE = 2,
        DECK_PILE = 3,
        MELEE_FIELD = 4,
        RANGE_FIELD = 5,
        SIEGE_FIELD = 6,
        EFFECT_FIELD = 7,
        MORALE_BOOST_FIELD = 8
    }

    public void TransferCardToCardPile(GameObject card)
    {
        card.transform.SetParent(gameObject.transform);
    }

    public int GetNumberOfCards()
    {
        return transform.childCount;
    }

    public List<GameObject> GetCardsInCardPile()
    {
        List<GameObject> cards = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            cards.Add(transform.GetChild(i).gameObject);
        }
        return cards;
    }

    public CardPileType GetCardPileType()
    {
        return cardPileType;
    }
}
