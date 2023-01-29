using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody myRigidbody;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = transform.forward * bulletSpeed;
    }
}
