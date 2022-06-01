using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] paterns;

    private void Start()
    {
        SelectPattern();
    }

    private void SelectPattern()
    {
        paterns[Random.Range(0, paterns.Length)].SetActive(true);
    }
}