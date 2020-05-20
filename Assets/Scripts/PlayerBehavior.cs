using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerBehavior : NetworkBehaviour
{
    [SerializeField] List<GameObject> UnitCards;
    [SerializeField] List<GameObject> SpecialCards;

    public Sprite Player1Live;
    public Sprite Player1Dead;
    public Sprite Player2Live;
    public Sprite Player2Dead;
    public GameObject Menu;
    private GameObject PassingButton;
    public GameObject Rounds;
    public GameObject Player;
    private GameState PlayerGameState;
    public GameObject Enemy;
    private GameState EnemyGameState;
    public GameObject PlayerDeck;
    public GameObject PlayerDiscard;
    public GameObject PassingToken;
    public GameObject EndOfRoundToken;
    public GameObject EnemyDeck;
    public GameObject EnemyDiscard;
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
    public GameObject PlayerCrystal;
    public GameObject PlayerCrystalDone;
    public GameObject EnemyCrystal;
    public GameObject EnemyCrystalDone;
    public GameObject PlayerCrystalPile;
    public GameObject EnemyCrystalPile;
    private const int DEALTCARDAMOUNT = 10;
    List<GameObject> cards = new List<GameObject>();

    private int PlayerRoundsWon;
    private int EnemyRoundsWon;


    // Start is called before the first frame update
    public override void OnStartClient()
    {
        base.OnStartClient();
        Rounds = GameObject.Find("Rounds");
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
        EnemyDiscard = GameObject.Find("Enemy Discard");
        PlayerDiscard = GameObject.Find("Player Discard");
        EnemyGameState = Enemy.GetComponent<GameState>();
        Menu = GameObject.Find("Menu Button");
        PassingButton = GameObject.Find("PassingButton");
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
        PlayerRoundsWon = 0;
        EnemyRoundsWon = 0;

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
    
    public void PassTurn()
    {
        CmdPassTurn();
        CmdCheckEndofRound();
    }

    [Command]
    public void CmdPassTurn()
    {
        GameObject passingToken = Instantiate(PassingToken, new Vector2(0, 0), Quaternion.identity);
        NetworkServer.Spawn(passingToken, connectionToClient);
        RpcPassTurn(passingToken);
    }

    [ClientRpc]
    private void RpcPassTurn(GameObject passingToken)
    {
        if(hasAuthority)
        {
            PlayerGameState.SetBattleState(BattleState.PLAYERPASSING);
            Debug.Log("Had Authority on passing token");
            if(!EnemyGameState.isPlayersPassing())
            {
                EnemyGameState.SetBattleState(BattleState.PLAYERTURN);
            }
        }
        else
        {
            EnemyGameState.SetBattleState(BattleState.PLAYERPASSING);
            Debug.Log("Did Not have Authority on passing token");
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
        NetworkServer.Spawn(eorToken, connectionToClient);
        RpcRunEndOfRoundCalculations(eorToken);
    }

    [Command]
    private void CmdResetRound(GameObject EORToken)
    {
        RpcResetRound(EORToken);
    }

    [ClientRpc]
    private void RpcResetRound(GameObject token)
    {
        if(PlayerGameState.isPlayersPassing() && EnemyGameState.isPlayersPassing())
        {
            if(hasAuthority)
            {
                foreach (GameObject card in PlayerSiege.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(PlayerDiscard.transform, false);
                }
                foreach (GameObject card in PlayerRange.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(PlayerDiscard.transform, false);
                }
                foreach (GameObject card in PlayerMelee.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(PlayerDiscard.transform, false);
                }
                foreach (GameObject card in EnemySiege.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(EnemyDiscard.transform, false);
                }
                foreach (GameObject card in EnemyRange.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(EnemyDiscard.transform, false);
                }
                foreach (GameObject card in EnemyMelee.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(EnemyDiscard.transform, false);
                }
                EnemyGameState.SetBattleState(BattleState.PLAYERTURN);
                PlayerGameState.SetBattleState(BattleState.ENEMYTURN);
            }
            if(!hasAuthority)
            {
                foreach (GameObject card in PlayerSiege.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(PlayerDiscard.transform, false);
                }
                foreach (GameObject card in PlayerRange.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(PlayerDiscard.transform, false);
                }
                foreach (GameObject card in PlayerMelee.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(PlayerDiscard.transform, false);
                }
                foreach (GameObject card in EnemySiege.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(EnemyDiscard.transform, false);
                }
                foreach (GameObject card in EnemyRange.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(EnemyDiscard.transform, false);
                }
                foreach (GameObject card in EnemyMelee.GetComponent<CardPile>().GetCardsInCardPile())
                {
                    card.transform.SetParent(EnemyDiscard.transform, false);
                }
                EnemyGameState.SetBattleState(BattleState.ENEMYTURN);
                PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            }
            Menu.GetComponent<MenuButtons>().Reset();
            PassingButton.GetComponent<PassingButton>().Reset();
            PlayerCounter.GetComponent<PlayerCounter>().UpdateCounter();
            EnemyCounter.GetComponent<PlayerCounter>().UpdateCounter();
        }
    }
    [Command]
    private void CmdClearGame(GameObject EORToken)
    {
        RpcClearGame(EORToken);
    }
    [ClientRpc]
    private void RpcClearGame(GameObject token)
    {
        if (hasAuthority)
        {
            foreach (GameObject card in PlayerHand.GetComponent<CardPile>().GetCardsInCardPile())
            {
                card.transform.SetParent(PlayerDiscard.transform, false);
            }
            foreach (GameObject card in EnemyHand.GetComponent<CardPile>().GetCardsInCardPile())
            {
                card.transform.SetParent(EnemyDiscard.transform, false);
            }
        }
        if (!hasAuthority)
        {
            foreach (GameObject card in PlayerHand.GetComponent<CardPile>().GetCardsInCardPile())
            {
                card.transform.SetParent(PlayerDiscard.transform, false);
            }
            foreach (GameObject card in EnemyHand.GetComponent<CardPile>().GetCardsInCardPile())
            {
                card.transform.SetParent(EnemyDiscard.transform, false);
            }
        }
    }
    [ClientRpc]
    private void RpcRunEndOfRoundCalculations(GameObject EndOfRoundToken)
    {
        if(hasAuthority)
        {
            if(PlayerGameState.isPlayersPassing() && EnemyGameState.isPlayersPassing())
            {
                EndOfRoundCalc(EndOfRoundToken);
            }
        }
        else if(!hasAuthority)
        {
            if (PlayerGameState.isPlayersPassing() && EnemyGameState.isPlayersPassing())
            {
                EndOfRoundCalc(EndOfRoundToken);
            }
        }
    }

    private void EndOfRoundCalc(GameObject EoRToken)
    {
        string output;
        int playerPoints = PlayerCounter.GetComponent<PlayerCounter>().GetCurrentPoints();
        int enemyPoints = EnemyCounter.GetComponent<PlayerCounter>().GetCurrentPoints();
        if (playerPoints > enemyPoints)
        {
            output = "Player Wins!!!";
            Rounds.GetComponent<Crystals>().EnemyLost();
            PlayerRoundsWon++;

        }
        else if(enemyPoints > playerPoints)
        {
            output = "Enemy Wins!!!";
            Rounds.GetComponent<Crystals>().PlayerLost();
            EnemyRoundsWon++;
        }
        else
        {
            output = "Draw!!!";
        }
        Rounds.GetComponent<OutcomeBehavior>().RoundOutcome(output);
        Debug.Log(output);
        CmdResetRound(EoRToken);
        if(PlayerRoundsWon == 2)
        {
            output = "Player Wins the Game!!!";
            Rounds.GetComponent<OutcomeBehavior>().RoundOutcome(output);
            CmdClearGame(EoRToken);
        }
        else if (EnemyRoundsWon == 2)
        {
            output = "Enemy Wins the Game!!!";
            Rounds.GetComponent<OutcomeBehavior>().RoundOutcome(output);
            CmdClearGame(EoRToken);
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
            if(hasAuthority)
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
                    PlayerGameState.SetPassing();
                }
            }
            else if (PlayerHand.GetComponent<CardPile>().GetNumberOfCards() > 0)
            {
                PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            }
            else
            {
                PlayerGameState.SetPassing();
            }
            PlayerCounter.GetComponent<PlayerCounter>().UpdateCounter();
            EnemyCounter.GetComponent<PlayerCounter>().UpdateCounter();
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
            if(!PlayerGameState.isPlayersPassing())
            {
                PlayerGameState.SetBattleState(BattleState.PLAYERTURN);
            }
            PlayerCounter.GetComponent<PlayerCounter>().UpdateCounter();
            EnemyCounter.GetComponent<PlayerCounter>().UpdateCounter();
        }
    }
}
