using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCount : MonoBehaviour
{
    public static ShipCount shipCount;

    public int[] MaxCount;
    public Button[] ShipButton;

    private void Awake()
    {
        if (shipCount != null) Destroy(this);
        else shipCount = this;
    }

    public void PlaceShip(int type)
    {
        type--;
        MaxCount[type]--;
        if (MaxCount[type] <= 0)
        {
            ShipButton[type].interactable = false;
        }
    }
}