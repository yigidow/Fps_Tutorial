using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YY_Games_Scripts
{
    public class WeaponPick : MonoBehaviour
    {
        public string gunName;
        private bool collected;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !collected)
            {
                PlayerControlller.instance.UnlockGun(gunName);
                collected = true;
                Destroy(gameObject);

                AudioManager.instance.PlaySfx(4);
            }
        }
    }
}