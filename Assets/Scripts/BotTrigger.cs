using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTrigger : MonoBehaviour
{
    [SerializeField] private Bot parent;
    [SerializeField] int triggerNumber;

    private void OnMouseDown()
    {
        parent.GetHit(triggerNumber);
        Destroy(this);
    }
}
