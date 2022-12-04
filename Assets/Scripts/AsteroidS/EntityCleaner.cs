using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCleaner : MonoBehaviour
{
    public float maxDistance;
    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, _playerTransform.position);
        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}