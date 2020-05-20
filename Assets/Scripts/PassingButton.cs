using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingButton : MonoBehaviour
{
    public void OnClick()
    {
        gameObject.SetActive(false);
    }
}
