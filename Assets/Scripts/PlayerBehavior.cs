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
    public GameObject PlayerCounter;
    public GameObject EnemyCounter;
    private const int DEALTCARDAMOUNT = 10;
    List<GameObject> PlayerCards;
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
        EnemyCounter = GameObject.Find("EnemyCounter");
        PlayerCounter = GameObject.Find("PlayerCounter");
    }

    [Server]
    public override void OnStartServer()
    {

    }

    [Command]
    public void CmdDealCards()
    {
        cards = PlayerDeck.GetComponent<Deck>().GetCards();
        int index;
        for(int i = 0; i < DEALTCARDAMOUNT; i++)
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
        PlayerCounter.GetComponent<PlayerCounter>().UpdateCounter();
    }

    [Command]
    public void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        EnemyCounter.GetComponent<PlayerCounter>().UpdateCounter();
        if (type == "Dealt")
        {
            if(hasAuthority)
            {
                card.transform.SetParent(PlayerHand.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyHand.transform, false);
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
    }
}
