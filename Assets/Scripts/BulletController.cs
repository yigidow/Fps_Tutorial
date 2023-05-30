using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YY_Games_Scripts
{
    public class BulletController : MonoBehaviour
    {
        public float bulletSpeed, lifeTime;
        public GameObject impactEffect;
        public Rigidbody myRigidbody;

        public int damage = 2;

        public bool damageEnemy;
        public bool damagePlayer;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            myRigidbody.velocity = transform.forward * bulletSpeed;
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy" && damageEnemy)
            {
                other.gameObject.GetComponent<EnemyHealth>().DamageEnemy(damage);
            }

            if (other.gameObject.tag == "EnemyHead" && damageEnemy)
            {
                other.transform.parent.GetComponent<EnemyHealth>().DamageEnemy(damage * 2);
            }
            if (other.gameObject.tag == "Player" && damagePlayer)
            {
                PlayerHealth.instance.DamagePayer(damage);
            }
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position + transform.forward * -bulletSpeed * Time.deltaTime, transform.rotation);
        }
    }
}