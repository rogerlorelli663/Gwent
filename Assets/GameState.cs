using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST, PLAYERPASSING, ENEMYPASSING, EOR}
public class GameState : NetworkBehaviour
{
    public PlayerBehavior PlayerBehavior;
    public BattleState state;

    public void SetBattleState(BattleState state)
    {
        this.state = state;
    }

    public bool isPlayersTurn()
    {
        return this.state == BattleState.PLAYERTURN;
    }

    public bool isPlayersPassing()
    {
        return this.state == BattleState.PLAYERPASSING;
    }

    public void SetPassing()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerBehavior = networkIdentity.GetComponent<PlayerBehavior>();
        PlayerBehavior.CmdPassTurn();
    }
}
