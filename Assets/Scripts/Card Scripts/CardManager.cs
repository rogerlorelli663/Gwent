using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    private enum CardType
    {
        NO_TYPE = 0,
        MELEE = 1,
        RANGED = 2,
        SIEGE = 3,
        WEATHER = 4,
        EFFECT = 5, 
        LEADER = 6,
    }

    //[SerializeField] private CardType type = CardType.NO_TYPE;
    private int cardType;
    private string cardName;
    private int power;
    private CardPileType cardPileLocation;
    public CardPileType getCardPileLocation()
    {
        setCardPileLocation();
        return this.cardPileLocation;
    }
    public void setCardPileLocation()
    {
        this.cardPileLocation = gameObject.transform.parent.transform.GetComponent<CardPileManager>().GetCardPileType();
    }
    public int getCardType()
    {
        return cardType;
    }

    public string getName()
    {
        return cardName;
    }

    public void setCardType(int cardType)
    {
        this.cardType = cardType;
    }

    public void setName(string cardName)
    {
        this.cardName = gameObject.transform.Find("Name").gameObject.GetComponent<Text>().text;
    }

    public int getPower()
    {
        this.power = Int32.Parse(gameObject.transform.Find("Power").gameObject.GetComponent<Text>().text);
        return this.power;
    }

    public void setPower(int power)
    {
        this.power = Int32.Parse(gameObject.transform.Find("Power").gameObject.GetComponent<Text>().text); 
    }

    public void Update()
    {
        if(gameObject.transform.parent.CompareTag("Siege") || gameObject.transform.parent.CompareTag("Melee") || gameObject.transform.parent.CompareTag("Range") || gameObject.transform.parent.CompareTag("Hand"))
        if (getCardPileLocation() != CardPileType.HAND_PILE)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
}
