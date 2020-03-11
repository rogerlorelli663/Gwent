using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCardsToHand : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject card;
    private Image cardImage;

    void Start()
    {
        CardPileManager[] cardPiles = FindObjectsOfType<CardPileManager>();
        foreach(CardPileManager cpm in cardPiles){
            switch (cpm.GetCardPileType())
            {
                case CardPileType.HAND_PILE:
                    GameObject hand = cpm.gameObject;
                    card = hand.transform.GetChild(0).gameObject; //requires 1 card as a template
                    cardImage = card.GetComponent<Image>();
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject cardCopy = Instantiate(card, hand.transform);
                        cpm.AddCardToPile(card);
                    }
                    break;
            }
        }
    }

    private void Update()
    {
        //This will disable the card entirely and reformat
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (card.activeSelf == true)
        //    {
        //        card.SetActive(false);
        //    }
        //    else
        //    {
        //        card.SetActive(true);
        //    }
        //}


        //this will make the card invisible and will remain as invisible even when format is called. Thus it will remain the same formatted state from before.
        if (Input.GetMouseButtonDown(0))
        {
            if (cardImage.color.a == 0f)
            {
                cardImage.color = new Color(cardImage.color.r, cardImage.color.g, cardImage.color.b, 100f);
            }
            else
            {
                cardImage.color = new Color(cardImage.color.r, cardImage.color.g, cardImage.color.b, 0f);
            }
        }
    }
}
