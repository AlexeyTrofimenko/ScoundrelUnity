using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 mousePos;
    private Vector2 objPos;
    private Vector2 direction;
    private Vector2 currentDir;
    void Start()
    {
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objPos = transform.position;

        direction = mousePos - objPos;
        direction.Normalize();

        currentDir = Vector2.Lerp(currentDir, direction, Time.deltaTime * speed);
        transform.up = currentDir;
    }
}