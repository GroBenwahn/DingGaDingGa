using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playset : MonoBehaviour
{
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError;
    public int inputDelayInMilliseconds;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
