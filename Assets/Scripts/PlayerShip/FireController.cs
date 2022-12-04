using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject projectileContainer;
    [Tooltip("Shoots per minute")] public float fireRate;
    [Tooltip("Overheating capacity")] public float overHeatCapacity;
    [Tooltip("Overheat volume down")] public float overHeatVolumeDown;
    [Tooltip("Overheat volume up")] public float overHeatVolumeUp;

    private bool _canShoot = true;
    private Vector3 _offset;

    private AudioSource gunAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        float gunSizeY = gameObject.GetComponent<SpriteRenderer>().size.y;
        _offset = new Vector3(0, gunSizeY / 2, 0);
        gunAudioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.gameIsPaused && (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)))
        {
            Fire();
        }

        if (overHeatCapacity < 100)
        {
            overHeatCapacity += (Time.deltaTime * overHeatVolumeUp);
        }
    }

    void Fire()
    {
        if (_canShoot)
        {
            if (overHeatCapacity > overHeatVolumeDown)
            {
                gunAudioSource.Play();
                overHeatCapacity -= overHeatVolumeDown;
                GameObject bulletEntity = Instantiate(bullet, transform.TransformPoint(_offset), transform.rotation);
                bulletEntity.transform.parent = projectileContainer.transform;
                _canShoot = false;
                StartCoroutine(ShootTimer());
            }
        }
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(1 / (fireRate / 60));
        _canShoot = true;
    }
}