using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPileDisplay : MonoBehaviour
{

    private CardPile cardPile;
    private GridLayoutGroup gridLayout;
    private RectTransform rectTransform;

    private float cardPileWidth;

    public float cardWidth;
    public float cardHeight;
    public float cardScale;

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
            float sumOfCardWidths = 0;
            for (int child = 0; child < transform.childCount; child++)
            {
                RectTransform cardRect = transform.GetChild(child).GetComponent<RectTransform>();
                sumOfCardWidths += cardRect.rect.width * cardRect.transform.localScale.x;
            }
            
            if (rectTransform.rect.width < sumOfCardWidths)
            {
                DisplayCompactedCardPile(); //spacing = cardWidth * (cardScale - 1)
            }
            else
            {
                DisplayUncompactedCardPile();
            }
        }
    }

    private void DisplayCompactedCardPile()
    {

        float visibleCardWidth = cardWidth * cardScale;
        int remainingCardsToFitOntoPile = transform.childCount - (int)(cardPileWidth / visibleCardWidth);
        int cardsThatFitOntoPile = transform.childCount - remainingCardsToFitOntoPile;
        float compactedSpacingForCardPile = -(cardWidth - (cardWidth * cardScale));

        for (int remainingCardIndex = 1; remainingCardIndex <= remainingCardsToFitOntoPile; remainingCardIndex++)
        {
            compactedSpacingForCardPile -= visibleCardWidth / cardsThatFitOntoPile;
            visibleCardWidth -= visibleCardWidth / cardsThatFitOntoPile;
            cardsThatFitOntoPile++;
        }

        gridLayout.spacing = new Vector2(compactedSpacingForCardPile, 0);
    }

    private void DisplayUncompactedCardPile()
    {
        gridLayout.spacing = new Vector2(-(cardWidth - (cardWidth * cardScale)), 0);
    }

}
