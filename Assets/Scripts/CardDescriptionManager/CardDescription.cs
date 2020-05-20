using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDescription : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TurnDescriptionFieldOFF();
    }

    // Update is called once per frame
    void Update()
    {
        CardSelector cvm = FindObjectOfType<CardSelector>();
        if (cvm.IsCardPlaceableAndInCardSelector())
        {
            GameObject card = cvm.GetOriginalCard();
            if (card.GetComponent<Card>().HasDescription()) 
            { 
                TurnDescriptionFieldON();
                gameObject.GetComponentInChildren<Text>().text = card.GetComponent<SpecialUnitCard>().GetCardDescription();
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
