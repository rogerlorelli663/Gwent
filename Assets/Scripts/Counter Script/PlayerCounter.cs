using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerCounter : MonoBehaviour
{
 /*   private enum CounterType
    {
        NO_TYPE,
        PLAYER1_COUNTER,
        PLAYER2_COUNTER
    }
    [SerializeField] private CounterType type = CounterType.NO_TYPE; 


    CardPile[] cardpiles;
    CardPile[] playerPiles = new CardPile[3];
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        cardpiles = FindObjectsOfType<CardPile>();
        if(this.type == CounterType.PLAYER2_COUNTER)
        {
            foreach (CardPile cpm in cardpiles)
            {
                if (cpm.GetCardPileType() == CardPile.CardPileType.PLAYER2_CLOSE_COMBAT_FIELD_PILE ||
                    cpm.GetCardPileType() == CardPile.CardPileType.PLAYER2_RANGE_COMBAT_FIELD_PILE ||
                    cpm.GetCardPileType() == CardPile.CardPileType.PLAYER2_SIEGE_COMBAT_FIELD_PILE)
                {
                    playerPiles[i] = cpm;
                    i++;
                }
            }
        }
        else if(this.type == CounterType.PLAYER1_COUNTER)
        {
            foreach (CardPile cpm in cardpiles)
            {
                    if (cpm.GetCardPileType() == CardPile.CardPileType.PLAYER1_CLOSE_COMBAT_FIELD_PILE ||
                        cpm.GetCardPileType() == CardPile.CardPileType.PLAYER1_RANGE_COMBAT_FIELD_PILE ||
                        cpm.GetCardPileType() == CardPile.CardPileType.PLAYER1_SIEGE_COMBAT_FIELD_PILE)
                    {
                        playerPiles[i] = cpm;
                        i++;
                    }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponentInChildren<Text>().text = UpdateCounter();
    }

    string UpdateCounter()
    {
        int sum = 0;
        string totalPower;
        foreach(CardPile cpm in playerPiles)
        {
            if(cpm != null)
            {
                GameObject[] cardList = cpm.GetCardList().ToArray();
                foreach (GameObject card in cardList)
                {
                    if (card.GetComponent<Card>() == null)
                    {
                        Debug.Log("Component is NULL\n");
                    }
                    else
                    {
                        sum += card.GetComponent<Card>().GetPower();
                    }
                }
            }
            else
            {
                Debug.Log("Missing Card Pile\n");
            }
        }
        totalPower = "" + sum;
        return totalPower;
    }*/
}
