using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;
    public GameObject Model;

    public int rotateState = 0;

    [Range(1, 4)] public int type = 1;
    [SerializeField] private int health;

    private void Awake()
    {
        health = type;
    }

    public void SetTransparent(bool available) => MainRenderer.material.color = available ? Color.green : Color.red;

    public void SetNormal() => MainRenderer.material.color = Color.white;

    public void GetHit()
    {
        health--;
        if (health == 0)
        {
            Bot.bot.cashedPos = Vector3.zero;
            Destroy(this);
        }
    }
}