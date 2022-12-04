using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    public Sprite[] asteroidSprites;

    [Tooltip("Seconds before entity spawns")]
    public float spawnRate;

    public float spawnDistance;
    public float maxEntities;

    private Transform _playerTransform;

    public GameObject asteroidContainer;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("SpawnAsteroid", 0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnAsteroid()
    {
        if (CanSpawn())
        {
            GameObject asteroidEntity = Instantiate(asteroid, RandomOffset(), _playerTransform.transform.rotation);
            asteroidEntity.transform.parent = asteroidContainer.transform;
            SpriteRenderer asteroidSpriteRenderer = asteroidEntity.GetComponent<SpriteRenderer>();


            int randomIdx = Random.Range(0, asteroidSprites.Length);
            Sprite asteroidSprite = asteroidSprites[randomIdx];
            asteroidSpriteRenderer.sprite = asteroidSprite;

            Destroy(asteroidEntity.GetComponent<PolygonCollider2D>());
            asteroidEntity.AddComponent<PolygonCollider2D>();
        }
    }


    Vector3 RandomOffset()
    {
        float randomAngle = Random.Range(1, 360);

        float randomX = _playerTransform.position.x + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * spawnDistance;
        float randomY = _playerTransform.position.y + Mathf.Sin(randomAngle * Mathf.Deg2Rad) * spawnDistance;


        return new Vector3(randomX, randomY, 0);
    }

    bool CanSpawn()
    {
        return GameObject.FindGameObjectsWithTag("Asteroid").Length < maxEntities;
    }
}