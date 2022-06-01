using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissTrigger : MonoBehaviour
{
    [SerializeField] GameObject missPrefab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    Camera mainCamera;
    [SerializeField] List<GameObject> cashMissedPossitions = new List<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
        cashMissedPossitions = new List<GameObject>();
    }

    private void OnMouseDown()
    {
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float possition))
        {
            Vector3 worldPossition = ray.GetPoint(possition);
            int x = Mathf.RoundToInt(worldPossition.x / 10) * 10;
            int y = Mathf.RoundToInt(worldPossition.z / 10) * 10;

            Vector3 spawnPos = new Vector3(x, 0, y);

            //это не работает!!! ИСПРАВИТЬ!!!

            if (cashMissedPossitions.Count <= 0) Spawn(spawnPos);
            for (int i = 0; i < cashMissedPossitions.Count; i++)
            {
                if (cashMissedPossitions[i].transform.position == spawnPos) break;
                else Spawn(spawnPos); break;
            }
        }
     }

    void Spawn(Vector3 spawnPos)
    {
        GameObject missHit = Instantiate(missPrefab, spawnPos, Quaternion.identity);
        cashMissedPossitions.Add(missHit);
        audioSource.PlayOneShot(clip);
    }
}
