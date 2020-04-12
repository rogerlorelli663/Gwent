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

    [SerializeField] private Sprite cardSymbol;
    [SerializeField] private Sprite cardBackside;
    [SerializeField] private Sprite cardArt;
    [SerializeField] private Color cardBackground;
    [SerializeField] private string cardName;
    [SerializeField] private CardType cardType;
    [SerializeField] bool hasDescription;

    public virtual bool HasCardDesciption()
    {
        return this.hasDescription;
    }

    //public string cardDescription;

    public virtual string getCardName()
    {
        return this.cardName;
    }
    public virtual CardType GetCardType()
    {
        return this.cardType;
    }




    /*    public virtual void setCardName(string name)
        {
            this.cardName = name;
        }*/

    /*    public virtual string getCardDescription()
        {
            return this.cardDescription;
        }

        public virtual void setCardDescription(string description)
        {
            this.cardDescription = description;
        }*/

    public virtual Sprite getCardArt()
    {
        return this.cardArt;
    }

    public virtual Sprite setCardBackside()
    {
        return this.cardBackside;
    }

    public virtual Color setCardBackground()
    {
        return this.cardBackground;
    }

    public virtual Sprite setCardSymbol()
    {
        return this.cardSymbol;
    }
}


