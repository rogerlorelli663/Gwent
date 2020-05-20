using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckDisplay : MonoBehaviour
{

    private CardPile cardPile;
    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;

    private float cardPileWidth;

    void Start()
    {
        cardPile = GetComponent<CardPile>();
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();

        cardPileWidth = rectTransform.rect.width;
    }


    void Update()
    {
        DetermineFormatOfGridLayout();
    }

    private void DetermineFormatOfGridLayout()
    {
        if (transform.childCount > 0)
        {
            RectTransform cardRect = transform.GetChild(0).GetComponent<RectTransform>(); //instance of first card
            float sumOfCardWidths = cardRect.rect.width * cardRect.transform.localScale.x * transform.childCount;
            if (rectTransform.rect.width < sumOfCardWidths)
            {
                DisplayCompactedCardPile(cardRect); //spacing = cardWidth * (cardScale - 1)
            }
            else
            {
                DisplayUncompactedCardPile(cardRect);
            }
        }
    }

    private void DisplayCompactedCardPile(RectTransform cardRect)
    {

        float visibleCardWidth = cardRect.rect.width * cardRect.transform.localScale.x;
        int remainingCardsToFitOntoPile = transform.childCount - (int)(cardPileWidth / visibleCardWidth);
        int cardsThatFitOntoPile = transform.childCount - remainingCardsToFitOntoPile;
        float compactedSpacingForCardPile = -(cardRect.rect.width - (cardRect.rect.width * cardRect.transform.localScale.x));

        for (int remainingCardIndex = 1; remainingCardIndex <= remainingCardsToFitOntoPile; remainingCardIndex++)
        {
            compactedSpacingForCardPile -= visibleCardWidth / cardsThatFitOntoPile;
            visibleCardWidth -= visibleCardWidth / cardsThatFitOntoPile;
            cardsThatFitOntoPile++;
        }

        gridLayout.spacing = new Vector2(compactedSpacingForCardPile, 0);
    }

    private void DisplayUncompactedCardPile(RectTransform cardRect)
    {
        gridLayout.spacing = new Vector2(-(cardRect.rect.width - (cardRect.rect.width * cardRect.transform.localScale.x)), 0);
    }

}
