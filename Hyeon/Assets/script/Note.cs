using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Playset Playset;
    double timeInstantiated;
    public float assignedTime;

    void Start()
    {
        timeInstantiated = GamePlay.GetAudioSourceTime();
    }

   
    void Update()
    {
        double timeSinceInstantiated = GamePlay.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (GamePlay.Instance.playset.noteTime * 2));


        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * GamePlay.Instance.playset.noteSpawnY, Vector3.up * GamePlay.Instance.playset.noteDespawnY, t);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}