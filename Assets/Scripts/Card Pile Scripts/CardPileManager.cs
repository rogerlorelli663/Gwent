using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardPileType
{
    NO_CARD_PILE_TYPE = 0,
    HAND_PILE = 1,
    DISCARD_PILE = 2,
    DECK_PILE = 3,
    CLOSE_COMBAT_FIELD_PILE = 4,
    RANGE_COMBAT_FIELD_PILE = 5,
    SIEGE_COMBAT_FIELD_PILE = 6,
    MORALE_BOOST_FIELD_PILE = 7, //6 total on board
    EFFECT_FIELD_PILE = 8,
    OPPONENT_HAND_PILE = 9,
    OPPONENT_DISCARD_PILE = 10,
    OPPONENT_DECK_PILE = 11,
    OPPONENT_CLOSE_COMBAT_FIELD_PILE = 12,
    OPPONENT_RANGE_COMBAT_FIELD_PILE = 13,
    OPPONENT_SIEGE_COMBAT_FIELD_PILE = 14
}

public class CardPileManager : MonoBehaviour
{
    public CardPileViewManager cpvm;

    [SerializeField] private CardPileType type = CardPileType.NO_CARD_PILE_TYPE;
    [SerializeField] private List<GameObject> cards = null;
    public List<GameObject> cardsToSend = null;

    void Start()
    {
        cpvm = GetComponent<CardPileViewManager>();
    }

    //add a card to car pile
    public void AddCardToPile(GameObject card)
    {
        Debug.Log("Setting new parent");
        cards.Add(card);
        card.transform.SetParent(gameObject.transform);
    }

    //Remove a card from card pile
    public void RemoveCardFromPile(GameObject card)
    {
        cards.Remove(card);
        card.transform.SetParent(null);
    }

    //Returns index of the first instance of this card in card pile;
    public int GetIndexOFCard(GameObject card)
    {
        return cards.IndexOf(card);
    }

    //Returns the number of cards in the card pile
    public int GetNumberOfCards()
    {
        return cards.Count;
    }

    //Returns a copy of the list of cards
    public List<GameObject> GetCardList()
    {
        return cards;
    }

    //Returns the card pile enum type
    public CardPileType GetCardPileType()
    {
        return type;
    }

    public void CardListToPileView()
    {
        List<GameObject> temp = null;

        temp = GetCardList();

        Debug.Log("\nThe Count is : " + temp.Count);

        for (int x = 0; x < temp.Count;x++)
        {
            Debug.Log("\nThe index is : " + x);
            cardsToSend.Add(Instantiate(temp[x]));
        }

        cpvm.GetCardListFromPile(cardsToSend);
    }
}
