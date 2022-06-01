using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 30;
    public bool res = false;

    private void Start()
    {
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            res = true;
        }
    }
}