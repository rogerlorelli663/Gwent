using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQBCard : MonoBehaviour
{
    public enum CardType
    {
        NO_TYPE = 0,
        UNIT = 1,
        EFFECT = 2,
        LEADER = 3,
    }

    public enum UnitType
    {
        FIGHTER = 0,
        CORVETTE = 1,
        FRIGATE = 2,
        CAPITAL = 3,
    }

    [SerializeField] private string cardName;
    [SerializeField] private int power;
    [SerializeField] private CardPile.CardPileType fieldType;
    [SerializeField] private CardType cardType;
    [SerializeField] private UnitType unitType;
    [SerializeField] private bool hasCardDescripton;
    public virtual string GetCardName()
    {
        return this.cardName;
    }
    public virtual CardPile.CardPileType GetCardType()
    {
        return this.fieldType;
    }

    public virtual int GetPower()
    {
        return this.power;
    }
}
