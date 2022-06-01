using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotate : MonoBehaviour
{
    public static ShipRotate rotateShip;

    public Vector3 RotateVector = new Vector3(0, 90, 0);
    public Vector3 TransformVector = new Vector3(0, 0, 1);

    private void Awake()
    {
        if (rotateShip != null) Destroy(this);
        else rotateShip = this;
    }

    public void Rotate(Ship ship)
    {
        switch (ship.rotateState)
        {
            case 0:
                ship.Model.transform.eulerAngles += RotateVector;
                ship.Model.transform.localPosition += TransformVector;
                int cashX = ship.Size.x;
                int cashY = ship.Size.y;
                ship.Size.x = cashY;
                ship.Size.y = cashX;
                ship.rotateState = 1;
                break;

            case 1:
                ship.Model.transform.eulerAngles -= RotateVector;
                ship.Model.transform.localPosition -= TransformVector;
                int cashedX = ship.Size.x;
                int cashedY = ship.Size.y;
                ship.Size.x = cashedY;
                ship.Size.y = cashedX;
                ship.rotateState = 0;
                break;
        }
    }
}