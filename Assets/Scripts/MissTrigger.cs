using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissTrigger : MonoBehaviour
{
    [SerializeField] private GameObject missPrefab;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private Camera mainCamera;
    [SerializeField] private List<Vector3> cashMissedPossitions = new List<Vector3>();

    private void Start()
    {
        mainCamera = Camera.main;
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

            bool available = true;

            if (cashMissedPossitions.Count <= 0) available = true; ;
            for (int i = 0; i < cashMissedPossitions.Count; i++)
            {
                if (cashMissedPossitions[i] == spawnPos)
                {
                    available = false;
                }
            }
            if (available) Spawn(spawnPos);
        }
    }

    private void Spawn(Vector3 spawnPos)
    {
        Instantiate(missPrefab, spawnPos, Quaternion.identity);
        cashMissedPossitions.Add(spawnPos);
        audioSource.PlayOneShot(clip);
        SwitchManager._switch.SwitchPlayer();
    }
}