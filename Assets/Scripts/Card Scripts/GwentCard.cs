using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GwentCard : MonoBehaviour
{
    public enum CardType
    {
        NO_TYPE = 0,
        UNIT = 1,
        SPECIAL_UNIT = 2,
        WEATHER = 3,
        EFFECT = 4,
        LEADER = 5,
    }

    [SerializeField] private string cardName;
    [SerializeField] private CardPile.CardPileType cardType;
    [SerializeField] private bool hasCardDescripton;
    public virtual string GetCardName()
    {
        return this.cardName;
    }
    public virtual CardPile.CardPileType GetCardType()
    {
        return this.cardType;
    }
    public virtual bool HasDescription()
    {
        return this.hasCardDescripton;
    }
    private void Start()
    {
        /*foreach (Transform child in gameObject.transform)
        {
            if(child.name == "BackSide")
            {
                child.gameObject.SetActive(false);
                return;
            }
        }*/
    }
}


