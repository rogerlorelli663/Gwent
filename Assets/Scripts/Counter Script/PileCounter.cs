using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileCounter : MonoBehaviour
{
    public CardPile UnitField;
    public CardPile BoostField;
    public SpecialUnitCard.AbilityType WeatherType;
    public CardPile WeatherField;
    private int cardsInPile;
    private int boostMultiplier;
    private List<GameObject> weatherCards;
    private bool weatherCardActive;
    private int pileTotal;
    // Start is called before the first frame update
    void Start()
    {
        weatherCardActive = false;
        cardsInPile = 0;
        boostMultiplier = 1;
        pileTotal = 0;
    }

    // Update is called once per frame
    private bool UpdateCheck()
    {
        bool update = false;
        //check boost field
        if(BoostField.GetNumberOfCards() > 0)
        {
            boostMultiplier = 2;
            update = true;
        }
        weatherCards = WeatherField.GetCardsInCardPile();
        foreach(GameObject card in weatherCards)
        {
            if(WeatherType == card.GetComponent<SpecialUnitCard>().GetUnitAbilityType())
            {
                weatherCardActive = true;
                update = true;
                break;
            }
        }
        if(cardsInPile != UnitField.GetNumberOfCards() || update)
        {
            cardsInPile = UnitField.GetNumberOfCards();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateCounter()
    {
        int[] cardsPower = new int[cardsInPile];
        List<GameObject> cards = UnitField.GetCardsInCardPile();
        int index = 0;
        int sum = 0;
        foreach(GameObject card in cards)
        {
            cardsPower[index] = card.GetComponent<CQBCard>().GetPower();
            index++;
        }
        if(weatherCardActive)
        {
            for(int i = 0; i < cardsInPile; i++)
            {
                cardsPower[i] = (cardsPower[i] / cardsPower[i]) * boostMultiplier;
                sum += cardsPower[i];
            }
        }
        else
        {
            for (int i = 0; i < cardsInPile; i++)
            {
                cardsPower[i] *= boostMultiplier;
                sum += cardsPower[i];
            }
        }
        this.pileTotal = sum;
    }

    public int GetPileTotal()
    {
        if(UpdateCheck())
        {
            UpdateCounter();
        }
        return this.pileTotal;
    }
}
