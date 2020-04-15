using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    private GameObject selectedCard;
    private CardHolder originalCard;

    private bool deleteSelectedCard;

    private void Start()
    {
        originalCard = FindObjectOfType<CardHolder>();
        selectedCard = null;
        deleteSelectedCard = false;
    }

    public bool IsCardSelectableAndInCardPile()
    {
        if (originalCard.GetSavedCard() == null && selectedCard == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsCardPlaceableAndInCardSelector()
    {
        if (originalCard.GetSavedCard() != null && selectedCard != null && GetComponent<CardPositionAnimator>().IsAnimating() == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject GetSelectedCard()
    {
        return selectedCard;
    }

    public GameObject GetOriginalCard()
    {
        return originalCard.GetSavedCard();
    }

    public void CreateSelectedCardInstance()
    {
        selectedCard = Instantiate(originalCard.GetSavedCard(), gameObject.transform);
        selectedCard.transform.position = originalCard.GetSavedCard().transform.position;
    }

    public void DeleteSelectedCardInstance()
    {
        deleteSelectedCard = true;
    }

    private void Update()
    {
        DeleteSelectedCardInstanceOnCall();
    }

    private void DeleteSelectedCardInstanceOnCall()
    {
        if (deleteSelectedCard == true && GetComponent<CardPositionAnimator>().IsAnimating() == false)
        {
            Destroy(selectedCard);
            MakeOriginalCardVisible();
            FindObjectOfType<CardHolder>().DeleteSavedCard();
            deleteSelectedCard = false;
        }
    }

    public void AnimateCardToCardSelector()
    {
        GetComponent<CardPositionAnimator>().AnimateCardToPosition(selectedCard, gameObject.transform.position);
        GetComponent<CardScaleAnimator>().AnimateCardToScale(selectedCard);
    }

    public void AnimateCardToCardPile(GameObject cardPile)
    {
        GetComponent<CardPositionAnimator>().AnimateCardToPosition(selectedCard, cardPile.transform.position);
        GetComponent<CardScaleAnimator>().AnimateCardToScale(selectedCard, GetOriginalCard().transform.localScale);
    }

    public void MakeOriginalCardInvisible()
    {
        foreach (Transform child in GetOriginalCard().transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void MakeOriginalCardVisible()
    {
        foreach (Transform child in GetOriginalCard().transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
