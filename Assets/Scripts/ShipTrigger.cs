using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrigger : MonoBehaviour
{
    public GameObject Flag;

    private void OnMouseDown()
    {
        Instantiate(Flag, transform.position, Quaternion.identity);
        Destroy(this);
    }

    private void Update()
    {
    }
}