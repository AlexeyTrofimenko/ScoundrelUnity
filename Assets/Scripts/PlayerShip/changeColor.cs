using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public ShipStats shipStat;
    void Start()
    {
        EngineColor();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void EngineColor()
    {
        TrailRenderer myTrailRenderer = GetComponent<TrailRenderer>();
        float strength = shipStat.maxStrength;
        float shields = shipStat.maxShields;
        float maxSpeed = shipStat.maxSpeed;


        float[] stats = { strength, shields, maxSpeed };
        float maxStat = stats.Max();
        float indexMax = Array.IndexOf(stats, maxStat);
        switch (indexMax)
        {
            case 0: 
                myTrailRenderer.startColor = Color.red;
                break;
            case 1:
                myTrailRenderer.startColor = Color.blue;
                break;
            case 2: 
                myTrailRenderer.startColor = Color.green;
                break;
        }
    }

}
