using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileActionListener : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("test");
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Action Triggered!\nOpening card pile set up\nCreating card pile set up object");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos2D = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                CardPile cpm = hit.collider.gameObject.GetComponent<CardPile>();
                if (cpm != null && hit.collider != null)
                {
                    Debug.Log("Action Triggered!\nOpening card pile set up\nCreating card pile set up object");
                }
            }
        }
    }

}
