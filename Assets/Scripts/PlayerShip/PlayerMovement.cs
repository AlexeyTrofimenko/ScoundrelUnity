using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentSpeed;
    public float acceleration;
    public float deceleration;

    private AudioSource engineAudioSource;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = gameObject.GetComponent<ShipStats>().maxSpeed;
        engineAudioSource = GetComponent<AudioSource>();
        
        engineAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSound();
        if (Input.GetKey("space"))
        {
            transform.Translate(Time.deltaTime * currentSpeed * Vector3.up);
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
        }
        else
        {
            transform.Translate(Time.deltaTime * currentSpeed * Vector3.up);
            currentSpeed -=  deceleration * Time.deltaTime;
            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }
    }

    void UpdateSound()
    {
        engineAudioSource.volume = Mathf.InverseLerp(0f, maxSpeed, currentSpeed);
    }
}