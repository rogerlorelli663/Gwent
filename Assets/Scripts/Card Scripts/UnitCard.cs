using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCard : GwentCard
{



    [SerializeField] string cardFlavorText;
    [SerializeField] int cardPower;

    public virtual string GetCardFlavorText()
    {
        return this.cardFlavorText;
    }

    public virtual int GetCardPower()
    {
        return this.cardPower;
    }
}
