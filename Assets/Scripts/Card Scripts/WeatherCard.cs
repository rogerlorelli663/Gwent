using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCard : GwentCard
{

    [SerializeField] public string cardDescription;
    public string getCardDescription()
    {
        return this.cardDescription;
    }
}
