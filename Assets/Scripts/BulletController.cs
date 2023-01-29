using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed, lifeTime;
    public GameObject impactEffect;
    public Rigidbody myRigidbody;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = transform.forward * bulletSpeed;
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
        Instantiate(impactEffect, transform.position + (transform.forward * -bulletSpeed * Time.deltaTime), transform.rotation);
    }
}
