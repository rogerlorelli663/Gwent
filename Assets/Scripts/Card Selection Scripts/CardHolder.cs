using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    private GameObject card;

    void Start()
    {
        card = null;
    }

    public void SaveCard(GameObject card)
    {
        if (this.card == null)
        {
            this.card = card;
        }
    }

    public GameObject GetSavedCard()
    {
        return card;
    }

    public void DeleteSavedCard()
    {
        card = null;
    }
}
