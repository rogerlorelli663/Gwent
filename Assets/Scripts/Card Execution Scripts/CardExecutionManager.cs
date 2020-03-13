using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardExecutionManager : MonoBehaviour
{

    private GameObject card = null;

    private GameObject cardDisplay = null;

    public GameObject GetCard()
    {
        return card;
    }

    public GameObject GetDisplayCard()
    {
        return cardDisplay;
    }

    public bool HasCard()
    {
        if(card != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetCardForPlay(GameObject card)
    {
        if(this.card == null)
        {
            this.card = card;
            cardDisplay = Instantiate(this.card);
            cardDisplay.transform.SetParent(gameObject.transform);
            foreach(Transform child in this.card.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void removeCard()
    {
        foreach (Transform child in card.transform)
        {
            child.gameObject.SetActive(true);
        }
        card = null;
        Destroy(cardDisplay);
    }

}
