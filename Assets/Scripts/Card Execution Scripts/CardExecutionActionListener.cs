using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardExecutionActionListener : MonoBehaviour
{
    private CardExecutionManager cem;

    void Start()
    {
        cem = GetComponent<CardExecutionManager>();
    }

    void Update()
    {
        if (cem.GetCard() != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos2D = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

                foreach (RaycastHit2D hit in hits)
                {
                    CardPileManager cpm = hit.collider.gameObject.GetComponent<CardPileManager>();

                    if (cpm != null && hit.collider != null && cem.HasCard())
                    {
                        switch (cpm.GetCardPileType())
                        {
                            case CardPileType.CLOSE_COMBAT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.RANGE_COMBAT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.SIEGE_COMBAT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.MORALE_BOOST_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.EFFECT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.OPPONENT_CLOSE_COMBAT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.OPPONENT_RANGE_COMBAT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.OPPONENT_SIEGE_COMBAT_FIELD_PILE:
                                cpm.AddCardToPile(cem.GetCard());
                                cem.removeCard();
                                break;
                            case CardPileType.HAND_PILE:
                                cem.removeCard();
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