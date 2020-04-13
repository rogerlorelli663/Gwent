using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileSelector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos2D = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    CardPile cpm = hit.collider.gameObject.GetComponent<CardPile>();
                    if (cpm != null)
                    {
                        //open card pile view
                        Debug.Log("test");
                    }
                }
            }
        }
    }

}
