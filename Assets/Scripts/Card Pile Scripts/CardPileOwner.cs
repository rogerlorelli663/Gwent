using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileOwner : MonoBehaviour
{
    public enum PileOwner
    {
        NO_OWNER = 0,
        PLAYER = 1,
        ENEMY = 2
    }

    [SerializeField] private PileOwner cardPileOwner = PileOwner.NO_OWNER;

    public PileOwner GetOwnerOfPile()
    {
        return cardPileOwner;
    }
}
