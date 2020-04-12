using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
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
    private CardPileManager.CardPileType cardPileLocation;

    private GwentCard card;
    private void Start()
    {
        
    }
    public CardPileManager.CardPileType GetCardPileLocation()
    {
        SetCardPileLocation();
        return this.cardPileLocation;
    }
    public void SetCardPileLocation()
    {
        this.cardPileLocation = gameObject.transform.parent.transform.GetComponent<CardPileManager>().GetCardPileType();
    }
    public int GetCardType()
    {
        return cardType;
    }

    public string GetName()
    {
        return cardName;
    }

    public void SetCardType(int cardType)
    {
        this.cardType = cardType;
    }

    public void SetName(string cardName)
    {
        this.cardName = gameObject.transform.Find("Name").gameObject.GetComponent<Text>().text;
    }

    public int GetPower()
    {
        this.power = Int32.Parse(gameObject.transform.Find("Power").gameObject.GetComponent<Text>().text);
        return this.power;
    }

    public void SetPower(int power)
    {
        this.power = Int32.Parse(gameObject.transform.Find("Power").gameObject.GetComponent<Text>().text); 
    }

    public void Update()
    {
        if(gameObject.transform.parent.CompareTag("Siege") || gameObject.transform.parent.CompareTag("Melee") || gameObject.transform.parent.CompareTag("Range") || gameObject.transform.parent.CompareTag("Hand"))
        if (GetCardPileLocation() != CardPileManager.CardPileType.PLAYER1_HAND_PILE)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
}
