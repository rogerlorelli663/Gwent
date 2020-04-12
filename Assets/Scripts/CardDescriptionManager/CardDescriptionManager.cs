using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDescriptionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TurnDescriptionFieldOFF();
    }

    // Update is called once per frame
    void Update()
    {
        CardViewManager cvm = FindObjectOfType<CardViewManager>();
        if (cvm.HasCard())
        {
            SpecialCard card = cvm.GetDisplayCard().GetComponentInChildren<SpecialCard>();
            if (card != null)
            {
                TurnDescriptionFieldON();
                gameObject.GetComponentInChildren<Text>().text = card.getCardDescription();
            }

        }
        else
        {
            TurnDescriptionFieldOFF();
        }
    }

    private void TurnDescriptionFieldON()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void TurnDescriptionFieldOFF()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
