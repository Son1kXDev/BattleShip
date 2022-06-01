using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{

    [SerializeField, Range(1,4)] int TriggersCount;
    [SerializeField] Transform[] HitPoints;
    [SerializeField] GameObject hitPrefab;
    [SerializeField] Renderer model;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] hitClips;
    [SerializeField] AudioClip killClip;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("effectAudioSource").GetComponent<AudioSource>();
    }

    public void GetHit(int TriggerNumber)
    {
        TriggersCount--;
        print(TriggersCount);
        Instantiate(hitPrefab, HitPoints[TriggerNumber-1]);
        if (TriggersCount == 0)
        {
            model.enabled = true;
            model.material.color = new Color(0.3f, 0.3f, 0.3f, 1);
            audioSource.PlayOneShot(killClip);
        }
        else audioSource.PlayOneShot(hitClips[Random.Range(0, hitClips.Length)]);
    }
}
