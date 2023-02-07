using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public float range, timeBetweenShots, rotateSpeed = 50f;
    private float timer;

    public Transform turretGun, firePoint;

    void Start()
    {
        timer = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerControlller.instance.transform.position) < range)
        {
            turretGun.LookAt(PlayerControlller.instance.transform.position + new Vector3(0f, 1.2f, 0f));

            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                timer = timeBetweenShots;
            }
        }
        else
        {
            timer = timeBetweenShots;

            turretGun.rotation = Quaternion.Lerp(turretGun.rotation, Quaternion.Euler(0f, turretGun.rotation.eulerAngles.y + 10, 0f), rotateSpeed * Time.deltaTime);
        }
    }
}
