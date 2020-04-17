using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBehavior : NetworkBehaviour
{
    [SerializeField] List<GameObject> UnitCards;
    [SerializeField] List<GameObject> SpecialCards;
    public GameObject PlayerDeck;
    public GameObject EnemyDeck;
    public GameObject WeatherCard;
    public GameObject WeatherField;
    public GameObject EnemyHand;
    public GameObject EnemyMelee;
    public GameObject EnemyRange;
    public GameObject EnemySiege;
    public GameObject PlayerHand;
    public GameObject PlayerMelee;
    public GameObject PlayerRange;
    public GameObject PlayerSiege;
    private int initialCardAmount = 10;


    List<GameObject> cards = new List<GameObject>();
    // Start is called before the first frame update
    public override void OnStartClient()
    {
        base.OnStartClient();
        EnemyDeck = GameObject.Find("Enemy Deck");
        EnemyHand = GameObject.FindGameObjectWithTag("Enemy Hand");
        EnemyMelee = GameObject.FindGameObjectWithTag("Enemy Melee");
        EnemyRange = GameObject.FindGameObjectWithTag("Enemy Range");
        EnemySiege = GameObject.FindGameObjectWithTag("Enemy Siege");
        PlayerDeck = GameObject.Find("Player Deck");
        PlayerHand = GameObject.FindGameObjectWithTag("Player Hand");
        PlayerMelee = GameObject.FindGameObjectWithTag("Player Melee");
        PlayerRange = GameObject.FindGameObjectWithTag("Player Range");
        PlayerSiege = GameObject.FindGameObjectWithTag("Player Siege");
        WeatherField = GameObject.Find("Weather Field");
    }

    [Server]
    public override void OnStartServer()
    {
/*        int index;
        for (int i = 0; i < 4; i++)
        {
            cards.Add(WeatherCard);
        }
        for (int i = 0; i < 9; i++)
        {
            index = Random.Range(0, SpecialCards.Count - 1);
            cards.Add(SpecialCards[index]);
        }
        for (int i = 0; i < 17; i++)
        {
            index = Random.Range(0, UnitCards.Count - 1);
            cards.Add(UnitCards[index]);
        }*/
    }

   

    [Command]
    public void CmdDealCards()
    {
        cards = PlayerDeck.GetComponent<Deck>().GetCards();
        int index;
        for(int i = 0; i < initialCardAmount; i++)
        {
            index = Random.Range(0, cards.Count);
            GameObject card = Instantiate(cards[index], new Vector2(0, 0), Quaternion.identity);
            cards.RemoveAt(index);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    public void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if(type == "Dealt")
        {
            if(hasAuthority)
            {
                card.transform.SetParent(PlayerHand.transform, false);
            }
            else
            {

                card.transform.SetParent(EnemyHand.transform, false);
                //card.GetComponent<CardFlipper>().Flip();
            }
        }
        else if(type == "Played" && !hasAuthority)
        {
            CardPile.CardPileType CardType = card.GetComponent<Card>().GetCardType();
            if(CardType == CardPile.CardPileType.MELEE_FIELD)
            {
                card.transform.SetParent(EnemyMelee.transform, false);
            }
            else if (CardType == CardPile.CardPileType.RANGE_FIELD)
            {
                card.transform.SetParent(EnemyRange.transform, false);
            }
            else if (CardType == CardPile.CardPileType.SIEGE_FIELD)
            {
                card.transform.SetParent(EnemySiege.transform, false);
            }
            else if (CardType == CardPile.CardPileType.EFFECT_FIELD)
            {
                card.transform.SetParent(WeatherField.transform, false);
            }
        }
        else if(type == "Played")
        {
/*           CardPile.CardPileType CardType = card.GetComponent<Card>().GetCardType();
            if (CardType == CardPile.CardPileType.MELEE_FIELD)
            {
                card.transform.SetParent(PlayerMelee.transform, false);
            }
            else if (CardType == CardPile.CardPileType.RANGE_FIELD)
            {
                card.transform.SetParent(PlayerRange.transform, false);
            }
            else if (CardType == CardPile.CardPileType.SIEGE_FIELD)
            {
                card.transform.SetParent(PlayerSiege.transform, false);
            }
            else if (CardType == CardPile.CardPileType.EFFECT_FIELD)
            {
                card.transform.SetParent(WeatherField.transform, false);
            }*/
        }
    }
}
