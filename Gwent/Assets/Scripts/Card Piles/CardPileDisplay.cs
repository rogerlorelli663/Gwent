using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPileDisplay : MonoBehaviour
{
    //Component fields required for Card Display
    private CardPileManager cpm;
    private GridLayoutGroup grid;
    private RectTransform panel;

    //Width (x dimension) of the panel for the card pile
    private static float cardPileWidth;

    // Start is called before the first frame update
    void Start()
    {
        cpm = GetComponent<CardPileManager>();
        grid = GetComponent<GridLayoutGroup>();
        panel = GetComponent<RectTransform>();

        cardPileWidth = panel.rect.width;
    }

    //formats the entire card pile by getting component and calling format
    public void Format()
    {
        GameObject[] cards = cpm.GetCardList().ToArray(); //gets the card list from manager
        if (cards.Length >= 1)
        {
            RectTransform cardRect = cards[0].GetComponent<RectTransform>(); //gets the rect transform of the first instance of a card
            float cardWidth = cardRect.rect.width; //width of 1 card from the pile
            float totalCardListWidth = cardWidth * cards.Length; //non-scaled width of the total cards summed up
            if (cardPileWidth < totalCardListWidth * cardRect.transform.localScale.x) //Changes the spacing of cards so that they overlap for any input of scale
            {
                float remainingCardsToFit = (totalCardListWidth - cardPileWidth) / cardWidth; //The amount of cards that cannot fit w/ overlapping
                float cardsThatCanFit = (cardPileWidth / cardWidth); //The amount of cards that can fit within the panel boundry
                float scaledSpacing = ((1 - cardRect.transform.localScale.x) * cardWidth) / remainingCardsToFit; //Contains the number of spacing that is placed back that is relevant to the scale
                float spacing = (cardPileWidth - cardWidth - scaledSpacing) / (cards.Length - 1); //Contains the total spacing between the pivots of each card
                Vector2 newSpace = new Vector2((-(spacing  * remainingCardsToFit / (cardsThatCanFit - 1))), grid.spacing.y); //Sets the new spacing by multiplying the pivot spacing and ratio of card fitness within the panel.
                grid.spacing = newSpace;
            }
            else
            {
                grid.spacing = new Vector2((cardRect.transform.localScale.x * 100) - 100, grid.spacing.y); //The spacing for cards that aren't overlapping
            }
        }
    }
}
