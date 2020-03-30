using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardExecutionGameState : MonoBehaviour
{

    [SerializeField] private GameObject objects;
    [SerializeField] private Component comp;
    private CardViewManager cvm;

    void Start()
    {
        cvm = FindObjectOfType<CardViewManager>();
    }

    void Update()
    {
       /* if (cem.HasCard())
        {
            DisableListeners();
        }
        else
        {
            EnableListeners();
        }*/
    }

    /*private void DisableListeners()
    {
        CardPileManager[] cardPileManagers = FindObjectsOfType<CardPileManager>();
        foreach(CardPileManager cpm in cardPileManagers)
        {
            switch (cpm.GetCardPileType())
            {
                case CardPileType.HAND_PILE:
                    GameObject cardPile = cpm.gameObject;
                    cardPile.GetComponent<CardPileActionListener>().enabled = false;
                    break;
            }
        }

        CardProperties[] cp = FindObjectsOfType<CardProperties>();
        foreach(CardProperties cardp in cp)
        {
            cardp.GetComponent<CardProperties>().enabled = false;
        }
    }

    private void EnableListeners()
    {
        CardPileManager[] cardPileManagers = FindObjectsOfType<CardPileManager>();
        foreach (CardPileManager cpm in cardPileManagers)
        {
            switch (cpm.GetCardPileType())
            {
                case CardPileType.HAND_PILE:
                    GameObject cardPile = cpm.gameObject;
                    cardPile.GetComponent<CardPileActionListener>().enabled = true;
                    break;
            }
        }

        CardProperties[] cp = FindObjectsOfType<CardProperties>();
        foreach (CardProperties cardp in cp)
        {
            cardp.GetComponent<CardProperties>().enabled = true;
        }
    }*/
}
