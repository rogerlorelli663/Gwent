using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardViewDisplay : MonoBehaviour
{

    private CardViewManager cvm;
    [SerializeField] private float scale = 1;

    void Start()
    {
        cvm = GetComponent<CardViewManager>();
    }

    void Update()
    {
        if(cvm.GetDisplayCard() != null)
        {
            cvm.GetDisplayCard().transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            cvm.GetDisplayCard().transform.localScale = new Vector2(scale, scale);
        }
    }
}
