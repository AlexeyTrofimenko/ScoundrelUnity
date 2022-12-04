using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipsUIBars : MonoBehaviour
{
    public ShipStats shipStat;
    public PlayerMovement speedStat;
    public FireController overHeat;

    public Image strengthBar;
    public Image shieldsBar;
    public Image speedBar;
    public Image capacityBar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float maxSpeed = shipStat.maxSpeed;
        float speed = speedStat.currentSpeed;
        
        float capacity = overHeat.overHeatCapacity;
        float strength = shipStat.maxStrength;
        float shields = shipStat.currentShield;
        
        
        speedBar.fillAmount = speed / maxSpeed;
        strengthBar.fillAmount = strength / 10;
        shieldsBar.fillAmount = shields / 10;
        capacityBar.fillAmount = capacity / 100;
    }
}
