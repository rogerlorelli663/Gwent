using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private CardType type = CardType.NO_TYPE;
    private int cardType;
    private string cardName;
    private int power;

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
        this.cardName = cardName;
    }

    public int getPower()
    {
        return this.power;
    }

    public void setPower(int power)
    {
        this.power = power;
    }
}
