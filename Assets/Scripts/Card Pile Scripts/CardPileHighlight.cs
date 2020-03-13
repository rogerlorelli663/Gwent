using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPileHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Image highlight;
    private float defaultAlpha;

    void Start()
    {
        highlight = GetComponent<Image>();
        defaultAlpha = highlight.color.a;
        highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, 0f);
    }

    //Enables the highlighted image for this card pile
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, defaultAlpha);
    }

    //Disables the highlighted image for this card pile
    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, 0f);
    }
}
