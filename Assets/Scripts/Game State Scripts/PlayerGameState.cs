using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameState state;
    public enum GameState
    {
        NONPLAYABLE_STATE = 0,
        PLAYABLE_STATE = 1,
        CARD_PILE_VIEW_STATE = 2,
        CARD_EXECUTION_STATE = 3
    }

    public GameState GetPlayerGameState()
    {
        return state;
    }

    public void SetPlayerGameState(GameState state)
    {
        this.state = state;
    }

    void Start()
    {
        state = GameState.NONPLAYABLE_STATE;
    }

    
    void Update()
    {
        switch (state)
        {
            case GameState.NONPLAYABLE_STATE:
                
                break;
            case GameState.PLAYABLE_STATE:

                break;
            case GameState.CARD_PILE_VIEW_STATE:

                break;
            case GameState.CARD_EXECUTION_STATE:
                
                break;
        }
    }
}
