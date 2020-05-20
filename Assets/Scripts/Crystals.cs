using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    public GameObject playerPile;
    public GameObject enemyPile;
    public GameObject PLAYERCRYSTAL;
    public GameObject PLAYERCRYSTALDONE;
    public GameObject ENEMYCRYSTAL;
    public GameObject ENEMYCRYSTALDONE;


    private void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            GameObject enemyCrystal = Instantiate(ENEMYCRYSTAL, enemyPile.transform);
            GameObject playerCrystal = Instantiate(PLAYERCRYSTAL, playerPile.transform);
        }
    }

    public void EnemyLost()
    {
        GameObject crystal = enemyPile.transform.GetChild(0).gameObject;
        Destroy(crystal);
        crystal = Instantiate(ENEMYCRYSTALDONE, enemyPile.transform);
    }

    public void PlayerLost()
    {
        GameObject crystal = playerPile.transform.GetChild(0).gameObject;
        Destroy(crystal);
        crystal = Instantiate(PLAYERCRYSTALDONE, playerPile.transform);
    }


}
