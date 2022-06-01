using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPatternCreator : MonoBehaviour
{
    public GameObject[] shipPrefabs;

    [SerializeField] private List<GameObject> ObjectsOnScene = new List<GameObject>();

    private List<Vector3> CashedPossitions = new List<Vector3>();

    private float startX = 140f;
    private float endX = 230f;
    private float startZ = 10;
    private float endZ = 100;

    [ContextMenu("Confirm")]
    public void ConfirmObject()
    {
        CashedPossitions.Clear();
        ObjectsOnScene.Clear();
    }

    public void DeleteObjects()
    {
        foreach (GameObject obj in ObjectsOnScene)
        {
            DestroyImmediate(obj);
        }
    }

    [ContextMenu("Spawn ship")]
    public void SpawnShip()
    {
        DeleteObjects();
        CashedPossitions.Clear();
        ObjectsOnScene.Clear();
        startX = 140f;
        endX = 230f;
        startZ = 10;
        endZ = 100;
        for (int i = 0; i < shipPrefabs.Length; i++)
        {
            if (i == 4) { endX -= 10; endZ -= 10; startX += 10; startZ += 10; }
            if (i == 7) { endX -= 10; endZ -= 10; startX += 10; startZ += 10; }
            if (i == 9) { endX -= 10; endZ -= 10; startX += 10; startZ += 10; }

            int x = Mathf.RoundToInt(Random.Range(startX, endX) / 10) * 10;
            int z = Mathf.RoundToInt(Random.Range(startZ, endZ) / 10) * 10;

            Vector3 spawnPos = new Vector3(x, 0, z);
            Vector3 rotatePos;

            int rotate = Random.Range(0, 2);
            if (rotate == 0) rotatePos = new Vector3(0, 0, 0);
            else rotatePos = new Vector3(0, 90, 0);

            CheckCash(spawnPos, i, rotatePos);
        }
    }

    private void CheckCash(Vector3 cash, int number, Vector3 rotate)
    {
        foreach (var pos in CashedPossitions)
        {
            if (cash == pos) cash = generatingVector(number);
        }

        CashShip(cash, number, rotate);
    }

    private Vector3 generatingVector(int number)
    {
        int x = Mathf.RoundToInt(Random.Range(startX, endX) / 10) * 10;
        int z = Mathf.RoundToInt(Random.Range(startZ, endZ) / 10) * 10;
        Vector3 newPos = new Vector3(x, 0, z);

        if (CashedPossitions.Count <= 0) return newPos;

        foreach (var pos in CashedPossitions)
        {
            if (newPos == pos) newPos = generatingVector(number);
        }

        return newPos;
    }

    private void CashShip(Vector3 cash, int type, Vector3 rotate)
    {
        CashedPossitions.Add(cash); //середина
        if (type < 4)
        {
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z)); //середина право
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z)); //середина лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z + 10)); //вверх право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z + 10)); //вверх середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z + 10)); //вверх лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z - 10)); //низ право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z - 10)); //низ середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z - 10)); //низ лево
        }
        if (type < 7 && type >= 4)
        {
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z - 10)); //низ право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z - 10)); //низ середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z - 10)); //низ лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z)); //середина право
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z)); //середина лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z + 10)); //вверх право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z + 10)); //вверх середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z + 10)); //вверх лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z + 20)); //вверх право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z + 20)); //вверх середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z + 20)); //вверх лево
        }
        if (type < 9 && type >= 7)
        {
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z - 10)); //низ право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z - 10)); //низ середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z - 10)); //низ лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z)); //середина право
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z)); //середина лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z + 10)); //вверх право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z + 10)); //вверх середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z + 10)); //вверх лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z + 20)); //вверх право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z + 20)); //вверх середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z + 20)); //вверх лево
            CashedPossitions.Add(new Vector3(cash.x + 10, cash.y, cash.z + 30)); //вверх право
            CashedPossitions.Add(new Vector3(cash.x, cash.y, cash.z + 30)); //вверх середина
            CashedPossitions.Add(new Vector3(cash.x - 10, cash.y, cash.z + 30)); //вверх лево
        }

        GameObject placingShip = Instantiate(shipPrefabs[type], cash, Quaternion.Euler(rotate));
        ObjectsOnScene.Add(placingShip);
    }
}