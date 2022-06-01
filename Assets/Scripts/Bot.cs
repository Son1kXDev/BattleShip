using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public static Bot bot;

    public Vector3 cashedPos;

    [SerializeField] private GameObject shootPrefab;

    [SerializeField] private List<Vector3> cashPossitions = new List<Vector3>();

    private Vector3 spawnPossition;

    private void Awake()
    {
        if (bot != null) Destroy(this);
        else bot = this;
    }

    public void DidHit()
    {
        float waitTime = Random.Range(3, 7);
        StartCoroutine(Shoot(waitTime));
    }

    private IEnumerator Shoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        spawnPossition = spawnPos();

        if (Check(spawnPossition)) Instantiate(shootPrefab, spawnPossition, Quaternion.identity);
    }

    private Vector3 spawnPos()
    {
        float startX = 10f;
        float endX = 90f;
        float startZ = 10;
        float endZ = 90;

        int x = Mathf.RoundToInt(Random.Range(startX, endX) / 10) * 10;
        int z = Mathf.RoundToInt(Random.Range(startZ, endZ) / 10) * 10;

        if (cashedPos != Vector3.zero)
        {
            return closeShot(cashedPos);
        }

        return new Vector3(x, 10, z);
    }

    private bool Check(Vector3 sPos)
    {
        if (cashPossitions.Count <= 0)
        {
            cashPossitions.Add(sPos); return true;
        }
        for (int i = 0; i < cashPossitions.Count; i++)
        {
            if (cashPossitions[i].x == sPos.x && cashPossitions[i].z == sPos.z)
            {
                spawnPossition = spawnPos();
                return Check(spawnPossition);
            }
        }
        cashPossitions.Add(sPos);
        return true;
    }

    private Vector3 closeShot(Vector3 hitPos)
    {
        int xorz = Random.Range(1, 3);
        int x = Random.Range(1, 3);
        int z = Random.Range(1, 3);

        switch (xorz)
        {
            case 1:
                switch (x)
                {
                    case 1:
                        x = Mathf.RoundToInt(Random.Range(hitPos.x - 10, hitPos.x - 20) / 10) * 10;
                        z = Mathf.RoundToInt(hitPos.z);
                        break;

                    case 2:
                        x = Mathf.RoundToInt(Random.Range(hitPos.x + 10, hitPos.x + 20) / 10) * 10;
                        z = Mathf.RoundToInt(hitPos.z);
                        break;
                }
                break;

            case 2:
                switch (z)
                {
                    case 1:
                        z = Mathf.RoundToInt(Random.Range(hitPos.z - 10, hitPos.z - 20) / 10) * 10;
                        x = Mathf.RoundToInt(hitPos.x);
                        break;

                    case 2:
                        z = Mathf.RoundToInt(Random.Range(hitPos.z + 10, hitPos.z + 20) / 10) * 10;
                        x = Mathf.RoundToInt(hitPos.x);
                        break;
                }
                break;
        }

        return new Vector3(x, 10, z);
    }
}