using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class ShipStats : MonoBehaviour
{
    [Tooltip("Ship strength")] public float maxStrength;
    [Tooltip("Ship shields")] public float maxShields;
    [Tooltip("Ship shields increase")] public float shieldsIncrease;
    [Tooltip("Ship speed")] public float maxSpeed;
    public float currentShield;
    [SerializeField] private bool _canPress;
    public static bool inDodge = false;


    void Start()
    {
        currentShield = maxShields;
        _canPress = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && _canPress)
        {
            StartCoroutine(ShieldsTimer());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemyBullet"))
        {
            float bulletDamage = col.gameObject.GetComponent<BulletCollideBehaviour>().bulletDamage;
            DealDamage(bulletDamage);
        }
    }

    void DealDamage(float damage)
    {
        if (!inDodge)
        {
            currentShield -= damage;
            if (currentShield <= 0)
            {
                currentShield = 0;
                maxStrength -= damage;
            }
        }
    }

    private IEnumerator ShieldsTimer()
    {
        _canPress = false;
        while (currentShield < maxShields)
        {
            yield return new WaitForSeconds(1);
            currentShield += shieldsIncrease;
        }

        _canPress = true;
    }
}