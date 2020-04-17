using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialUnitCard : UnitCard
{
    public enum AbilityType
    {
        NO_TYPE = 0,
        SPY = 1,
        MEDIC = 2,
        MORALE = 3,
        SCORCH = 4,
        BOND = 5,
        AGILE = 6,
        MUSTER = 7,
        BITING_FROST = 8,
        CLEAR_SKY = 9,
        FOG = 10,
        TORRENTAL_RAIN = 11,
    }
    [SerializeField] private AbilityType abilityType;
    [SerializeField] public string cardDescription;

    public string GetCardDescription()
    {
        return this.cardDescription;
    }
    public AbilityType GetUnitAbilityType()
    {
        return this.abilityType;
    }
}
