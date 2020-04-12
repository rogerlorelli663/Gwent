using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GwentCard : MonoBehaviour
{
    public enum CardType
    {
        NO_TYPE = 0,
        MELEE = 1,
        RANGED = 2,
        SIEGE = 3,
        WEATHER = 4,
        EFFECT = 5,
        LEADER = 6,
    }

    [SerializeField] private string cardName;
    [SerializeField] private CardType cardType;

    public virtual string getCardName()
    {
        return this.cardName;
    }
    public virtual CardType GetCardType()
    {
        return this.cardType;
    }
}


