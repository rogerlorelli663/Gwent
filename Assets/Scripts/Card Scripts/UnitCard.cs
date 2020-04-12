using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCard : GwentCard
{


    [SerializeField] string cardFlavorText;
    [SerializeField] int cardPower;
    [SerializeField] Sprite cardFlavorTextArt;
    [SerializeField] Sprite cardPowerToken;



    public virtual string GetCardFlavorText()
    {
        return this.cardFlavorText;
    }

    public virtual int GetCardPower()
    {
        return this.cardPower;
    }

    public virtual Sprite GetCardFlavorTextArt()
    {
        return this.cardFlavorTextArt;
    }
    public virtual Sprite GetCardPowerToken()
    {
        return this.cardPowerToken;
    }
}
