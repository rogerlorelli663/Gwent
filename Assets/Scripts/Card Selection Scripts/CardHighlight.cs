using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHighlight : MonoBehaviour
{

    private Vector2 originalScale;
    public Vector2 highlightedScale = new Vector2(1f, 1f);

    private GameObject highlightedCard;

    void Start()
    {
        highlightedCard = null;
    }

    
    void Update()
    {
        GameObject hitCard = GetHighlightedCard();
        if (hitCard != null && highlightedCard == null && hitCard.transform.parent.GetComponent<CardPile>() != null)
        {
            originalScale = hitCard.transform.localScale;
            highlightedCard = hitCard;
            highlightedCard.transform.localScale = highlightedScale;
            highlightedCard.transform.position = new Vector3(highlightedCard.transform.position.x, highlightedCard.transform.position.y, highlightedCard.transform.position.z - 1);
        }
        else if (hitCard != highlightedCard && highlightedCard != null)
        {
            highlightedCard.transform.localScale = originalScale;
            highlightedCard.transform.position = new Vector3(highlightedCard.transform.position.x, highlightedCard.transform.position.y, highlightedCard.transform.position.z + 1);
            highlightedCard = null;
        }
    }

    private GameObject GetHighlightedCard()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        RaycastHit2D[] objectsOnMousePosition = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        foreach (RaycastHit2D objectHit in objectsOnMousePosition)
        {
            if (objectHit.collider.gameObject.GetComponent<Card>() != null)
            {
                return objectHit.collider.gameObject;
            }
        }
        return null;
    }

}
