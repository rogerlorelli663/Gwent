using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardsToHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CardPileManager[] cardPiles = FindObjectsOfType<CardPileManager>();
        foreach(CardPileManager cpm in cardPiles){
            switch (cpm.GetCardPileType())
            {
                case CardPileType.HAND_PILE:
                    GameObject hand = cpm.gameObject;
                    GameObject card = hand.transform.GetChild(0).gameObject; //requires 1 card as a template
                    //cpm.RemoveCardFromPile(card);
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject cardCopy = Instantiate(card, hand.transform);
                        cpm.AddCardToPile(card);
                    }
                    break;
            }
        }
    }
}
