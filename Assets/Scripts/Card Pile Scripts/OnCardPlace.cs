using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCardPlace : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CardHolder cardHolder = FindObjectOfType<CardHolder>();
            if (cardHolder != null)
            {
                if (cardHolder.GetCard() != null)
                {
                    GameObject card = cardHolder.GetCard();

                    Vector2 mousePos2D = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider != null)
                        {
                            CardPileManager cpm = hit.collider.gameObject.GetComponent<CardPileManager>();
                            if (cpm != null)
                            {
                                switch (cpm.GetCardPileType())
                                {
                                    case CardPileManager.CardPileType.PLAYER1_CLOSE_COMBAT_FIELD_PILE:
                                        cpm.AddCardToPile(card);
                                        MakeCardVisible(card);
                                        cardHolder.EraseCard();
                                        break;
                                    case CardPileManager.CardPileType.PLAYER1_RANGE_COMBAT_FIELD_PILE:
                                        cpm.AddCardToPile(card);
                                        MakeCardVisible(card);
                                        cardHolder.EraseCard();
                                        break;
                                    case CardPileManager.CardPileType.PLAYER1_SIEGE_COMBAT_FIELD_PILE:
                                        cpm.AddCardToPile(card);
                                        MakeCardVisible(card);
                                        cardHolder.EraseCard();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.Log("requires a card holder placement.");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            CardHolder cardHolder = FindObjectOfType<CardHolder>();
            if (cardHolder != null)
            {
                if (cardHolder.GetCard() != null)
                {
                    GameObject card = cardHolder.GetCard();

                    CardPileManager[] cpmList = FindObjectsOfType<CardPileManager>();
                    foreach(CardPileManager cpm in cpmList)
                    {
                        if(cpm.GetCardPileType() == CardPileManager.CardPileType.PLAYER1_HAND_PILE)
                        {
                            MakeCardVisible(card);
                            cardHolder.EraseCard();
                            break;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("requires a card holder placement.");
            }
        }
    }

    private void MakeCardVisible(GameObject card)
    {
        foreach(Transform child in card.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
