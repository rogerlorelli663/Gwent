using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardPileActionListener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Image highlight;
    private bool isSelectableCardPile = false;
    // Start is called before the first frame update
    void Start()
    {
        highlight = GetComponent<Image>();
        highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isSelectableCardPile)
        {
            Debug.Log("Action Triggered!\nOpening card pile set up\nCreating card pile set up object");
        }
    }

    //Enables the highlighted image for this card pile
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, 100f);
        isSelectableCardPile = true;
    }

    //Disables the highlighted image for this card pile
    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.color = new Color(highlight.color.r, highlight.color.g, highlight.color.b, 0f);
        isSelectableCardPile = false;
    }
}
