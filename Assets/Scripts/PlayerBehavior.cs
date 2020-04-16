using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBehavior : NetworkBehaviour
{
    public GameObject UnitCard;
    //public GameObject SpecialCard;
    //public GameObject WeatherCard;
    public GameObject EnemyHand;
    public GameObject EnemyMelee;
    public GameObject EnemyRange;
    public GameObject EnemySiege;
    public GameObject PlayerHand;
    public GameObject PlayerMelee;
    public GameObject PlayerRange;
    public GameObject PlayerSiege;
    private int initialCardAmount = 10;

    [SyncVar]
    int cardsPlayed = 0;

    List<GameObject> cards = new List<GameObject>();
    // Start is called before the first frame update
    public override void OnStartClient()
    {
        base.OnStartClient();
        EnemyHand = GameObject.FindGameObjectWithTag("Enemy Hand");
        EnemyMelee = GameObject.FindGameObjectWithTag("Enemy Melee");
        EnemyRange = GameObject.FindGameObjectWithTag("Enemy Range");
        EnemySiege = GameObject.FindGameObjectWithTag("Enemy Siege");
        PlayerHand = GameObject.FindGameObjectWithTag("Player Hand");
        PlayerMelee = GameObject.FindGameObjectWithTag("Player Melee");
        PlayerRange = GameObject.FindGameObjectWithTag("Player Range");
        PlayerSiege = GameObject.FindGameObjectWithTag("Player Siege");
    }

    [Server]
    public override void OnStartServer()
    {
        cards.Add(UnitCard);
       // cards.Add(SpecialCard);
       // cards.Add(WeatherCard);
    }

   

    [Command]
    public void CmdDealCards()
    {
        for(int i = 0; i < initialCardAmount; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
        cardsPlayed++;
        Debug.Log(cardsPlayed);
    }

    void CmdPlayCard(GameObject card)
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
                card.GetComponent<CardFlipper>().Flip();
            }
        }
        else if(type == "Played")
        {
            //card.transform.SetParent(PlayerHand.transform, false);
        }
    }
}
