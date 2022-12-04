using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    public float bulletSpeed;
    public float destroyTime;

    public bool useShipForce;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, destroyTime);
        if (useShipForce)
        {
            float shipForce = player.GetComponent<PlayerMovement>().currentSpeed;
            bulletSpeed += shipForce;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * bulletSpeed * Vector3.up);
    }
}