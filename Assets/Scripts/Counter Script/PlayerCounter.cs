﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerCounter : MonoBehaviour
{
    public PileCounter Melee;
    public PileCounter Range;
    public PileCounter Siege;

    // Start is called before the first frame update

    // Update is called once per frame

    public void UpdateCounter()
    {
        int sum = 0;
        string totalPower;
        sum += Melee.GetPileTotal();
        sum += Range.GetPileTotal();
        sum += Siege.GetPileTotal();
        totalPower = "" + sum;
        this.GetComponentInChildren<Text>().text = totalPower;
    }
}
