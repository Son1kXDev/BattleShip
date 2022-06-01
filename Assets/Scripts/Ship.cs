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

    public void SetTransparent(bool available)
    {
        MainRenderer.material.color = available ? Color.green : Color.red;
    }

    public void SetNormal()
    {
        MainRenderer.material.color = Color.white;
    }

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = new Color(0, 0, 1, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}