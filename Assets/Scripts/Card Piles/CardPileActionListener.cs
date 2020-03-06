using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardPileActionListener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Image highlight;
    // Start is called before the first frame update
    void Start()
    {
        highlight = GetComponent<Image>();
        highlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && highlight.IsActive())
        {
            Debug.Log("Action Triggered!\nOpening card pile set up\nCreating card pile set up object");
        }
    }

    //Enables the highlighted image for this card pile
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.enabled = true;
    }

    //Disables the highlighted image for this card pile
    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.enabled = false;
    }
}
