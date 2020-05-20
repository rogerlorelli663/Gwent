using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCards : NetworkBehaviour
{
    public PlayerBehavior PlayerBehavior;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerBehavior = networkIdentity.GetComponent<PlayerBehavior>();
        PlayerBehavior.CmdDealCards();
        gameObject.SetActive(false);
    }

}
