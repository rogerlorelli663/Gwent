using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileActionListener : MonoBehaviour
{

    CardPileManager cpm;

    void Start()
    {
        cpm = GetComponent<CardPileManager>();
    }



    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Action Triggered!\nOpening card pile set up\nCreating card pile set up object");
        }
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("UWUWUWUWUWUUWWUUWUWUWUWUW");
            cpm.CardListToPileView();
        }

    }





}
