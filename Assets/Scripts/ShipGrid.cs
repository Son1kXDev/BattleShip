using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);

    public bool Place = false;

    private Ship[,] grid;
    private Ship placingShip;
    private Camera mainCamera;

    private bool available = true;

    private void Awake()
    {
        grid = new Ship[GridSize.x, GridSize.y];
        mainCamera = Camera.main;
    }

    public void StartPlacing(Ship ship)
    {
        if (placingShip != null)
        {
            Destroy(placingShip.gameObject);
        }

        Vector3 startPos = new Vector3(0, -50, 0);
        placingShip = Instantiate(ship, startPos, Quaternion.identity);
    }

    public void RotateShip()
    {
        if (placingShip != null) ShipRotate.rotateShip.Rotate(placingShip);
        if (CheckGrid((int)placingShip.transform.position.x, (int)placingShip.transform.position.z) == false)
            ShipRotate.rotateShip.Rotate(placingShip);
        CheckPlace((int)placingShip.transform.position.x, (int)placingShip.transform.position.z);
    }

    public void Placing() => Place = true;

    private void Update()
    {
        if (placingShip != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            available = true;

            if (groundPlane.Raycast(ray, out float possition))
            {
                Vector3 worldPossition = ray.GetPoint(possition);

                int x = Mathf.RoundToInt(worldPossition.x / 10) * 10 - 10;
                int y = Mathf.RoundToInt(worldPossition.z / 10) * 10 - 10;

                if (CheckGrid(x, y) && Input.GetMouseButtonDown(0))
                {
                    placingShip.transform.position = new Vector3(x, 0, y);
                    CheckPlace((int)placingShip.transform.position.x, (int)placingShip.transform.position.z);
                }

                if (Place)
                {
                    Place = false;
                    CheckPlace((int)placingShip.transform.position.x, (int)placingShip.transform.position.z);
                    if (available)
                        PlaceShip((int)placingShip.transform.position.x, (int)placingShip.transform.position.z);
                }
            }
        }
    }

    private bool CheckGrid(int x, int y)
    {
        if (x < 0 || x > GridSize.x - placingShip.Size.x) return false;
        else if (y < 0 || y > GridSize.y - placingShip.Size.y) return false;
        else return true;
    }

    private void CheckPlace(int x, int y)
    {
        if (available && IsPlaceTaken(x, y)) available = false;
        placingShip.SetTransparent(available);
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < placingShip.Size.x; x++)
        {
            for (int y = 0; y < placingShip.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceShip(int placeX, int placeY)
    {
        ShipCount.shipCount.PlaceShip(placingShip.type);

        for (int x = 0; x < placingShip.Size.x; x++)
        {
            for (int y = 0; y < placingShip.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = placingShip;
            }
        }

        placingShip.SetNormal();
        placingShip = null;
    }
}