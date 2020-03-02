using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileActionListener : MonoBehaviour
{

    private SpriteRenderer highlight;
    private BoxCollider2D hitbox;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        highlight = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<BoxCollider2D>();
        rect = GetComponent<RectTransform>();
        highlight.enabled = false;
        hitbox.size = new Vector2(rect.rect.width, rect.rect.height); //resizes the box collider to always fit size of rect transform.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && highlight.isVisible)
        {
            Debug.Log("Action Triggered!\nOpening card pile set up\nCreating card pile set up object");
        }
    }

    //Enables the highlighted sprite for this card pile
    public void OnMouseEnter()
    {
        highlight.enabled = true;
    }

    //Disables the highlighted sprite for this card pile
    public void OnMouseExit()
    {
        highlight.enabled = false;
    }
}
