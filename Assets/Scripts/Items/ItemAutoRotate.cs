using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAutoRotate : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AutoRotate();
    }

    void AutoRotate()
    {
        transform.Rotate(Time.deltaTime * rotationSpeed * new Vector3(0, 0, 1));
    }
}