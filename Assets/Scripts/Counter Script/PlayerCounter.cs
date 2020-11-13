using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerCounter : MonoBehaviour
{
    public PileCounter Melee;
    public PileCounter Range;
    public PileCounter Siege;
    private int totalPoints;
    // Start is called before the first frame update

    // Update is called once per frame

    public int UpdateCounter()
    {
        int sum = 0;
        string totalPower;
        sum += Melee.GetPileTotal();
/*        sum += Range.GetPileTotal();
        sum += Siege.GetPileTotal();*/
        totalPower = "" + sum;
        this.GetComponentInChildren<Text>().text = totalPower;
        this.totalPoints = sum;
        return sum;
    }

    public int GetCurrentPoints()
    {
        return this.totalPoints;
    }

}
