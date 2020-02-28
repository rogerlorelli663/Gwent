using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileManager : MonoBehaviour
{

    public enum CardPileType
    {
        CARD_PLAY_FIELD_PILE = 0,
        HAND_PILE = 1,
        DISCARD_PILE = 2,
        DECK_PILE = 3,
        NO_CARD_PILE_TYPE = 4
    }

    [SerializeField] private CardPileType type = (CardPileType)4;
    [SerializeField] private List<GameObject> cards = null;
    public void AddCardToPile(GameObject card)
    {
        cards.Add(card);
    }

    public void RemoveCardFromPile(GameObject card)
    {
        cards.Remove(card);
    }

    public int GetIndexOFCard(GameObject card)
    {
        return cards.IndexOf(card);
    }

    public int GetCardAmount()
    {
        return cards.Count;
    }

    public List<GameObject> GetCardList()
    {
        return cards;
    }

    public CardPileType GetCardPileType()
    {
        return type;
    }
}
