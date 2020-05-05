using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class GameState : MonoBehaviour
{
    public BattleState state;

    public void SetBattleState(BattleState state)
    {
        this.state = state;
    }

    public bool isPlayersTurn()
    {
        return this.state == BattleState.PLAYERTURN;
    }

}
