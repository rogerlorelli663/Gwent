using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardExecutionDisplay : MonoBehaviour
{

    private CardExecutionManager cem;
    [SerializeField] private float scale = 1;

    void Start()
    {
        cem = GetComponent<CardExecutionManager>();
    }

    void Update()
    {
        GameObject cardDisplay = cem.GetDisplayCard();
        if(cardDisplay != null)
        {
            cardDisplay.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            cardDisplay.transform.localScale = new Vector2(scale, scale);
        }
    }
}
