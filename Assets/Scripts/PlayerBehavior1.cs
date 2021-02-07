using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBehavior1 : NetworkBehaviour
{
    [SerializeField] List<GameObject> UnitCards;
    [SerializeField] List<GameObject> SpecialCards;

    public GameObject Player;
    private GameState PlayerGameState;
    public GameObject Enemy;
    private GameState EnemyGameState;
    public GameObject PlayerDeck;
    public GameObject PassingToken;
    public GameObject EndOfRoundToken;
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
    public BattleState state;

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
        Player = GameObject.Find("PlayerGameState");
        PlayerGameState = Player.GetComponent<GameState>();
        Enemy = GameObject.Find("EnemyGameState");
        EnemyGameState = Enemy.GetComponent<GameState>();
        if (isClientOnly)
        {
            PlayerGameState.SetBattleState(BattleState.ENEMYTURN);
            EnemyGameState.SetBattleState(BattleState.PLAYERTURN);
        }
        else
        {
            PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            EnemyGameState.SetBattleState(BattleState.ENEMYTURN);
        }
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
        for (int i = 0; i < DEALTCARDAMOUNT; i++)
        {
            index = Random.Range(0, cards.Count);
            GameObject card = Instantiate(cards[index], new Vector2(0, 0), Quaternion.identity);
            cards.RemoveAt(index);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, "Dealt");
        }
    }

    [Command]
    public void CmdPassTurn()
    {
        GameObject passingToken = Instantiate(PassingToken, new Vector2(0, 0), Quaternion.identity);
        RpcPassTurn(passingToken);
    }

    [ClientRpc]
    private void RpcPassTurn(GameObject passingToken)
    {
        if (hasAuthority)
        {
            PlayerGameState.SetBattleState(BattleState.PLAYERPASSING);
            if (!EnemyGameState.isPlayersPassing())
            {
                EnemyGameState.SetBattleState(BattleState.PLAYERTURN);
            }
            CmdCheckEndofRound();
        }
        else
        {
            EnemyGameState.SetBattleState(BattleState.PLAYERPASSING);
            if (!PlayerGameState.isPlayersPassing())
            {
                PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            }
        }
    }

    [Command]
    private void CmdCheckEndofRound()
    {
        GameObject eorToken = Instantiate(EndOfRoundToken, new Vector2(0, 0), Quaternion.identity);
        RpcRunEndOfRoundCalculations(eorToken);
    }

    [ClientRpc]
    private void RpcRunEndOfRoundCalculations(GameObject EndOfRoundToken)
    {
        if (hasAuthority)
        {
            if (PlayerGameState.isPlayersPassing() && EnemyGameState.isPlayersPassing())
            {
                EndOfRoundCalc();
            }
        }
        else
        {
            if (PlayerGameState.isPlayersPassing() && EnemyGameState.isPlayersPassing())
            {
                EndOfRoundCalc();
            }
        }
    }

    private void EndOfRoundCalc()
    {
        int playerPoints = PlayerCounter.GetComponent<PlayerCounter>().GetCurrentPoints();
        int enemyPoints = EnemyCounter.GetComponent<PlayerCounter>().GetCurrentPoints();
        if (playerPoints > enemyPoints)
        {
            Debug.Log("Player Wins!!!");
        }
        else if (enemyPoints > playerPoints)
        {
            Debug.Log("Enemy Wins!!!");
        }
        else
        {
            Debug.Log("Draw!!!");
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
        if (type == "Dealt")
        {
            if (hasAuthority)
            {
                card.transform.SetParent(PlayerHand.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyHand.transform, false);
            }
        }
        else if (type == "Played" && hasAuthority)
        {
            if (!EnemyGameState.isPlayersPassing())
            {
                if (PlayerHand.GetComponent<CardPile>().GetNumberOfCards() > 0)
                {
                    PlayerGameState.SetBattleState(BattleState.ENEMYTURN);
                }
                else
                {
                    PlayerGameState.SetBattleState(BattleState.PLAYERPASSING);
                }
            }
            else if (PlayerHand.GetComponent<CardPile>().GetNumberOfCards() > 0)
            {
                PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            }
            else
            {
                PlayerGameState.SetBattleState(BattleState.PLAYERPASSING);
            }
            PlayerCounter.GetComponent<PlayerCounter>().UpdateCounter();
            EnemyCounter.GetComponent<PlayerCounter>().UpdateCounter();
            CmdCheckEndofRound();
        }
        else if (type == "Played" && !hasAuthority)
        {
            CardPile.CardPileType CardType = card.GetComponent<Card>().GetCardType();
            if (CardType == CardPile.CardPileType.MELEE_FIELD)
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
            if (!PlayerGameState.isPlayersPassing())
            {
                PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            }
            PlayerCounter.GetComponent<PlayerCounter>().UpdateCounter();
            EnemyCounter.GetComponent<PlayerCounter>().UpdateCounter();
        }
    }
}
