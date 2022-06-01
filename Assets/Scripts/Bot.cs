using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public static Bot bot;

    [SerializeField, Range(1, 4)] private int TriggersCount;
    [SerializeField] private Transform[] HitPoints;
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private Renderer model;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] hitClips;
    [SerializeField] private AudioClip killClip;
    [Space(5), SerializeField] private GameObject shootPrefab;

    private void Awake()
    {
        if (bot != null) Destroy(this);
        else bot = this;
    }

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("effectAudioSource").GetComponent<AudioSource>();
    }

    public void GetHit(int TriggerNumber)
    {
        TriggersCount--;
        print(TriggersCount);
        Instantiate(hitPrefab, HitPoints[TriggerNumber - 1]);
        if (TriggersCount == 0)
        {
            model.enabled = true;
            model.material.color = new Color(0.3f, 0.3f, 0.3f, 1);
            audioSource.PlayOneShot(killClip);
        }
        else audioSource.PlayOneShot(hitClips[Random.Range(0, hitClips.Length)]);
    }

    public void DidHit()
    {
        float startX = 10f;
        float endX = 90f;
        float startZ = 10;
        float endZ = 90;

        int x = Mathf.RoundToInt(Random.Range(startX, endX) / 10) * 10;
        int z = Mathf.RoundToInt(Random.Range(startZ, endZ) / 10) * 10;

        Vector3 spawnPos = new Vector3(x, 0, z);
        Instantiate(shootPrefab, spawnPos, Quaternion.identity);
    }

    public void DidCloseHit(Vector3 hitPos)
    {
        int x = Mathf.RoundToInt(Random.Range(hitPos.x - 10, hitPos.x + 10) / 10) * 10;
        int z = Mathf.RoundToInt(Random.Range(hitPos.z - 10, hitPos.z + 10) / 10) * 10;

        Vector3 spawnPos = new Vector3(x, 0, z);
        Instantiate(shootPrefab, spawnPos, Quaternion.identity);
    }
}