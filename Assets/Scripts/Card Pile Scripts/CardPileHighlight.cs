using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardPileHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image highlightImage;
    private float defaultHighlightImageAlpha; //constant alpha highlight not on mouse over
    private bool mouseIsHoveringOverCardPile;
    
    void Start()
    {
        highlightImage = GetComponent<Image>();
        defaultHighlightImageAlpha = 0f;
        mouseIsHoveringOverCardPile = false;
        highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, defaultHighlightImageAlpha);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsHoveringOverCardPile = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseIsHoveringOverCardPile = false;
    }

    public void SetDefaultHighlightImageAlpha(float alpha)
    {
        defaultHighlightImageAlpha = alpha;
    }

    public void ResetDefaultHighlightImageAlpha()
    {
        defaultHighlightImageAlpha = 0f;
    }

    void Update()
    {
        ChangeHighlightImageAlpha();
    }

    private void ChangeHighlightImageAlpha()
    {
        if (mouseIsHoveringOverCardPile)
        {
            highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, 255f);
        }
        else
        {
            highlightImage.color = new Color(highlightImage.color.r, highlightImage.color.g, highlightImage.color.b, defaultHighlightImageAlpha);
        }
    }
}
