using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YY_Games_Scripts
{
    public class GunController : MonoBehaviour
    {
        public GameObject bullet;
        public Transform firePoint;

        public bool canAutoFire;
        public float fireRate;

        public int ammoCount, ammoPickAmount;

        public float zoomAmount;

        public string gunName;

        [HideInInspector] public double fireCounter;
        void Start()
        {
            UIController.instance.ammo.text = "AMMO:" + ammoCount;
        }

        // Update is called once per frame
        void Update()
        {
            if (fireCounter > 0)
            {
                fireCounter -= Time.deltaTime;
            }
        }
        public void GetAmmo()
        {
            ammoCount += ammoPickAmount;
            UIController.instance.ammo.text = "AMMO:" + ammoCount;
        }
    }
}