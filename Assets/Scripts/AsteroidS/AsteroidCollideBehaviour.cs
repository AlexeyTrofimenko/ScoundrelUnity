using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AsteroidCollideBehaviour : MonoBehaviour
{
    public float asteroidHealth;
    public Image asteroidHealthBar;
    public GameObject smallVersion;
    public Sprite[] asteroidSprites;
    private GameObject _asteroidContainer;

    // Start is called before the first frame update
    void Start()
    {
        _asteroidContainer = GameObject.Find("AsteroidContainer");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            float bulletDamage = col.gameObject.GetComponent<BulletCollideBehaviour>().bulletDamage;
            DealDamage(bulletDamage);
        }
    }

    private void DealDamage(float damage)
    {
        asteroidHealth -= damage;
        if (asteroidHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (asteroidHealth <= 50 && IsBig())
        {
            SpawnParts();
            Destroy(gameObject);
        }
    }

    private void SpawnParts()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 offset = new Vector3(i, i, 0);
            GameObject asteroidSmallEntity =
                Instantiate(smallVersion, transform.position + offset, smallVersion.transform.rotation);
            asteroidSmallEntity.transform.parent = _asteroidContainer.transform;
            SpriteRenderer asteroidSpriteRenderer = asteroidSmallEntity.GetComponent<SpriteRenderer>();


            int randomIdx = Random.Range(0, asteroidSprites.Length);
            Sprite asteroidSprite = asteroidSprites[randomIdx];
            asteroidSpriteRenderer.sprite = asteroidSprite;

            Destroy(asteroidSmallEntity.GetComponent<PolygonCollider2D>());
            asteroidSmallEntity.AddComponent<PolygonCollider2D>();
        }
    }

    private bool IsBig()
    {
        return gameObject.transform.localScale.x >= 1f;
    }
}