using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CounterManager : MonoBehaviour
{
    private enum CounterType
    {
        NO_TYPE,
        PLAYER_COUNTER,
        OPPONENT_COUNTER
    }
    [SerializeField] private CounterType type = CounterType.NO_TYPE; 


    CardPileManager[] cardpiles;
    CardPileManager[] playerPiles = new CardPileManager[3];
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        cardpiles = FindObjectsOfType<CardPileManager>();
        if(this.type == CounterType.OPPONENT_COUNTER)
        {
            foreach (CardPileManager cpm in cardpiles)
            {
                if (cpm.GetCardPileType() == global::CardPileType.OPPONENT_CLOSE_COMBAT_FIELD_PILE ||
                    cpm.GetCardPileType() == global::CardPileType.OPPONENT_RANGE_COMBAT_FIELD_PILE ||
                    cpm.GetCardPileType() == global::CardPileType.OPPONENT_SIEGE_COMBAT_FIELD_PILE)
                {
                    playerPiles[i] = cpm;
                    i++;
                }
            }
        }
        else if(this.type == CounterType.PLAYER_COUNTER)
        {
            foreach (CardPileManager cpm in cardpiles)
            {
                if (cpm.GetCardPileType() == global::CardPileType.CLOSE_COMBAT_FIELD_PILE ||
                    cpm.GetCardPileType() == global::CardPileType.RANGE_COMBAT_FIELD_PILE ||
                    cpm.GetCardPileType() == global::CardPileType.SIEGE_COMBAT_FIELD_PILE)
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
        this.GetComponentInChildren<Text>().text = updateCounter();
    }

    string updateCounter()
    {
        int sum = 0;
        string totalPower;
        foreach(CardPileManager cpm in playerPiles)
        {
            GameObject[] cardList = cpm.GetCardList().ToArray();
            foreach(GameObject card in cardList)
            {
                if(card.GetComponent<CardManager>() == null)
                {
                    Debug.Log("Component is NULL\n");
                }
                else
                {
                    sum += card.GetComponent<CardManager>().getPower();
                }
            }
        }
        totalPower = "" + sum;
        return totalPower;
    }
}
