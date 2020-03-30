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

    public GameObject GetCard()
    {
        return card;
    }

    public void SaveCard(GameObject card)
    {
        if (this.card == null)
        {
            this.card = card;
        }
        else
        {
            Debug.Log("Cannot overwrite saved card.");
        }
    }

    public void EraseCard()
    {
        card = null;
    }
}
