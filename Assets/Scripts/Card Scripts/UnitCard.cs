using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCard : GwentCard
{

/*    public enum UnitType
    {
        NO_TYPE = 0,
        MELEE = 1,
        RANGE = 2,
        SIEGE = 3,
    }*/

    [SerializeField] string cardFlavorText;
    [SerializeField] int cardPower;
    //[SerializeField] UnitType unitType;

    public virtual string GetCardFlavorText()
    {
        return this.cardFlavorText;
    }

    public virtual int GetCardPower()
    {
        return this.cardPower;
    }
/*    public virtual UnitType GetUnitType()
    {
        return this.unitType;
    }*/
}
