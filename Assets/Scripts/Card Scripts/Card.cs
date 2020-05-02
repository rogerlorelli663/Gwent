using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private string cardName;
    private int power;

    void Start()
    {
        UnitCard unitCard = gameObject.GetComponent<UnitCard>();
        this.power = unitCard.GetCardPower();
    }
    public string GetName()
    {
        return cardName;
    }

    public int GetPower()
    {
        return this.power;
    }

    public CardPile.CardPileType GetCardType()
    {
        return gameObject.GetComponent<GwentCard>().GetCardType();
    }

    public bool HasDescription()
    {
        return gameObject.GetComponent<GwentCard>().HasDescription();
    }

}
