using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameMonitor : NetworkBehaviour
{
    public PlayerBehavior PlayerBehavior;
    // Start is called before the first frame update
    public void Startup()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerBehavior = networkIdentity.GetComponent<PlayerBehavior>();
        PlayerBehavior.CmdDealCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
