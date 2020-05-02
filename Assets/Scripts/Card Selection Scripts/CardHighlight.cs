using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHighlight : MonoBehaviour
{

    private GameObject cardCopy;
    private GameObject hoveredCard;

    [SerializeField] private float distanceGap = 0;

    void Start()
    {
        cardCopy = null;
        hoveredCard = null;
    }

    
    void Update()
    {
        hoveredCard = GetHighlightedCard();
        if(hoveredCard != null && cardCopy == null)
        {
            CreateCopyCard();
        }
        else if(cardCopy != null && hoveredCard == null)
        {
            DeleteCopyCard();
        }
    }

    private void CreateCopyCard()
    {
        GameObject cardCopy = Instantiate(hoveredCard, hoveredCard.transform);
        cardCopy.transform.parent = null;
        cardCopy.transform.position = hoveredCard.transform.position;
        float distance = hoveredCard.GetComponent<RectTransform>().rect.height * hoveredCard.transform.localScale.y + distanceGap;
        if(hoveredCard.transform.parent.GetComponent<CardPileOwner>().GetOwnerOfPile() == CardPileOwner.PileOwner.ENEMY)
        {
            cardCopy.transform.position = new Vector2(cardCopy.transform.position.x, cardCopy.transform.position.y - distance);
        }
        else
        {
            cardCopy.transform.position = new Vector2(cardCopy.transform.position.x, cardCopy.transform.position.y + distance);
        }
    }

    private void DeleteCopyCard()
    {
        Destroy(cardCopy);
        cardCopy = null;
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
