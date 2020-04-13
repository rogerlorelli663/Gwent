using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPileDisplay : MonoBehaviour
{

<<<<<<< HEAD
    private CardPile cardPile;
    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;
=======
    //Component fields required for Card Display
    private CardPile cpm;
    private GridLayoutGroup grid;
    private RectTransform panel;
>>>>>>> c3171847646cc344ee7d7076501492ac54be4289

    private float cardPileWidth;

    void Start()
    {
<<<<<<< HEAD
        cardPile = GetComponent<CardPile>();
        gridLayout = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
=======
        cpm = GetComponent<CardPile>();
        grid = GetComponent<GridLayoutGroup>();
        panel = GetComponent<RectTransform>();
>>>>>>> c3171847646cc344ee7d7076501492ac54be4289

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
