using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMultipleGameObjects : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CardHolder cardHolder = FindObjectOfType<CardHolder>();
            if (cardHolder != null && cardHolder.GetCard() != null)
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
                                    cardHolder.EraseCard();
                                    break;
                                case CardPileManager.CardPileType.PLAYER1_RANGE_COMBAT_FIELD_PILE:
                                    cpm.AddCardToPile(card);
                                    cardHolder.EraseCard();
                                    break;
                                case CardPileManager.CardPileType.PLAYER1_SIEGE_COMBAT_FIELD_PILE:
                                    cpm.AddCardToPile(card);
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
    }
}
