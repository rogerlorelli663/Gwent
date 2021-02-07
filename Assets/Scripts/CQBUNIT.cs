using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQBUnit : CQBCard
{
    [SerializeField] int cardPower;

    public virtual int GetCardPower()
    {
        return this.cardPower;
    }
}
