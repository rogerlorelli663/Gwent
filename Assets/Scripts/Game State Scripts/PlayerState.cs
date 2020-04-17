using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    public enum PlayerStatus
    {
        NO_INPUT_STATE = 0,
        DEFAULT_STATE = 1,
        CARD_SELECTED_STATE = 2,
        CARD_PILE_SELECTED_STATE = 3
    }

    private PlayerStatus currentPlayerState;

    void Start()
    {
        currentPlayerState = PlayerStatus.DEFAULT_STATE;
    }

    public PlayerStatus GetPlayerState()
    {
        return currentPlayerState;
    }

    public void SetPlayerState(PlayerStatus state)
    {
        currentPlayerState = state;
    }
}
