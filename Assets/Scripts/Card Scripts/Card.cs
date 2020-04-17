using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private string cardName;
    private int power;

    public string GetName()
    {
        return cardName;
    }

    public int GetPower()
    {
        this.power = Int32.Parse(gameObject.transform.Find("Power").gameObject.GetComponent<Text>().text);
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
