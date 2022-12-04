using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject projectileContainer;

    public float fireRate;

    private bool _canShoot = true;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        float gunSizeY = gameObject.GetComponent<SpriteRenderer>().size.y;
        _offset = new Vector3(0, gunSizeY / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (_canShoot)
        {
            GameObject bulletEntity = Instantiate(bullet, transform.TransformPoint(_offset), transform.rotation);
            bulletEntity.transform.parent = projectileContainer.transform;
            _canShoot = false;
            StartCoroutine(ShootTimer());
        }
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(1 / (fireRate / 60));
        _canShoot = true;
    }
}