using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{

    [SerializeField] private CardPileType type = CardPileType.NO_CARD_PILE_TYPE;
    public enum CardPileType
    {
        NO_CARD_PILE_TYPE = 0,
        PLAYER1_HAND_PILE = 1,
        PLAYER1_DISCARD_PILE = 2,
        PLAYER1_DECK_PILE = 3,
        PLAYER1_CLOSE_COMBAT_FIELD_PILE = 4,
        PLAYER1_RANGE_COMBAT_FIELD_PILE = 5,
        PLAYER1_SIEGE_COMBAT_FIELD_PILE = 6,
        PLAYER1_MORALE_BOOST_FIELD_PILE = 7, 
        EFFECT_FIELD_PILE = 8,
        PLAYER2_HAND_PILE = 9,
        PLAYER2_DISCARD_PILE = 10,
        PLAYER2_DECK_PILE = 11,
        PLAYER2_CLOSE_COMBAT_FIELD_PILE = 12,
        PLAYER2_RANGE_COMBAT_FIELD_PILE = 13,
        PLAYER2_SIEGE_COMBAT_FIELD_PILE = 14,
        PLAYER2_MORALE_BOOST_FIELD_PILE = 15
    }

    //add a card to car pile
    public void AddCardToPile(GameObject card)
    {
        card.transform.SetParent(gameObject.transform);
    }

    //Remove a card from card pile
    public void RemoveCardFromPile(GameObject card)
    {
        card.transform.SetParent(null);
    }

    //Returns the number of cards in the card pile
    public int GetNumberOfCards()
    {
        return transform.childCount;
    }

    //Returns a list of cards of the pile
    public List<GameObject> GetCardList()
    {
        List<GameObject> cardList = new List<GameObject>();
        for(int i = 0; i < transform.childCount; i++)
        {
            cardList.Add(transform.GetChild(i).gameObject);
        }
        return cardList;
    }

    //Returns the card pile enum type
    public CardPileType GetCardPileType()
    {
        return type;
    }
}
