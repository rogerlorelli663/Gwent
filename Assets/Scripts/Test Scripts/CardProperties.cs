using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CardProperties : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        // foreach (Transform child in transform)
        //     print("Foreach loop: " + child);
        GameObject mynewball = gameObject;
        RectTransform rt = (RectTransform)mynewball.transform;

        //GameObject copy = Instantiate(gameObject);
        CardExecutionManager cem = FindObjectOfType<CardExecutionManager>();
        
        if (!cem.HasCard())
        {
            cem.SetCardForPlay(gameObject);
        }


        float width = rt.rect.width;
        float height = rt.rect.height;
        float scaleX = mynewball.transform.localScale.x;
        float scaleY = mynewball.transform.localScale.y;
        
        //Debug.Log("height: " + height + "\n");
        //Debug.Log("width: " + width + "\n");
        //Debug.Log("ScaleX: " + scaleX + "\n");
        //Debug.Log("ScaleY: " + scaleY + "\n");
        
        foreach (Transform child in gameObject.transform)
            if (child.GetComponent<Text>() != null)
            {
                //Debug.Log(child.GetComponent<Text>().text + "\n");
            }
        
    }

}
