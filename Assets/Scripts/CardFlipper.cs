using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    public void Flip()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "BackSide")
            {
                if(child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                    return;
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
